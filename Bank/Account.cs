using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Account
    {
        private int numbr; // номер счёта
        private string name; //ФИО владельца
        private double money; //сумма денег на счету

        /// <summary>
        /// Создание счёта
        /// </summary>
        public Account()
        {
            this.name = "";
        }

        /// <summary>
        /// Выбор приватного метода
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        public void Start(List<Account> accounts)
        {
            this.AccountAppear(accounts);
        }

        /// <summary>
        /// Открытие счёта
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        private void AccountAppear(List<Account> accounts)
        {
            if (accounts.Count < 1)
            {
                Console.WriteLine("Для начала работы создайте хотя бы один счёт.\n");
            }
            accounts.Add(new Account());
            Account last = accounts.Last();
            last.InfoInput(accounts);
            Console.WriteLine();
            Console.WriteLine("Чтобы начать работу, нажмите Enter. Если хотите создать ещё счёт, введите '+' и нажмите Enter.");
            string answ = Console.ReadLine();
            Console.WriteLine();
            if (answ == "+")
            {
                this.AccountAppear(accounts);
            }
            else
            {
                this.ChooseAccount(accounts);
            }
        }

        /// <summary>
        /// Заполнение информации о счёте
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        private void InfoInput(List<Account> accounts)
        {
            this.NumberInput(accounts);
            this.NameInput();
            this.MoneyInput();
        }

        /// <summary>
        /// Заполнение номера счёта
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        private void NumberInput(List<Account> accounts)
        {
            Console.Write("Введите номер счёта (не может быть меньше нуля): ");
            int numb = Convert.ToInt32(Console.ReadLine());
            if (numb < 0)
            {
                this.NumberInput(accounts);
            }
            int a = 0;
            foreach (Account account in accounts)
            {
                if (numb == account.numbr)
                {
                    Console.WriteLine("Счёт с таким номером уже существует.");
                    a++;
                    this.NumberInput(accounts);
                }
            }
            if (a == 0)
            {
                this.numbr = numb;
            }
        }

        /// <summary>
        /// Заполнение ФИО владельца счёта
        /// </summary>
        private void NameInput()
        {
            Console.Write("Введите ФИО владельца (не может остаться пустым): ");
            string name = Console.ReadLine();
            if (name == "")
            {
                this.NameInput();
            }
            else
            {
                this.name = name;
            }
        }

        /// <summary>
        /// Заполнение суммы на счету
        /// </summary>
        private void MoneyInput()
        {
            Console.Write("Положите на счёт деньги (сумма должна быть больше нуля): ");
            double money = Convert.ToDouble(Console.ReadLine());
            if (money < 0)
            {
                this.MoneyInput();
            }
            else
            {
                this.money = Math.Round(money, 2);
            }
        }

        /// <summary>
        /// Выбор счёта
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        private void ChooseAccount(List<Account> accounts)
        {
            Console.WriteLine("Выберите счёт:\n");
            foreach (Account account in accounts)
            {
                account.InfoOutput();
                Console.WriteLine();
            }
            int accChoice = Convert.ToInt32(Console.ReadLine());
            foreach (Account account in accounts)
            {
                if (accChoice == account.numbr)
                {
                    account.ChooseAction(accounts);
                    break;
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод информации о счёте
        /// </summary>
        private void InfoOutput()
        {
            Console.WriteLine("№" + this.numbr);
            Console.WriteLine("Владелец: " + this.name);
            Console.WriteLine("Сумма: " + this.money);
        }

        /// <summary>
        /// Выбор действия
        /// </summary>
        /// <param name="accounts">Список счетов</param>
        private void ChooseAction(List<Account> accounts)
        {
            Console.WriteLine("\nВыберите действие:\n1 - Информация о счёте\n2 - Внести денежные средства\n3 - Снять денежные средства\n4 - Обнулить счёт\n5 - Перевести денежные средства\n6 - Выбрать другой счёт\n7 - Открыть новый счёт\nEnter - выход\n");
            string actChoice = Console.ReadLine();
            Console.WriteLine();
            switch (actChoice)
            {
                case "1":
                    this.InfoOutput();
                    this.ChooseAction(accounts);
                    break;

                case "2":
                    this.DepositMoney();
                    this.ChooseAction(accounts);
                    break;

                case "3":
                    this.WithdrawalMoney();
                    this.ChooseAction(accounts);
                    break;

                case "4":
                    this.Reset();
                    this.ChooseAction(accounts);
                    break;

                case "5":
                    this.Transaction(accounts);
                    this.ChooseAction(accounts);
                    break;

                case "6":
                    this.ChooseAccount(accounts);
                    break;

                case "7":
                    this.AccountAppear(accounts);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Внесение средств на счёт
        /// </summary>
        private void DepositMoney()
        {
            Console.Write("Введите сумму внесения (должна быть > нуля): ");
            double money = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            if (money > 0)
            {
                this.money += Math.Round(money, 2);
                Console.WriteLine("Денежные средства успешно внесены на счёт.");
            }
            else
            {
                this.DepositMoney();
            }
        }

        /// <summary>
        /// Снятие средств со счёта
        /// </summary>
        private void WithdrawalMoney()
        {
            Console.Write("Введите сумму снятия (должна быть > нуля): ");
            double money = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            if (money > 0)
            {
                this.money -= Math.Round(money, 2);
                Console.WriteLine("Денежные средства усешно сняты со счёта.");
            }
            else
            {
                this.DepositMoney();
            }
        }

        /// <summary>
        /// Обнуление счёта
        /// </summary>
        private void Reset()
        {
            this.money = 0;
            Console.WriteLine("Обнуление счёта произошло успешно.");
        }

       /// <summary>
       /// Транзакция(перевод)
       /// </summary>
       /// <param name="accounts">Список счетов</param>
        private void Transaction(List<Account> accounts)
        {
            Console.Write("Введите сумму перевода (должна быть > нуля): ");
            double money = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            if (money > 0)
            {
                if (money > this.money)
                {
                    Console.Write("Вы не можете перевести больше средств, чем у вас имеется на счету.");
                }
                else
                {
                    Console.WriteLine("Выберите счёт:\n");
                    foreach (Account account in accounts)
                    {
                        if (account.numbr != this.numbr)
                        {
                            account.InfoOutput();
                            Console.WriteLine();
                        }
                    }
                    int accChoice = Convert.ToInt32(Console.ReadLine());
                    foreach (Account account in accounts)
                    {
                        if (accChoice == account.numbr)
                        {
                            this.money -= money;
                            account.money += money;
                            Console.WriteLine("Перевод доставлен.");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                this.Transaction(accounts);
            }
        }
    }
}
