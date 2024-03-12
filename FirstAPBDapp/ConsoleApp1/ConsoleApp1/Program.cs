using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            if (int.TryParse(Console.ReadLine(), out int userInput)) {
                if(userInput>0)
                {
                    Console.WriteLine("The value is a positive one");
                }else if (userInput < 0)
                {
                    Console.WriteLine("The value is a negative one");
                }
                else
                {
                    Console.WriteLine("The value is equal to 0");
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
        static double CalculateAverage(int[] arr)
        {
            int sum = 0;
            foreach (var num in arr)
            {
                sum += num;
            }
            return (double)sum / arr.Length;
        }

        static int MaxValue(int[] arr)
        {
            int max = arr[0];

            //place for implementation

            return max;
        }
    }
}
