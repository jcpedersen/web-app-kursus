using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SticksGame
{
    class Program
    {
        static void Main(string[] args)
        {
            String strUserSelect;
            // Int16 userSelect; //The same as integer
            
            do
            {
                Console.WriteLine("////////// SticksGame //////////");
                Console.WriteLine("--------- Menu ---------");
                Console.WriteLine("1: Bruger vs. Bruger");
                Console.WriteLine("2: Bruger vs. Computer");
                Console.WriteLine("3: Computer vs. Computer");
                Console.WriteLine("4: Exit game");
                Console.WriteLine("------------------------");
                Console.Write("Please select: ");

                strUserSelect = Console.ReadLine();
                // userSelect = Int16.Parse(strUserSelect);

                RunSticks newGame = new RunSticks();

                switch (strUserSelect)
                {
                    case "1":
                        newGame.Mode(1);
                        break;
                    case "2":
                        newGame.Mode(2);
                        break;
                    case "3":
                        newGame.Mode(3);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Illegal selection. Please try again");
                        break;
                }

            } while (strUserSelect != "4");

            Console.WriteLine("Game over, please press return to exit");
            Console.ReadLine();

        }
    }
}
