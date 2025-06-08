using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// In-memory data store
var todoItems = new List<TodoItem>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/todos", () => todoItems);

app.MapGet("/todos/{id}", (int id) => 
{
    var todoItem = todoItems.Find(item => item.Id == id);
    return todoItem is not null ? Results.Ok(todoItem) : Results.NotFound();
});

app.MapPost("/todos", (TodoItem todoItem) => 
{
    todoItem.Id = todoItems.Count + 1;
    todoItems.Add(todoItem);
    return Results.Created($"/todos/{todoItem.Id}", todoItem);
});

app.MapPut("/todos/{id}", (int id, TodoItem updatedItem) => 
{
    var index = todoItems.FindIndex(item => item.Id == id);
    if (index == -1) return Results.NotFound();

    updatedItem.Id = id;
    todoItems[index] = updatedItem;
    return Results.Ok(updatedItem);
});

app.MapDelete("/todos/{id}", (int id) => 
{
    var index = todoItems.FindIndex(item => item.Id == id);
    if (index == -1) return Results.NotFound();

    todoItems.RemoveAt(index);
    return Results.NoContent();
});

app.Run();