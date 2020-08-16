using System;
using System.Collections.Generic;
using System.Linq;
using BikeManager.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BikeManager.API.Data
{
    public class InitData
    {
        /// <summary>
        /// Add data if database is empty
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<BikeManagerDbContext>();

            if (!context.BikeCategories.Any())
            {
                //add categories
                context.BikeCategories.AddRange(new List<BikeCategory>()
                {
                    new BikeCategory()
                    {
                        CategoryName = "Highway",
                    },
                    new BikeCategory()
                    {
                        CategoryName = "Mountain"
                    }
                });
                
                context.SaveChanges();
            }

            if (!context.BikeStatuses.Any())
            {
                //add statuses
                context.BikeStatuses.AddRange(new List<BikeStatus>()
                {
                    new BikeStatus()
                    {
                        StatusName = "Available"
                    },
                    new BikeStatus()
                    {
                        StatusName = "Rented"
                    }
                });
                
                context.SaveChanges();
            }

            if (!context.Bikes.Any())
            {
                //add test bikes
                var idAvail = context.BikeStatuses
                    .FirstOrDefault(x => x.StatusName == "Available")?.StatusId;
                var idRent = context.BikeStatuses
                    .FirstOrDefault(x => x.StatusName == "Rented")?.StatusId;
                
                var idHighwayCategory = context.BikeCategories
                    .FirstOrDefault(x => x.CategoryName == "Highway")?.CategoryId;
                var idMountainCategory = context.BikeCategories
                    .FirstOrDefault(x => x.CategoryName == "Mountain")?.CategoryId;

                if (idHighwayCategory == default || idMountainCategory == default ||
                    idAvail == default || idRent == default)
                {
                    return;
                }

                context.Bikes.AddRange(new List<Bike>()
                {
                    new Bike()
                    {
                        BikeName = "Test bike 1",
                        CategoryId = (int)idHighwayCategory,
                        StatusId = (int)idAvail,
                        Price = 500
                    },
                    new Bike()
                    {
                        BikeName = "Test bike 2",
                        CategoryId = (int)idHighwayCategory,
                        StatusId = (int)idAvail,
                        Price = 550
                    },
                    new Bike()
                    {
                        BikeName = "Test bike 3",
                        CategoryId = (int)idMountainCategory,
                        StatusId = (int)idRent,
                        Price = 680
                    }
                });
                
                context.SaveChanges();
            }
        }
    }
}