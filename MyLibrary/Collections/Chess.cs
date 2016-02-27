using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Collections
{
    public class MyChessBoard : IEnumerable<List<Coordinate>>
    {
        internal Coordinate _start;
        internal Coordinate _arrive;

        internal Coordinate _limit;
        internal List<Coordinate> _locked;
        internal Dictionary<string, Coordinate> _award;
        internal List<string> _directions;

        public MyChessBoard() { }
        public MyChessBoard( Coordinate start, Coordinate arrive, Coordinate limit,
         List<Coordinate> locked, Dictionary<string, Coordinate> award,List<string> directions)
        {
            _start = start; _arrive = arrive;_limit = limit;_locked = locked; _award = award;_directions = directions;
        }

        public IEnumerator<List<Coordinate>> GetEnumerator()
        {
            return new MyEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator : IEnumerator<List<Coordinate>>
    {
        private int index = -1;
        private List<List<Coordinate>> _listMax;
        private List<List<Coordinate>> final;
        private MyChessBoard chess;

        public MyEnumerator() { }
        public MyEnumerator(MyChessBoard chess):this()
        {
            this.chess = chess;
            _listMax.Add(new List<Coordinate>() { chess._start });
            SetAll(chess._start, new List<Coordinate>() {chess._start}, 0);
        }

        public List<Coordinate> Current
        {
            get
            {
                return final[index];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if(index>=final.Count)
            {
                return false;
            }

            index++;
            return true;
        }

        private void SetAll(Coordinate _first, List<Coordinate> locked, int index)
        {
            var copyListMax = CopyFrom(_listMax[index]);
            int copyIndex = index;

            foreach (var nodePossible in chess._directions)
            {                
                List<Coordinate> copyLocked = CopyFrom(locked);
                var possibleCoordinate = MoveByDirection(nodePossible, _first);

                if (possibleCoordinate<chess._limit && 
                    !chess._locked.Contains(possibleCoordinate, possibleCoordinate) && 
                    !locked.Contains(possibleCoordinate, possibleCoordinate))
                {
                    if (copyIndex != index)
                    {
                        _listMax.Add(new List<Coordinate>(copyListMax));
                        copyIndex = _listMax.Count - 1;
                    }

                    _listMax[copyIndex].Add(possibleCoordinate);
                    copyLocked.Add(possibleCoordinate);
                    SetAll(possibleCoordinate, copyLocked, copyIndex);
                    index++;
                }
            }
        }
        
        private Coordinate MoveByDirection(string direction,Coordinate coor)
        {
            #region est 
            if (direction=="nne")
            {
                return coor + new int[] { 1, +2 };
            }

            if (direction == "ene")
            {
                return coor + new int[] { 2, +1 };
            }

            if (direction == "ese")
            {
                return coor + new int[] { 2, -1 };
            }

            if (direction == "sse")
            {
                return coor + new int[] { 1, -2 };
            }
            #endregion

            #region ovest
            if (direction == "nno")
            {
                return coor + new int[] { -1, +2 };
            }

            if (direction == "ono")
            {
                return coor + new int[] { -2, +1 };
            }

            if (direction == "oso")
            {
                return coor + new int[] { -2, -1 };
            }

            if (direction == "sso")
            {
                return coor + new int[] { -1, -2 };
            }
            #endregion

            return new Coordinate(0, 0);
        }

        private T CopyFrom<T>(T list) where T : class, IEnumerable, ICollection, IList, new()
        {
            T result = new T();
            foreach (var n in list)
            {
                result.Add(n);
            }
            return result;
        }

        public void Reset()
        {
            index = -1;
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

    public struct Coordinate:IEqualityComparer<Coordinate>
    {
        int x;
        int y;

        public Coordinate(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator >(Coordinate obj1,Coordinate obj2)
        {
            if(obj1.x>obj2.x && obj1.y>obj2.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Coordinate obj1, Coordinate obj2)
        {
            if (obj1.x < obj2.x && obj1.y < obj2.y)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var obj1 = (Coordinate)obj;
            return this.x==obj1.x && this.y==obj1.y;
        }

        #region IEqualityCmparer
        public bool Equals(Coordinate x, Coordinate y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Coordinate obj)
        {
            return (obj.x + obj.y).GetHashCode();
        }
        #endregion

        #region Operator
        public static bool operator ==(Coordinate obj1, Coordinate obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Coordinate obj1, Coordinate obj2)
        {
            if(obj1.Equals(obj2))
            {
                return false;
            }

            return true;
        }
        
        public static Coordinate operator +(Coordinate obj1,int[] xy)
        {
            return new Coordinate(obj1.x + xy[0], obj1.y + xy[1]);
        }
        #endregion
    }
}
