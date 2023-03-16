using Microsoft.EntityFrameworkCore;
using Sales.DAL.Entities;

namespace Sales.DAL.Data.Seeds
{
    public static partial class Seed
    {
        public static void CreateSubElement(ModelBuilder modelBuilder)
        {
            // For window: a6831805-0892-4b76-878a-32d586d49aad
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("b76d17b2-73c6-4071-99ca-40c7fde6c988"),
                Element = 1,
                ElementTypeId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"), // Dooes
                Width = 1200,
                Height = 1850,
                Quantity = 1,
                WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
            });
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("f86e0c8e-52ea-4dc5-abd0-7394fef50f97"),
                Element = 2,
                ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), // Window
                Width = 800,
                Height = 1850,
                Quantity = 1,
                WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
            });
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("b3ae868a-fb83-40d9-8b04-50b8207357b1"),
                Element = 3,
                ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), // Window
                Width = 700,
                Height = 1850,
                Quantity = 1,
                WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
            });

            // For window: 1b110392-9652-44b3-81c5-ff2f8689e873
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("15c6e0a1-048f-4766-a622-d16caa14dbf7"),
                Element = 1,
                ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), // Window
                Width = 1500,
                Height = 2000,
                Quantity = 1,
                WindowId = new Guid("1b110392-9652-44b3-81c5-ff2f8689e873")
            });

            // For window: d1f084c1-0c59-4ee3-8674-af2ece39c7bd
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("de86fd8d-c953-48bb-bef5-b8b7f90bf6c1"),
                Element = 1,
                ElementTypeId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"), // Dooes
                Width = 1400,
                Height = 2200,
                Quantity = 1,
                WindowId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd")
            });
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("fa6066d3-7ac5-4a47-95ac-d5757f83893a"),
                Element = 2,
                ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), // Window
                Width = 600,
                Height = 2200,
                Quantity = 1,
                WindowId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd")
            });


            // For window: a06e1626-10e7-472b-9373-0d673868c699
            modelBuilder.Entity<SubElement>().HasData(new SubElement
            {
                UId = new Guid("f534c91e-c0df-4e80-acf7-0a3907669dbb"),
                Element = 1,
                ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), // Window
                Width = 1500,
                Height = 2000,
                Quantity = 2,
                WindowId = new Guid("a06e1626-10e7-472b-9373-0d673868c699")
            });
        }
    }
}
