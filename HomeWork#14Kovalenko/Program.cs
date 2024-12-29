using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace HomeWork_14Kovalenko
{
    internal class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            string nameAccount = "Загальний рахунок";
            string nameVipAccount = "VIP рахунок";

            decimal balance = 1245.45m;
            decimal vipBalance = 100000.25m;

            Account AccountLebedev = new(nameAccount, balance);
            Account AccountVipLebedev = new(nameVipAccount, vipBalance);

        

            List<Account> list = [ AccountLebedev, AccountVipLebedev ];
     
            int indexAccount;
            //int indexMenu;
            while (true)
            {
                Console.Clear();
                WriteMenu(1, list);

                Console.Write("Виберіть опцію 1 - 3 "); 
                bool outBlendInput = int.TryParse((Console.ReadLine()), out int indexMenu);
                if (outBlendInput && indexMenu <= 3)
                {
                    switch ((Menu)indexMenu)
                    {
                        case 0:
                            { break; }
                       
                        case Menu.checkBalance: // Перевірка балансу
                            {
                                CheckBalance(list);
                            }
                            break;
                        case Menu.makeAdeposit: // внести депозит
                            {
                                WriteMenu(2, list);
                                outBlendInput = int.TryParse((Console.ReadLine()), out indexAccount); // обработать не коррктный ввод
                                if (outBlendInput)
                                {
                                    switch ((ChangeAccount)indexAccount)
                                    {
                                        case ChangeAccount.account:
                                            {
                                                list = ChangeBalance(Menu.makeAdeposit, list, indexAccount);
                                            }
                                            break;
                                        case ChangeAccount.vipAccount:
                                            {
                                                list = ChangeBalance(Menu.makeAdeposit, list, indexAccount);
                                            }
                                            break;
                                    }
                                }
                                else { WriteBlend(); }
                            }
                            break;
                        case Menu.withdrawCash: // зняття готівки
                            {
                                WriteMenu(2, list);
                                outBlendInput = int.TryParse((Console.ReadLine()), out indexAccount);
                                if (outBlendInput)
                                {
                                    switch ((ChangeAccount)indexAccount)
                                    {
                                        case ChangeAccount.account:
                                            {
                                                list = ChangeBalance(Menu.withdrawCash, list, indexAccount);
                                            }
                                            break;
                                        case ChangeAccount.vipAccount:
                                            {
                                                list = ChangeBalance(Menu.withdrawCash, list, indexAccount);
                                            }
                                            break;
                                    }
                                } else { WriteBlend(); }
                            }
                            break;
                    }
                }else { WriteBlend(); continue; }

                Console.Write("\nЗакінчити роботу: 1 - Так / 2 - Ні  ");

                int.TryParse((Console.ReadLine()), out int exit);

                if (exit == 1)
                { break; }

                else if (exit == 2)
                { continue; }

                else { WriteBlend(); continue; }
            }
        }
        

        enum Menu
        {
            exit,
            checkBalance,
            makeAdeposit,
            withdrawCash,
            
        }
        enum ChangeAccount
        {
            account,
            vipAccount,
        }
        static List<Account> ChangeBalance(Menu menu, List<Account> list, int index)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Введіть сумму ");// а - добавить возможность ввода суммы
            bool outBlendInput = decimal.TryParse(Console.ReadLine(), out decimal summ);
              // в - исключить некректнный ввод
                switch (menu)
                {
                    case Menu.withdrawCash:
                    {
                        if (outBlendInput && summ <= list[index].Balance)// б - исключить снятие больше чем есть 
                        {
                            list[index].Balance = list[index].Balance - summ;
                            Console.WriteLine($"Сума {summ} була успішно знята з вашого рахунку.\n");
                        }
                        else if (summ > list[index].Balance) { Console.WriteLine("Нажаль на вашому рахунку бракує коштів\n" +
                            ""); }
                        else { WriteBlend(); }

                    }
                    break;
                    case Menu.makeAdeposit:
                        {
                            list[index].Balance = list[index].Balance + summ;
                            Console.WriteLine($"Сума {summ} була успішно додана на ваш рахунок\n");
                        }
                        break;
                }
            
            return list;
        }
        static void CheckBalance(List<Account> list)
        {
            Console.Clear();
            Console.WriteLine($"\n{list[0].NameAccount}: Баланс - {list[0].Balance}");
            Console.WriteLine($"\n{list[1].NameAccount}: Баланс - {list[1].Balance}");
        }
        static void WriteMenu(int typeMenu, List<Account> list)
        {
            switch (typeMenu)
            {
                case 1:
                    {
                        Console.WriteLine("\tПан Лебєдєв Вітаємо в нашому Банку!\n\n");
                        Console.WriteLine("\t\tВиберіть дію\n\n");
                        Console.WriteLine("1 - Переглянути баланс\t\t2 - Внести депозит");
                        Console.WriteLine("\n3 - Зняти гроші\t\t\t0 - Вихід");
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine($"0 - {list[0].NameAccount}\t1 - {list[1].NameAccount}\n");
                        Console.WriteLine("Виберіть рахунок ");
                    }
                    break;
            }
        }
        static void WriteBlend()
        {
            Console.WriteLine("Некоректне введення повторіть спробу!");
        }


    }

}
