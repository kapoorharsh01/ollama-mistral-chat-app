using Microsoft.AspNetCore.Mvc;
using Ollama.Mistral.Demo.Models;
using System.Text.Json;

namespace Ollama.Mistral.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MistralController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public MistralController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ollama");
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] askRequestDto request)
        {
            ChatMemory.Messages.Add(new ChatMessage { Role = "user", Content = request.Message });

            ChatMemory.Messages.Insert(0, new ChatMessage
            {
                Role = "system",
                Content = "You are a helpful AI assistant. Answer clearly and concisely in 2-3 sentences. Be friendly and professional. If asked for lists, format with line breaks for readability."
            });

            var modelPayload = new
            {
                model = "mistral",
                //messages = new[]
                //{
                //    new { role = "user", content = request }
                //},
                messages = ChatMemory.Messages.Select(m => new { role = m.Role, content = m.Content }),
                //prompt = request,
                stream = false,
                options = new
                {
                    num_predict = 180,
                    temperature = 0.1,
                    //top_p = 0.9
                }

                //n = 1,
                //stop = (string?)null
            };

            //var res = await _httpClient.PostAsJsonAsync("api/generate", payload);
            var res = await _httpClient.PostAsJsonAsync("api/chat", modelPayload);
            var json = await res.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(json);

            //var answer = doc.RootElement.GetProperty("response").GetString();

            //Console.Write(doc.RootElement);

            if(doc.RootElement.TryGetProperty("error", out var error))
            {
                return BadRequest(error.GetString());
            }

            var answer = doc.RootElement.GetProperty("message").GetProperty("content").GetString();

            ChatMemory.Messages.Add(new ChatMessage { Role = "assistant", Content = answer });

            return Ok(new {response = answer} );
        }
    }
}

/*
add on comments line to line 2-4 

stories - multiple sprints

sprints - task (on azure portal) then sub tasks

if task is uncomplete or seem to be difficult then coordinate with team mates or rm

focus on single task then only move forward, 
make timelines 4hr -> 2-3hr

-> remember the errors whichever you've faced as of now n how u figured out the solution (document as well)


angular: deep linking or dynamic links (like amazon product link) look for alternative apart from using firebase which is deprecated
*/

