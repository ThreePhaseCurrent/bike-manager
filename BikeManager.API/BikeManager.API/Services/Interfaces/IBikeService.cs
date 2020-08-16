using System.Collections.Generic;
using System.Threading.Tasks;
using BikeManager.API.Models;
using BikeManager.Core.Models;
using BikeManager.Core.Repositories.Interfaces;

namespace BikeManager.API.Services.Interfaces
{
    public interface IBikeService: IBikeRepository
    {
        Task<List<Bike>> BikesFilterForStatus(string status);
        Task<bool> RemoveBike(long id);
        Task<bool> UpdateBikeStatus(long id, string toStatus);
        Task<bool> AddFromDto(BikeDto bikeDto);
    }
}