using Bank;

internal class Program
{
    static void Main()
    {
        List<Account> accounts = new List<Account>(); // список счетов
        Account account = new Account(); // объект для взаимодействия
        account.Start(accounts);
    }
}