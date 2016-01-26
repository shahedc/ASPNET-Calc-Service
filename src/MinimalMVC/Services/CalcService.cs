using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalMVC.Services
{
    public class CalcService : ICalcService
    {
        public int AddNumbers(int x, int y)
        {
            return x + y ;
        }

        public int SubtractNumbers(int x, int y)
        {
            return x - y;
        }
        

        public int AddNumbersIfSuccessful(int x, int y, IExternalService es)
        {
            if (es.DoGreatThings())
                return x + y;
            else
                return -999;
        }

        public int MultiplyNumbers(int x, int y)
        {
            return x * y;
        }

        public bool IsEven(int x)
        {
            if ((x % 2) == 0)
                return true;
            else
                return false;
        }

        public bool IsEvenOrOdd(int x)
        {
            if ((x % 2) == 0)
                return true;
            else
                return false;
        }
        public int UnsafeDivide(int x, int y)
        {
            return (x / y);
        }

        public double SafeDivide(int x, int y)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(x) / y;
            }
            catch (DivideByZeroException e)
            {
                return -1;
            }
            return result;
        }
    }
}
