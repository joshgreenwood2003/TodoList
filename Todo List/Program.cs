using System;

namespace Todo_List
{
    class List
    {

        //Todo list:
        //savelist

        const int MAX_SIZE = 10;
        private string[] arr = new string[MAX_SIZE];

        private int lastElement = -1;
        
        public List(){
        
        }

        public bool addToList(string item)
        {
            if (isFull())
            {
                return false;
            }
            arr[lastElement + 1] = item;
            lastElement++;
            return true;
        }
        public bool removeFromList(int item)     
        {
            if (isEmpty())
            {
                return false;
            }
            if(item >= MAX_SIZE || item <= -1)
            {
                return false;
            }
            if(arr[item] == null)
            {
                return false;
            }
            arr[item] = null;
            for (int i = item+1;i<=lastElement ;i++)
            {
                arr[i - 1] = arr[i];
                arr[i] = null;
            }
            lastElement--;
            return true;
        }
        public bool isFull()
        {
            if (lastElement >= MAX_SIZE-1)
            {
                return true;
            }
            return false;
        }
        private bool isEmpty()
        {
            return (lastElement < 0);
        }
        public void viewList()
        {
            if (isEmpty())
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                for (int i =0;i<=lastElement;i++)
                {
                    Console.WriteLine((i+1).ToString() + ": " + arr[i]);
                }
            }
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            List[] lists= new List[50];
            for(int i = 0; i< 50; i++)
            {
                lists[i] = new List();
            }


            string menuInput;
            int listNumber = 0;
            while (true)
            {
                Console.WriteLine("Here is list "+ (listNumber+1).ToString() + ":");
                lists[listNumber].viewList();
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("Press 1 to add to the list");
                Console.WriteLine("Press 2 to remove from the list");
                Console.WriteLine("Press 3 to change list");
                menuInput = Console.ReadLine();
                if (menuInput == "1")
                {
                    Console.WriteLine("What would you like to add?");
                    lists[listNumber].addToList(Console.ReadLine());
                }
                else if (menuInput == "2")
                {
                    Console.WriteLine("Which line would you like to remove?");
                    lists[listNumber].removeFromList(Convert.ToInt32(Console.ReadLine()) - 1);
                }
                else if (menuInput == "3")
                {
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
