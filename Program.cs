using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mastermind
{
    class Program
    {
        public static int digits;

        static string generateNum()
        {
            while (digits < 4 || digits > 10)
            {
                bool c = false;
                Console.WriteLine("How many digits (4-10) would you like to play with?");

                //DO: catch conversion exceptions
                try
                {
                    digits = int.Parse(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("You must enter a number.");
                    c = true;
                }
                
                if (c == false && digits < 4 || digits > 10 )
                {
                    Console.WriteLine("You must enter a number between 4 and 10.");
                }
            }
            string preNum = "";
            
            Random rand = new Random();
            int d = digits;
            while (d > 0)
            {
                int a = rand.Next(0, 9);
                preNum = preNum + a;
              
                d -= 1;
            }
            Console.WriteLine(preNum);
            
            //num = Convert.ToInt32(preNum);
            return preNum;
        }

        static string guess()
        {
            bool valid = false;
            bool exc = false;

            string gNum;
            do
            {
                exc = false;
                Console.WriteLine("What is your guess?");
                gNum = Console.ReadLine();
                try
                {
                    int.Parse(gNum);
                }
                catch
                {
                    Console.WriteLine("Your guess can only be entered as a number " + digits + " digits long.");
                    exc = true;
                }
                if (gNum.Length != digits && exc == false)
                {
                    Console.WriteLine("You must enter a guess of " + digits + " numeric digits.");
                }
                if (exc == false && gNum.Length == digits)
                {
                    valid = true;
                }
            }
            while (valid == false);
            return gNum;
        }

        static void checkNum(string mNum)
        {
            int match = 0;
            int exactmatch = 0;
            string gNum = guess();
            
            if (mNum == gNum)
                {
                    Console.WriteLine("Amazing, you've guessed the number! Congratulations!");
                    Console.WriteLine("Let's play again!");
                    //restart the program somehow
                    playGame();
                }
            
            //check the guess against the master number, determine how many match/match exactly
            int i = 0;
            int j = 0;

            foreach (char l in mNum)
            {
                j = 0;
                bool m = false;
                bool e = false;
                foreach (char k in gNum)
                {
                    if ( i == j && l == k)
                    {
                        e = true;
                    }
                    else if ( l == k )
                    {
                        m = true; 
                    }
                    j++;
                }
                if (e)
                {
                    match++;
                    exactmatch++;
                }
                else if (m)
                {
                    match++;
                }
                i++;
            }
            Console.WriteLine("Your guess " + gNum + " had " + match + " matches and " + exactmatch + " were in the right position.");
        }

        static void playGame()
        {
            int turns = 10;
            string masterNum = generateNum();

            do
            {
                checkNum(masterNum);
                turns -= 1;
                Console.WriteLine("You have "+ turns + " turns left.");
            }
            while (turns > 0);
        }

        static void Main(string[] args)
        {
            playGame();
        }
    }
}
