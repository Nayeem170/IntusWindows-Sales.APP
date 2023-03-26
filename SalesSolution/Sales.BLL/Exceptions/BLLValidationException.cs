namespace Sales.BLL.Exceptions
{
    public class BLLValidationException : Exception
    {
        public BLLValidationException(string message) : base(message) { }
    }
}
