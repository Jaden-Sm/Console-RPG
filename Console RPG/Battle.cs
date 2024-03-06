using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Console_RPG
{
    class Battle
    {
        public List<Enemy> enemies;
        public bool isResolved;

        public Battle(List<Enemy> enemies)
        {
            this.enemies = enemies;
            this.isResolved = false;
        }
        public void Resolve(List<Player> players)
        {
            int counter = 0;
            while (!isResolved)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].dead)
                        players.RemoveAt(i);
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].dead)
                        enemies.RemoveAt(i);
                }
                if (players.Count == 0)
                    isResolved = true;
                if (enemies.Count == 0)
                    isResolved = true;
                Entity fastest = new Player("test", 0, 0, new Stats(0, -95999));
                counter++;
                Console.WriteLine($"Round {counter}");
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].stats.speed > fastest.stats.speed)
                        fastest = players[i];
                    Console.WriteLine($"{players[i].name}: \n{players[i].health} health | {players[i].energy} energy \n{players[i].stats.attackDamage} damage | {players[i].stats.speed} speed");
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].stats.speed > fastest.stats.speed)
                        fastest = enemies[i];
                    Console.WriteLine($"{enemies[i].name}: \n{enemies[i].health} health | {enemies[i].energy} energy \n{enemies[i].stats.attackDamage} damage | {enemies[i].stats.speed} speed");
                }
                Console.WriteLine(fastest.name + " was the fastest, and was able to attack quicker.");
                if (fastest.isEnemy)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].name == fastest.name)
                            enemies[i].Attack(players.Cast<Entity>().ToList());
                    }
                }
                else
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[i].name == fastest.name)
                        {
                            Console.WriteLine("What will you do? \n \n1:Light Attack \n2:Use an item\n3:Heavy attack\n4:Do Nothing");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1)
                            {
                                players[i].Attack(enemies.Cast<Entity>().ToList());
                            }
                            else if (choice == 2)
                            {
                                players[i].HeavyAttack(enemies.Cast<Entity>().ToList());
                            }
                            else if (choice == 3)
                            {
                                Player.jackson.UseItem(Player.jackson);
                            }
                            else if (choice == 4)
                            {
                                Console.WriteLine("You just sit there and do nothing");
                            }
                        }
                    }
                }

            }
        }
    }
}