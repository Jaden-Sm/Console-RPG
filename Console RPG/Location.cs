using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public string name, description;
        public Battle battle;

        public bool isShop;
        public Location north, east, south, west;
        public Location(string name, string description, Battle battle = null)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
        }
        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if(!(north is null))
            {
                this.north = north;
                south.north = this;
            }
            if (!(south is null))
            {
                this.south = north;
                north.south = this;
            }
            if (!(east is null))
            {
                this.east = north;
                west.east= this;
            }
            if (!(west is null))
            {
                this.west = north;
                east.west = this;
            }
        }
        public void Resolve(List<Player> players)
        {
            Console.WriteLine("You are in " + this.name + "\n" + description);
            battle.Resolve(players);
            if (!(this.north is null))
                Console.WriteLine("North: " + north);
            if (!(this.east is null))
                Console.WriteLine("East: " + east);
            if (!(this.south is null))
                Console.WriteLine("South: " + south);
            if (!(this.west is null))
                Console.WriteLine("West: " + west);
            if (this.west is null && this.south is null && this.east is null && this.north is null)
                Console.WriteLine("There is no escape.");
            Console.WriteLine("Where do you want to go?");
            string choice = Console.ReadLine();
            Location nextLocation = null;
            if (choice.ToLower() == "north")
                nextLocation = north;
            if (choice.ToLower() == "west")
                nextLocation = west;
            if (choice.ToLower() == "east")
               nextLocation = east;
            if (choice.ToLower() == "south")
               nextLocation = south;
             else
            {
                Console.WriteLine("Please input north, east, south, or west.");
                this.Resolve(players);
            }
            nextLocation.Resolve(players);
        }
    }
}
