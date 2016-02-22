//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MyLibrary.Maths.Fraction;

//namespace MyLibrary.Collection
//{
//    public class MyList<T>: IEnumerable<T>,ICollection<T>,IList<T>
//    {
//        private T[] array;
//        private int realLength;

//        #region ICollection properties
//        public int Count
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//        }

//        public bool IsReadOnly
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//        }
//        #endregion

//        #region IList property
//        public T this[int index]
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }

//            set
//            {
//                throw new NotImplementedException();
//            }
//        }
//        #endregion

//        #region Costruttore
//        public MyList(int index)
//        {
//            array = new T[IncreaseMyList(index)];
//            realLength = index;
//        }

//        public MyList(): this(1) { }
//        #endregion

//        private int IncreaseMyList(int index,bool fall=false)
//        {
//            int indexIncreased = 1;
//            if(!fall) { indexIncreased=(int)((new Fraction(1, 2) + index)); }
            
//            return indexIncreased+array.Length;
//        }

//        private void Resize(int index)
//        {            
//            Array.Resize(ref array, IncreaseMyList(index));            
//        }

//        #region IEnumerable
//        public IEnumerator<T> GetEnumerator()
//        {
//            return ((IEnumerable<T>)array).GetEnumerator();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return ((IEnumerable<T>)array).GetEnumerator();
//        }
//        #endregion

//        #region ICollection method
//        public void Add(T item)
//        {
//            if(array.Length>realLength)
//            {
//                array[realLength] = item;
//                realLength++;
//            }
//            else
//            {
//                Resize(2); realLength++;
//                array[realLength] = item;
//            }
//        }

//        public void Clear()
//        {
//            array = new T[array.Length];
//        }

//        public bool Contains(T item)
//        {
//            return array.Contains(item);
//        }

//        public void CopyTo(T[] array, int arrayIndex)
//        {
//            this.array.CopyTo(array, arrayIndex);
//        }

//        public bool Remove(T item)
//        {
//            int x = Array.FindIndex(array, (T itemLamba) => { if (itemLamba.Equals(item)) { return true; } return false; });
//            var arrayCopy = array;
//            Array.Resize(ref array, array.Length - 1);
//            return true;
//        }
//        #endregion

//        #region IList method
//        public int IndexOf(T item)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(int index, T item)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveAt(int index)
//        {
//            throw new NotImplementedException();
//        }
//        #endregion

//    }
//}
