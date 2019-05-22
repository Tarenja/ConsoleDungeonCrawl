using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Player
    {
        public static int health = 15;
        public static string gender;
        public static string race;
        public static string playerClass;
        public static int meleeAttack = 1;
        public static int rangedAttack = 1;
        public static int magicAttack = 1;
        public static int gold = 0;
        public static bool characterDone = false;
        public static int exp = 0;

        public static void CharacterCreation()
        {
            Console.WriteLine("So to create your characters you get to pick your gender, race and class.\n" +
                "Your stats are: Melee, Magic, Ranged and Health.\n" +
                "Each class and race has different bonuses for these stats.\n" +
                "All of them start at 1, except for Health which starts at 15.\n");
            Console.Clear();
            GenderSelection();
        }

        static void GenderSelection()
        {
            int correct = 0;
            do
            {
                Console.WriteLine("First, please select your gender you would like to be: \n" +
                    "1. Female\n" +
                    "2. Male\n" +
                    "3. Non-binary\n");
                Console.Write("Your choice: ");
                string genderSelection = Console.ReadLine().Trim().ToLower();
                switch (genderSelection)
                {
                    case "female":
                        gender = "Female";
                        correct = 1;
                        break;
                    case "male":
                        gender = "Male";
                        correct = 1;
                        break;
                    case "non-binary":
                        gender = "Non-binary";
                        correct = 1;
                        break;
                    default:
                        Console.WriteLine("\nValue not recognised.");
                        Console.Clear();
                        break;
                }
            } while (correct == 0);

            Console.WriteLine("\nYou have selected: " + gender + "\n\n" +
                "Please hit 'Enter' to continue.\n");
            Console.ReadLine();
            Console.Clear();
            RaceSelection();
        }

        static void RaceSelection()
        {
            int correct = 0;
            do
            {
                Console.WriteLine("Please select the race you would like to be: \n" +
                    "1. Human (+1 all stats)\n" +
                    "2. Elf (+2 Magic; +1 Ranged, Health)\n" +
                    "3. Dwarf (+2 Ranged; +1 Melee, Magic)\n" +
                    "4. Troll (+2 Melee, Health)\n");
                Console.Write("Your choice: ");
                string raceSelection = Console.ReadLine().Trim().ToLower();
                switch (raceSelection)
                {
                    case "human":
                        race = "Human";
                        magicAttack++;
                        rangedAttack++;
                        meleeAttack++;
                        health++;
                        correct = 1;
                        break;
                    case "elf":
                        race = "Elf";
                        magicAttack += 2;
                        rangedAttack++;
                        health++;
                        correct = 1;
                        break;
                    case "dwarf":
                        race = "Dwarf";
                        rangedAttack += 2;
                        meleeAttack++;
                        magicAttack++;
                        correct = 1;
                        break;
                    case "troll":
                        race = "Troll";
                        meleeAttack += 2;
                        health += 2;
                        correct = 1;
                        break;
                    default:
                        Console.WriteLine("\nValue not recognised.");
                        Console.Clear();
                        break;
                }
            } while (correct == 0);
            Console.WriteLine("\nYou have selected: " + race + "\n\n" +
                "Please hit 'Enter' to continue.\n");
            Console.ReadLine();
            Console.Clear();
            ClassSelection();
        }

        static void ClassSelection()
        {
            int correct = 0;
            do
            {
                Console.WriteLine("Please select the class you would like to be: \n" +
                    "1. Warrior (+2 to Melee; +1 Ranged; +1 Health)\n" +
                    "2. Mage (+3 Magic; +1 Ranged)\n" +
                    "3. Rogue (+2 Ranged; +1 Melee, Magic)\n");
                Console.Write("Your choice: ");
                string classSelection = Console.ReadLine().Trim().ToLower();
                switch (classSelection)
                {
                    case "warrior":
                        playerClass = "Warrior";
                        meleeAttack += 2;
                        rangedAttack++;
                        health++;
                        correct = 1;
                        break;
                    case "mage":
                        playerClass = "Mage";
                        magicAttack += 3;
                        rangedAttack++;
                        correct = 1;
                        break;
                    case "rogue":
                        playerClass = "Rogue";
                        rangedAttack += 2;
                        meleeAttack++;
                        magicAttack++;
                        correct = 1;
                        break;
                    default:
                        Console.WriteLine("\nValue not recognised.");
                        Console.Clear();
                        break;
                }
            } while (correct == 0);
            Console.WriteLine("\nYou have selected: " + playerClass + "\n\n" +
                "Please hit 'Enter' to continue.\n");
            Console.ReadLine();
            Console.Clear();
            string finished;
            do
            {
                Console.WriteLine("You have chosen to play a " + gender + " " + race + " " + playerClass + "\n" +
                    "Your stats are: " + "health: " + health + ", melee: " + meleeAttack + ", ranged: " + rangedAttack + ", magic: " + magicAttack +
                    "\nAre you happy with this character? Please type Yes or No.\n");
                Console.Write("Your choice: ");
                finished = Console.ReadLine().ToLower();
            } while (finished != "yes" && finished != "y" && finished != "no" && finished != "n");
            if(finished == "yes" || finished == "y")
            {
                Console.Clear();
                characterDone = true;
            } else if (finished == "no" || finished == "n")
            {
                GenderSelection();
            }
        }
    }
}
