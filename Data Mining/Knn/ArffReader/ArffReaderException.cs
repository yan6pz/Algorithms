namespace ArffSharp
{
    using System;

    public class ArffReaderException : Exception
    {
        public ArffReaderException(string message) : base(message) { }
        public ArffReaderException(string message, Exception innerException) : base(message, innerException) { }
    }
}
