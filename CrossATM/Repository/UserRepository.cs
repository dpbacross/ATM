using System.Collections.Generic;
using System.Linq;
using CrossATM.Model;

namespace CrossATM.Repository
{
    public class UserRepository
    {
        private List<User> UserList = new List<User>
        {
            new User
            {
                Identification = "40200611149", Code = "1708", Money = 100000.00, Name = "Jorge David Peña Brito"
            },
            new User
            {
                Identification = "40200611148", Code = "1234", Money = 50000.00, Name = "Christian Emmanuel Vasquez Melo"
            }
            
        };
        
        public User GetUser(string id,string code)
        {
            return UserList.FirstOrDefault(x => x.Identification == id && x.Code == code);
        }

        public void Deposit(User user, double moneyToBeDeposit)
        {
            var userToDeposit = UserList.FirstOrDefault(x => x.Identification == user.Identification && x.Code == user.Code);
            if (userToDeposit != null) userToDeposit.Money = user.Money + moneyToBeDeposit;
        }
        
        public void Withdraw(User user,double moneyToBeWithdraw)
        {
            var userToDeposit = UserList.FirstOrDefault(x => x.Identification == user.Identification && x.Code == user.Code);
            if (userToDeposit != null) userToDeposit.Money = user.Money - moneyToBeWithdraw;
        }

        public void Transfer(Transference transference)
        {
            var receptor = UserList.FirstOrDefault(x => x.Identification == transference.Receptor);
            if (receptor == null)
                return;
            Deposit(receptor,transference.MoneyToBeTransfered);
            Withdraw(transference.CurrentUser,transference.MoneyToBeTransfered);
        }
        
    }
}