using MyLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace MyLibrary.Collections
{
    public class MyLinkedList<T, TK>:IEnumerable<MyLinkedListNode<T, TK>>, ICollection<MyLinkedListNode<T, TK>>
    {
        internal List<MyLinkedListNode<T, TK>> _head;
        internal int _count = 1;

        public List<MyLinkedListNode<T, TK>> First
        {
            get
            {
                return _head;
            }
        }        

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<MyLinkedListNode<T, TK>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(MyLinkedListNode<T, TK> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _head = null;
        }

        public bool Contains(MyLinkedListNode<T, TK> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(MyLinkedListNode<T, TK>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(MyLinkedListNode<T, TK> item)
        {
            throw new NotImplementedException();
        }
    }

    internal class MyEnumerator<T, TK> : IEnumerator<MyLinkedListNode<T, TK>>
    {
        MyLinkedList<T, TK> mylink;
        private List<int>

        public MyEnumerator(MyLinkedList<T,TK> mylink)
        {
            this.mylink = mylink;
        }

        public MyLinkedListNode<T, TK> Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class MyLinkedListNode<T,TK>
    {
        internal List<MyLinkedListNode<T,TK>> _next;
        internal List<MyLinkedListNode<T,TK>> _prev;
        internal MyLinkedList<T, TK> _myLinkedList;
        internal Dictionary<List<T>, TK> _value;

        public MyLinkedListNode (List<T> name,TK value)
        {
            _value.Add(name, value);
        }

        internal MyLinkedListNode(MyLinkedList<T, TK> mylink, List<T> name, TK value):this (name, value)
        {
            _myLinkedList = mylink;
        }

        public override string ToString()
        {
            string toPrint = "";
            foreach(var key in _value)
            {
                bool aggiungi = false;
                toPrint += " (";

                foreach(var names in key.Key)
                {
                    toPrint += $"{names}, ";
                    if(aggiungi)
                    {
                        toPrint += $"{key.Value}";
                    }
                }
                toPrint += ")";
            }

            return toPrint;
        }

        public Dictionary<List<T>, TK> Value
        {
            get{ return _value; }
            set { _value = value; }
        }

        public MyLinkedListNode<T,TK> this[int index]
        {
            get
            {
                if(index>=0)
                {
                    return _next[index];
                }

                return _prev[(-index)];
            }
        }
    }
}

//AddAfter(LinkedListNode<T>, T)

//Aggiunge un nuovo nodo che contiene il valore specificato dopo il nodo esistente indicato nell'oggetto LinkedList<T>.
 
//System_CAPS_pubmethod AddAfter(LinkedListNode<T>, LinkedListNode<T>)
