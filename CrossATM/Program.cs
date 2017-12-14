using System;
using System.Resources;
using System.Security.Authentication;
using CrossATM.Exceptions;
using CrossATM.Model;
using CrossATM.Repository;
using CrossATM.Services;

namespace CrossATM
{
    internal class Program
    {
        private static readonly UserService UserService = new UserService(new UserRepository());
        public static void Main(string[] args)
        {
            Login:
            Console.WriteLine("Please Enter Identification:");
            var userIdentification = Console.ReadLine();

            Console.WriteLine("Please Enter the access Code:");
            var userCode = Console.ReadLine();

            var user = UserService.GetUser(userIdentification, userCode);
            if (user == null)
            {
                throw new InvalidCredentialException("Invalid Credentials");
            }
            
            Reset:
            Console.Clear();
            Console.WriteLine($"Welcome {user.Name}");
            Console.WriteLine("Please select one of the options below.");
            Console.WriteLine("1...............................Deposit");
            Console.WriteLine("2...............................Withdraw");
            Console.WriteLine("3...............................Transfer");
            Console.WriteLine("4...............................Logout");
            Console.WriteLine("5...............................Cancel");

            var selectedOption = Console.ReadLine();
            Console.Clear();
            
            switch (selectedOption)
            {
               case "1":
                {
                    Console.WriteLine("Introduce amount to be deposit:");
                    var amountToBeDeposit = Convert.ToDouble(Console.ReadLine());
                    
                    if(amountToBeDeposit > 10000)
                        throw new DepositAmountExceedException("Deposit max amount has been exceeded");
                    
                    UserService.Deposit(user,amountToBeDeposit);
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Introduce amount withdraw:");
                    var amountToWithdraw = Convert.ToDouble(Console.ReadLine());
                    
                    if(amountToWithdraw > 20000)
                        throw new WithdrawAmountExceedException("Withdraw max amount has been exceeded");
                    
                    UserService.Withdraw(user,amountToWithdraw);
                    break;
                }
                    
                case "3":
                {
                    Console.WriteLine("Introduce receptor identification number:");
                    var receptor = Console.ReadLine();
                    
                    Console.WriteLine("Introduce amount to transfer:");
                    var amountToTransfer = Convert.ToDouble(Console.ReadLine());

                    var transference = new Transference
                    {
                        CurrentUser = user,
                        MoneyToBeTransfered = amountToTransfer,
                        Receptor = receptor
                    };
                    UserService.Transfer(transference);
                    break;
                }
                case "4":
                {
                    goto Login;
                    break;
                }
                case "5":
                {
                    return;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Option");
                    return;
                }
            }
            
            Console.Clear();
            Console.WriteLine($"Actual Balance: {user.Money}, Name:{user.Name}");

            Console.WriteLine("Do you want to realize another action? y/n");
            if(Console.ReadLine()?.ToUpper() == "Y")
                goto Reset;
            Console.ReadKey();
        }
    }
}