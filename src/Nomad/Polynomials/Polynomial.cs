using System;
using System.Collections.Generic;
using System.Linq;

namespace Nomad.Polynomials
{
    public class Polynomial
    {
        public List<double> Coefficients;
        public double Value;

        public Polynomial()
        {
            Value = 0;
            Coefficients = new List<double> { 1 };
        }

        public Polynomial(double value)
        {
            Value = 0;
            Coefficients = new List<double> { value };
        }

        public Polynomial(List<double> Coeffs)
        {
            Value = 0;
            Coefficients = Coeffs;
        }

        public Polynomial(Polynomial copy)
        {
            Value = 0;
            Coefficients = copy.Coefficients;
        }

        public Polynomial(double[] Coeffs)
        {
            Value = 0;
            Coefficients = Coeffs.ToList();
        }

        public double Evaluate(double X)
        {
            double result = 0;
            for (int i = Coefficients.Count - 1; i >= 0 ; i--)
                result += Math.Pow(X, i) * Coefficients[i];
            return result;
        }

        public static Polynomial operator+(Polynomial first, Polynomial second)
        {

            return new Polynomial();
        }
    }
}
