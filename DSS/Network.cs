using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class Network : ICloneable
    {
        private int mLayerIndex = 0;
        private Dictionary<int,Layer> mLayers = new Dictionary<int, Layer>();
        private List<VectorLayer> mVectorLayers = new List<VectorLayer>();
        public void addLayer(Layer layer)
        {
            mLayers.Add(mLayerIndex, layer);
            mLayerIndex++;
        }

        public Dictionary<int, Layer> Layers
        {
            get { return mLayers; }
            set { mLayers = value; }
        }

        public List<VectorLayer> VectorLayers
        {
            get { return mVectorLayers; }
            set { mVectorLayers = value; }
        }

        public void reset()
        {
            for(int i = 0; i < mVectorLayers.Count; i++)
            {
                mVectorLayers[i].setWeights();
            }
        }

        public double compute(double[] data)
        {
            List<double[]> layerOutput = new List<double[]>();
            mLayers[0].compute(new List<double[]> {data}, 0);
            for (int i = 1; i < mLayers.Count; i++)
            {
                layerOutput = mVectorLayers[i - 1].synapse();
                mLayers[i].compute(layerOutput, mVectorLayers[i - 1].Bias);
            }
            return mLayers[mLayers.Count - 1].Neurons[0].Output;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        internal void createStructure()
        {
            for(int i = 0; i < mLayerIndex - 1; i++)
            {
                mVectorLayers.Add(new VectorLayer(mLayers[i], mLayers[i + 1], i));
            }
        }
    }
}
