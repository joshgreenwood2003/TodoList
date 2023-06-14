using System;

namespace Todo_List
{
   

    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> lists = new List<List<string>>();
            lists.addToList(new List<string>("Test list 1"));
            lists.addToList(new List<string>("Test list 2"));
            lists.addToList(new List<string>("Another list"));
            lists.addToList(new List<string>("Yet another"));
            lists.addToList(new List<string>("Final list"));
            string menuInput;
            int listNumber = 0;
            while (true)
            {
                Console.WriteLine("Here is list "+ (listNumber+1).ToString() + ":");
                lists.viewItem(listNumber).viewList();
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("Press 1 to add to the list");
                Console.WriteLine("Press 2 to remove from the list");
                Console.WriteLine("Press 3 to change list");
                menuInput = Console.ReadLine();
                if (menuInput == "1")
                {
                    Console.WriteLine("What would you like to add?");
                    lists.viewItem(listNumber).addToList(Console.ReadLine());
                }
                else if (menuInput == "2")
                {
                    Console.WriteLine("Which line would you like to remove?");
                    lists.viewItem(listNumber).removeFromList(Convert.ToInt32(Console.ReadLine()) - 1);
                }
                else if (menuInput == "3")
                {
                    Console.WriteLine("Here are the lists:");
                    lists.viewList();

                    Console.WriteLine("Which list would you like to select?");
                    menuInput = Console.ReadLine();
                    var isNumeric = int.TryParse(menuInput, out int n);
                    if (isNumeric && n <= 50 && n>=1)
                    {
                        listNumber = n-1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid list option. Press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection option. Press any key to continue");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}
