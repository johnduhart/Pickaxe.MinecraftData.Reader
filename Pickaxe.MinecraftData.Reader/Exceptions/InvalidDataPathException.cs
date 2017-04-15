using System;

namespace Pickaxe.MinecraftData.Reader.Exceptions
{
    [Serializable]
    public class InvalidDataPathException : Exception
    {
        public InvalidDataPathException()
        {
        }

        public InvalidDataPathException(string message) : base(message)
        {
        }

        public InvalidDataPathException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}