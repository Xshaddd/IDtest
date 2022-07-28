using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace IDtest
{
	public struct MenuItem
	{
		public string Content;
		public int TargetAction;
	}
	
	public class Menu
	{
        public int ID { get; private set; }
		public string Header { get; private set; }
		public MenuItem[] Items { get; private set; }
		public string Path { get; private set; }

    	public void Init()
    	{
	        if(!File.Exists(Path))
	        {

	        	Console.WriteLine(Path + " doesn't exist");
				FailInitialisation();
	        }
	        else if(File.ReadAllText(Path) == "")
	        {
	        	Console.WriteLine(Path + " is empty");
				FailInitialisation();
	        }

			XmlDocument menuXml = new XmlDocument();
			menuXml.Load(Path);
            XmlElement root = menuXml.DocumentElement;

			if (!root.HasChildNodes)
			{
				Console.WriteLine($"{0} has no menu items", Path);
				FailInitialisation();
			}

			foreach (XmlAttribute attr in root.Attributes)
            {
                if(attr.Name == "name")
					Header = attr.Value;
				if (attr.Name == "id")
					if (!int.TryParse(attr.Value, out int ID))
						FailInitialisation();

			}

			XmlNodeList items = root.ChildNodes;
			Items = new MenuItem[items.Count];
			int i = 0;
			foreach(XmlElement item in items)
			{

				foreach (XmlAttribute attr in item.Attributes)
				{
					if (attr.Name == "name")
						Items[i].Content = attr.Value;
					if (attr.Name == "id")
						Items[i].TargetAction = int.Parse(attr.Value);
				}
				i++;
            }
		}

		private void FailInitialisation()
        {
			Console.WriteLine($"Initialisation of {0} has failed", Path);
			Console.ReadKey();
			Environment.Exit(0);
		}
		
		public void ShowContents()
		{
			Console.WriteLine(Header);
			
			int n = 0;
			foreach(MenuItem item in Items)
			{
				Console.WriteLine(n+1 + ". " + item.Content);
				n++;
			}
			DoItemAction();
		}

		private void DoItemAction()
        {
			Console.WriteLine("Select 1-" + Items.Length);
			int menuItemNumber = int.Parse(Console.ReadLine());
			MenuItem lookedItem = Items[menuItemNumber - 1];
			Console.WriteLine(lookedItem.TargetAction);
			ActionList.Actions.Find(item => item.ActionID == lookedItem.TargetAction).Function();
        }
		
		public Menu(string FileUsed)
		{
			this.Path = FileUsed;
		}
		
	}
}