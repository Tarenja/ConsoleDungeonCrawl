using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Enemy
    {
        // this class is fairly small, it didn't need much, just enough to be able to create 
        // multiple enemy types
        public int health;
        public int damage;
        public int loot;
        public int expReward;
        public string name;

        public Enemy(int _health, int _damage, int _loot, int _expReward, string _name)
        {
            name = _name;
            health = _health;
            damage = _damage;
            loot = _loot;
            expReward = _expReward;
        }

        // this function will return whatever damage the creature has in combat
        public int attackPlayer()
        {
            return damage;
        }
    }
}
