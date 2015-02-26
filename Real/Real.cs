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


        public static RealNumber operator -(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number - b.Number);
            }
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


        public static RealNumber operator *(RealNumber a, RealNumber b)
        {
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return new RealNumber(a.Number * b.Number);
            }
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


        public static RealNumber operator /(RealNumber a, RealNumber b)
        {
            if (b.Number.IsZero)
            {
                throw new DivideByZeroException("Zero division error");
            }
            if (a.Exponent <= 0 && b.Exponent <= 0)
            {
                return  new RealNumber(SetCommaDiv(Divide(a, b),a.Exponent - b.Exponent));
            }
                if (a.Exponent < b.Exponent)
                {
                    a = BalanceNumber(a, b.Exponent);
                }
                else if (b.Exponent < a.Exponent)
                {
                    b = BalanceNumber(b, a.Exponent);
                }

                return new RealNumber(SetCommaDiv(Divide(a, b),0));
        }

        public static string Divide(RealNumber a, RealNumber b, int precision = 15)
        {
            string result = "";
            BigInteger rem = 1;
            int i = 1;
            var num = a.Number;
            var denom = b.Number;
            while (!(result.ToString().Length - result.ToString().IndexOf('.') > precision) && !rem.IsZero)
            {
                result = String.Concat(result, BigInteger.DivRem(num, denom, out rem));
                if (i == 1)
                {
                    result = string.Concat(result, '.');
                    i++;
                }
                if (!rem.IsZero)
                {
                    num = BigInteger.Multiply(rem, 10);
                    if ((denom.ToString().Length - rem.ToString().Length - 1) > 0)
                    {
                        num = BigInteger.Multiply(num, BigInteger.Pow(10, denom.ToString().Length - rem.ToString().Length - 1));
                        result = result.PadRight(result.Length + (denom.ToString().Length - rem.ToString().Length - 1), '0');
                    }
                    if (BigInteger.Compare(num, denom) < 0)
                    {
                        num = BigInteger.Multiply(num, 10);
                        result = string.Concat(result, '0');
                    }
                }
            }
            return result;
        }

        public static string SetCommaDiv(string result, int maxexp)
        {
            string res = "";
            var comma = result.IndexOf('.');
            var diff = BigInteger.Subtract(comma, maxexp);
            result = result.Remove(comma, 1);
            if (diff.Sign < 0 || (diff.Sign == 0 && maxexp > 0))
            {
                for (BigInteger i = 0; i < -diff; i++)
                {
                    result = String.Format("0{0}", result);
                }
                res = String.Format("0.{0}", result);
            }
            else if (diff.Sign > 0 && diff <= result.Length)
            {
                res = result.Insert((int)diff, ".");
            }
            else
            {
                res = result;
            }
            return res;
        }




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
