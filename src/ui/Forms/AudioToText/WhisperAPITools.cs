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
        public async Task<List<WhisperApiResponse>> SendAudioFile(string filePath)
        {
            // Create a multipart form-data content
            var formData = new MultipartFormDataContent();

            // Add the file content
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");
            formData.Add(fileContent, "file", Path.GetFileName(filePath));

            // Add the language parameter
            formData.Add(new StringContent(Program.AppSettings.Language), "language");

            // Send the POST request
            var response = await client.PostAsync(Program.AppSettings.ApiEndpoint, formData);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read and deserialize the response
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var srtResponse = JsonConvert.DeserializeObject<List<WhisperApiResponse>>(jsonResponse);

            return srtResponse;
        }
    }
}
