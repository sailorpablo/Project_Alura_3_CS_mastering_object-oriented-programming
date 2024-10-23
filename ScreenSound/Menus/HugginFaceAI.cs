using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class HugginFaceAI
    {
        private static readonly string apiKey = "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";

        private static readonly string apiUrl = "https://api-inference.huggingface.co/models/gpt2";

        public string Resultado { get; set; }

        public async Task Request(string message) 
        {
            using (HttpClient client = new HttpClient()) 
            { 
                
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

               

                var data = new { inputs = message };

                string JsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                StringContent content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string result = await response.Content.ReadAsStringAsync();

                Resultado = result;

            }
        }

    }
}
