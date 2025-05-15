// See https://aka.ms/new-console-template for more information

using A2A;
using A2A.Client.Configuration;
using A2A.Client.Services;
using A2A.Models;
using A2A.Requests;
using Azure.Identity;
using Microsoft.Extensions.Options;

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {(await new DefaultAzureCredential().GetTokenAsync(new Azure.Core.TokenRequestContext(new[] { "https://management.azure.com/" }))).Token}");
var client = new A2AProtocolHttpClient(Options.Create<A2AProtocolClientOptions>(new A2AProtocolClientOptions
{
    Endpoint = new System.Uri("https://eastus.api.azureml.ms/workflows/a2a/v1.0/subscriptions/ccac791d-d74e-4ba8-8487-0e2fbc1d0415/resourceGroups/rg-admin-5724_ai/providers/Microsoft.MachineLearningServices/workspaces/a2a-demo/agents/asst_o8dLdsZB5hOYcA059IsrAZVt")
}), httpClient);


//arrange
var request = new SendTaskRequest()
{
    Params = new()
    {
        Id = Guid.NewGuid().ToString("N"),
        Message = new()
        {
            Role = MessageRole.User,
            Parts =
            [
                new TextPart("Hi there how are you?")
            ]
        }
    }
};

//act
var response = await client.SendTaskAsync(request);

foreach (var artifact in response.Result?.Artifacts ?? Enumerable.Empty<Artifact>())
{
    if (artifact.Parts != null)
    {
        foreach (var part in artifact.Parts.OfType<TextPart>()) Console.WriteLine($"Agent> {part.Text}");
    }
}