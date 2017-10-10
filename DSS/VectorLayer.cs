using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class VectorLayer
    {
        private const double mBias = 1.0;
        private double mBiasWeight;
        private Layer mInput, mJOutput;
        private int mIndex;
        private List<double[]> mWeights, mOutputs;
        public VectorLayer(Layer i, Layer j, int index)
        {
            mInput = i;
            mJOutput = j;
            mIndex = index;
        }

        public List<double[]> Weights
        {
            get { return mWeights; }
            set { mWeights = value; }
        }

        public double BiasWeight
        {
            get { return mBiasWeight; }
            set { mBiasWeight = value; }
        }

        public double Bias
        {
            get { return mBiasWeight * mBias; }
        }

        public int Index
        {
            get { return mIndex;  }
        }

        public Layer Input
        {
            get { return mInput; }
        }

        public Layer JOutput
        {
            get { return mJOutput; }
        }

        public void updateBiasWeight(double weight)
        {
            mBiasWeight += weight;
        }

        public void setWeights()
        {
            mWeights = new List<double[]>();
            Random rand = new Random();
            double[] tempSet;
            for (int i = 0; i < mJOutput.NeuronCount; i++)
            {
                tempSet = new double[mInput.NeuronCount];
                for (int j = 0; j < mInput.NeuronCount; j++)
                {
                    tempSet[j] = rand.NextDouble();
                }
                mWeights.Add(tempSet);
            }
            mBiasWeight = rand.NextDouble();
        }

        public List<double[]> synapse()
        {
            mOutputs = new List<double[]>();
            for (int c = 0; c < mJOutput.NeuronCount; c++)
            {
                double[] values = new double[mInput.NeuronCount];
                for (int w = 0; w < mInput.NeuronCount; w++)
                {
                    values[w] = mWeights[c][w] * mInput.Neurons[w].Output;
                }
                mOutputs.Add(values);
            }
            return mOutputs;
        }
    }
}
