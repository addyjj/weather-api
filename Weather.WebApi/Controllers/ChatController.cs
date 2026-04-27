using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using System.Runtime.CompilerServices;
using Weather.Core.Interfaces;
using Weather.WebApi.Dtos;

namespace Weather.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController(IChatClient chatClient, IWeatherService service) : ControllerBase
{
    [HttpPost("stream")]
    public async Task<IResult> StreamAsync([FromBody] ChatConversation chatConversation, CancellationToken cancellationToken = default)
    {
        var messages = chatConversation.GetChatMessages();
        var options = new ChatOptions
        {
            Tools = [AIFunctionFactory.Create(service.GetDevicesAsync), AIFunctionFactory.Create(service.GetDeviceDataAsync)],
        };

        var streamingResponse = GetStreamingResponseAsync(messages, options, cancellationToken);
        return TypedResults.ServerSentEvents(streamingResponse);
    }

    private async IAsyncEnumerable<string> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var response in chatClient.GetStreamingResponseAsync(messages, options, cancellationToken: cancellationToken))
        {
            yield return response.Text;
        }
    }
}
