using System;
using System.Collections.Generic;
using System.Linq;
using static MyLibrary.Maths.NumericExtension.Factors;

namespace MyLibrary.Maths.Fraction
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;
        private bool _integer = false;
        private int _number;        

        public int Numerator
        {
            get
            {
                return _numerator;
            }

            set
            {
                if (value == 0)
                {
                    _integer = true;
                    _number = 0;
                    _numerator = 0;
                }

                else { _numerator = value; _integer = false; }
            }
        }
        public int Denominator
        {
            get
            {
                return _denominator;
            }

            set
            {
                if(value==0)
                {
                    throw new Exception("impossibile");
                }

                else
                { _denominator = value; }
            }
        }

        #region Constructors
        public Fraction(int numerator,int denominator)
        {
            this._numerator = numerator;

            if (denominator != 0)
            { this._denominator = denominator; }
            else
            { throw new Exception("impossibile"); }
        }

        public Fraction(int n) : this(n, 1) { }

        public Fraction():this(1, 1) { }
        #endregion

        public override string ToString()
        {
            if(_integer)
            { return $"{_number}"; }
            return $"{_numerator}/{_denominator} ";
        }
        private static Tuple<Fraction,Fraction> EqualFractions(Fraction fra1, Fraction fra2)
        {
            var denom1 = fra1.Denominator;
            var denom2 = fra2.Denominator;
            if (fra1.Numerator==0)
            {
                return new Tuple<Fraction, Fraction>(new Fraction (fra2.Numerator,fra2.Denominator), new Fraction { Numerator = 0, Denominator = 1 });
            }

            else if(fra2.Numerator == 0)
            {
                return new Tuple<Fraction, Fraction>(new Fraction(fra1.Numerator,fra1.Denominator), new Fraction { Numerator = 0, Denominator = 1 });
            }
            //simbolico devo sistemare prima mcm.
            int denom = 1;
            //var denom = Getmcm_factors(denom1, denom2);
            var numer1 = (denom / denom1) * fra1.Numerator;
            var numer2 = (denom / denom2) * fra2.Numerator;

            return new Tuple<Fraction, Fraction>(new Fraction(numer1,denom), new Fraction(numer2,denom));
        }

        #region OverloadOperators
        //somma 
        public static Fraction operator +(Fraction fra1,Fraction fra2)
        {
            var equalFractions = Fraction.EqualFractions(fra1, fra2);
            var equalFra1 = equalFractions.Item1;
            var equalFra2 = equalFractions.Item2;

            return new Fraction((equalFra1.Numerator + equalFra2.Numerator), (equalFra1.Denominator));
        }        
        public static Fraction operator +(Fraction fra1, int n)
        {
            var fractionN = new Fraction(n);
            return fra1 + fractionN;
        }
        public static Fraction operator +(int n, Fraction fra1)
        {
            var fractionN = new Fraction(n);
            return fra1 + fractionN;
        }

        //differenza
        public static Fraction operator -(Fraction fra1, Fraction fra2)
        {
            var equalFractions = Fraction.EqualFractions(fra1, fra2);
            var equalFra1 = equalFractions.Item1;
            var equalFra2 = equalFractions.Item2;

            return new Fraction((equalFra1.Numerator - equalFra2.Numerator), (equalFra1.Denominator));
        }
        public static Fraction operator -(Fraction fra1, int n)
        {
            var fractionN = new Fraction(n);
            return fra1 - fractionN;
        }
        public static Fraction operator -(int n, Fraction fra1)
        {
            var fractionN = new Fraction(n);
            return fra1 - fractionN;
        }

        //prodotto
        public static Fraction operator *(Fraction fra1,Fraction fra2)
        {
            if(fra1.Numerator==0 || fra2.Numerator==0)
            {
                return new Fraction(0, 1);
            }
            var numerator = fra1.Numerator * fra2.Numerator;
            var denominator = fra1.Denominator * fra2.Denominator;
            //var mcd=GetMCD(numerator,denominator); numerator/=mcd; denomina...
            return new Fraction(numerator, denominator);
        }
        public static Fraction operator *(int n, Fraction fra1)
        {
            var fractionN = new Fraction(n);
            return fractionN * fra1;
        }
        public static Fraction operator *(Fraction fra1, int n)
        {
            var fractionN = new Fraction(n);
            return fractionN * fra1;
        }

        //quoziente
        public static Fraction operator /(Fraction fra1, Fraction fra2)
        {
            var fra2Reciproco = new Fraction(fra2.Denominator, fra2.Numerator);
            return fra1 * fra2Reciproco;
        }
        public static Fraction operator /(Fraction fra1, int n)
        {
            var fra2Reciproco = new Fraction(1, n);
            return fra1 * fra2Reciproco;
        }
        public static Fraction operator /(int n, Fraction fra1)
        {
            var fra1Reciproco = new Fraction(fra1.Denominator, fra1.Numerator);
            var nFraction = new Fraction(n, 1);
            return nFraction * fra1Reciproco;
        }
        #endregion

        #region conversion
        public static explicit operator int (Fraction fra)
        {
            return fra.Numerator / fra.Denominator;
        }
        public static implicit operator Fraction(int n)
        {
            return new Fraction(n, 1);
        }

        public static explicit operator double(Fraction fra)
        {
            return fra.Numerator / fra.Denominator;
        }
        public static implicit operator Fraction(double n)
        {
            return new Fraction((int)n, 1);
        }
        #endregion
    }
}
