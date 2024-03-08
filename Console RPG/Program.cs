using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Console_RPG
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                break;
            }
            while(false)
            {
                //die;
                Console.WriteLine("you re daead");
            }
            Item potion1 = new Potion("Health Potion", "", 2, 1, 5, 0, "health");
            Item potion2 = new Potion("Greater Health Potion", "", 2, 1, 10, 0, "health");
            Shop shop = new Shop(new List<Item>() { potion1, potion2 });
            shop.shop();
            string deepwoken;
            List<Entity> enemyList = new List<Entity>() { Enemy.e, Enemy.a };
            List<Player> players = new List<Player>() { Player.jackson };
            Player.jackson.inventory.Add(potion1);
            Player.jackson.inventory.Add(potion2);
            Console.WriteLine("You awaken in a dark room, you don't know where you are, and what happened. \nYou have some sort of potion in your pocket, and you see some figure in the corner.");
            Console.WriteLine("What will you do? \n \n1:Attack the entity\n2:Drink the potion\n3:Do nothing.");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                Player.jackson.Attack(enemyList);
                Battle battle = new Battle(enemyList.Cast<Enemy>().ToList());
                battle.Resolve(players);
            } else if (choice == 2) 
            {
                Player.jackson.UseItem(Player.jackson);
                Player.jackson.inventory.Clear();
                Main();
            } else if(choice == 3) 
            {
                Console.Clear();
                Console.WriteLine("You do nothing.");
                Thread.Sleep(2500);
                Main(); 
            }
            
        }
    }
}
