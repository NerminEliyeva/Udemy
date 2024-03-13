﻿using FreeCourse.Shared.Dtos;
using FreeCourses.Services.Basket.Dtos;
using System.Text.Json;

namespace FreeCourses.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(200) : Response<bool>.Fail("Basket not found", 500);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("basket not found", 404);
            }
            var data = JsonSerializer.Deserialize<BasketDto>(existBasket);
            return Response<BasketDto>.Success(data,200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success(200) : Response<bool>.Fail("Basket could not update or save", 500);
        }
    }

}