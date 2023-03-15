using Microsoft.EntityFrameworkCore;
using Sales.Api.Models;

namespace Sales.Api.Data.Seeds
{
    public static partial class Seed
    {
        public static void CreateElementType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElementType>().HasData(new ElementType
            {
                UId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"),
                Name = "Doors",
            });
            modelBuilder.Entity<ElementType>().HasData(new ElementType
            {
                UId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                Name = "Window",
            });
        }
    }
}
