using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите распределяемую сумму: ");
            double InputSumm = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите суммы массива через точку запятую(;): ");
            double[] numbers = Console.ReadLine().Split(';').Select(double.Parse).ToArray();

            List<double> listNumbers = new List<double>(); // коллекция для хранения результата
            double TotalSummList = 0; // общая сумма элементов в коллекции
            double remains = 0; // остаток

            Console.Write("Введите тип распределения (проп, перв, посл): ");
            string TypeRaspred = Console.ReadLine().ToUpper();

            switch (TypeRaspred)
            {
                case "ПРОП":

                    double total = 0; // общая сумма в массиве чисел
                    for (int i = 0; i < numbers.Length; i++)
                        total += numbers[i];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        TotalSummList = listNumbers.Sum();
                        remains = InputSumm - TotalSummList;
                        double coefficient = InputSumm / total; // коэффициент для умножения элементов массива
                        double summRaspred = Math.Round(coefficient * numbers[i], 2);

                        if (remains > summRaspred) // если остаток больше, чем сумма
                        {
                            listNumbers.Add(summRaspred);
                        }

                        if ((remains < summRaspred) || (i == numbers.Length - 1))
                        {
                            listNumbers[listNumbers.Count - 1] = listNumbers[listNumbers.Count - 1];
                        }
                    }

                    Console.WriteLine($"Вывод: {String.Join(";", listNumbers)}");
                    break;

                case "ПЕРВ":
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        TotalSummList = listNumbers.Sum();
                        remains = InputSumm - TotalSummList;

                        if (remains >= numbers[i])
                        {
                            listNumbers.Add(Math.Round(numbers[i], 2));
                        }
                        else listNumbers.Add(Math.Round(remains, 2));
                    }

                    Console.WriteLine($"Вывод: {String.Join(";", listNumbers)}");
                    break;

                case "ПОСЛ":
                    Array.Reverse(numbers);

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        TotalSummList = listNumbers.Sum();
                        remains = InputSumm - TotalSummList;

                        if (remains >= numbers[i])
                        {
                            listNumbers.Add(Math.Round(numbers[i], 2));
                        }
                        else listNumbers.Add(Math.Round(remains, 2));
                    }

                    listNumbers.Reverse();
                    Console.WriteLine($"Вывод: {String.Join(";", listNumbers)}");
                    break;
            }
                
        }
    }
}
