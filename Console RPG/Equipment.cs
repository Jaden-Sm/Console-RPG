using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Console_RPG
{
    class Equipment : Item
    {
        public static Equipment empty = new Equipment("Empty", "", 0, -581395, 0, 0);
        public Equipment(string name, string description, int price, int sell, int buffAmount, int debuffAmount, string buffType = null, string debuffType = null, int buffLength = -1, int debuffLength = -1) : base(name, description, price, sell, buffAmount, debuffAmount, buffType, debuffType, buffLength, debuffLength)
        {


        }
        
        public override void Use(Player user, Entity Target)
        {
            if (buffType != null)
            {
                if (buffType == "Defense")
                {
                    if (user.Shield == this)
                        user.Shield = empty;
                    else
                        user.Shield = this;
                }
                if (buffType == "Attack")
                {
                    if (user.Weapon == this)
                        user.Weapon = empty;
                    else
                        user.Weapon = this;
                }
            }
            
            
        }
    }
}
