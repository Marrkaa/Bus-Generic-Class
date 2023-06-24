// Dmitrovskis Martynas IFIN-2/2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*--------------------------------------------------------------------------------------------
    L5_2. Autobusai. Turime duomenis apie autobusų maršrutus. Keleiviai perka bilietus. 
Suformuokite maršrutų, kuriais važiuos bent vienas keleivis, sąrašą. Raskite pelningiausią 
maršrutą.

Duomenys:
    Tekstiniame faile U2a.txt yra duomenys apie autobusų maršrutus: maršruto numeris, savaitės
diena, išvykimo laikas, bilieto kaina.
    Tekstiniame faile U2b.txt yra duomenys apie keleivių nupirktus bilietus: pavardė, vardas,
savaitės diena, išvykimo laikas, maršruto numeris.

Reikalavimai programai:
     Dvi skirtingos duomenų klasės (jeigu reikalinga gali būti ir daugiau klasių), bendrinė 
mazgo klasė ir bendrinė susieto sąrašo klasė.
    Pradiniai duomenys duoti dviejuose skirtingos struktūros duomenų tekstiniuose failuose.
    Visa programa įvykdoma keliais meniu punktų paspaudimais.
--------------------------------------------------------------------------------------------*/

namespace L5_2.Autobusai
{
    public partial class Form1 : Form
    {
        string[] CFd;
        string CFr;

        List<Route> route;
        List<Traveler> traveler;
        List<Route> newList = new List<Route>();
        List<Route> mostProfitable = new List<Route>();

        public Form1()
        {
            InitializeComponent();
            setDataToolStripMenuItem.Enabled = true;
            printToolStripMenuItem.Enabled = false;
            formattingToolStripMenuItem.Enabled = false;
            findingMaxToolStripMenuItem.Enabled = false;
            endToolStripMenuItem.Enabled = true;
            informationToolStripMenuItem.Enabled = true;
        }

        //=========================================================================
        // GRAPHIC USER INTERFACE METHODS
        //=========================================================================

        /// <summary>
        /// Actions of the "Įvesti pradinius duomenis" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Pasirinkite duomenų failus";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                CFd = openFileDialog1.FileNames;
                route = ReadRoute(CFd[0]);
                traveler = ReadTraveler(CFd[1]);
            }

            setDataToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = true;

