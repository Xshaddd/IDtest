using System;
using System.IO;
using System.Collections.Generic;

namespace IDtest
{
    

    public class Program
    {
        /*
    		todo later: item quality(like in dayz) (later with inventory etc)
    					item description
    	*/
        public static void Main()
        {
            ActionList.Init();
            Menu mainMenu = new Menu("Menus/mainmenu.xml");
            mainMenu.Init();
            mainMenu.ShowContents();

            ItemList il = new ItemList("itemlist.txt");
            il.Init();
            il.CheckManually();
        }
    }
}