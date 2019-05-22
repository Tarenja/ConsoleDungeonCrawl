using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStart();
        }

        static void GameStart()
        {
            Console.WriteLine("Welcome to my fun little dungeon crawler game!\n" +
                "This game currently includes only a tutorial level.\n" +
                "Gameplay is based on a d20 dice roll, just like D&D, plus whatever bonuses you have.\n" +
                "Press 'Enter' to play!");
            Console.ReadLine();
            Console.Clear();
            Player.CharacterCreation();
            if(Player.characterDone)
            {
                Tutorial();
            }
        }

        static void Tutorial()
        {
            Console.Clear();
            Console.WriteLine("Let's start by giving you a little tutorial on how things work.");
            Console.ReadLine();
        }


    }
}
