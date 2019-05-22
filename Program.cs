using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Program
    {
        static int playerDamage = 2;
        static int damageResult;
        static int enemyDamage = 2;
        static int loot = 5;
        static int health = 10;
        static int exp = 20;
        static int diceRoll;
        static string diceResult;

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
                "A 20 is a critical success, you will find a big pile of loot!\n\n" +
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
        }

        public static void FightGoblin()
        {
            Enemy goblin = new Enemy(health, enemyDamage, loot, exp);

            int hit = goblin.attackPlayer();
            Console.WriteLine("The goblin hits you for " + hit + " damage.");
            Player.health -= hit;
            Console.WriteLine("You have " + Player.health + "health left.");
        }

        public static int RollDiceForEncounter()
        {
            Random rnd = new Random();
            diceRoll = rnd.Next(1, 21);
            Console.WriteLine("You rolled a " + diceRoll);
            if (diceRoll == 1)
            {
                diceResult = "a tough enemy!";
            }
            else if (diceRoll >= 2 && diceRoll <= 11)
            {
                diceResult = "an enemy";
            }
            else if (diceRoll >= 12 && diceRoll <= 16)
            {
                diceResult = "nothing";
            }
            else if (diceRoll >= 14 && diceRoll <= 19)
            {
                diceResult = "some loot!";
            }
            else if (diceRoll == 20)
            {
                diceResult = "big pile of loot!";
            }
            return diceRoll;
        }

        public static int RollDiceForCombat()
        {
            Random rnd = new Random();
            diceRoll = rnd.Next(1, 21);
            Console.WriteLine("You rolled a " + diceRoll);
            if (diceRoll == 1)
            {
                diceResult = "Critical Fail";
            }
            else if (diceRoll >= 2 && diceRoll <= 6)
            {
                diceResult = "miss";
            }
            else if (diceRoll >= 7 && diceRoll <= 13)
            {
                diceResult = "hit";
            }
            else if (diceRoll >= 14 && diceRoll <= 19)
            {
                diceResult = "hit hard";
            }
            else if (diceRoll == 20)
            {
                diceResult = "Critical Hit";
            }
            return diceRoll;
        }

    }
}
