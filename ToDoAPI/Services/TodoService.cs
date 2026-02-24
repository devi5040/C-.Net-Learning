using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.DTOs;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;
    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDoResponseDto>> GetAllAsync()
    {
        return await _context.Todos.Select(t => MapToResponse(t)).ToListAsync();
    }

    public async Task<ToDoResponseDto?> GetByIdAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        return todo is null ? null : MapToResponse(todo);
    }

    public async Task<ToDoResponseDto> CreateAsync(CreateToDoDto createToDo)
    {
        var todo = new Todo
        {
            Title = createToDo.Title,
            Description = createToDo.Description,
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return MapToResponse(todo);
    }

    public async Task<ToDoResponseDto?> UpdateAsync(int id, UpdateToDoDto dto)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null) return null;

        todo.Title = dto.Title;
        todo.Description = dto.Description;
        todo.IsCompleted = dto.IsCompleted;
        todo.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return MapToResponse(todo);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null) return false;

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }

    // Private mapper
    private static ToDoResponseDto MapToResponse(Todo todo) => new()
    {
        Id = todo.Id,
        Title = todo.Title,
        Description = todo.Description,
        IsCompleted = todo.IsCompleted,
        CreatedAt = todo.CreatedAt,
        UpdatedAt = todo.UpdatedAt
    };
}