using System;

namespace IDtest
{
    public class Item 
    {
        public string Name { get; private set; }
        public int ID;
        
        public Item (string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
}