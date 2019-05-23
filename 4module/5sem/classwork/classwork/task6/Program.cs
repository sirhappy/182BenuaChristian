using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task6
{

    public class BinomialCoefficients
    {
        private int _alreadyCalced;
        private List<List<long>> _coefs;

        public BinomialCoefficients()
        {
            _alreadyCalced = 1;
            _coefs = new List<List<long>>();
            _coefs.Add(new List<long>(2));
            _coefs[0].Add(1);
        }

        public void CalcUpTo(int n)
        {
            if (_alreadyCalced >= n)
            {
                return;
            }

            for (int i = (_coefs.Count); i <= n; ++i)
            {
                _coefs.Add(new List<long>(i));

                for (int j = 0; j <= i; ++j)
                {
                    _coefs[_coefs.Count - 1].Add(Recalc(_coefs.Count - 1, j ));
                }
            }

            _alreadyCalced = n;
            Print();
        }

        private void Print()
        {
            foreach (var cn in _coefs)
            {
                foreach (var cnk in cn)
                {
                    Console.Write(cnk + " ");
                }
                Console.WriteLine();
            }
        }

        private long Recalc(int n, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            long ans = 0;
            if (n > 0 && k <= n - 1)
            {
                ans += _coefs[n - 1][k];
            }

            if (n > 0 && k > 0)
            {
                ans += _coefs[n - 1][k - 1];
            }

            return ans;
        }

        public long this[int n, int k]
        {
            get
            {

                CalcUpTo(n + 1);
                var val = _coefs[n][k];
                return val;
            }
        }
        
    }


    public class Distribution : IEnumerable<double>
    {
        private BinomialCoefficients _coefficients;
        private double _p;
        private int _n;

        private double Q
        {
            get { return 1 - _p; }
        }

        public Distribution(BinomialCoefficients _coef, double p, int n)
        {
            this._coefficients = _coef;
            this._p = p;
            this._n = n;

        }
        public IEnumerator<double> GetEnumerator()
        {
            for (int i = 0; i <= _n; ++i)
            {
                yield return _coefficients[_n, i] * Math.Pow(_p, i) * Math.Pow(Q, _n - i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            double p = 0.5;
            int n = 10;
            var coefs = new BinomialCoefficients();
           
            var dist = new Distribution(coefs, p, n);
            foreach (var el in dist)
            {
                Console.Write(el + " ");
            }
        }
    }
}