            notificationLabel.Text = "Pradiniai duomenys nuskaityti iš failų\n "
                + CFd[0] + "\n" + CFd[1];
        }

        /// <summary>
        /// Actions of the "Spausdinti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                CFr = saveFileDialog1.FileName;

                if (File.Exists(CFr))
                    File.Delete(CFr);

                PrintRoute(CFr, route, "Maršrutai:");
                PrintTraveler(CFr, traveler, "Keleiviai:");
            }

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            printToolStripMenuItem.Enabled = false;
            formattingToolStripMenuItem.Enabled = true;

            notificationLabel.Text = "Pradiniai duomenys faile\n" + CFr;
        }

        /// <summary>
        /// Actions of the "Baigti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Actions of the "Formavimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindAtleastOnce(route, traveler, newList);

            PrintRoute(CFr, newList, "Maršrutai, kuriais buvo važiuota nors kartą:");

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            formattingToolStripMenuItem.Enabled = false;
            findingMaxToolStripMenuItem.Enabled = true;
            notificationLabel.Text = "Sėkmingai suformavome naują sąrašą!";
        }

        /// <summary>
        /// Actions of the "Pelningiausio radimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findingMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter fr = new StreamWriter(File.Open(CFr,
                    FileMode.Append)))
            {
                fr.WriteLine("Pelningiausio maršruto pelnas: {0,2:f2}",SearchForEqual(newList, traveler, mostProfitable));
            }
            PrintRoute(CFr, mostProfitable, "Pelningiausių maršrutų sąrašas:");

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            findingMaxToolStripMenuItem.Enabled = false;
            notificationLabel.Text = "Sėkmingai suradome pelningiausią(-ius) maršrutą!";
        }

        /// <summary>
        /// Actions of the "Informacija" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programos versija: 17.5.3\n" +
                            "Programos sukūrimo data: 2023 gegužė\n" +
                            "Programos autorius: MD",
                            "Informacija apie programą");
        }

        //===================================================================
        // USER METHODS
        //===================================================================

        /// <summary>
        /// Reads routes data from a file to an array
        /// </summary>
        /// <param name="fn">file name</param>
        /// <returns>the reference list of routes data</returns>
        static List<Route> ReadRoute(string fn)
        {
            List<Route> route = new List<Route>();
            using (StreamReader reader = new StreamReader(fn))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    int number = int.Parse(parts[0]);
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), 
                        parts[1].Trim());
                    TimeSpan time = TimeSpan.Parse(parts[2]);
                    double price = double.Parse(parts[3]);
                    Route temp = new Route(number, day, time, price);
                    route.SetDataBackwards(temp);
                }
            }
            return route;
        }

        /// <summary>
        /// Reads travelers data from a file to an array
        /// </summary>
        /// <param name="fn">file name</param>
        /// <returns>the reference list of travelers data</returns>
        static List<Traveler> ReadTraveler(string fn)
        {
            List<Traveler> traveler = new List<Traveler>();
            using (StreamReader reader = new StreamReader(fn))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string surname = parts[0];
                    string name = parts[1];
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), 
                        parts[2].Trim());
                    TimeSpan time = TimeSpan.Parse(parts[3]);
                    int number = int.Parse(parts[4]);
                    Traveler temp = new Traveler(surname, name, day, time, number);
                    traveler.SetDataBackwards(temp);
                }
            }
            return traveler;
        }

        /// <summary>
        /// Prints routes data on file
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="route">list of routes data</param>
        /// <param name="comment">a comment</param>
        static void PrintRoute(string fn, List<Route> route, string comment)
        {
            route.Start();
            if (route.Exists() == true)
            {
                using (StreamWriter fr = new StreamWriter(File.Open(fn, 
                    FileMode.Append)))
                {
                    fr.WriteLine(comment);
                    fr.WriteLine("+------------------+------------------" +
                        "+--------------+---------------+");
                    fr.WriteLine("|   Maršruto nr.   |  Savaitės diena  " +
                        "| Išvyk. laik. | Bilieto kaina |");
                    fr.WriteLine("+------------------+------------------" +
                        "+--------------+---------------+");
                    for (route.Start(); route.Exists(); route.Next())
                    {
                        fr.WriteLine("{0}", route.GetData().ToString());
                    }
                    fr.WriteLine("+------------------+------------------" +
                        "+--------------+---------------+");
                    fr.WriteLine();
                }
            }
            else
            {
                using (StreamWriter fr = new StreamWriter(File.Open(fn, 
                    FileMode.Append)))
                {
                    fr.WriteLine("Nėra duomenų!");
                }
            }
        }

        /// <summary>
        /// Prints travelers data on file
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="traveler">list of travelers data</param>
        /// <param name="comment">a comment</param>
        static void PrintTraveler(string fn, List<Traveler> traveler, 
            string comment)
        {
            traveler.Start();
            if (traveler.Exists() == true)
            {
                using (StreamWriter fr = new StreamWriter(File.Open(fn, 
                    FileMode.Append)))
                {
                    fr.WriteLine(comment);
                    fr.WriteLine("+---------------+---------------+-------------------" +
                        "+--------------+--------------+");
                    fr.WriteLine("|    Vardas     |    Pavardė    |  Savaitės diena   " +
                        "| Išvyk. laik. | Marštuto nr. |");
                    fr.WriteLine("+---------------+---------------+-------------------" +
                        "+--------------+--------------+");
                    for (traveler.Start(); traveler.Exists(); traveler.Next())
                    {
                        fr.WriteLine("{0}", traveler.GetData().ToString());
                    }
                    fr.WriteLine("+---------------+---------------+-------------------" +
                        "+--------------+--------------+");
                    fr.WriteLine();
                }
            }
            else
            {
                using (StreamWriter fr = new StreamWriter(File.Open(fn, 
                    FileMode.Append)))
                {
                    fr.WriteLine("Nėra duomenų!");
                }
            }
        }

        /// <summary>
        /// A method which finds the number of times 
        /// travelers have went along a certain route
        /// </summary>
        /// <param name="travelers">list of travelers data</param>
        /// <param name="route">Route class object</param>
        /// <returns>count</returns>
        static int FindRouteCount(List<Traveler> travelers, Route route) 
        {
            int count = 0;
            foreach (Traveler traveler in travelers) 
            {
                if (traveler.number == route.number) 
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Finds and inputs routes which have 
        /// one or more successful journeys
        /// </summary>
        /// <param name="routes">list of routes data</param>
        /// <param name="travelers">list of travelers data</param>
        /// <param name="newList">new list</param>
        static void FindAtleastOnce(List<Route> routes, 
            List<Traveler> travelers, List<Route> newList)
        {
            Route temp;
            foreach (Route route in routes)
            {
                temp = route;
                if (FindRouteCount(travelers, temp) > 0)
                {
                    newList.SetDataForwards(temp);
                }
            }
        }

        /// <summary>
        /// A method which calculates the routes profit
        /// </summary>
        /// <param name="route">Route class object</param>
        /// <param name="travelers">list of travelers data</param>
        /// <returns>profit</returns>
        static double CalculateProfit(Route route, List <Traveler> travelers) 
        {
            if (route != null)
            { 
                double profit;
                profit = route.price * FindRouteCount(travelers, route);
                return profit;
            }
            return 0.0;
        }

        /// <summary>
        /// A method which finds the most profitable route
        /// </summary>
        /// <param name="finalList">the final list</param>
        /// <param name="travelers">list of travelers data</param>
        /// <returns>most profitable route</returns>
        static Route FindMostProfitable(List<Route> finalList, List<Traveler> travelers) 
        {
            Route mostProfitable = null;

            foreach (Route route in finalList)
            {
                if (CalculateProfit(route, travelers) > 
                    CalculateProfit(mostProfitable, travelers)) 
                {
                    mostProfitable = route;
                }
            }
            return mostProfitable;
        }

        /// <summary>
        /// A method which searches for multiple most profitable routes
        /// </summary>
        /// <param name="routes">list of routes data</param>
        /// <param name="finalList">final list</param>
        /// <param name="travelers">list of travelers data</param>
        static double SearchForEqual(List<Route> routes, List<Traveler> travelers, List<Route> finalList) 
        {
            Route maxRoute = null;
            maxRoute = FindMostProfitable(routes, travelers);
            double max = CalculateProfit(maxRoute, travelers);
            foreach (Route route in routes) 
            {
                if (CalculateProfit(route, travelers) == max) 
                {
                    finalList.SetDataForwards(route);
                }
            }
            return max;
        }

        // End USER METHODS
    }
}
