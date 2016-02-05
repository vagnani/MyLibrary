using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Maths.NumericExtension
{
    public static partial class Factors
    {
        public static Dictionary<int, int> Getmcm_factors(params int[] array)
        {
            #region variabili e operazioni pre-eliminari

            //conterra tutti i fattori con i relativi esponenti di tutte le scomposizioni
            List<Dictionary<int, int>> allFattori = new List<Dictionary<int, int>>();

            //lista che conterrà il fattore con tutti i relativi esponenti
            Dictionary<int, List<int>> fattoreAndHisEsponenti = new Dictionary<int, List<int>>();

            //variabile che conterra il risultato finale
            Dictionary<int, int> mcm = new Dictionary<int, int>() { [1] = 1 };
            int[] keys;

            foreach (var n in array)
            {
                //chiamo metodo per ottenere tutti fattori primi
                allFattori.Add(PrimeFactorization(n));
            }
            #endregion

            #region core

            foreach (var fattori in allFattori)
            {
                foreach (var n in fattori)
                {
                    if (mcm.ContainsKey(n.Key))
                    {
                        fattoreAndHisEsponenti[n.Key].Add(n.Value);
                    }

                    else
                    {
                        mcm.Add(n.Key, 1);
                        fattoreAndHisEsponenti.Add(n.Key, new List<int>());
                        fattoreAndHisEsponenti[n.Key].Add(n.Value);
                    }
                }
            }

            keys = mcm.Keys.ToArray();

            foreach (var n in keys)
            {
                List<int> esponenti = fattoreAndHisEsponenti[n];
                int[] esp = esponenti.ToArray();
                Array.Sort(esp);

                mcm[n] = esp[esp.Length - 1];
            }

            #endregion                       

            return mcm;
        }
    }
}
