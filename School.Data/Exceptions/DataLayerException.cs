namespace School.Data.Exceptions
{
    public class DataLayerException : Exception
    {
        public DataLayerException(string message): base(message) { }

        public DataLayerException(string message, Exception innerException) : base(message, innerException) 
        { }
    }
}
