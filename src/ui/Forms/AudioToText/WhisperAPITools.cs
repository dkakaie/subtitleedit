using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    public class WhisperApiResponse
    {
        public float Start { get; set; }
        public float End { get; set; }
        public float Score { get; set; }
        public string Text { get; set; }
    }

    internal class WhisperAPITools
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<List<WhisperApiResponse>> SendAudioFile(string filePath, string language)
        {
            // Create a multipart form-data content
            var formData = new MultipartFormDataContent();

            // Add the file content
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");
            formData.Add(fileContent, "file", Path.GetFileName(filePath));

            // Add the language parameter
            formData.Add(new StringContent(language), "language");

            // Send the POST request
            var response = await client.PostAsync("http://127.0.0.1:8000/generate-srt", formData);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read and deserialize the response
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var srtResponse = JsonConvert.DeserializeObject<List<WhisperApiResponse>>(jsonResponse);

            return srtResponse;
        }
    }
}
