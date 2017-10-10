using System;
using System.Collections.Generic;

namespace DSS
{
    class BackPropagation
    {
        private Network mNetwork;
        private const double LEARNING_RATE = 0.5;
        private double mOutput, mError, mOutputDerivative, mOutputSignal;
        private Neuron mOutputNeuron;
        public BackPropagation(Network network)
        {
            mNetwork = network;
        }
        public void learn(double output, double error)
        {
            mOutput = output;
            mError = error;
            Network networkClone = (Network)mNetwork.Clone();
            int numInput = networkClone.Layers[0].NeuronCount;
            int numHidden = networkClone.Layers[1].NeuronCount;
            int numOutput = networkClone.Layers[2].NeuronCount;

            mOutputNeuron = mNetwork.Layers[mNetwork.Layers.Count - 1].Neurons[0];
            mOutputDerivative = calcSigmoidDerivative(mOutputNeuron);
            mOutputSignal = mError * mOutputDerivative;

            //hidden to output weight gradients
            double[] hoGrads = new double[numHidden];
            double obGrad = 0.0;
            for (int j = 0; j < numHidden; ++j)
            {
                hoGrads[j] = mOutputSignal * networkClone.Layers[1].Neurons[j].Output;
            }
            obGrad = mOutputSignal * 1.0;

            //hidden neuron signals
            double[] hSignals = new double[numHidden];
            for (int j = 0; j < numHidden; ++j)
            {
                double derivative = calcSigmoidDerivative(networkClone.Layers[1].Neurons[j]);
                double sum = 0.0;
                sum += mOutputSignal * networkClone.VectorLayers[1].Weights[0][j];
                hSignals[j] = derivative * sum;
            }

            //initialse input to hidden array
            double[][] ihGrads = new double[numInput][];
            for(int c = 0; c < ihGrads.Length; c++)
            {
                ihGrads[c] = new double[numHidden];
            }

            //input to hidden weight gradients
            for (int i = 0; i < numInput; ++i)
            {
                for (int j = 0; j < numHidden; ++j)
                {
                    ihGrads[i][j] = hSignals[j] * networkClone.Layers[0].Neurons[i].Output;
                }
            }
            double[] hbGrads = new double[numHidden];
            for (int j = 0; j < networkClone.Layers[1].NeuronCount; ++j)
            {
                hbGrads[j] = hSignals[j] * 1.0;
            }

            //input to hidden weight update
            double delta = 0.0;
            for (int i = 0; i < numInput; ++i)
            {
                for (int j = 0; j < numHidden; ++j)
                {
                    delta = ihGrads[i][j] * LEARNING_RATE;
                    networkClone.VectorLayers[0].Weights[j][i] += delta;
                }
            }

            //hidden node bias update
            for (int j = 0; j < numHidden; ++j)
            {
                delta = hbGrads[j] * LEARNING_RATE;
                networkClone.VectorLayers[0].updateBiasWeight(delta);
            }

            //hidden to output weight update
            for (int j = 0; j < numHidden; ++j)
            {
                delta = hoGrads[j] * LEARNING_RATE;
                networkClone.VectorLayers[1].Weights[0][j] += delta;
            }

            //output node bias update
            delta = obGrad * LEARNING_RATE;
            networkClone.VectorLayers[1].updateBiasWeight(delta);

            mNetwork = networkClone;
        }

        private double calcSigmoidDerivative(Neuron neuron)
        {
            return neuron.Output * (1 - neuron.Output);
        }
    }
}
