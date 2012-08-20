using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SticksGame
{
    class RunSticks
    {
        public int Sticks { get; set; }

        // Method. 
        public int Mode(int userMode)
        { 
            String strUser1 = "";
            String strUser2 = "";
            String strCurrentUser = "";
            String strTakeSticks;
            int removeSticks;

            Console.WriteLine("----------");
            Console.WriteLine("Mode is {0}", userMode);
            Console.WriteLine("----------");

            switch (userMode)
            {
                case 1:
                    Console.Write("User #1: ");
                    strUser1 = Console.ReadLine();
                    Console.Write("User #2: ");
                    strUser2 = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("User #1: ");
                    strUser1 = Console.ReadLine();
                    strUser2 = "'Computer 1'";
                    break;
                case 3:
                    strUser1 = "'Computer 1'";
                    strUser2 = "'Computer 2'";
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nUser #1 is {0}, User #2 is {1}.");
            Console.WriteLine("\nLets begin the game!");
            strCurrentUser = strUser1;

            while (Sticks > 1)
            {
                Console.WriteLine();
                for (int i = 0; i < Sticks; i++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
                Console.WriteLine("\n{0} sticks left. User {1}'s turn", Sticks, strCurrentUser);
                if (strCurrentUser.Contains("Computer"))
                {
                    Random rnd = new Random();
                    removeSticks = rnd.Next(1, 3);

                    Console.Write("{0} selected to remove {1} sticks", strCurrentUser, removeSticks);
                    
                }
                else
                {
                    Console.Write("{0}, select no. of sticks (1 to 3): ", strCurrentUser);
                    strTakeSticks = Console.ReadLine();
                    if (Int32.TryParse(strTakeSticks, out removeSticks) && (removeSticks < 4))
                    {
                        Sticks -= removeSticks;
                        if (strCurrentUser == strUser1)
                            strCurrentUser = strUser2;
                        else
                            strCurrentUser = strUser1;
                    }
                    else
                    {
                        Console.WriteLine("What ??? - Please select 1, 2 or 3 sticks!");
                    }
                }
                
            }

            Console.WriteLine("\n**** User {0} looses! ****\n", strCurrentUser);

            return Sticks;
        }

        // Instance Constructor. 
        public RunSticks()
        {
            Sticks = 15;
        }


    }
}
