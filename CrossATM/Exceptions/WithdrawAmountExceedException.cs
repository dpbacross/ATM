using System;

namespace CrossATM.Exceptions
{
    public class WithdrawAmountExceedException : Exception
    {
        public WithdrawAmountExceedException()
        {
            
        }

        public WithdrawAmountExceedException(string message)
        {
            Console.WriteLine(message);
        }
    }
}