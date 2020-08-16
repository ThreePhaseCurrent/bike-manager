using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeManager.API.Models;
using BikeManager.API.Services.Interfaces;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeManager.API.Services
{
    public class BikeService: BikeRepository, IBikeService
    {
        private readonly IBikeStatusService _bikeStatusService;
        private readonly IBikeCategoryService _bikeCategoryService;
        
        public BikeService(BikeManagerDbContext context, IBikeStatusService bikeStatusService, 
            IBikeCategoryService bikeCategoryService) 
            : base(context)
        {
            _bikeStatusService = bikeStatusService;
            _bikeCategoryService = bikeCategoryService;
        }

        /// <summary>
        /// Filter bikes by specific status
        /// </summary>
        /// <param name="status">Specific status for filter</param>
        /// <returns></returns>
        public async Task<List<Bike>> BikesFilterForStatus(string status)
        {
            var availId = await _bikeStatusService.FindIdByStatusName(status);

            var bikes = Bikes
                .Include(x => x.Category)
                .Include(x => x.Status)
                .Where(x => x.StatusId == availId);

            return bikes.ToList();
        }

        /// <summary>
        /// Delete bike by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveBike(long id)
        {
            var bike = await Bikes
                .FirstOrDefaultAsync(x => x.BikeId == id);

            if (bike ==default)
            {
                return false; 
            }
            
            await Remove(bike);
            return true;
        }

        
        /// <summary>
        /// updating bike status by id and desired status
        /// </summary>
        /// <param name="id">Id specific bike</param>
        /// <param name="toStatus">Desired status</param>
        /// <returns></returns>
        public async Task<bool> UpdateBikeStatus(long id, string toStatus)
        {
            var bike = await Bikes
                .FirstOrDefaultAsync(x => x.BikeId == id);

            var statusId = await _bikeStatusService.FindIdByStatusName(toStatus);

            if (bike == default || statusId == default)
            {
                return false;
            }

            bike.StatusId = statusId;
            await Update(bike);

            return true;
        }

        /// <summary>
        /// Use this when you get bike dto from UI
        /// </summary>
        /// <param name="bikeDto"></param>
        /// <returns></returns>
        public async Task<bool> AddFromDto(BikeDto bikeDto)
        {
            var categoryId = await _bikeCategoryService
                .FindIdByCategoryName(bikeDto.CategoryName);

            var statusId = await _bikeStatusService
                .FindIdByStatusName(bikeDto.StatusName);
            
            var bike = new Bike()
            {
                BikeName = bikeDto.BikeName,
                CategoryId = categoryId,
                StatusId = statusId,
                Price = bikeDto.Price
            };

            //add new bike
            await Add(bike);
            return true;
        }
    }
}