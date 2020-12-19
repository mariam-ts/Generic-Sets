using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ProjectAssignment4.COMPE361
{
    public class Set<T> : IEnumerable<T>
    {
        // I am storing the data in list
        protected List<T> mySet;
        // make Count and IsEmpty properties only readable and not writable
        public int Count
        {
            get
            {
                return this.mySet.Count();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !(this.mySet.Any());
            }
        }
        //default constructor
        public Set()
        {
            this.mySet = new List<T>();
        }
        //constructor
        public Set(IEnumerable<T> e)
        {
            this.mySet = new List<T>();
            foreach (var item in e)
            {
                if (!mySet.Contains(item))
                    this.mySet.Add(item);
            }
        }
        // + operator overload
        public static Set<T> operator +(Set<T> lhs, Set<T> rhs)
        {
            Set<T> newSet = new Set<T>();

            // add all the element that is in the rhs to the new set
            foreach (var item1 in rhs)
            {
                newSet.mySet.Add(item1);
            }
            // add all remaining element from the lhs to the new set 
            foreach (var item2 in lhs)
            {
                if (!rhs.Contains(item2))
                {
                    newSet.mySet.Add(item2);
                }
            }
            // return new set
            return newSet;
        }
        //add item to set (using list.Add)
        public virtual bool Add(T item)
        {
            bool added = false;
            if (!mySet.Contains(item))
            {
                this.mySet.Add(item);
                added = true;
            }


            return added;
        }
        // remove item from set (list.Remove)
        public virtual bool Remove(T item)
        {
            bool removed = false;
            if (mySet.Contains(item))
            {
                this.mySet.Remove(item);
                removed = true;
            }
            return removed;
        }
        //returns true if the item is in the set otherwise false
        public bool Contains(T item)
        {
            return mySet.Contains(item);
        }
        //delegate function
        public  delegate bool F<T>(T elt);

        //Filters set acording the passed function
        public Set<T> Filter(F<T> filterFunction)
        {
            Set<T> newSet = new Set<T>();
            foreach (var item in mySet)
            {
                if (filterFunction(item))
                {
                    newSet.mySet.Add(item);
                }
            }
            return newSet;
        }



    //implementing IEnumerable interface
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in mySet)
            {
                yield return item;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        

    }
    // derived class which sorts the set
    public class SortedSet<T> : Set<T> where T : IComparable<T>
    {
        //constructor from base class then sort
        public SortedSet(IEnumerable<T> e) : base(e)
        {
            this.mySet.Sort();

        }
        //default constructor
        public SortedSet()
        {
            this.mySet = new List<T>();
        }
        //add item at specific place
        public override bool Add(T item)
        {
            int count = 0;
            bool added = false;
            if (!mySet.Contains(item))
            {
                foreach (var i in mySet.ToList())
                {
                    if (item.CompareTo(i) <= 0)
                    {
                        this.mySet.Insert(count, item);
                        added = true;
                        break;
                    }
                    count++;
                }
            }
            return added;
        }
        //same remove as in base class
        public override bool Remove(T item)
        {
            int count = 0;
            bool removed = false;
            foreach (var i in mySet.ToList())
            {
                if (item.CompareTo(i) == 0)
                {
                    this.mySet.RemoveAt(count);
                    removed = true;
                    break;
                }
                count++;
            }
            return removed;

        }
        //+operator overload
        public static SortedSet<T> operator +(SortedSet<T> lhs, SortedSet<T> rhs)
        {
            SortedSet<T> newSet = new SortedSet<T>();
            foreach (var item1 in rhs)
            {
                newSet.mySet.Add(item1);
            }
            // add all remaining element from the lhs to the new set 
            foreach (var item2 in lhs)
            {
                if (!rhs.Contains(item2))
                {
                    newSet.mySet.Add(item2);
                }
            }
            newSet.mySet.Sort();
            // return new set
            return newSet;
        }



    }

}


