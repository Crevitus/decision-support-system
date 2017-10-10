using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class CSVNormalisation
    {
        public void normaliseAll(double[] minArray, double[] maxArray, List<double[]> data, 
            out List<double[]> normalisedData)
        {
            normalisedData = new List<double[]>();
            foreach(double[] row in data)
            {
                double[] normalisedRow = new double[row.Length - 1];
                normalise(minArray, maxArray, row, out normalisedRow);
                normalisedData.Add(normalisedRow);
            }
        }

        public void normalise(double[] minArray, double[] maxArray, double[] row,
            out double[] normalisedRow)
        {
            normalisedRow = new double[row.Length];
            for (int i = 0; i < row.Length; i++)
            {
                normalisedRow[i] = (row[i] - minArray[i]) / (maxArray[i] - minArray[i]);
            }
        }

        public double deNormalise(double min, double max, double input)
        {
               return ((min - max) * input - min) / -1;
        }
    }
}
