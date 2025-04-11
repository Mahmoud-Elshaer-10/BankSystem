using A_DataAccess.Repositories;
using B_Business;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AccountDTO> a = Account.GetAccountsByFilter("Balance", "30");

            foreach (var item in a)
            {
                Console.WriteLine($"AccountID: {item.AccountID}, ClientID: {item.ClientID}, Balance: {item.Balance}, CreatedAt: {item.CreatedAt}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}