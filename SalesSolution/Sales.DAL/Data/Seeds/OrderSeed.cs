using Microsoft.EntityFrameworkCore;
using Sales.DAL.Entities;

namespace Sales.DAL.Data.Seeds
{
    public static partial class Seed
    {
        public static void CreateOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order
            {
                UId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"),
                Name = "New York Building 1",
                State = "NY"
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                UId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"),
                Name = "California Hotel AJK",
                State = "CA"
            });
        }
    }
}
