using MyLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace MyLibrary.Collections.Grafo
{
    public class MyLinkedList
    {
        internal List<MyLinkedListNode> _head;
        internal int _count = 1;
    }

    public class MyEnumerator: IEnumerator<List<MyLinkedListNode>>
    {
        private List<MyLinkedListNode> _head;
        private List<MyLinkedListNode> _current;

        private List<int> _followingIndex;
        private int _currentIndexHead = -1;

        private bool stop = false;
        private bool changeIndexHead = false;

        //ricordarsi di aumentare _currentIndex
        //ricordarsi di stop

        public MyEnumerator(MyLinkedList mylink)
        {
            this._head = mylink._head;
            int _countHead = _head.Count - 1;

            for (int n = 0; n <= _countHead; n++)
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
        public List<MyLinkedListNode> Current
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
            if (!IsLast())
            {
                _current = null; _current = new List<MyLinkedListNode>();
                SetNextList();
                return true;
            }

            stop = true;
            return false;
        }

        private void SetNextList()
        {
            if (_currentIndexHead < 0 || changeIndexHead == true)
            {
                _currentIndexHead++;
                _followingIndex = null; _followingIndex = new List<int>();
            }

            var currentNode = _head[_currentIndexHead];
            //numero di elementi passati
            int position = -1;

            while (true)
            {
                _current.Add(currentNode);

                if (currentNode.NextCount < 1 || currentNode._next == null)
                {
                    break;
                }
                position++;
                if (_followingIndex.Count <= position)
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
            var last = lastNodeHead.Previous(indexLast);

            if (_current.Equals(last))
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _followingIndex = null; _followingIndex = new List<int>();
            int _countHead = _head.Count - 1;

            for (int n = 0; n <= _countHead; n++)
            {
                _followingIndex.Add(n);
            }
        }
    }

    public class MyLinkedListNode
    {
        internal List<MyLinkedListNode> _next;
        internal List<MyLinkedListNode> _prev;
        internal bool _isLock=false;
        internal readonly string name;
        internal Dictionary<string, int> value;

        public MyLinkedListNode(string name, Dictionary<string, int> value)
        {
            this.name = name;
            this.value = value;
        }

        public Tuple<bool,MyLinkedListNode> Next(int n)
        {
            if(!_isLock)
            {
                return new Tuple<bool, MyLinkedListNode>(true, _next[n]);
            }

            return null;
        }

        public Tuple<bool, MyLinkedListNode> Previous(int n)
        {
            if (!_isLock)
            {
                return new Tuple<bool, MyLinkedListNode>(true, _prev[n]);
            }

            return null;
        }

        public override bool Equals(object obj)
        {
            MyLinkedListNode external = obj as MyLinkedListNode;
            if(this.name.Equals(external.name))
            { return true; }

            return false;
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
