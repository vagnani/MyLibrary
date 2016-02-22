//using MyLibrary.Collections;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Collections;

//namespace MyLibrary.Collections.Grafo
//{
//    public class MyLinkedList : IEnumerable<List<MyLinkedListNode>>
//    {
//        internal MyLinkedListNode _first;
//        internal MyLinkedListNode _goal;
//        internal int _count = 1;

//        public MyLinkedList(MyLinkedListNode first, MyLinkedListNode last)
//        {
//            _first = first; _goal = last;
//        }

//        public IEnumerator<List<MyLinkedListNode>> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class MyEnumerator : IEnumerator<List<MyLinkedListNode>>
//    {
//        private MyLinkedListNode _first;
//        private MyLinkedListNode _last;
//        private List<MyLinkedListNode> _current;

//        private List<int> _followingIndex;
//        private readonly int _countFirst;

//        private bool stop = false;
//        private bool changeIndexHead = false;

//        //ricordarsi di stop
//        #region other
//        public MyEnumerator(MyLinkedList mylink)
//        {
//            this._first = mylink._first;
//            _last = mylink._goal;
//            _countFirst = _first.NextCount;

//        }

//        object IEnumerator.Current
//        {
//            get
//            {
//                return Current;
//            }
//        }
//        public List<MyLinkedListNode> Current
//        {
//            get
//            {
//                if (!stop)
//                {
//                    return _current;
//                }

//                throw new IndexOutOfRangeException();
//            }
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//        #endregion

//        public bool MoveNext()
//        {
//            if (_current == null | _current.Count <= 2)
//            {
//                _current.Add(_first);
//            }


//            List<string> locked = new List<string>();
//            MyLinkedListNode current = null;

//            //Implementare aggiunta di tutte le classi     
//            //locked.Add(_first._next,false)
//            int _currentGrade =0;

//            while(true)
//            {
//               _currentGrade++;
//               if(_currentGrade>_followingIndex.Count)
//               {
//                    for (int n = 0; n < current.NextCount; n++)
//                    {
//                        var currentName = current.Next(n).name;

//                        if (locked.Contains(currentName)== false)
//                        {
//                            _followingIndex.Add(n);
//                            current = current.Next(n);
//                            _current.Add(current);
//                        }
//                    }
//                }
//            }
            

//            return false;
//        }

//        public void Reset()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    //rivedre metodo di blocco (isLock) per muoversi
//    public class MyLinkedListNode
//    {
//        internal List<MyLinkedListNode> _next;
//        internal List<MyLinkedListNode> _prev;
//        internal bool _isLock = false;
//        internal readonly string name;
//        internal Dictionary<string, int> value;

//        public MyLinkedListNode(string name, Dictionary<string, int> value)
//        {
//            this.name = name;
//            this.value = value;
//        }

//        public MyLinkedListNode Next(int n)
//        {
//            return _next[n];
//        }

//        public MyLinkedListNode Previous(int n)
//        {
//            return _prev[n];
//        }

//        public override bool Equals(object obj)
//        {
//            MyLinkedListNode external = obj as MyLinkedListNode;
//            if (this.name.Equals(external.name))
//            { return true; }

//            return false;
//        }        

//        public int NextCount
//        {
//            get
//            {
//                return _next.Count;
//            }
//        }

//        public int PreviousCount
//        {
//            get
//            {
//                return _prev.Count;
//            }
//        }
//    }
//}

////AddAfter(LinkedListNode<T>, T)

////Aggiunge un nuovo nodo che contiene il valore specificato dopo il nodo esistente indicato nell'oggetto LinkedList<T>.

////System_CAPS_pubmethod AddAfter(LinkedListNode<T>, LinkedListNode<T>)
