﻿using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Discount.Services
{
    public interface IDiscountService
    {
        //TODO : burda dto alib servisde maplemek olardi
        Task<Response<List<Models.Discount>>> GetAll();
        Task<Response<Models.Discount>> GetById(int id);
        Task<Response<Models.Discount>> GetByCodeAndUserId(string code,string userId);
        Task<Response<NoContent>> Update(Models.Discount discount);
        Task<Response<NoContent>> Save(Models.Discount discount);
        Task<Response<NoContent>> Delete(int id);
    }
}
