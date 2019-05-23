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
        static int playerDamageResult;
        static int enemyDamage = 2;
        static int enemyLoot = 5;
        static int enemyHealth = 10;
        static int expReward = 15;
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
                "The goal in the tutorial level is to get to 100 gold before you die." +
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
            Console.WriteLine("Press 'Enter' when you are ready to try out an encounter!");
            Console.ReadLine();
            RoomEncounter();
        }

        public static void RoomEncounter()
        {
            RollDiceForEncounter();
            Console.WriteLine("You walk into the next room and you find " + diceResult);
            if (diceRoll <= 12)
            {
                if (diceRoll == 1)
                {
                    Enemy skeleton = new Enemy(enemyHealth * 2, enemyDamage * 2, enemyLoot * 2, expReward * 2, "skeleton");
                    Console.WriteLine("You have run into a big skeleton!\n");
                    Console.WriteLine("Your health is currenty at {0}.\n", Player.health);
                    Combat(skeleton);
                }
                else
                {
                    Enemy goblin = new Enemy(enemyHealth, enemyDamage, enemyLoot, expReward, "goblin");
                    Console.WriteLine("You have run into a goblin!\n");
                    Combat(goblin);
                }
            }
            else if (diceRoll >= 16 && diceRoll <= 19)
            {
                int loot = RandomLoot("normal");
                Player.gold += loot;
                Console.WriteLine("You now have {0} gold.\n", Player.gold);
            }
            else if (diceRoll == 20)
            {
                int loot = RandomLoot("epic");
                Player.gold += loot;
                Console.WriteLine("You now have {0} gold!\n", Player.gold);
            }
            if (Player.gold >= 100)
            {
                Console.WriteLine("\n\nA Winner is You!\n" +
                    "You have gathered enough gold to retire and live the good life!\n" +
                    "Well done on completing this little tutorial level/game!\n" +
                    "If you would like to play again, press enter to continue,\n" +
                    "otherwise feel free to close the game.");
                Console.ReadLine();
                Console.Clear();
                GameStart();
            }
            Console.Write("\nPress enter to continue to the next room.\n");
            Console.ReadLine();
            Console.Clear();
            RoomEncounter();
        }

        public static void Combat(Enemy enemy)
        {
            do
            {
                string action = Player.SelectCombatType();
                RollDiceForCombat();
                Console.WriteLine("That's a {0}", diceResult);
                if (action == "melee attack")
                {
                    playerDamageResult = playerDamage + Player.meleeAttack;
                }
                else if (action == "magic attack")
                {
                    playerDamageResult = playerDamage + Player.magicAttack;
                }
                else if (action == "ranged attack")
                {
                    playerDamageResult = playerDamage + Player.rangedAttack;
                }
                PlayerAttack(action, enemy);
                if (enemy.health > 0)
                {
                    FightMonster(enemy);
                }
            } while (Player.health > 0 && enemy.health > 0);
            if (Player.health <= 0)
            {
                Console.WriteLine("You have died!\n" +
                    "Press 'Enter' to restart the game.");
                Console.ReadLine();
                Console.Clear();
                GameStart();
            }
            else if (enemy.health <= 0)
            {
                Console.WriteLine("You won! The {0} is dead!\n\n" +
                    "You get {1} loot and {2} exp!", enemy.name, enemy.loot, enemy.expReward);
                Player.gold += enemy.loot;
                Player.exp += enemy.expReward;
                Console.WriteLine("You now have {0} gold and {1} exp!", Player.gold, Player.exp);
            }
        }

        public static int RollDiceForEncounter()
        {
            Random rnd = new Random();
            diceRoll = rnd.Next(1, 21);
            Console.WriteLine("You rolled a {0}.\n", diceRoll);
            if (diceRoll == 1)
            {
                diceResult = "a tough enemy!\n";
            }
            else if (diceRoll >= 2 && diceRoll <= 12)
            {
                diceResult = "an enemy.\n";
            }
            else if (diceRoll >= 13 && diceRoll <= 15)
            {
                diceResult = "nothing.\n";
            }
            else if (diceRoll >= 16 && diceRoll <= 19)
            {
                diceResult = "some loot!\n";
            }
            else if (diceRoll == 20)
            {
                diceResult = "a big pile of loot!\n";
            }
            return diceRoll;
        }

        public static int RollDiceForCombat()
        {
            Random rnd = new Random();
            diceRoll = rnd.Next(1, 21);
            Console.WriteLine("\nThe d20 rolls a " + diceRoll);
            if (diceRoll == 1)
            {
                diceResult = "Critical Fail!";
            }
            else if (diceRoll >= 2 && diceRoll <= 6)
            {
                diceResult = "miss.";
            }
            else if (diceRoll >= 7 && diceRoll <= 13)
            {
                diceResult = "hit.";
            }
            else if (diceRoll >= 14 && diceRoll <= 19)
            {
                diceResult = "hard hit.";
            }
            else if (diceRoll == 20)
            {
                diceResult = "Critical Hit!";
            }
            return diceRoll;
        }

        public static void PlayerAttack(string action, Enemy enemy)
        {
            if (diceRoll == 1)
            {
                Console.WriteLine("You stumble and take damage!\n" +
                    "You have {0} health left.", Player.health);
                Player.health--;
            }
            if (diceRoll >= 7 && diceRoll <= 13)
            {
                Console.WriteLine("\nYou hit the {0} with a {1}!", enemy.name, action);
                Console.WriteLine("You hit the {0} for {1} damage.", enemy.name, playerDamageResult);
            }
            else if (diceRoll >= 14 && diceRoll <= 19)
            {
                Console.WriteLine("\nYou hit the {0} with a {1}!", enemy.name, action);
                playerDamageResult += playerDamage;
                Console.WriteLine("You hit the {0} for {1} damage.", enemy.name, playerDamageResult);
            }
            else if (diceRoll == 20)
            {
                Console.WriteLine("\nYou hit the {0} with a {1}!", enemy.name, action);
                playerDamageResult *= 2;
                Console.WriteLine("You hit the {0} for {1} damage.", enemy.name, playerDamageResult);
            }
            enemy.health -= playerDamageResult;
            Console.Write("\nPress enter to continue.\n");
            Console.ReadLine();
            Console.Clear();
        }

        public static void FightMonster(Enemy monster)
        {
            int hit = 0;
            Console.WriteLine("The {0} moves to attack you!", monster.name);
            RollDiceForCombat();
            Console.WriteLine("That's a {0}\n", diceResult);
            if (diceRoll == 1)
            {
                Console.WriteLine("The {0} stumbles and takes damage!", monster.name);
                monster.health--;
            }
            if (diceRoll >= 7 && diceRoll <= 13)
            {
                hit = monster.attackPlayer();
                Console.WriteLine("The {0} hits you for {1} damage.", monster.name, hit);
            }
            else if (diceRoll >= 14 && diceRoll <= 19)
            {
                hit = monster.attackPlayer() + 1;
                Console.WriteLine("The {0} hits you for {1} damage.", monster.name, hit);
            }
            else if (diceRoll == 20)
            {
                hit = monster.attackPlayer() * 2;
                Console.WriteLine("The {0} hits you for {1} damage.", monster.name, hit);
            }
            Player.health -= hit;
            Console.WriteLine("You have {0} health left.", Player.health);
            Console.Write("\nPress enter to continue.\n");
            Console.ReadLine();
            Console.Clear();
        }

        static int RandomLoot(string type)
        {
            Random rnd = new Random();
            int gold = 0;
            if (type == "normal")
            {
                gold = rnd.Next(2, 13);
            }
            else if (type == "epic")
            {
                gold = rnd.Next(30, 51);
            }
            return gold;
        }
    }
}
