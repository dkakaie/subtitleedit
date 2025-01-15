from fastapi import FastAPI, File, UploadFile, HTTPException
from faster_whisper import WhisperModel
import os
from typing import List, Dict
from scalar_fastapi import get_scalar_api_reference
from datetime import datetime

app = FastAPI()

# Load the Whisper model
MODELS_ROOT = "E:/whisper.cpp/models/lab/models"
UPLOADS_DIR = "./uploads"

# Define the model paths for each language
MODEL_PATHS = {
    "fa": os.path.join(MODELS_ROOT, "multi@47k"),  # Persian
    "ar": os.path.join(MODELS_ROOT, "razhan-large-ct2"),  # Central Kurdish
}

# Load the Whisper models for each language in advance
processors = {
    lang: WhisperModel(
        model_path,
        device="cuda",
        compute_type="float16",
    )
    for lang, model_path in MODEL_PATHS.items()
}


def process(file_path: str, language: str) -> List[Dict]:
    # Get the processor for the specified language
    processor = processors.get(language)
    if not processor:
        raise HTTPException(status_code=404, detail=f"Processor for language '{language}' not found")
    
    print (f"running inference for language {language}")
    start_time = datetime.now()
    segments, _ = processor.transcribe(
        file_path,
        language=language,
        condition_on_previous_text=False,
        beam_size=1,
        best_of=1,
        word_timestamps=True,
        vad_filter=True,
        vad_parameters=dict(min_silence_duration_ms=500, min_speech_duration_ms=250),
        max_new_tokens=440,
        chunk_length=30,
        max_initial_timestamp=1.0,
        log_prob_threshold=-1.5,
        temperature=0.2,
    )
    segments = list(segments)

    # Capture the end time
    end_time = datetime.now()
    # Calculate the elapsed time
    elapsed_time = end_time - start_time

    results = []
    for s in segments:
        score = 0
        word_count = len(s.words)  # Number of words in the segment
        
        # Iterate through words and sum their probabilities
        for word in s.words:
            score += word.probability  # Sum the probabilities of all words
        
        # Compute the mean score
        mean_score = score / word_count if word_count > 0 else 0

        segment_dict = {"start": s.start, "end": s.end, "score": mean_score, "text": s.text}
        results.append(segment_dict)

    # Calculate the elapsed time
    elapsed_time = end_time - start_time

    # Format the elapsed time as HH:mm:ss:ms
    hours, remainder = divmod(elapsed_time.total_seconds(), 3600)
    minutes, remainder = divmod(remainder, 60)
    seconds, milliseconds = divmod(remainder, 1)
    milliseconds = int(milliseconds * 1000)

    formatted_duration = f"{int(hours):02}:{int(minutes):02}:{int(seconds):02}:{milliseconds:03}"
    print(f"Total processing time: {formatted_duration}")

    return results

@app.get("/scalar", include_in_schema=False)
async def scalar_html():
    return get_scalar_api_reference(
        openapi_url=app.openapi_url,
        title=app.title,
        dark_mode=False,
        hide_models=True
    )

@app.post("/generate-srt/")
async def generate_srt(file: UploadFile = File(...), language: str = "fa"):
    # Save the uploaded file temporarily
    os.makedirs(UPLOADS_DIR, exist_ok=True)

    file_path = os.path.join(UPLOADS_DIR, file.filename)
    with open(file_path, "wb") as buffer:
        buffer.write(await file.read())

    try:
        # Process the audio file
        result = process(file_path, language)

        # Clean up the temporary file
        os.remove(file_path)
        
        return result
    except HTTPException as e:
        os.remove(file_path)
        raise e
    except Exception as e:
        os.remove(file_path)
        raise HTTPException(status_code=500, detail=str(e))

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=8000)