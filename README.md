# Todo Minimal API

This is a simple Todo API built using .NET 8 and the Minimal API approach. It allows users to manage their todo items with basic CRUD operations.

## Project Structure

- **Program.cs**: Entry point of the application, sets up the API and routes.
- **TodoItem.cs**: Defines the `TodoItem` class with properties and methods.
- **todo-minimal-api.csproj**: Project file containing dependencies and configuration.
- **README.md**: Documentation for the project.

## Getting Started

### Prerequisites

- .NET 8 SDK installed on your machine.

### Setup

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the API

To run the API, use the following command:
```
dotnet run
```

The API will be available at `http://localhost:5000`.

### API Endpoints

- **GET /todos**: Retrieve all todo items.
- **GET /todos/{id}**: Retrieve a specific todo item by ID.
- **POST /todos**: Create a new todo item.
- **PUT /todos/{id}**: Update an existing todo item.
- **DELETE /todos/{id}**: Delete a todo item.

### Example Requests

- **Create a Todo Item**:
  ```
  POST /todos
  {
      "title": "Learn .NET 8",
      "isCompleted": false
  }
  ```

- **Get All Todo Items**:
  ```
  GET /todos
  ```

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.

## License

This project is licensed under the MIT License.