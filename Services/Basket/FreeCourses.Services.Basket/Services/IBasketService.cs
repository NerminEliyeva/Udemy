using FreeCourse.Shared.Dtos;
using FreeCourses.Services.Basket.Dtos;

namespace FreeCourses.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basket);
        Task<Response<bool>> Delete(string userId);
    }

}
