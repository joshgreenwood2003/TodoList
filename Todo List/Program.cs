using System;

namespace Todo_List
{
    class List
    {

        //Todo list:
        // -Add something to list
        // -Take something off list
        // View the list

        //savelist
        //add element to list
        //remove element from list
        const int MAX_SIZE = 3;
        private string[] arr = new string[MAX_SIZE];

        private int lastElement = -1;
        
        public List(string filename){
        
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
                    Console.WriteLine(arr[i]);
                }
            }
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List("list.txt");
            string menuInput;
            while (true)
            {
                Console.WriteLine("Here is the list:");
                list.viewList();
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("Press 1 to add to the list");
                Console.WriteLine("Press 2 to remove from the list");
                menuInput = Console.ReadLine();
                if(menuInput == "1")
                {
                    Console.WriteLine("What would you like to add?");
                    list.addToList(Console.ReadLine());
                }
                else if(menuInput == "2")
                {
                    Console.WriteLine("Which line would you like to remove?");
                    list.removeFromList(Convert.ToInt32(Console.ReadLine()));
                }
                Console.Clear();
            }



            Console.WriteLine("DISPLAYING LIST:::::::::::");
            list.viewList();
            list.addToList("Hello");
            list.addToList("World!");
            list.addToList("World2!");
            Console.WriteLine("DISPLAYING LIST:::::::::::");
            list.viewList();
            list.removeFromList(0);
            Console.WriteLine("DISPLAYING LIST:::::::::::");
            list.viewList();
            Console.ReadLine();
        }
    }
}
