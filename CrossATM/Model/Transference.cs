using System.Security.Cryptography.X509Certificates;

namespace CrossATM.Model
{
    public class Transference
    {
        public User CurrentUser { get; set; }
        public string Receptor { get; set; }
        public double MoneyToBeTransfered { get; set; }
    }
}