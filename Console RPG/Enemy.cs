using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy e = new Enemy("Luigi", 22, 32, new Stats(1321, -451));
        public static Enemy a = new Enemy("Mario", 52, 31, new Stats(1213, -451));

        public Enemy(string name, int health, int energy, Stats stats) : base(name, health, energy, stats)
        {
            isEnemy = true;
        }
        public override Entity Target(List<Entity> choice)
        {
            Random random = new Random();
            return choice[random.Next(0, choice.Count)];
        }
        public override void Attack(List<Entity> list)
        {
            Entity target = Target(list);
            int damage = target.health - this.stats.attackDamage;
            Console.WriteLine(this.name + " attacked " + target.name + " dealing " + damage + " damage!");
            target.health -= this.stats.attackDamage; 
            target.CheckDeath();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public override void HeavyAttack(List<Entity> list)
        { 
            Entity target = Target(list);
            int damage = target.health - this.stats.attackDamage * 2;
            Console.WriteLine(this.name + " attacked " + target.name + " dealing " + damage + " damage!");
            target.health -= this.stats.attackDamage;
            this.energy -= 5;
            target.CheckDeath();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public override void CheckDeath()
        {
            if (health <= 0)
            {
                dead = true;
            }
        }
    }
}
