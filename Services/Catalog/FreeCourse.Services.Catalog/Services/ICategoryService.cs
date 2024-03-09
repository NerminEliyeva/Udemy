using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsnyc();
        Task<Response<CategoryDto>> GetByIdAsnyc(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);

    }
}
