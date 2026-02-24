using TodoApi.DTOs;

namespace TodoApi.Services;

public interface ITodoService
{
    Task<IEnumerable<ToDoResponseDto>> GetAllAsync();
    Task<ToDoResponseDto?> GetByIdAsync(int id);
    Task<ToDoResponseDto> CreateAsync(CreateToDoDto createToDo);
    Task<ToDoResponseDto?> UpdateAsync(int id, UpdateToDoDto updateToDo);
    Task<bool> DeleteAsync(int id);
}