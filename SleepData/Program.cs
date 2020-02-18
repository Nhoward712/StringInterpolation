using System;
using System.IO;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            string file = "data.txt";
            //string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1") 
            {
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")//parse data file
            {
                string readFile = "data.txt";
                StreamReader sleep = new StreamReader(readFile);
                while (!sleep.EndOfStream)
                {
                    string line = sleep.ReadLine();
                    string[] arg = line.Split(',');
                    string[] date = arg[0].Split('/');
                    string[] hours = arg[1].Split('|');
                    int m = int.Parse(date[0]);
                    int d = int.Parse(date[1]);
                    int y = int.Parse(date[2]);
                    Console.WriteLine("{0}/{1}/{2}",m,d,y);
                    
                    string s = "su";
                    string mo = "mo";
                    string t = "tu";
                    string w = "we";
                    string th = "th";
                    string f = "fr";
                    string sa = "sa";

                    //DateTime thisDate1 = new DateTime(long.Parse(arg[0]));
                    //Console.WriteLine("Today is " + thisDate1.ToString("mm dd, yyyy") + ".");


                    Console.WriteLine("{0,-3}{1,-3}{2,-3}{3,-3}{4,-3}{5,-3}{6,-3}",s,mo,t,w,th,f,sa);
                    //Console.WriteLine("Week of ",arg[0].ToString("D", culture);
                    Console.WriteLine("{0,-3}{1,-3}{2,-3}{3,-3}{4,-3}{5,-3}{6,-3}\n",hours[0],hours[1],hours[2], hours[3], hours[4], hours[5], hours[6]);
                }
                Console.WriteLine("press enter to end program");
                string pause = Console.ReadLine();
                sleep.Close();

                

            }
        }
    }
}
