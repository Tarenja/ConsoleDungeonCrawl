using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    class Enemy
    {
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

        public int attackPlayer()
        {
            return damage;
        }
    }
}
