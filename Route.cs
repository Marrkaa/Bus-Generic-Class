using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace L5_2.Autobusai
{
    /// <summary>
    /// Route class
    /// </summary>
    internal class Route
    {
        /// <summary>
        /// Number of route
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// Routes day of the week
        /// </summary>
        public DayOfWeek dayOfWeek { get; set; }

        /// <summary>
        /// Routes departure
        /// </summary>
        public TimeSpan timeOfDeparture { get; set; }

        /// <summary>
        /// Routes ticket cost
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Route() 
        {
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="numb">route number</param>
        /// <param name="day">route day of the week</param>
        /// <param name="departure">route departure time</param>
        /// <param name="cost">route ticket cost</param>
        public Route(int numb, DayOfWeek day, 
            TimeSpan departure, double cost) 
        {
            this.number = numb;
            this.dayOfWeek = day;
            this.timeOfDeparture = departure;
            this.price = cost;
        }

        /// <summary>
        /// A method to set data of a route
        /// </summary>
        /// <param name="numb">route number</param>
        /// <param name="day">route day of the week</param>
        /// <param name="departure">route departure time</param>
        /// <param name="cost">route ticket cost</param>
        public void Set(int numb, DayOfWeek day, 
            TimeSpan departure, double cost) 
        {
            number = numb;
            dayOfWeek = day;
            timeOfDeparture = departure;
            price = cost;
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>concatenated string (all class properties)</returns>
        public override string ToString() 
        {
            string line;
            line = string.Format("|{0, 10}        | {1, -15}  " +
                "| {2, 8}     | {3, 8:f3}      |",
            number, dayOfWeek, timeOfDeparture, price);
            return line;
        }
    }
}
