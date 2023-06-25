using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        //Генерация рандомного числа для номера дела
        static public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        static DateTime inputDate()
        {
            DateTime date; // inputDate value
            string input;

            do
            {
                Console.WriteLine("Введите дату в формате дд.ММ.гггг (день.месяц.год):");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));

            return date;
        }

        static void Main(string[] args)
        {
            //Переменные (Полуконстанты для заполнения информации о судбном заседании)
            int DeloNumber = GenerateRandomNo();
            DateTime currentDate = DateTime.Today;
            //Console.WriteLine("           Решенее по гражданскому делу          ");
            //Console.WriteLine("Дело № 2-" + DeloNumber +"/2023");
            //Console.WriteLine("УИД:" + Guid.NewGuid().ToString());
            //Console.WriteLine("           Именем Российской Федерации          ");
            //Console.WriteLine("Дата:" + currentDate.ToShortDateString() + "              город Пермь");
            //Console.WriteLine("Ленинский районный суд г. Перми в составе: ");
            //Console.WriteLine("председательствующего судьи Шпигарь Ю.Н., ");
            //Console.WriteLine("при секретаре судебного заседания Томиловой Е.Д., ");
            //Console.WriteLine("рассмотрев в открытом судебном заседании гражданское дело по иску ");
            //Переменные для заполнения информации о деле по договору займа\\
           
            //Console.WriteLine("Сегодняшняя дата:" +  currentDate.ToShortDateString());

            //Переменные для договора займа\\
            string ContractName, ContractLocation, LenderName, LenderPass, BorrowerName, BorrowerPass ;
            int ContractForm, Currency, CompensationType, PercentExist, PercentType, Soglashenie,  RepaymentType, PaymentProcedure, PenaltyType, PennyType;
            double ZaymSumm = 0, ZaymPercent=0, CBPercent = 0 , ShtrafSize = 0, PennyPercent = 0 , PennySum = 0 ,  ItogSumm = 0 ;
            double PercentCount = 0; 
            DateTime StartDate, FinishDate, DateTrebovania;
            //Дата, до которого % в два раза превышающий ставку ЦБ не признавался ростовщическим!!!
            DateTime RostDate = new DateTime(2018, 6, 1);

            //------------------------------------------------------//
            //Console.WriteLine("Введите данные о договоре займа");
            //Console.Write("Введите номер договора займа: ");
            //ContractName = Console.ReadLine();
            //Console.Write("Введите место заключения договора: ");
            //ContractLocation = Console.ReadLine();
            //Console.Write("Введите ФИО Заимодавца: ");
            //LenderName = Console.ReadLine();
            //Console.Write("Введите Пасспортные данные Заимодавца: ");
            //LenderPass = Console.ReadLine();
            //Console.Write("Введите ФИО Заёмщика: ");
            //BorrowerName = Console.ReadLine();
            //Console.Write("Введите Пасспортные данные Заёмщика: ");
            //BorrowerPass = Console.ReadLine();
            Console.WriteLine("Введите дату заключения договора: ");
            StartDate = inputDate();
            Console.Write("Договор заключен в письменном виде? 1 - Да. 2 - Нет. Ваш ответ: ");
            ContractForm = Convert.ToInt32(Console.ReadLine());
            //Первая точка выхода из программы, в случае, если договора нет в письменном виде
            if (ContractForm == 2)
                throw new Exception("Договор в неправильной форме, дальнейшая консультация невозможна");

            Console.Write("Введите сумму займа: ");
            ZaymSumm = Convert.ToInt32(Console.ReadLine());
            Console.Write("В какой валюте заключён займ? 1 - Рубли. 2 - Другая валюта. Ваш ответ: ");
            Currency = Convert.ToInt32(Console.ReadLine());
            //Выход в случае, если займ в другой валюте
            if (Currency == 2)
                throw new Exception("Займ заключен в валюте, которую мы не обрабатываем");
            Console.Write("В договоре явно указана безвозмездность? 1 - Да. 2 - Нет. ВАШ ОТВЕТ: ");
            CompensationType = Convert.ToInt32(Console.ReadLine());
            switch (CompensationType)
            {
                case 1:
                    {
                        Console.WriteLine("Договор является безвозмездным, % ставка = 0 ");
                        ZaymPercent = 0;
                        break;
                    }


                case 2:
                    {   //Проверка на то, указана ли явно процентная ставка
                        Console.Write("Процентная ставка явно указана в договоре? 1 - Да. 2 - Нет. Ваш ответ: ");
                        PercentExist = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        switch (PercentExist)
                        {
                            case 1:
                                {
                                    Console.Write("Введите процент прописанный в договоре: ");
                                    ZaymPercent = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine();
                                    //В конечной реализации предполагается доставать ставку ЦБ рф из БД
                                    Console.Write("Введите текущую процентную ставку ЦБ РФ:");
                                    CBPercent = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine();
                                    //Добавить проверку на Дату с Ростовщическими процентами!!!!
                                    if (ZaymPercent >= 2 * CBPercent && StartDate > RostDate)
                                    {
                                        throw new Exception("Данный процент в 2 раза больше чем ключевая ставка ЦБ\n" +
                                            "Значит данный процент признаётся ростовщическим!!!");
                                    }
                                    break;
                                }


                            case 2:
                                {
                                    if (ZaymSumm > 100000)
                                    {
                                        Console.Write("Введите текущую процентную ставку ЦБ РФ: ");
                                        CBPercent = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine();
                                        ZaymPercent = CBPercent;
                                        Console.Write("Так как сумма займа превышает 100000 руб, процентная ставка = ставке ЦБ");
                                    }
                                    else
                                        ZaymPercent = 0;
                                    break;

                                }
                        }
                        
                        break;

                    }
            }
            Console.WriteLine("Текущая проценная ставка = " + ZaymPercent);
             //ПРОВЕРКА НА ТО, УКЗАН ЛИ СРОК ВОЗВРАТА В ДОГОВОРЕ
             Console.Write("Дата возврата прописана в договоре? 1 - Да. 2 - Нет. ВАШ ОТВЕТ: ");                 
             int ExistFinishDate = Convert.ToInt32(Console.ReadLine());
            if (ExistFinishDate == 1)
            {   //Дата прописывается в договоре
                Console.WriteLine("Введите дату возврата займа согласно договору:");
                FinishDate = inputDate();
            }
            else
            {
                //Если дата возврата не прописана в договоре, то смотрим есть ли согласие о сокрещении сроков возврата
                Console.WriteLine("Иммется соглашение об уменьшении сроков возврата? 1- Да. 2 - Нет.  ВАШ ОТВЕТ: ");
                int KolvoDneyPoSoglasheniu = 30; //Значение по умолчанию = 30 дней
                Soglashenie = Convert.ToInt32(Console.ReadLine());
                if (Soglashenie == 1)
                {
                    Console.WriteLine("Введите количество дней, согласно принятому соглашению");
                    KolvoDneyPoSoglasheniu = Convert.ToInt32(Console.ReadLine());
                    
                }
                Console.WriteLine("Введите дату предъявления требования займодавца о возврате дененых средств: ");
                DateTrebovania = inputDate();
                FinishDate = DateTrebovania.AddDays(KolvoDneyPoSoglasheniu);//Дата возврата (30 или другое число дней + дата требования о возврате)
                //В этом варианте реализации не учитываем выходные и праздничные дни, остаим это на усмотрение судьям
            }

            //Определяем порядок начисления процентов по договору (Только если займ процентный)
            if (ZaymPercent != 0) {

                Console.Write("ПО ДОГОВОРУ ПРОЦЕНТ НАЧИСЛЯЕТСЯ КАЖДЫЙ? 1 - ДЕНЬ. 2 - МЕСЯЦ. 3 - ГОД. 4 - Не Указан. ВАШ ОТВЕТ: ");
                PercentType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (PercentType)
                {
                    case 1:
                        {
                            //Вычисляем процент, при условии начисления ЕЖЕДНЕВНО 
                            int Days = currentDate.Subtract(StartDate).Days + 1;
                            Console.WriteLine("Количество дней  = " + Days);
                            PercentCount = Days * ZaymPercent / 100 * ZaymSumm;
                            Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PercentCount);
                            break;
                        }


                    case 2:
                        {
                            //Вычисляем процент, при условии начисления ЕЖЕМЕСЯЧНО
                            int Months = currentDate.Month - StartDate.Month;
                            Console.WriteLine("Количество месяцев  = " + Months);
                            PercentCount = Months * ZaymPercent / 100 * ZaymSumm;
                            Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PercentCount);
                            break;
                        }


                    case 3:
                        {
                            //Вычисляем процент, при условии начисления ЕЖЕГОДНО
                            int Years = currentDate.Year - StartDate.Year;
                            Console.WriteLine("Количество лет  = " + Years);
                            PercentCount = Years * ZaymPercent / 100 * ZaymSumm;
                            Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PercentCount);
                            break;
                        }

                    case 4:
                        {
                            //В случае, если явно не прописан порядок начисления процентов, они начисляются ЕЖЕМЕСЯЧНО (Как в case 2 )
                            int Months = FinishDate.Month - StartDate.Month;
                            PercentCount = Months * ZaymPercent / 100 * ZaymSumm;
                            Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PercentCount);
                            break;
                        }

                }


            }



            //ПРОВЕРКА НА ТО, УКАЗАНА ЛИ НЕУСТОЙКА В ДОГОВОРЕ ИЛИ НЕТ 
            Console.Write("В договоре указана неустойка, в случае просрочки выплаты долга? 1 - Да. 2 - Нет. Ваш ответ: ");
            int NeustExist = Convert.ToInt32(Console.ReadLine());
            switch (NeustExist)
            {
          

                case 1:
                    {
                        //Случай, когда у нас по договору прописана некотарая неустойка (Два вида 1 - Штраф 2 - Пенни )
                        Console.Write("КАКОЙ ТИП НЕУСТОЙКИ ПРОПИСАН В ДОГОВОРЕ? 1 - ШТАФ, 2 - ПЕННИ(ПРОЦЕНТ), 3 - ОБА ВАРИАНТА ВАШ ОТВЕТ: ");
                        PenaltyType = Convert.ToInt32(Console.ReadLine());
                        switch (PenaltyType)
                        {

                            case 1 :
                                {
                                    //Неустойка представлена единоразовой выплатой - штрафом
                                    Console.Write("Введите сумму штрафа за просрочку выплаты займа: ");
                                    ShtrafSize = Convert.ToDouble(Console.ReadLine());
                                    break;
                                }

                            case 2:
                                {
                                    //Неустока представлена Пенни - процентом с определенным порядком начисления
                                    Console.Write("ВВЕДИТЕ ПРОЦЕНТ НЕУСТОКИ СОГЛАСНО ДОГОВОРУ: ");
                                    PennyPercent = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("ПОРЯДОК НАЧИСЛЕНИЯ ПЕННИ ПРОИСХОДИТ КАЖДЫЙ? 1 -  ДЕНЬ. 2 - МЕСЯЦ. 3 - ГОД. ВАШ ОТВЕТ: ");
                                    PennyType = Convert.ToInt32(Console.ReadLine());
                                    //Подсчёт начисления пенни процента 
                                    switch (PennyType)
                                    {

                                        case 1:
                                            {
                                                //Процент ПЕННИ начилсяется ЕЖЕДНЕВНО начиная с  определенная дата возврата по Текущую дату 
                                                int Days = currentDate.Subtract(FinishDate).Days + 1;
                                                Console.WriteLine("Количество дней  = " + Days);
                                                PennySum = Days * PennyPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                        case 2:
                                            {
                                                //Процент ПЕННИ начисляется ЕЖЕМЕСЯЧНО начиная с  определенная дата возврата по Текущую дату 
                                                int Months = currentDate.Month - FinishDate.Month;
                                                Console.WriteLine("Количество месяцев  = " + Months);
                                                PennySum = Months * ZaymPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                        case 3:
                                            {
                                                //Процент ПЕННИ начисляется ЕЖЕГОДНО начиная с  определенная дата возврата по Текущую дату 
                                                int Years = currentDate.Year - FinishDate.Year;
                                                Console.WriteLine("Количество лет  = " + Years);
                                                PennySum = Years * ZaymPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                    }

                                    break;
                                }

                            case 3: 
                                {

                                    //Неустойка представлена единоразовой выплатой - штрафом
                                    Console.Write("Введите сумму штрафа за просрочку выплаты займа: ");
                                    ShtrafSize = Convert.ToDouble(Console.ReadLine());
                                    //Неустока представлена Пенни - процентом с определенным порядком начисления
                                    Console.Write("ВВЕДИТЕ ПРОЦЕНТ НЕУСТОКИ СОГЛАСНО ДОГОВОРУ: ");
                                    PennyPercent = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("ПОРЯДОК НАЧИСЛЕНИЯ ПЕННИ ПРОИСХОДИТ КАЖДЫЙ? 1 -  ДЕНЬ. 2 - МЕСЯЦ. 3 - ГОД. ВАШ ОТВЕТ: ");
                                    PennyType = Convert.ToInt32(Console.ReadLine());
                                    //Подсчёт начисления пенни процента 
                                    switch (PennyType)
                                    {

                                        case 1:
                                            {
                                                //Процент ПЕННИ начилсяется ЕЖЕДНЕВНО начиная с  определенная дата возврата по Текущую дату 
                                                int Days = currentDate.Subtract(FinishDate).Days + 1;
                                                Console.WriteLine("Количество дней  = " + Days);
                                                PennySum = Days * PennyPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                        case 2:
                                            {
                                                //Процент ПЕННИ начисляется ЕЖЕМЕСЯЧНО начиная с  определенная дата возврата по Текущую дату 
                                                int Months = currentDate.Month - FinishDate.Month;
                                                Console.WriteLine("Количество месяцев  = " + Months);
                                                PennySum = Months * ZaymPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                        case 3:
                                            {
                                                //Процент ПЕННИ начисляется ЕЖЕГОДНО начиная с  определенная дата возврата по Текущую дату 
                                                int Years = currentDate.Year - FinishDate.Year;
                                                Console.WriteLine("Количество лет  = " + Years);
                                                PennySum = Years * ZaymPercent / 100 * ZaymSumm;
                                                Console.WriteLine("Сумма процентов, которые были начислены поверх основной суммы долга = " + PennySum);
                                                break;
                                            }

                                    }
                                    break;
                                }

                        }
                        break;
                    }   
                      

                    case 2:
                    {
                        //Если неустойка не прописана в договоре, то она начисляется по 395 процентам:
                        Console.Write("Введите ставку ЦБ, на момент даты возврата по договору " + FinishDate.ToShortDateString() + " : ");
                        double newCBPercent = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ставка = " + newCBPercent);
                        int PennyDays = currentDate.Subtract(FinishDate).Days + 1;
                        Console.WriteLine("Количество дней = " + PennyDays);
                        PennySum = PennyDays * newCBPercent / (100 * 365) * ZaymSumm;
                        Console.WriteLine("Неустойка начисляется согласно 309 статье ГК РФ и составляет: " + PennySum);
                        break;
                    }
                        
            }

           
            //Получение итоговой суммы, которую должен выплатить заемщик заимодавцу
            ItogSumm = ZaymSumm + PercentCount + ShtrafSize+ PennySum;
            Console.WriteLine("Итоговая суммма к выплате = " + ItogSumm);
            Console.ReadLine();
            //Console.WriteLine("           Решенее по гражданскому делу          ");
            //Console.WriteLine("Дело № 2-" + DeloNumber +"/2023");
            //Console.WriteLine("УИД:" + Guid.NewGuid().ToString());
            //Console.WriteLine("           Именем Российской Федерации          ");
            //Console.WriteLine("Дата:" + currentDate.ToShortDateString() + "              город Пермь");
            //Console.WriteLine("Ленинский районный суд г. Перми в составе: ");
            //Console.WriteLine("председательствующего судьи Шпигарь Ю.Н., ");
            //Console.WriteLine("при секретаре судебного заседания Томиловой Е.Д., ");
            //Console.WriteLine("рассмотрев в открытом судебном заседании гражданское дело по иску ");
            //Переменные для заполнения информации о деле по договору займа\\

            //Console.WriteLine("Сегодняшняя дата:" +  currentDate.ToShortDateString());


        }
    }
}
