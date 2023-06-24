using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_2.Autobusai
{
    /// <summary>
    /// Traveler class
    /// </summary>
    internal class Traveler
    {
        /// <summary>
        /// Traveler last name
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Traveler name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Traveler routes day of the week
        /// </summary>
        public DayOfWeek dayOfWeek { get; set; }

        /// <summary>
        /// Traveler routes time of departure
        /// </summary>
        public TimeSpan timeOfDeparture { get; set; }

        /// <summary>
        /// Traveler routes number
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Traveler()
        {
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="surname">last name</param>
        /// <param name="firstName">name</param>
        /// <param name="day">day of the week</param>
        /// <param name="departure">time of departure</param>
        /// <param name="numb">route number</param>
        public Traveler(string surname, string firstName, 
            DayOfWeek day, TimeSpan departure, int numb)
        {
            this.lastName = surname;
            this.name = firstName;
            this.dayOfWeek = day;
            this.timeOfDeparture = departure;
            this.number = numb;
        }

        /// <summary>
        /// A method to set data of a traveler
        /// </summary>
        /// <param name="surname">last name</param>
        /// <param name="firstName">first name</param>
        /// <param name="day">day of departure</param>
        /// <param name="departure">time of departure</param>
        /// <param name="numb">route number</param>
        public void Set(string surname, string firstName, 
            DayOfWeek day, TimeSpan departure, int numb)
        {
            lastName = surname;
            name = firstName;
            dayOfWeek = day;
            timeOfDeparture = departure;
            number = numb;
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>concatenated string (all class properties)</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("|    {0, -10} | {1, -12}  " +
                "|    {2, -12}   |{3, 11}   | {4, 8}     |",
            lastName, name, dayOfWeek, timeOfDeparture, number);
            return line;
        }
    }
}
