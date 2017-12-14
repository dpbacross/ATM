using System;

namespace CrossATM.Exceptions
{
    public class DepositAmountExceedException : Exception
    {
        public DepositAmountExceedException()
        {
            
        }

        public DepositAmountExceedException(string message) 
        {
            Console.WriteLine(message);   
        }
    }
}