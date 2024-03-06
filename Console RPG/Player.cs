using System;
using System.Collections.Generic;
using System.Linq;
namespace Console_RPG
{
    class Player : Entity
    {
        public static Player jackson = new Player("You", 2, 3, new Stats(1, 6));
        public static Player Braden = new Player("Braden", 15, 5, new Stats(10, -8));
        public List<Item> inventory = new List<Item>();
        
        public Player(string name, int health, int energy, Stats stats) : base(name, health, energy, stats)
        {
            isEnemy = false;
        }

        public override Entity Target(List<Entity> choice)
        {
            Console.WriteLine("Which enemy would you like to hit?");
            for(var i = 0; i < choice.Count; i++)
            {
                Console.WriteLine(choice[i].name);
            }
            string choice2 = Console.ReadLine();
            int counter = 0;
            while(true)
            {   
                if (counter >= choice.Count)
                {
                    Console.WriteLine("Please put the name of the enemy.");
                    
                    return Target(choice);
                }
                if (choice[counter].name.ToLower() == choice2.ToLower())
                {
                    return choice[counter];
                }
                counter++;
            }
        }
        public override void Attack(List<Entity> list)
        {
            Entity target = Target(list);
            int damage = this.stats.attackDamage + Weapon.buffAmount;
            Console.WriteLine($"{this.name} attacked {target.name} dealing {damage} damage!");
            target.health -= this.stats.attackDamage;
            target.CheckDeath();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public override void HeavyAttack(List<Entity> list)
        {
            Entity target = Target(list);
            int damage = (this.stats.attackDamage + Weapon.buffAmount) * 2;
            Console.WriteLine($"{this.name} attacked {target.name} dealing {damage} damage!");
            target.health -= this.stats.attackDamage;
            this.energy -= 5;
            this.stats.speed -= 1;
            target.CheckDeath();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public override void CheckDeath()
        {
            if(health <= 0)
            {
                dead = true;
            }
        }
        public void UseItem(Entity target)
        {
            if(inventory.Count == 0)
            {
               Console.WriteLine("You can't use any items");
                return;
            }
            if(inventory.Count == 1)
            {
                inventory[0].Use(this, target);
            } else
            {
                Console.WriteLine("Which item would you like to use?");
                for (var i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine(i + 1 + ": " + inventory[i].name);
                }
                string choice2 = Console.ReadLine();
                int counter = 0;
                while (true)
                {
                    if (inventory[counter].name == choice2 || Convert.ToString(counter) == choice2)
                    {
                        inventory[counter].Use(this, target);
                        inventory.Remove(inventory[counter]);
                        break;
                    }
                    if (counter > inventory.Count)
                    {
                        UseItem(target);
                        break;
                    }
                    counter++;
                }
            }
        }
    }
}
