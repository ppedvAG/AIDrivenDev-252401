# MiniShop

MiniShop is a sample .NET 9.0 application demonstrating Clean Architecture principles and AI integration within a simple e-commerce domain.

## Project Structure

The solution follows a Clean Architecture approach, organized into the following projects:

- **MiniShop.Domain**: Contains the core business logic and entities (e.g., `Cart`, `Product`, `Customer`, `Order`). This project has no dependencies on other layers.
- **MiniShop.Application**: Contains application use cases (e.g., `AddItemToCart`) and interfaces for external services (e.g., `ILlmClient`).
- **MiniShop.Infrastructure**: Implements interfaces defined in the Application layer. It includes AI clients for:
    - **OpenAI**: `OpenAIResponseClient` using the official OpenAI library.
    - **Local LLM**: `LocalLlmClient` for connecting to local inference servers.
- **MiniShop.App**: A console application that serves as the entry point, demonstrating how to wire up the components and execute use cases.
- **MiniShop.Domain.Tests**: Unit tests for the Domain layer using xUnit.

## Features

- **Domain-Driven Design**: Encapsulated business logic within domain entities.
- **AI Integration**: Flexible `ILlmClient` interface with implementations for both cloud-based (OpenAI) and local LLMs.
- **Unit Testing**: Comprehensive test coverage for domain logic.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- An OpenAI API Key (if using `OpenAIResponseClient`)

## Getting Started

### 1. Clone the repository

```bash
git clone <repository-url>
cd AIDrivenDev-252401
```

### 2. Set up Environment Variables

The application requires an OpenAI API key to run the AI demonstration. Set the `OPENAI_API_KEY` environment variable:

**macOS/Linux:**
```bash
export OPENAI_API_KEY="your-api-key-here"
```

**Windows (PowerShell):**
```powershell
$env:OPENAI_API_KEY="your-api-key-here"
```

### 3. Run the Application

Navigate to the root directory and run the console app:

```bash
dotnet run --project src/MiniShop.App/MiniShop.App.csproj
```

You should see output demonstrating the shopping cart logic and a test response from the AI client.

### 4. Run Tests

To execute the unit tests:

```bash
dotnet test
```

## Usage Example

The `Program.cs` demonstrates a simple flow:
1.  Creates a `Product` and a `Cart`.
2.  Executes the `AddItemToCart` use case.
3.  Prints the cart contents.
4.  Initializes the `OpenAiResponsesClient` and sends a test prompt to the LLM.

## License

[MIT](LICENSE)
