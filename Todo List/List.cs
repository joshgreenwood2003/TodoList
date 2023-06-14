using System;

namespace Todo_List
{


    
    public class List<T>
    {

        //Todo list:
        //savelist

        const int MAX_SIZE = 10;
        private T[] arr = new T[MAX_SIZE];

        private int lastElement = -1;

        public List()
        {

        }

        public int Size()
        {
            return lastElement + 1;
        }

        public bool addToList(T item)
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
            if (item >= MAX_SIZE || item <= -1)
            {
                return false;
            }
            if (arr[item] == null)
            {
                return false;
            }
            arr[item] = default(T);
            for (int i = item + 1; i <= lastElement; i++)
            {
                arr[i - 1] = arr[i];
                arr[i] = default(T);
            }
            lastElement--;
            return true;
        }
        public bool isFull()
        {
            if (lastElement >= MAX_SIZE - 1)
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
                for (int i = 0; i <= lastElement; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ": " + arr[i].ToString());
                }
            }
        }

        public T viewItem(int item)
        {
            if (item >= 0 && item <= Size()-1)
            {
                return arr[item];
            }
            else
            {
                return default(T);
            }
        }

    }
}
