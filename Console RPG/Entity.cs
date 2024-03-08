using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;
        public int health, maxHealth, energy, maxEnergy;
        public bool dead = false, isEnemy;
        public Stats stats;
        public Equipment Weapon = Equipment.empty, Shield = Equipment.empty;
        //public static Entity shopkeep = new Entity("Derek", 1, 100000, new Stats(1221321, 5555));
        public Entity(string name, int health, int energy, Stats stats)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.energy = energy;
            this.maxEnergy = energy;
            this.stats = stats;
        }
        public abstract Entity Target(List<Entity> choice);
        public abstract void Attack(List<Entity> choice);
        public abstract void HeavyAttack(List<Entity> choice);
        public abstract void CheckDeath();
    }
}
