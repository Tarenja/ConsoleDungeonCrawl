using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Program
    {
        int damage = 2;

        static void Main(string[] args)
        {
            GameStart();
        }

        static void GameStart()
        {
            Console.WriteLine("Welcome to my fun little dungeon crawler game!\n" +
                "This game currently includes only a tutorial level.\n" +
                "Gameplay is based on a d20 (twenty-sided-die) dice roll, just like D&D, plus whatever bonuses you have.\n" +
                "The way this works is you will get a list of options, and you will type the option you want.\n" +
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
            Console.WriteLine("Let's start by giving you a little tutorial on how things work.\n" +
                "Let's say you have just entered the dungeon in search of loot.\n" +
                "Each room you encounter will randomly have either an enemy, loot, or nothing.\n" +
                "This game uses a d20 'dice rolling' mechanic to randomly generate a number between 1 and 20,\n" +
                "and the result will determine what you run into.\n\n" +
                "A 1 is a critical failure, you will enounter a really tough enemy!\n" +
                "A 20 is a critical success, you will find an epic piece of loot!\n\n" +
                "Hit 'Enter' when you are ready to continue the tutorial.");
            Console.ReadLine();
            Console.WriteLine("If you encounter an enemy, you will enter a fight, at which point you can choose\n" +
                "if you want to attack it using your Melee, Magic or Ranged skill. \n" +
                "Here again a d20 will be 'rolled' to determine whether you hit.\n" +
                "A 1 is a critical failure, you won't hit the creature and you will take damage.\n" +
                "A 20 is a critical success and will double all bonuses and damage you do.\n" +
                "Damage starts at 2 for all attack types, and bonuses from your race and class will be added.\n" +
                "So let's say you are a Human Rogue, and you attack a monster with a ranged attack, and you roll a normal hit.\n" +
                "You hit the monster with 5 damage (2 base damage, Human + 1, Rogue + 2)\n" +
                "If the monster is not dead, it can then try to hit you, using the same dice mechanics, this will decrease your health.\n" +
                "Let's try it out shall we?\n");
            Console.WriteLine("Press 'Enter' when you are ready to try out combat!");
            Console.ReadLine();
        }


    }
}
