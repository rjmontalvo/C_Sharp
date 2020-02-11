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
            //Convert month to int
            string month = Console.ReadLine();

            //Ask user for Day
            Console.WriteLine("Please enter a day");
            //Convert days to int
            string day = Console.ReadLine();

            //Ask user for Year
            Console.WriteLine("Please enter a year");
            //Convert year to int
            string year = Console.ReadLine();

            //Ask user how many days to add
            Console.WriteLine("How many days do you want to add?");

            //Convert days to add to int
            int addDays = Convert.ToInt32(Console.ReadLine());

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

        }


        /*
        static int dateCalc (int m, int d, int y, int dayAdd)
        {
            int totalDays = d + dayAdd;
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] days = { 31, 28, 29, 30 };

            if (y % 4 == 0)
            {
                
            }
            else
            {

            }
            //If the month entered is one of the months that has 31 days
            //and the total number of days to add are greater than 31
            if ((m == months[0] || m == months[2] || m == months[4] || m == months[6] ||
                m == months[7] || m == months[9] || m == months[11]) && (totalDays > days[0]))
            {
                int diffDays = totalDays - days[0];

                if (diffDays < months[])
                while (totalDays > days[0])
                {
                    totalDays -= 31;
                    m += 1;
                } 

            }
            

        } 
        
        public static int sumDays2(int daysInput, int daysToAdd)
        {
            
        }
        
        
        public static int sumDays(int daysInput, int daysToAdd)
        {
            int totalDays = daysInput + daysToAdd;
            return totalDays;
        }
        */
    }
}
