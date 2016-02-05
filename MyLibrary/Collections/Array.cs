using System;
using System.Collections.Generic;
using System.Collections;

namespace MyLibrary.Collection
{
    public static class ArrayExtension
    {
        public static int FindIndex(this int[] array, int n)
        {
            int index = array.Length / 2; ;
            System.Array.Sort(array);

            do
            {
                if (index > array.Length - 1) { Console.Write(" metodo da ridefinire."); Console.ReadKey(); }
                if (array[index] == n)
                { break; }

                if (array[index] > n)
                {
                    index = (index / 2) * 3;
                }

                else
                {
                    index = (index / 2);
                }
            }
            while (true);

            return index;
        }

        //scambiare il valore di due oggetti
        public static void Swape<U>(ref U primo, ref U secondo)
        {
            var copiaPrimo = primo;
            primo = secondo;
            secondo = copiaPrimo;

        }

        public static void BubbleSort<T>(T[] array, bool is_CrescenteTrue_DecrescenteFalse = true) where T : struct, IComparable
        {
            if (is_CrescenteTrue_DecrescenteFalse)
            {
                T[] copiaArray = array; T[] copiaArray2 = array;

                for (int indice = 0; indice < array.GetLength(0); indice++)
                {
                    for (int indice2 = 0; indice2 < array.GetLength(0); indice2++)
                    {
                        int valoreCompare = array[indice].CompareTo(copiaArray2[indice2]);

                        // se il segno è <, li mette in ordine crescente
                        // se il segno è >, li mette in ordine decrescente
                        // non so perchè
                        if (valoreCompare < 0)
                        {
                            T copia = copiaArray[indice];
                            copiaArray[indice] = copiaArray2[indice2];
                            copiaArray[indice2] = copia;
                        }
                    }

                    array = copiaArray;
                }
            }

            else
            {
                T[] copiaArray = array; T[] copiaArray2 = array;

                for (int indice = 0; indice < array.GetLength(0); indice++)
                {
                    for (int indice2 = 0; indice2 < array.GetLength(0); indice2++)
                    {
                        int valoreCompare = array[indice].CompareTo(copiaArray2[indice2]);

                        // se il segno è <, li mette in ordine crescente
                        // se il segno è >, li mette in ordine decrescente
                        if (valoreCompare < 0)
                        {
                            T copia = copiaArray[indice];
                            copiaArray[indice] = copiaArray2[indice2];
                            copiaArray[indice2] = copia;
                        }
                    }

                    array = copiaArray;
                }
            }
        }

        public static T[] SortingNetwork<T>(T[] array)
        {
            throw new NotImplementedException();            
        }
    }
}
