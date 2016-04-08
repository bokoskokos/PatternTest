using System;

namespace MyPegasus.DomainModel.Factories
{
    public class MyPegasusFactoryException<T> : Exception
    {
        public MyPegasusFactoryException(string message) : base($"Error creating {typeof(T)}: {message}")
        {
        }

        public MyPegasusFactoryException(string message, Exception ex) : base($"Error creating {typeof(T)}: {message}", ex)
        {
        }
    }
}
