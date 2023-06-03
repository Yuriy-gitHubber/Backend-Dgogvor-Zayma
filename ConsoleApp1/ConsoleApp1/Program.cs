﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            string ContractName, ContractLocation, LenderName, LenderPass, BorrowerName, BorrowerPass, StartDate, FinishDate;
            int ContractForm, Currency, CompensationType, PercentExist, PercentType,  RepaymentType, PaymentProcedure, PenaltyType, PennyType;
            float ZaymSumm, ZaymPercent, CBPercent, ShtrafSize, PennyPercent, ItogSumm;
            Console.WriteLine("Введите данные о договоре займа:");
            Console.Write("Введите номер договора займа:");
            ContractName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите место заключения договора");
            ContractLocation = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите ФИО Заимодавца:");
            LenderName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите Пасспортные данные Заимодавца :");
            LenderPass = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите ФИО Заёмщика:");
            BorrowerName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите Пасспортные данные Заёмщика:");
            BorrowerPass = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите дату заключения договора:");
            StartDate = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Договор заключен в письменном виде? 1 - Да. 2 - Нет. Ваш ответ:");
            ContractForm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (ContractForm == 2)
                throw new Exception("Договор в неправильной форме, дальнейшая консультация невозможна");

            Console.Write("Введите сумму займа:");
            ZaymSumm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("В какой валюте заключён займ? 1 - Рубли. 2 - Другая валюта. Ваш ответ:");
            Currency = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (Currency == 2)
                throw new Exception("Займ заключен в валюте, которую мы не обрабатываем");
            //Console.Write("Введите дату возврата займа согласно договору:");
            //FinishDate = Console.ReadLine();
            //Console.WriteLine();
            Console.Write("В договоре явно указана безвозмездность? 1 - Да. 2 - Нет. ВАШ ОТВЕТ:");
            CompensationType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (CompensationType)
            {
                case 1:
                    Console.WriteLine("Договор является безвозмездным, % ставка = 0 ");
                    ZaymPercent = 0;
                    break;
                        
                case 2:
                    Console.Write("Процентная ставка явно указана в договоре? 1 - Да. 2 - Нет. Ваш ответ:");
                    PercentExist = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine() ;

                    switch (PercentExist)
                    {
                        case 1:
                            Console.Write("Введите процент прописанный в договоре:");
                            ZaymPercent = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            //var cultureInfo = new CultureInfo("en-US");
                            Console.Write("Введите текущую процентную ставку ЦБ РФ:");
                            CBPercent =Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine() ;
                            // Добавить проверку на Дату с Ростовщическими процентами!!!!
                            //if (ZaymPercent > 2 * CBPercent)
                            //{
                            //    try
                            //    {

                            //        var CurrentDate = DateTime.ParseExact(StartDate, "d", cultureInfo);
                            //        Console.WriteLine(CurrentDate);
                            //    }
                            //    catch(FormatException)
                            //    {
                            //        Console.WriteLine("Unable to parse '{0}'", StartDate);
                            //    }

                            //    break;
                            //    DateTime rostDate = new DateTime()
                            //}
                            break;

                        case 2:
                            if (ZaymSumm > 100000)
                            {
                                Console.Write("Введите текущую процентную ставку ЦБ РФ:");
                                CBPercent = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                ZaymPercent = CBPercent;
                            }
                            else
                                ZaymPercent = 0;
                            Console.Write("ПО ДОГОВОРУ ПРОЦЕНТ НАЧИСЛЯЕТСЯ КАЖДЫЙ? 1 - ЧАС. 2 - ДЕНЬ. 3 - МЕСЯЦ. 4 - ГОД. 5 - Не Указан. ВАШ ОТВЕТ:");
                            PercentType = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            //ПРОВЕРКА НА ТО, УКЗАН ЛИ СРОК ВОЗВРАТА В ДОГОВОРЕ
                            Console.Write("Дата возврата прописана в договоре? 1 - Да. 2 - Нет. ВАШ ОТВЕТ:");
                            int ExistFinishDate = Convert.ToInt32(Console.ReadLine()) ;
                            Console.WriteLine() ;
                            if (ExistFinishDate == 1)
                            {
                                Console.Write("Введите дату возврата займа согласно договору:");
                                FinishDate = Console.ReadLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.Write("Введите дату предъявления требования займодавца о возврате дененых средств:");
                                string DateTrebovania = Console.ReadLine();
                                Console.WriteLine();
                                //В переменную Finish Date присвоить значение по следующему правилу : (Что - то связанное с 30 днями после даты )
                            }
                            switch (PercentType)
                            { case 1:
                                    //Вычислить проценты начисляя ежечасно
                                    break;

                              case 2:
                                    //Вычислить проценты начисляя ежедневно
                                    break;

                              case 3:
                              case 5:
                                    //Вычислить проценты начисляя ежемесячно
                                    break;

                                case 4:
                                    //Вычислить проценты начилсяя ежегодно
                                    break;

                            



                            }
                            break;
                       
                                
                    }

                    break;
            }

            //ВЫПОЛНИТЬ ПРОВЕРКУ НА ТО, ВОВРЕМЯ ЛИ ВЫПЛАЧЕН ДОЛГ, ЕСЛИ ДА ТО ВЫХОД, ЕСЛИ НЕТ ТО ПРОДОЛЖАЕМ
            Console.Write("В договоре указана сумма неустойки в случае просрочки выплаты долга? 1 - Да. 2 - Нет. Ваш ответ:");
            int NeustExist = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine() ;
            switch (NeustExist)
            {
                case 2:
                    float currenNeust;
                    Console.WriteLine("Неустойка начисляется согласно 309 статье ГК РФ и составляет: ТУТ БУДЕТ СУММА НЕУСТОЙКИ");
                    break;
                case 1:
                    Console.Write("ТИП НЕУСТОЙКИ СОГЛАСНО ДОГОВОРУ? 1 - ШТРАФ. 2 - ПЕННИ. ВАШ ОТВЕТ:");
                    PenaltyType = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (PenaltyType) 
                    { 
                        case 1:
                            Console.Write("ВВЕДИТЕ СУММУ ШТРАФА ЗА ПРОСРОЧЕНЫЙ СРОК ВОЗВРАТА ДОГОВОРА:");
                            ShtrafSize = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.Write("ВВЕДИТЕ ПРОЦЕНТ ПЕННИ НАЧИСЛЯЕМЫ ЗА ПРОСРОК ВОЗВРАТА ДОГОВОРА:");
                            PennyPercent = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("ВВЕДИТЕ ПРОЦЕНТ ПЕННИ НАЧИСЛЯЕМЫ ЗА ПРОСРОК ВОЗВРАТА ДОГОВОРА:");
                            PennyPercent = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("ПОРЯДОК НАЧИСЛЕНИЯ ПЕННИ ПРОИСХОДИТ КАЖДЫЙ? 1 - ЧАС. 2 - ДЕНЬ. 3- МЕСЯЦ. 4 - ГОД. 5 - НЕ УКАЗАН. ВАШ ОТВЕТ:");
                            PennyType = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            switch (PennyType)
                            {

                                case 1:
                                    //Вычислить проценты начисляя ежечасно
                                    break;

                                case 2:
                                    //Вычислить проценты начисляя ежедневно
                                    break;

                                case 3:
                                case 5:
                                    //Вычислить проценты начисляя ежемесячно
                                    break;

                                case 4:
                                    //Вычислить проценты начилсяя ежегодно
                                    break;


                            }
                            break;
                    }

                    break;
            }

            //Далее нужно добавить условия с выплатами по частям, но это только рекомендации для Заёмщика и на сумму не влияют!!!

        }
    }
}