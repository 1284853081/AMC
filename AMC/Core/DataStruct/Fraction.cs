using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Core.DataStruct
{
    public struct Fraction: IComparable
    {
        public long Molecule { get; private set; }
        public long Denominator { get; private set; }
        public Fraction(long molecule, long denominator)
        {
            if (denominator == 0) throw new ArgumentException();
            else if (molecule == 0)
            {
                Molecule = 0;
                Denominator = 1;
                return;
            }
            else if (denominator < 0)
            {
                molecule = -molecule;
                denominator = -denominator;
            }
            long m = Math.Abs(molecule);
            long d = Math.Abs(denominator);
            long gcd = Amath.GCD(m, d);
            Molecule = molecule / gcd;
            Denominator = denominator / gcd;
        }
        public Fraction Reciprocal() => new Fraction(Denominator, Molecule);
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            if (Denominator == 1 || Denominator == 0)
                str.Append(Molecule);
            else str.Append($"{Molecule}/{Denominator}");
            return str.ToString();
        }
        public int CompareTo(object value)
        {
            if (value == null) return 1;
            if (value is Fraction num)
            {
                if (this < num) return -1;
                if (this > num) return 1;
                return 0;
            }
            throw new ArgumentException();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public Fraction Inverse() => -this;
        public static Fraction operator +(Fraction left, Fraction right)
        {
            long lcm = Amath.LCM(left.Denominator, right.Denominator);
            return new Fraction(left.Molecule * lcm / left.Denominator + right.Molecule * lcm / right.Denominator, lcm);
        }
        public static Fraction operator +(Fraction left, long right)
        {
            return new Fraction(left.Molecule + right * left.Denominator, left.Denominator);
        }
        public static Fraction operator +(long left, Fraction right)
        {
            return new Fraction(right.Molecule + left * right.Denominator, right.Denominator);
        }
        public static Fraction operator -(Fraction left, Fraction right)
        {
            long lcm = Amath.LCM(left.Denominator, right.Denominator);
            return new Fraction(left.Molecule * lcm / left.Denominator - right.Molecule * lcm / right.Denominator, lcm);
        }
        public static Fraction operator -(Fraction left, long right)
        {
            return new Fraction(left.Molecule - right * left.Denominator, left.Denominator);
        }
        public static Fraction operator -(long left, Fraction right)
        {
            return new Fraction(left * right.Denominator - right.Molecule, right.Denominator);
        }
        public static Fraction operator -(Fraction fraction) => new Fraction(-fraction.Molecule, fraction.Denominator);
        public static Fraction operator *(Fraction left, Fraction right) => new Fraction(left.Molecule * right.Molecule, left.Denominator * right.Denominator);
        public static Fraction operator *(Fraction left, long right) => new Fraction(left.Molecule * right, left.Denominator);
        public static Fraction operator *(long left, Fraction right) => new Fraction(right.Molecule * left, right.Denominator);
        public static Fraction operator /(Fraction left, Fraction right) => left * right.Reciprocal();
        public static Fraction operator /(Fraction left, long right) => left * Amath.Reciprocal(right);
        public static Fraction operator /(long left, Fraction right) => left * right.Reciprocal();
        public static bool operator >(Fraction left, Fraction right) => (double)left > (double)right;
        public static bool operator <(Fraction left, Fraction right) => (double)left < (double)right;
        public static bool operator >=(Fraction left, Fraction right) => (double)left >= (double)right;
        public static bool operator <=(Fraction left, Fraction right) => (double)left <= (double)right;
        public static bool operator ==(Fraction left, Fraction right) => (double)left == (double)right;
        public static bool operator !=(Fraction left, Fraction right) => (double)left != (double)right;
        public static implicit operator Fraction(long num) => new Fraction(num, 1);
        public static explicit operator double(Fraction fraction) => (double)fraction.Molecule / fraction.Denominator;
        public static explicit operator long(Fraction num) => (long)Math.Floor((double)num);
    }
}
