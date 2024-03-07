using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Console_RPG
{
    internal class Shop
    {
        public bool shopping = true;
        List<Item> itemlist;

        public Shop(List<Item> itemlist)
        {
            this.itemlist = itemlist;
        }
        public void shop() 
        { 
            while (shopping) 
            {
                Console.WriteLine("Welcome to my shop, I currently have: \n");
                for(int i = 0; i < itemlist.Count; i++)
                {
                    Console.WriteLine($"{itemlist[i]}\n");
                }
            }
            
        }
    }
}
