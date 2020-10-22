using System;
using System.Globalization;
using static System.Console; // Simplifying the task of writing the Console.

namespace Finance_accounting_program
{
    class Program
    {
        static void Main(string[] args)
        {          
            Random numb = new Random(); // Create a random class that will give a random number of "Income" and "Costs"

            // Create a variable for the number of months, an array of financial records and an array of bad months
            WriteLine("Write the number of months");
            int Mounth = int.Parse(Console.ReadLine()); // Record number of months in variable
            int[,] FinancialAccounting = new int[Mounth, 4]; // Create a two-dimensional array with month rows and financial accounting columns
            int[] WorstMounth = new int[Mounth]; // Creating a one-dimensional array that will record data from the "Profit" column

            int PositiveMounth = 0; // A variable that will contain the number of months with a positive profit


            // Начало таблицы
            WriteLine("\nGetting Started Filling the Table:");
            WriteLine("Mounth\t\tIncome$\t\tCosts$\t\tProfit$");
            for (int j = 0; j < FinancialAccounting.GetLength(0); j++) // Loop iteration of lines, that is, our months
            {
                // Метод записи номера месяца
                FinancialAccounting[j, 0] = j + 1;
                Console.Write(FinancialAccounting[j, 0]);

                for (int k = 1; k < FinancialAccounting.GetLength(1); k++) // Loop through the columns, that is, our financial data
                {

                    if (k == FinancialAccounting.GetLength(1) - 1) // Check operator for the "Profits" column
                    {
                        // The method of implementing the deduction of "Costs" from "Income" to obtain the number of "Profits"
                        FinancialAccounting[j, k] = FinancialAccounting[j, k - 2] - FinancialAccounting[j, k - 1];
                        WorstMounth[j] += FinancialAccounting[j, k]; // Adding the "Profit" column to the array, which will be checked for the worst months in the future
                        Write($"\t\t{FinancialAccounting[j, k]}$"); // Record implementation for the "Profit" line

                    }
                    else
                    {
                        // Record implementation method for the Income and Expense columns
                        FinancialAccounting[j, k] = numb.Next(70_000, 150_000); // Writing a random number using the Random class in the range 70_000 - 150_000
                        Write($"\t\t{FinancialAccounting[j, k]}$"); // Implementing a record for the "Income" and "Costs" columns
                    }

                }
                WriteLine();
            }

            Array.Sort(WorstMounth); // Sorting the array with the recorded data from the "Profit" column to find the first 3 months with the worst profit

            Write("\nWorst months: ");
            for (int i = 0; i < FinancialAccounting.GetLength(0); i++) // Loop iteration of our months
            {
                if (FinancialAccounting[i, 3] == WorstMounth[0] || FinancialAccounting[i, 3] == WorstMounth[1] || FinancialAccounting[i, 3] == WorstMounth[2]) // Array check operator with month number and profit column
                {                                                                                                             // with 3 months with the worst profit, recorded in a sorted array of the same name
                    Write($"{FinancialAccounting[i,0]} ");
                }

                if (FinancialAccounting[i, 3] > 0) // Operator of checking months with positive profit
                {
                    PositiveMounth++; // Adding the number of months with a positive profit
                }
            }

            // A string with the number of months with positive profit and the end of the code.
            WriteLine($"\nNumber of months with a positive profit: {PositiveMounth}");
            ReadKey();
        }
    }
}
