using System;

namespace Console_RPG
{
    class Potion : Item
    {
        public Potion(string name, string description, int price, int sell, int buffAmount, int debuffAmount, string buffType = null, string debuffType = null, int buffLength = -1, int debuffLength = -1) : base(name, description, price, sell, buffAmount, debuffAmount, buffType, debuffType, buffLength, debuffLength)
        {

        }
        public override void Use(Player user, Entity Target)
        {
            if (buffType == "health")
            {
                user.health += buffAmount;
                Console.WriteLine($"{user.name} was healed by {buffAmount}!");
            }
            if (buffType == "attack")
            {
                user.stats.attackDamage += buffAmount;
                if(buffLength != -1)
                Console.WriteLine($"{user.name}'s damage was increased by {buffAmount} for {buffLength} turns!");
                else
                Console.WriteLine($"{user.name}'s damage was increased by {buffAmount} permanently!");
            }
            if (buffType == "speed")
            {
                user.stats.speed += buffAmount; 
                if (buffLength != -1)
                    Console.WriteLine($"{user.name}'s speed was increased by {buffAmount} for {buffLength} turns!");
                else
                    Console.WriteLine($"{user.name}'s speed was increased by {buffAmount} permanently!");
            }
            if (buffType == "maxhealth")
            {
                user.maxHealth += buffAmount;
                if (buffLength != -1)
                    Console.WriteLine($"{user.name}'s max health was increased by {buffAmount} for {buffLength} turns!");
                else
                    Console.WriteLine($"{user.name}'s max health was increased by {buffAmount} permanently!");
            }
            user.health += buffAmount;
            if (debuffType != null)
            {
                if (debuffType == "Defense")
                {
                    user.health = user.health / buffAmount;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (debuffLength != -1)
                        Console.WriteLine($"{user.name}'s health was decreased by {buffAmount} for {buffLength} turns!");
                    else
                        Console.WriteLine($"{user.name}'s health was decreased by {buffAmount} permanently!");

                }
                if (debuffType == "Speed")
                {
                    user.stats.speed = user.stats.speed / buffAmount;
                    if (debuffLength != -1)
                        Console.WriteLine($"{user.name}'s speed was decreased by {buffAmount} for {buffLength} turns!");
                    else
                        Console.WriteLine($"{user.name}'s speed was decreased by {buffAmount} permanently!");
                }
            }


        }
    }
}
