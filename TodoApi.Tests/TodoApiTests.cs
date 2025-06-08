using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using todo_minimal_api; // Add this line (replace with your actual namespace)

public class TodoApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TodoApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTodos_ReturnsOk()
    {
        var response = await _client.GetAsync("/todos");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PostTodo_AddsTodo()
    {
        var todo = new { Title = "Test Todo", IsCompleted = false };
        var response = await _client.PostAsJsonAsync("/todos", todo);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task PutTodo_UpdatesTodo()
    {
        var todo = new { Title = "To Update", IsCompleted = false };
        var postResponse = await _client.PostAsJsonAsync("/todos", todo);
        var created = await postResponse.Content.ReadFromJsonAsync<TodoItem>();

        var updated = new { Id = created.Id, Title = "Updated", IsCompleted = true };
        var putResponse = await _client.PutAsJsonAsync($"/todos/{created.Id}", updated);
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
    }

    [Fact]
    public async Task DeleteTodo_DeletesTodo()
    {
        var todo = new { Title = "To Delete", IsCompleted = false };
        var postResponse = await _client.PostAsJsonAsync("/todos", todo);
        var created = await postResponse.Content.ReadFromJsonAsync<TodoItem>();

        var deleteResponse = await _client.DeleteAsync($"/todos/{created.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}