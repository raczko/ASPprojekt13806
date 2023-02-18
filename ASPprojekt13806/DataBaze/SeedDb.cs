using ASPprojekt13806.Areas.Identity.Data;
using ASPprojekt13806.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPprojekt13806.DataBaze
{
    public class SeedDb
    {
        public static void SeedDatabase(ApplicationDBContext context)
        {
            context.SaveChanges();
            if (!context.Vehicles.Any())
            {
                Categories motor = new Categories { Name = "motor" };
                Categories samochod = new Categories { Name = "samochod" };
                Categories bus = new Categories { Name = "bus" };

                Brands audi = new Brands { Name = "audi" };
                Brands suzuki = new Brands { Name = "suzuki" };
                Brands iveco = new Brands { Name = "iveco" };
                Brands seat = new Brands { Name = "seat" };
                Brands hundai = new Brands { Name = "hundai" };

                context.Vehicles.AddRange(
                                        new Vehicles
                                        {
                                            Brand = suzuki,
                                            Price = 8000.00M,
                                            Category = motor,
                                            Image = "suzukimoto1.jpg",
                                            Year = 2015,
                                            Model = "GSX - S1000GT TRAVEL PACK",
                                        },
                                        new Vehicles
                                        {
                                            Brand = audi,
                                            Price = 35000.00M,
                                            Category = samochod,
                                            Image = "audia3.jpg",
                                            Year = 2013,
                                            Model = "A3",
                                        },
                                        new Vehicles
                                        {
                                            Brand = iveco,
                                            Price = 45000.00M,
                                            Category = bus,
                                            Image = "bus1.jpg",
                                            Year = 2017,
                                            Model = "Daily",
                                        },
                                        new Vehicles
                                        {
                                            Brand = seat,
                                            Price = 5000.00M,
                                            Category = samochod,
                                            Image = "toledo2.jpg",
                                            Year = 2004,
                                            Model = "Toledo 2",
                                        },
                                        new Vehicles
                                        {
                                            Brand = hundai,
                                            Price = 50000.00M,
                                            Category = samochod,
                                            Image = "hundai.jpg",
                                            Year = 2014,
                                            Model = "i40",
                                        },
                                        new Vehicles
                                        {
                                            Brand = suzuki,
                                            Price = 10000.00M,
                                            Category = motor,
                                            Year = 2010,
                                            Image = "suzukimoto1.jpg",
                                            Model = "GSX - S1000GT TRAVEL PACK",
                                        }
                                    );
                context.VehicleRepairs.AddRange(
        new VehicleRepairs { Description = "Wymiana oleju", RepairDate = 2022, VehicleId = 1 },
        new VehicleRepairs { Description = "Zmiana Maski", RepairDate = 2021, VehicleId = 2 },
        new VehicleRepairs { Description = "Wymiana klocków hamulcowych", RepairDate = 2018, VehicleId = 3 },
        new VehicleRepairs { Description = "Zmiana linki hamulca reczengo", RepairDate = 2018, VehicleId = 3 },
        new VehicleRepairs { Description = "Wymiana turbiny", RepairDate = 2020, VehicleId = 4 },
        new VehicleRepairs { Description = "Zmiana linki hamulca reczengo", RepairDate = 2021, VehicleId = 5 }
    );

                context.SaveChanges();
            }
        }
    }
}
