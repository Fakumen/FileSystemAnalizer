using System;

namespace FileSystemAnalyzer.Infrastructure
{
    public class ObjectNotReadyException : Exception
    {
        public ObjectNotReadyException() : this("Object was not ready for use.") { }

        public ObjectNotReadyException(string message) : base(message) { }
    }
}
