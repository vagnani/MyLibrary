using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Maths.NumericExtension
{
    public static partial class Factors
    {
        public static int GetMCD(int a, int b)
        {
            if (b != 0)
            {
                if (a % b == 0)
                { return b; }

                int r = a % b;
                a = b;
                b = r;
                return GetMCD(a, b);
            }

            return a;
        }

        public static Dictionary<int, int> GetMCD_factors(this int[] array)
        {
            #region variabili e istruzioni pre-eliminari

            List<Dictionary<int, int>> allFattori = new List<Dictionary<int, int>>();

            //variabile che conterra il risultato finale
            Dictionary<int, int> MCD = new Dictionary<int, int>()
            {
                [1] = 1,
            };

            foreach (var n in array)
            {
                //chiamo metodo per ottenere tutti fattori primi
                allFattori.Add(PrimeFactorization(n));
            }
            #endregion

            #region core: foreach to find fattori comuni
            foreach (var nFattori1 in allFattori[0])
            {
                //tramite la variabile salvo valore false nel caso
                //un fattore non è presente nella scomposizione di un numero
                List<bool> isFattorePresente = new List<bool>();

                List<int> esponenti = new List<int>();

                //ho dovuto aggiungere subito esponente per problemi dopo
                esponenti.Add(nFattori1.Value);

                //serie di cicli foreach per trovare tutti i fattori
                foreach (var otherNumeric in allFattori)
                {
                    //se la scomposi di un n contiene gia il fattore di nFattori1
                    if (otherNumeric.ContainsKey(nFattori1.Key))
                    {
                        isFattorePresente.Add(true);

                        //cmq I add esponente xk non possono più save
                        // them again
                        esponenti.Add(otherNumeric[nFattori1.Key]);
                    }

                    else
                    {
                        isFattorePresente.Add(false);
                    }
                }

                bool thereIsAllFattore = isFattorePresente.Contains(false);

                if (thereIsAllFattore != true)
                {
                    esponenti.Sort();
                    MCD.Add(nFattori1.Key, esponenti[0]);
                }
            }
            #endregion

            return MCD;

            /*
            molto complicato
            */
        }
    }
}
