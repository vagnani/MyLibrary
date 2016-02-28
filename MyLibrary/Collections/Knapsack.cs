﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Collections
{
    public class Knapsack
    {
        internal List<Element> _elements;
        internal List<List<Element>> _listMax;

        public Knapsack() { }
        public Knapsack(List<Element> elements)
        {
            _elements = elements;
        }

        public List<Element> TheHighest(int number)
        {
            _listMax = new List<List<Element>>();
            _listMax.Add(new List<Element>() { _elements[0] });
            SetAll(new List<Element>() { _elements[0] }, number, 0);

            throw new NotImplementedException();

            return null;
        }


        //private void SetAll(Coordinate _first, List<Coordinate> locked, int index)
        private void SetAll(List<Element> locked,int number, int index)
        {
            var copyListMax = CopyFrom(_listMax[index]);
            int copyIndex = index;

            if (_listMax[index].Count < number)
            {
                foreach (var item in _elements)
                {
                    if (_listMax[index].Count < number)
                    {
                        List<Element> copyLocked = CopyFrom(locked);

                        if (!locked.Contains(item))
                        {
                            if (copyIndex != index)
                            {
                                _listMax.Add(new List<Element>(copyListMax));
                                copyIndex = _listMax.Count - 1;
                            }

                            _listMax[copyIndex].Add(item);
                            copyLocked.Add(item);
                            SetAll(copyLocked, number, copyIndex);
                            index++;
                        }
                    }
                }
            }
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


        #region add string

        //public void AddString(string str)
        //{
        //    str.Trim();

        //    char excluded1 = '(';
        //    char excluded2 = ')';
        //    char excluded3 = ',';

        //    List<List<string>> all = new List<List<string>>();

        //    for (int index = 0; index < str.Count(); index++)
        //    {
        //        List<string> temp = new List<string>();

        //        //if (str[index] == excluded1)                
        //        string name = "";
        //        for (; index <= str.Count(); index++)
        //        {
        //            if (str[index] != excluded1 && str[index] != excluded2 && str[index] != excluded3) //exception
        //            {
        //                name += str[index];
        //            }

        //            if (str[index] == excluded3)
        //            {
        //                temp.Add(name);
        //                name = "";
        //            }

        //            if (str[index] == excluded2)
        //            {
        //                temp.Add(name);
        //                break;
        //            }
        //        }

        //        all.Add(temp);
        //    }

        //    List<string> mustContain = new List<string>() { _first.name };
        //    int countDone = 0;
        //    //int indexMust = 0;


        //    //to see again the function of islock, i mean when i must lock the iterazione
        //    for (int indexMust = 0; countDone < all.Count; indexMust++)
        //    {
        //        List<List<string>> rightToAdd = new List<List<string>>();

        //        foreach (var list in all)
        //        {
        //            if (list[0] == mustContain[indexMust])
        //            {
        //                rightToAdd.Add(list);
        //            }
        //        }

        //        if (rightToAdd.Count > 0)
        //        {
        //            foreach (var list in rightToAdd)
        //            {
        //                SetAllNodeString();

        //                //if(_allNodeString.Contains(list[0]))
        //                int indexFather = _allNodeString.FindIndex(x => x == list[0]);

        //                if (_allNodeString.Contains(list[1]))
        //                {
        //                    int indexSon = _allNodeString.FindIndex(x => x == list[1]);
        //                    AddAfter(_allNode[indexFather], _allNode[indexSon]);
        //                    _allNode[indexFather].value.Add(list[1], Convert.ToInt32(list[2]));
        //                    mustContain.Add(list[1]);
        //                    countDone++;
        //                }
        //                else
        //                {
        //                    var node = new MyLinkedListNode(list[1], new Dictionary<string, int>());
        //                    //check if it is added to _allNode
        //                    AddAfter(_allNode[indexFather], node);
        //                    _allNode[indexFather].value.Add(list[1], Convert.ToInt32(list[2]));
        //                    mustContain.Add(list[1]);
        //                    countDone++;
        //                }
        //            }
        //        }
        //    }
        //}           
        #endregion

    }

        public struct Element
    {
        internal string _name;
        internal int _value;
        internal int _weight;

        public Element(string name,int value,int weight)
        {
            this._name = name;
            this._value = value;
            this._weight = weight;
        }

        #region operatori (da definire)
        public static bool operator ==(Element ele1,Element ele2)
        {
            return false;
        }

        public static bool operator !=(Element ele1, Element ele2)
        {
            return false;
        }
        #endregion
    }
}
