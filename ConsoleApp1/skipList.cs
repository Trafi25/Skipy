using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SkipList<T>  where T : IComparable<T>
    {
        private int count;
        public int Count => count;      

        Node<T> head;

        public SkipList()
        {
            count = 0;
            head = new Node<T>(1);
        }

     
        private int RandomizeHeight()
        {
            
            int newHeight = 1;
            Random randHeight = new Random();

            while (randHeight.Next(1, 32) == 1 &&  newHeight < head.Height + 1 )
            {
                newHeight++;
            }

            if (newHeight > head.Height)
            {
                head.Increment();
            }

            return newHeight;
        }

        public void pushToList(T value)
        {
            Node<T> newNode = new Node<T>(value, RandomizeHeight());

            Node<T> currentBranch = head;

            int temp = currentBranch.Height - 1;

            while (temp >= 0)
            {
                int compare;
                if (currentBranch[temp] == null)
                {
                    compare = 1;
                }
                else
                {
                    compare = currentBranch[temp].Value.CompareTo(value);
                }

                if (compare > 0)
                {
                    if (newNode.Height > temp)
                    {
                        newNode[temp] = currentBranch[temp];
                        currentBranch[temp] = newNode;
                    }
                    temp--;
                }
                else
                {
                    currentBranch = currentBranch[temp];
                }
            }

            count++;
        }

      

        public bool deleteFromList(T value)
        {
            int level = head.Height - 1;
            Node<T> node = head;
            bool isDelete = false;

            while (level >= 0)
            {
                int comparison;
                if (node[level] == null)
                {
                    comparison = 1;
                }
                else
                {
                    comparison = node[level].Value.CompareTo(value);
                }

                if (comparison < 0)
                {
                    node = node[level];
                }
                else if (comparison > 0)
                {
                    level--;
                }
                else 
                {
                    isDelete = true;
                    node[level] = node[level][level]; 
                    level--;
                }
            }

            if (isDelete)
            {
                count--;
            }

            return isDelete;
        }

        public bool Find(T item)
        {
            Node<T> node = head;
            int level = head.Height - 1;

            while (level >= 0)
            {
                int comparison;
                if (node[level] == null)
                {
                    comparison = 1;
                }
                else
                {
                    comparison = node[level].Value.CompareTo(item);
                }

                if (comparison == 0)
                {
                    return true;
                }
                else if (comparison < 0)
                {
                    node = node[level];
                }
                else
                {
                    level--;
                }
            }

            return false;
        }

     
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentBranch = head;
            while (currentBranch[0] != null)
            {
                yield return currentBranch[0].Value;
                currentBranch = currentBranch[0];
            }
        }

       
    }


}
