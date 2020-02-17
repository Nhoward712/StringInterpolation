using System;

namespace YourName
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //// display a literal value
            //Console.WriteLine("What is your name?");
            //// input a value and assign it to a string variable
            //string name = Console.ReadLine();
            //// display the string variable
            //Console.WriteLine("Hello, " + name);
            //Console.WriteLine("Hello, {0}", name);

            try
            {
                Console.WriteLine("enter a number:  ");
                var one = Console.ReadLine();
                Console.WriteLine("enter number 2:  ");
                var two = Console.ReadLine();
                var result = 0;
                var isValidx = int.TryParse(one, out int x);
                var isvalidy = int.TryParse(two, out int y);

                if (isValidx && isvalidy) 
                {
                    result = x + y;

                }

                Console.Write($"your number is {result}");

            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("cannot divide by zero");
               
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {

            }















        }
    }
}
