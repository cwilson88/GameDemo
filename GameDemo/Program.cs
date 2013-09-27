using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDemo
{
    class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CountryFightingFor { get; set; }
        public int HitPoints { get; set; }

        public Player()
        {
            this.HitPoints = 100;
        }
    }

    /// <summary>
    /// this is a demo of the combat game to be built using classes, etc
    /// it will utilize dynamic types to get the game done quicker, but
    /// inherently less flexible.
    /// </summary>
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            // print a welcome message
            printl("Welcome to the game!");

            // get player 1 and 2 details
            Player player1 = new Player();
            Player player2 = new Player();
            
            player1.Name = read("Player 1 name: ");
            player1.CountryFightingFor = read("Player 1 countryfightingfor: ");
            player1.Age = Convert.ToInt32(read("Player 1 age: "));

            player2.Name = read("Player 2 name: ");
            player2.CountryFightingFor = read("Player 2 countryfightingfor: ");
            player2.Age = Convert.ToInt32(read("Player 2 age: "));

            // enter combat
                Console.WriteLine ("{0}{1}({2}) will fight {3}{4}{5})",
                player1.Name,
                player1.CountryFightingFor,
                player1.Age,
                player2.Name,
                player2.CountryFightingFor,
                player2.Age);

            int goFirst = rand.Next(minValue: 1, maxValue: 3);

            // combat loop
            while (player1.HitPoints > 0 && player2.HitPoints > 0)
            {
                // player1 goes first check
                if (goFirst == 1)
                {
                    int damage = getRandomDamage();
                    player2.HitPoints -= damage;
                    string output = player1.Name + " shot " 
                        + player2.Name + " for " + damage;
                    output += "(" + player2.HitPoints + ")";
                    printl(output);

                    // player 1 goes first
                    if (player2.HitPoints > 0)
                    {
                        // player 2 goes
                        damage = getRandomDamage();
                        player1.HitPoints -= damage;
                        output = player2.Name + " shot "
                            + player1.Name + " for " + damage;
                        output += "(" + player1.HitPoints + ")";
                        printl(output);
                    }
                }
                else // player2 goes first check
                {
                    // player 2 goes first
                    int damage = getRandomDamage();
                    player1.HitPoints -= damage;
                    string output = player2.Name + " shot "
                        + player1.Name + " for " + damage;
                    output += "(" + player1.HitPoints + ")";
                    
                    printl(output);

                    if (player1.HitPoints > 0)
                    {
                        // then player 1 goes
                        damage = getRandomDamage();
                        player2.HitPoints -= damage;
                        output = player1.Name + " shot "
                            + player2.Name + " for " + damage;
                        output += "(" + player2.HitPoints + ")";
                        printl(output);
                    }

                }
            }

            // post-combat
            if (player1.HitPoints <= 0)
            {
                printl(player1.Name + " was killed by Player2");
            }
            else
            {
                printl(player2.Name + " was killed by Player1");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// gets a random number from 0 to 10
        /// </summary>
        /// <returns>the damage</returns>
        private static int getRandomDamage()
        {
            return rand.Next(11);
        }

        /// <summary>
        /// a basic method to read a string from a specific prompt
        /// </summary>
        /// <param name="p"> the prompt to print</param>
        /// <returns>the string input by the user</returns>
        private static string read(string p)
        {
            print(p);
            return Console.ReadLine();
        }

        /// <summary>
        /// juts a helper method for Console.Write(string)
        /// note: this method doesn't append a newline character
        /// </summary>
        /// <param name="p"></param>
        private static void print(string p)
        {
            Console.Write(p);
        }

        /// <summary>
        /// just a helper method for Console.WriteLine(string)
        /// </summary>
        /// <param name="p">the string to write</param>
        private static void printl(string p)
        {
            Console.WriteLine(p);
        }
    }
}
