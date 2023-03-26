namespace Sales.LIB.Extentions
{
    public static class CheckerHelper
    {
        public static bool IsNull<T>(this T @this)
        {
            return @this == null;
        }
    }
}