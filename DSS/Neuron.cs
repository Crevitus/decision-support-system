using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class Neuron
    {
        private double[] mInputs;
        private double mOutput;
        private bool mIsInput;
        private int mIndex;

        public double Output
        {
            get { return mOutput; }
        }

        public double[] Inputs
        {
            get { return mInputs; }
        }

        public int Index
        {
            get { return mIndex; }
        }

        public Neuron(int index, bool isInput)
        {
            mIndex = index;
            mIsInput = isInput;
        }

        public double compute(double input)
        {
            mOutput = input;
            mInputs = new double[] { input };
            return mOutput;
        }


        public double compute(double[] inputs, double bias)
        {
            double neuronSum = 0.0;
            mInputs = inputs;
            for (int i = 0; i < inputs.Length; i++)
            {
                neuronSum += inputs[i];
            }
            neuronSum += bias;
            mOutput = calcSigmoidActivation(neuronSum);
            return mOutput;
        }

        private double calcSigmoidActivation(double x)
        {
            return x = 1.0d / (1.0d + Math.Exp(-1 * x));
        }
    }
}
