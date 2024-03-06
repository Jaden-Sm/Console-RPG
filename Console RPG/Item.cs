using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string benicio;
        public string name, description, buffType, debuffType;
        public int price, sell, buffAmount, debuffAmount, buffLength, debuffLength;
        public bool isUsed = false;

        public Item(string name, string description, int price, int sell, int buffAmount, int debuffAmount, string buffType, string debuffType = null, int buffLength = -1, int debuffLength = -1)
        {
            this.name = name;
            this.description = description;
            this.buffType = buffType;
            this.debuffType = debuffType;
            this.price = price;
            this.sell = sell;
            this.buffAmount = buffAmount;
            this.debuffAmount = debuffAmount;
            this.buffLength = buffLength;
            this.debuffLength = debuffLength;
        }
        public abstract void Use(Player user, Entity Target);
    }
}
