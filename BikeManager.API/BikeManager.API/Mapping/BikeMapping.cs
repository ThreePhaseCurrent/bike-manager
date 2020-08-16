using AutoMapper;
using BikeManager.API.Models;
using BikeManager.Core.Models;

namespace BikeManager.API.Mapping
{
    public class BikeMapping: Profile
    {
        public BikeMapping()
        {
            CreateMap<Bike, BikeDto>()
                .ForMember(x => x.Id,
                    q => q.MapFrom(x => x.BikeId))
                .ForMember(x => x.CategoryName,
                    q => q.MapFrom(x => x.Category.CategoryName))
                .ForMember(x => x.StatusName,
                    q => q.MapFrom(x => x.Status.StatusName));
        }
    }
}