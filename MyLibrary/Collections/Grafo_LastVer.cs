using MyLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace MyLibrary.Collections.Grafo
{
    public class MyLinkedList : IEnumerable<List<MyLinkedListNode>>
    {
        internal MyLinkedListNode _first;
        internal MyLinkedListNode _goal;        

        public MyLinkedList(MyLinkedListNode first, MyLinkedListNode last)
        {
            _first = first; _goal = last;
        }

        public IEnumerator<List<MyLinkedListNode>> GetEnumerator()
        {
            return (IEnumerator<List<MyLinkedListNode>>)(new MyEnumerator(this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator: IEnumerator<List<MyLinkedListNode>>
    {
        private MyLinkedListNode _first;
        private MyLinkedListNode _last;
        private int _index=-1;

        private List<List<MyLinkedListNode>> _listMax;
        private List<List<MyLinkedListNode>> _finalList;

        public List<MyLinkedListNode> Current
        {
            get
            {
                if(_index<_finalList.Count)
                    return _finalList[_index];
                throw new IndexOutOfRangeException();
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
              
        public MyEnumerator(MyLinkedList mylink)
        {
            this._first = mylink._first;
            _last = mylink._goal;            
        }
        
        public bool MoveNext()
        {
            if(_listMax.Count<1)
            {
                _listMax.Add(new List<MyLinkedListNode>() { _first });
                SetAll(_first, new List<MyLinkedListNode>() { _first}, _listMax.Count-1);
                CheckRightList();
            }

            _index++;
            if (_index >= _finalList.Count)
                return false;
            return true;
        }

        private void CheckRightList()
        {
            foreach(var node in _listMax)
            {
                if (node[node.Count - 1].Equals(_last))
                    _finalList.Add(node);
            }
        }

        private void SetAll(MyLinkedListNode _first, List<MyLinkedListNode> locked, int index)
        {
            var copyListMax = _listMax[index];            
            int copyIndex = index;

            foreach(var node in _first._next)
            {
                var copyLocked = locked;
                if (!locked.Contains(node,(IEqualityComparer<MyLinkedListNode>)node))
                {
                    if(copyIndex!=index)
                    {
                        _listMax.Add(new List<MyLinkedListNode>(copyListMax));
                        copyIndex = _listMax.Count - 1;
                    }

                    _listMax[copyIndex].Add(node);
                    copyLocked.Add(node);
                    SetAll(node, copyLocked, copyIndex);
                    index++;
                }
            }
        }

        public void Reset()
        {
            _index = -1;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MyEnumerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    
    public class MyLinkedListNode:IEqualityComparer<MyLinkedListNode>
    {
        internal List<MyLinkedListNode> _next;
        internal List<MyLinkedListNode> _prev;
        internal bool _isLock = false;
        internal readonly string name;
        internal Dictionary<string, int> value;

        public MyLinkedListNode(string name, Dictionary<string, int> value)
        {
            this.name = name;
            this.value = value;
        }

        public MyLinkedListNode Next(int n)
        {
            return _next[n];
        }

        public MyLinkedListNode Previous(int n)
        {
            return _prev[n];
        }

        public override bool Equals(object obj)
        {
            MyLinkedListNode external = obj as MyLinkedListNode;
            if (this.name.Equals(external.name))
            { return true; }

            return false;
        }

        #region interface
        public bool Equals(MyLinkedListNode x, MyLinkedListNode y)
        {
            if (x.name.Equals(y.name))
            { return true; }

            return false;
        }
        public int GetHashCode(MyLinkedListNode obj)
        {
            return obj.name.GetHashCode();
        }
        #endregion

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
