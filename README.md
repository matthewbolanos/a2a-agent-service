# A2A-Demo

This is a simple test app demonstrating how to call an [Azure AI Foundry Agent Service](https://learn.microsoft.com/en-us/azure/ai-services/foundry/) agent using the **A2A (Agent-to-Agent)** protocol.

The app sends a message to a configured agent endpoint and prints the response. It is intended for internal testing purposes only.

> [!CAUTION]
> The service often returns a **500** error; this is being investigated.
> In the meantime, use this tunnel as the endpoint URL: `https://khbc19mq-5000.usw2.devtunnels.ms/workflows/a2a/v1.0/subscriptions/921496dc-987f-410f-bd57-426eb2611356/resourceGroups/ai-agents-karthik-eu/providers/Microsoft.MachineLearningServices/workspaces/project-demo-eu-fw7g/agents/asst_gzaBKcQzu4G7Dx5FxT6Pk9Wk`

---

## 🛠️ Prerequisites

1. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
3. Access to the `A2AProtocolHttpClient` libraries (`A2A.*` packages)

---

## 🔐 Authentication

Before running this app, you **must log in** to Azure using the following test identity:

```bash
az login -u AdeleV@M365x63883554.OnMicrosoft.com
```

> 💬 **Note**: Reach out to **Mads Bolaris** to obtain the password for this test account.

---

## ▶️ Running the App

### Option 1: From VS Code

1. Open the project in VS Code
2. Use the preconfigured launch settings in `.vscode/`
3. Press `F5` to build and run in debug mode

### Option 2: Manually from Terminal

```bash
dotnet build
dotnet run
```

---

## 💬 Example Output

The app sends a simple message ("Hi there how are you?") to the agent and prints the response parts:

Agent> I'm doing well, thank you! How can I assist you today?

---

## 📁 Project Structure

A2A-DEMO/
- Program.cs — Main entry point  
- a2a-demo.csproj — Project file  
- a2a-demo.sln — Solution file  
- .vscode/ — VS Code launch and build configs  
- README.md — You're here  
