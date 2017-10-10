using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class Layer
    {
        private Neuron[] mNeurons;
        private int mNeuronCount;
        private bool mIsInput;

        public Layer(bool isInput, int neuronCount)
        {
            mNeuronCount = neuronCount;
            Random rand = new Random();
            mNeurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
            {
                mNeurons[i] = new Neuron(i, isInput);
            }
            mIsInput = isInput;
        }

        public int NeuronCount
        {
            get { return mNeuronCount; }
        }

        public Neuron[] Neurons
        {
            get { return mNeurons; }
            set { mNeurons = value;}
        }

        public void compute(List<double[]> inputs, double bias)
        {
            for(int i = 0; i < mNeuronCount; i++)
            {
                if(mIsInput)
                {
                    mNeurons[i].compute(inputs[0][i]);
                }
                else
                {
                    mNeurons[i].compute(inputs[i], bias);
                }
            }
        }
    }
}
