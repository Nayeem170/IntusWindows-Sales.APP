using Sales.BLL.Exceptions;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.BLL.Extentions
{
    public static class SubElementEnhancer
    {
        private static ISubElementRepository subElementRepository;

        public static void Configure(ISubElementRepository subElementRepository)
        {
            SubElementEnhancer.subElementRepository = subElementRepository;
        }

        public static SubElement SetElement(this SubElement subElement)
        {
            var maxElement = subElementRepository
                .GetAll(subElement.WindowId)
                .OrderByDescending(element => element.Element)
                .Select(element => element.Element)
                .FirstOrDefault();

            subElement.Element = maxElement + 1;

            return subElement;
        }

        public static SubElement VerifyHeight(this SubElement subElement)
        {
            var topHeight = subElementRepository
                .GetAll(subElement.WindowId)
                .OrderByDescending(element => element.CreatedAt)
                .Select(element => element.Height)
                .FirstOrDefault();

            if (topHeight > 0 && topHeight != subElement.Height)
            {
                throw new BLLValidationException("Make sure all elements have the same height as the last element.");
            }

            return subElement;
        }
    }
}
