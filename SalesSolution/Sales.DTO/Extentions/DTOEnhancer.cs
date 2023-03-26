
using Sales.DTO.Models;

namespace Sales.DTO.Extentions
{
    public static class DTOEnhancer
    {
        public static bool IsEquals<T>(this IEnumerable<T> previousDTOs, IEnumerable<T> currentDTOs)
            where T : notnull, BaseDTO
        {
            var previousSorted = previousDTOs.OrderByDescending(previous => previous.UpdatedAt);
            var currentSorted = currentDTOs.OrderByDescending(current => current.UpdatedAt);

            return previousSorted.SequenceEqual(currentSorted);
        }
    }
}
