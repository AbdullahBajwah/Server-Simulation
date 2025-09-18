# Server Simulation – CAB301 Practical Project

This project simulates a simplified web client system capable of interacting with virtual servers and endpoints via a URL-like structure. Developed as part of a CAB301 practical at QUT, the application enables registration of servers and endpoints, request processing, and custom error handling to ensure input validation and robustness.

## 🛠 Features

- List all registered servers
- Add a new server to the system
- Add endpoints to servers that can be requested
- Request data from a specific server’s endpoint
- Validate inputs and handle errors through custom exception types

## 📂 File Structure & Responsibilities

| File            | Description |
|-----------------|-------------|
| `Server.cs`     | Manages server data and validates server identifiers. |
| `EndPoint.cs`   | Represents endpoints and enforces path formatting. |
| `ServerHub.cs`  | Coordinates multiple servers and validates uniqueness. |
| `Client.cs`     | Parses and validates simulated URLs and handles routing logic. |
| `Program.cs`    | Entry point; wraps execution in exception-safe blocks and coordinates user interaction. |

## 🧩 Validation & Exceptions Implemented

The program includes custom and standard exceptions to handle various edge cases and incorrect user inputs.

### ✅ Custom Exceptions
- `InvalidPathException` – Triggered when endpoint paths are not correctly formatted.
- `ServerNotFoundException` – Thrown when a request is made to a non-existent server.
- `FailedRequestException` – Raised when endpoint response retrieval fails.
- `ServerAlreadyExistsException` – (Optional) If server duplication needs stricter control.

### ✅ Argument Exceptions
- When a server identifier is null, empty, or contains `/`
- When an endpoint path is not unique or doesn't start with `/`
- When endpoint paths already exist or don’t exist

## 📌 Implementation Highlights

- Used object-oriented programming in C# to structure entities such as `Server`, `EndPoint`, and `ServerHub`.
- Applied encapsulation, validation logic, and exception handling for reliable execution.
- Used `foreach`, `try-catch`, and `string.Split()` for parsing paths and managing errors.
- Project follows `.NET 8` (or modern .NET Core) standards and is developed in **JetBrains Rider**.
