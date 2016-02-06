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

    public class MyEnumerator<T, TK> : IEnumerator<List<MyLinkedListNode<T, TK>>>
    {
        private List<MyLinkedListNode<T, TK>> _head;
        private List<MyLinkedListNode<T, TK>> _current;        
        private List<int> _followingIndex;
        private int _currentIndexHead = -1;
        private bool stop = false;
        private bool changeIndexHead = false;
        
        //ricordarsi di aumentare _currentIndex

        public MyEnumerator(MyLinkedList<T,TK> mylink)
        {
            this._head = mylink._head;
            int _countHead = _head.Count-1;
                        
            for(int n=0;n<=_countHead;n++)
            {
                _followingIndex.Add(n);
            }
        }        
        

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public List<MyLinkedListNode<T, TK>> Current
        {
            get
            {
                if (!stop)
                {
                    return _current;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if(!IsLast())
            {
                _current = null;_current = new List<MyLinkedListNode<T, TK>>();
                SetNextList();
                return true;
            }

            stop = true;
            return false;
        }

        private void SetNextList()
        {
            if(_currentIndexHead<0 || changeIndexHead==true)
            {
               _currentIndexHead++;
                _followingIndex = null;_followingIndex = new List<int>();
            }

            var currentNode = _head[_currentIndexHead];
            //numero di elementi passati
            int position = -1;         

            while(true)
            {
                _current.Add(currentNode);

                if(currentNode.NextCount<1 || currentNode._next==null)
                {
                    break;
                }
                position++;
                if(_followingIndex.Count<=position)
                {
                    _followingIndex.Add(0);
                    _current.Add(currentNode);
                }
                
            }
        }

        private bool IsLast()
        {
            var lastNodeHead = _head[_head.Count - 1];
            int indexLast = lastNodeHead.PreviousCount - 1;
            var last = lastNodeHead[indexLast];

            if(_current.Equals(last))
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _followingIndex = null;
            int _countHead = _head.Count - 1;

            for (int n = 0; n <= _countHead; n++)
            {
                _followingIndex.Add(n);
            }
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

        public int NextCount
        {
            get
            {
                return _next.Count;
            }
        }

        public int PreviousCount
        {
            get
            {
                return _prev.Count;
            }
        }
    }
}

//AddAfter(LinkedListNode<T>, T)

//Aggiunge un nuovo nodo che contiene il valore specificato dopo il nodo esistente indicato nell'oggetto LinkedList<T>.
 
//System_CAPS_pubmethod AddAfter(LinkedListNode<T>, LinkedListNode<T>)
