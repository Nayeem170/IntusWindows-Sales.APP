using Microsoft.EntityFrameworkCore;
using Sales.Api.Entities;

namespace Sales.Api.Data.Seeds
{
    public static partial class Seed
    {
        public static void CreateWindow(ModelBuilder modelBuilder)
        {
            // For order: b3ca33e7-c319-40fd-a681-7e479364a352
            modelBuilder.Entity<Window>().HasData(new Window
            {
                UId = new Guid("a6831805-0892-4b76-878a-32d586d49aad"),
                Name = "A51",
                Quantity = 4,
                OrderId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352")
            });
            modelBuilder.Entity<Window>().HasData(new Window
            {
                UId = new Guid("1b110392-9652-44b3-81c5-ff2f8689e873"),
                Name = "C Zone 5",
                Quantity = 2,
                OrderId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352")
            });

            // For order: 4b103f67-130e-4e20-b4d4-7023871bc52a
            modelBuilder.Entity<Window>().HasData(new Window
            {
                UId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd"),
                Name = "GLB",
                Quantity = 3,
                OrderId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a")
            });
            modelBuilder.Entity<Window>().HasData(new Window
            {
                UId = new Guid("a06e1626-10e7-472b-9373-0d673868c699"),
                Name = "OHF",
                Quantity = 10,
                OrderId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a")
            });
        }
    }
}
