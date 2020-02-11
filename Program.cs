using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ask user for Month
            Console.WriteLine("Please enter a month: ");
            //Get user input and convert to int
            int month = Convert.ToInt32(Console.ReadLine());

            //Ask user for Day
            Console.WriteLine("Please enter a day");
            //Get user input and convert to int
            int day = Convert.ToInt32(Console.ReadLine());

            //Ask user for Year
            Console.WriteLine("Please enter a year");
            //Get user input and convert to int
            int year = Convert.ToInt32(Console.ReadLine());

            //Ask user how many days to add
            Console.WriteLine("How many days do you want to add?");
            //Convert days to add to int
            int addDays = Convert.ToInt32(Console.ReadLine());

            //
            Console.WriteLine(dateCalc(month, day, year, addDays));

            //***A BETTER WAY TO CALCULATE DATE***//
            /*
            //Concatenate user input into a string that can be parsed by DateTime
            string date = ($"{month}-{day}-{year}");
            
            //Convert the concatenated string to DateTime format
            var dateConvert = DateTime.Parse(date);

            //Calculate the new date by adding day input to the DateTime value
            DateTime newDate = dateConvert.AddDays(addDays);

            //Print the new datetime format as specified
            Console.WriteLine("New date is: {0:MM-dd-yyyy}",newDate);

            //Wait for input before exiting
            Console.ReadLine();
            */


            Console.Write("Press any key to exit...");
            Console.Read();
        }


        /// <summary>
        /// Returns an updated date based on the given arguments
        /// </summary>
        /// <param name="m">Takes user input variable for month</param>
        /// <param name="d">Takes user input variable for day</param>
        /// <param name="y">Takes user input variable for year</param>
        /// <param name="dayAdd">Takes user input variable for number of days to add</param>
        /// <returns></returns>
        static string dateCalc (int m, int d, int y, int dayAdd)
        {
            //Array representing the different months
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //Array representing the total number of days a month can have
            int[] days = { 31, 28, 29, 30 };

            //Calculate the total number of days based off the day input and days to add input
            int totalDays = sumDays(d, dayAdd);
            int daysinMonth = findMonthDays(months,days,m,y);
            int tempMonth;

            //If the summ of the total days is more than there are days in the month
            //increment the month and subtract from the sum of total days
            while (totalDays > daysinMonth)
            {
                //Calculate the Year
                y = findYear(m, totalDays, y);
                //Calculate how many days over the current month
                totalDays -= daysinMonth;
                //add a month
                m += 1;
                if (m == 13)
                {
                    m = 1;
                }
                //find the new month
                tempMonth = findMonth(m, months);
                //find how many days in the new month
                daysinMonth = findMonthDays(months, days, tempMonth, y);
                //If total days become negative, turn it positive
                if (totalDays < 0)
                {
                    totalDays = totalDays*(-1);
                }

            }

            d = totalDays;

            string dateOutput = ($"{Convert.ToString(m)}-{Convert.ToString(d)}-{Convert.ToString(y)}");
            return dateOutput;
        } 
        
        /// <summary>
        /// Calculates the total days
        /// </summary>
        /// <param name="daysInput">Initial day value from user</param>
        /// <param name="daysToAdd">How many days to add to initial value</param>
        /// <returns></returns>
        public static int sumDays(int daysInput, int daysToAdd)
        {
            int totalDays = daysInput + daysToAdd;
            return totalDays;
        }

        /// <summary>
        /// Finds the number of days in a month
        /// </summary>
        /// <param name="months">Uses a month array</param>
        /// <param name="days">Uses a day array</param>
        /// <param name="m">Takes the month from user input</param>
        /// <param name="y">Takes the year from user input</param>
        /// <returns></returns>
        public static int findMonthDays(int[] months, int[] days, int m, int y)
        {
            int daysinMonth = 0;
            if (y % 4 == 0)
            {
                if (m == months[0] || m == months[2] || m == months[4] || m == months[6] ||
                    m == months[7] || m == months[9] || m == months[11])
                {
                    daysinMonth = days[0];
                }
                else if (m == months[3] || m == months[5] || m == months[8] || m == months[10])
                {
                    daysinMonth = days[3];
                }
                else if (m == months[1])
                {
                    daysinMonth = days[2];
                }
            }
            else
            {
                if (m == months[0] || m == months[2] || m == months[4] || m == months[6] ||
                m == months[7] || m == months[9] || m == months[11])
                {
                    daysinMonth = days[0];
                }
                else if (m == months[3] || m == months[5] || m == months[8] || m == months[10])
                {
                    daysinMonth = days[3];
                }
                else if (m == months[1])
                {
                    daysinMonth = days[1];
                }
            }
            return daysinMonth;
        }
        
        /// <summary>
        /// Finds the month in the month array based off the user's month input
        /// </summary>
        /// <param name="m">User's month input</param>
        /// <param name="months">Month Array</param>
        /// <returns></returns>
        public static int findMonth(int m, int[] months)
        {
            int i=0;
            switch (m)
            {
                case 1:
                    i = months[0];
                    break;
                case 2:
                    i = months[1];
                    break;
                case 3:
                    i = months[2];
                    break;
                case 4:
                    i = months[3];
                    break;
                case 5:
                    i = months[4];
                    break;
                case 6:
                    i = months[5];
                    break;
                case 7:
                    i = months[6];
                    break;
                case 8:
                    i = months[7];
                    break;
                case 9:
                    i = months[8];
                    break;
                case 10:
                    i = months[9];
                    break;
                case 11:
                    i = months[10];
                    break;
                case 12:
                    i = months[11];
                    break;
            }
            return i;

        }
        /// <summary>
        /// Updates the year if necessary
        /// </summary>
        /// <param name="m">User month input</param>
        /// <param name="totalDays">Sum of current day plus days to add</param>
        /// <param name="y">Year</param>
        /// <returns></returns>
        public static int findYear(int m, int totalDays, int y)
        {
            if ((m==12) && (totalDays > 31))
            {
                y += 1;
            }
            return y;
        }
    }
}
