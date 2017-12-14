using System;
using CrossATM.Model;
using CrossATM.Repository;

namespace CrossATM.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        
        public User GetUser(string id,string code)
        {
            return _userRepository.GetUser( id,code);
        }

        public void Deposit(User user, double moneyToBeDeposit)
        {
           _userRepository.Deposit(user,moneyToBeDeposit);
        }
        
        public void Withdraw(User user,double moneyToBeWithdraw)
        {
            _userRepository.Withdraw(user,moneyToBeWithdraw);   
        }

        public void Transfer(Transference transference)
        {
            _userRepository.Transfer(transference); 
        }
    }
}