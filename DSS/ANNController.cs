using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace DSS
{
    class ANNController
    {
        private double[] mMinVals, mMaxVals;
        private List<double[]> mRawData;
        private List<List<double[]>> mDataSets;
        private FeedForward mFeedforward;
        private Thread mWorkerThread;
        private Form1 mForm;
        private bool mTrainingComplete = false;
        private Network mNetwork;
        private const string weightFileName = @"SavedWeights.bin";
        private const string dataFileName = @"SavedData.bin";

        public ANNController(Form1 form)
        {
            mForm = form;
            mWorkerThread = new Thread(new ThreadStart(execute));
        }

        public void loadANN(bool reset)
        {
            List<List<double[]>> savedWeights = null;
            if (!reset)
            {
                if (File.Exists(weightFileName))
                {
                    Stream TestFileStream = File.OpenRead(weightFileName);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    savedWeights = (List<List<double[]>>)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                }
            }
            List<double[]> normDataset = new List<double[]>();
            List<double> idealOutputs = new List<double>();
            CSVNormalisation normaliser = new CSVNormalisation();

            loadData();
            normaliser.normaliseAll(mMinVals, mMaxVals, mRawData, out normDataset);
            normDataset.Shuffle();
            mDataSets = normDataset.ChunkBy(60);
            mForm.updateComboBox(mDataSets[2]);

            mNetwork = new Network();
            mNetwork.addLayer(new Layer(true, mDataSets[0][0].Length - 1));
            mNetwork.addLayer(new Layer(false, 8));
            mNetwork.addLayer(new Layer(false, 1));
            mNetwork.createStructure();
            if(savedWeights != null)
            {
                for(int i = 0; i < mNetwork.VectorLayers.Count; i++)
                {
                    mNetwork.VectorLayers[i].Weights = savedWeights[i];
                }
            }

            mFeedforward = new FeedForward(mNetwork, 0.005, mDataSets[0][0].Length - 1, 1);

            mFeedforward.DataSets = mDataSets;

        }

        public void resetANN()
        {
            loadANN(true);
            mNetwork.reset();
        }

        public void saveANN()
        {
            List<List<double[]>> vLayerWeights = new List<List<double[]>>();
            foreach (VectorLayer vLayer in mNetwork.VectorLayers)
            {
                vLayerWeights.Add(vLayer.Weights);
            }
            Stream TestFileStream = File.Create(weightFileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, vLayerWeights);
            TestFileStream.Close();
        }

        public void train()
        {
            if(mWorkerThread.IsAlive)
            {
                mWorkerThread.Abort();
            }
            else
            {
                if (!mTrainingComplete)
                {
                    mWorkerThread = new Thread(new ThreadStart(execute));
                    mWorkerThread.Start();
                    mTrainingComplete = false;
                }
            }
        }

        public List<double[]> test()
        {
            List<double[]> priceList = new List<double[]>();
            for(int i = 0; i < mDataSets[2].Count; i++)
            {
                priceList.Add(getPrice(i));
            }
            return priceList;
        }

        public double[] getPrice(int index)
        {
            CSVNormalisation normaliser = new CSVNormalisation();
            mFeedforward.calculate(index);
            double[] prices = new double[2];
            prices[0] = normaliser.deNormalise(mMinVals[mMinVals.Length - 1], mMaxVals[mMinVals.Length - 1], mFeedforward.Output);
            prices[1] = normaliser.deNormalise(mMinVals[mMinVals.Length - 1], mMaxVals[mMinVals.Length - 1],
                mDataSets[2][index][mDataSets[2][index].Length - 1]);
            return prices;
        }

        private void updateErrorDisplay(string[] update, string err)
        {
            MethodInvoker action = () => mForm.updateErrorStatus(update, err);
            if (mForm.IsHandleCreated)
            {
                mForm.BeginInvoke(action);
            }
            else
            {
                mWorkerThread.Abort();
            }
        }

        private void execute()
        {
            do
            {
                updateErrorDisplay(mFeedforward.executeEpoch(), mFeedforward.mErrorCount.ToString());
                Thread.Sleep(50);
            } while (!mFeedforward.Trained);
            mWorkerThread.Abort();
            mTrainingComplete = true;
        }

        private void loadData()
        {
            mRawData = new List<double[]>();
            using (TextFieldParser parser = new TextFieldParser(@"ANN-TrainingData.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int count = 0;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (count == 0)
                    {
                        mMinVals = toDoubleArray(fields);
                        count++;
                    }
                    else if (count == 1)
                    {
                        mMaxVals = toDoubleArray(fields);
                        count++;
                    }
                    else
                    {
                        mRawData.Add(toDoubleArray(fields));
                    }
                }
            }
        }

        private double[] toDoubleArray(string[] array)
        {
            double[] doubleArray = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                doubleArray[i] = Convert.ToDouble(array[i]);
            }
            return doubleArray;
        }
    }
}
