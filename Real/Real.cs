using System;
using System.Linq;
using System.Numerics;

namespace Real
{
    [Serializable]
    public struct RealNumber : IFormattable, IComparable, IComparable<RealNumber>, IEquatable<RealNumber>
    {
        private int Exponent { get; set; }

        public BigInteger Number { get; set; }

        public RealNumber(string number) : this()
        {
            BigInteger Number;
            number.SingleOrDefault(t => t == '.');
            if (number.IndexOf('.') > 0)
            {
                Exponent = number.Length - number.IndexOf('.') - 1;
            }
            else
            {
                Exponent = 0;
            }
            if (BigInteger.TryParse(number.Replace(".",""), out Number))
            {
                this.Number = Number;
            }
            else
            {
                throw new InvalidCastException("Numero non valido");
            }
        }

        public RealNumber(BigInteger number):this()
        {
            this.Number = number;
            this.Exponent = 0;
        }


        public RealNumber(BigInteger number,int expo)
            : this()
        {
            this.Number = number;
            this.Exponent = expo;
        }

        public override string ToString()
        {
            var num = Number.ToString();
            if (Exponent > 0 && Exponent < num.Length)
            {
                return num.Substring(0, num.Length - Exponent) + '.' + num.Substring(num.Length - Exponent);
            }
            else if(Exponent >= num.Length)
            {
                var diff = Exponent - num.Length;
                return "0." + new string('0', diff) + num.Substring(0, num.Length);
            }
            return num;
        }


        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(RealNumber other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(RealNumber other)
        {
            return other.Number == Number;
        }

        private static RealNumber BalanceNumber(RealNumber a,int Exponent)
        {
            if (a.Exponent < Exponent && Exponent > 0)
            {
                var diff = Exponent - a.Exponent;
                a.Number = a.Number* BigInteger.Pow(10,diff);
            }
            return a;
        }


        public static RealNumber operator +(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number + b.Number);
            }
            else
            {
                if (a.Exponent < b.Exponent)
                {
                    a = BalanceNumber(a, b.Exponent);
                }
                else if (b.Exponent < a.Exponent)
                {
                    b = BalanceNumber(b, a.Exponent);
                }

                return new RealNumber(a.Number + b.Number, Max(a.Exponent,b.Exponent));
            }
            return new RealNumber();
        }


        public static RealNumber operator -(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number - b.Number);
            }
            else
            {
                if (a.Exponent < b.Exponent)
                {
                    a = BalanceNumber(a, b.Exponent);
                }
                else if (b.Exponent < a.Exponent)
                {
                    b = BalanceNumber(b, a.Exponent);
                }

                return new RealNumber(a.Number - b.Number, Max(a.Exponent, b.Exponent));
            }
            return new RealNumber();
        }


        public static RealNumber operator *(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number * b.Number);
            }
            else
            {
                if (a.Exponent < b.Exponent)
                {
                    a = BalanceNumber(a, b.Exponent);
                }
                else if (b.Exponent < a.Exponent)
                {
                    b = BalanceNumber(b, a.Exponent);
                }

                return new RealNumber(a.Number * b.Number, 2*Max(a.Exponent, b.Exponent));
            }
            return new RealNumber();
        }


        public static RealNumber operator /(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number / b.Number);
            }
            else
            {
                if (a.Exponent < b.Exponent)
                {
                    a = BalanceNumber(a, b.Exponent);
                }
                else if (b.Exponent < a.Exponent)
                {
                    b = BalanceNumber(b, a.Exponent);
                }

                return new RealNumber(a.Number / b.Number, a.Exponent - b.Exponent);
            }
            return new RealNumber();
        }

        //private static string Divide(RealNumber a, RealNumber b,int precision = 15)
        //{
        //    BigInteger rest;
        //    var result = BigInteger.DivRem(a.Number, b.Number, out rest);

        //}

        private static  int Max(int expo1,int expo2)
        {
            return expo1 < expo2 ? expo2 : expo1;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
