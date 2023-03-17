namespace Sales.API.Extentions
{
    public static class CheckerHelper
    {
        public static bool IsNull<T>(this T @this) where T : class
        {
            return @this == null;
        }
    }
}
