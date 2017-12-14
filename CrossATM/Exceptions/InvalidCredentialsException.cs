using System;

namespace CrossATM.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
        {
            
        }

        public InvalidCredentialsException(string message)
        {
            Console.WriteLine(message);
        }
    }
}