using System;
using System.IO;
using System.Collections.Generic;

namespace IDtest
{
    public class ItemList 
    {
    	public List<Item> list = new List<Item>();
    	public string FileUsed { get; private set; }
    	public bool IsFailed { get; private set; }
    	
    	public void Init()
    	{
    		
	        if(!File.Exists(FileUsed))
	        {
	        	Console.WriteLine(FileUsed + " didn't exist, refill it to continue testing");
	        	File.Create(FileUsed);
	        	IsFailed = true;
	        }
	        else if(File.ReadAllText(FileUsed) == "")
	        {
	        	Console.WriteLine(FileUsed + " is empty");
	        	IsFailed = true;
	        }
	        else {IsFailed = false;}
	        
	        using (StreamReader sr = new StreamReader(FileUsed))
	        {
	        	string line;
	        	string name;
	        	int ID;
	        	int index;
	       		
	        	while ((line = sr.ReadLine()) != null)
	        	{
	        		index = line.IndexOf(';');
	        		if (index == -1)
	        		{
	        			Console.WriteLine("Failed reading IDs. Wrong syntax in " + FileUsed);
	        			IsFailed = true;
	        			return;
	        		}
	        		else if (index == 0 || line.StartsWith("//"))
	        				continue;
	        			
	        		name = line.Remove(index, line.Length-index);
	        		ID = int.Parse(line.Remove(0, index+1));
	        		list.Add(new Item(name, ID));
	        	}
	        }
        }
        
        public void CheckManually()
        {
        	if(IsFailed)
        	{
        		Console.WriteLine("Method can't be called because initialisation failed");
        		return;
        	}
        	
        	int input = -1;
        	Item operatedItem = new Item(default(string), default(int));
        	while(true)
        	{
        		Console.Write("Enter ID to find. 0 to exit: ");
        		try
        		{
        			input = int.Parse(Console.ReadLine());
        		}
        		catch
        		{
        			Console.WriteLine("Wrong Arguments");
        			continue;
        		}
        		
        		if(input == 0)
        			break;
        		
        		try
        		{
        			operatedItem = list.Find(item => (item.ID == input));
        			Console.WriteLine(operatedItem.Name);
        		}
        		catch
        		{
        			Console.WriteLine("Item with such ID does not exist");
        		}
        	}
        }
        
        public ItemList(string file)
        {
        	this.FileUsed = file;
        }
    }
}