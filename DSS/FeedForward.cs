using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class FeedForward
    {
        private Network mNetwork;
        private List<List<double[]>> mDataSets;
        double[] mXValues, mTValues;
        private double mError = 1.0, mOutput = 0.0, mRawError = 0.0;
        private readonly double ERROR_THRESOLD;
        private bool mTrained = true;
        private int mInputNum, mOutputNum;
        private BackPropagation mPropagation;
        public int mErrorCount = 0;
        public FeedForward(Network network, double errorThresold, int inputNum, int outputNum)
        {
            mPropagation = new BackPropagation(network);
            mNetwork = network;
            ERROR_THRESOLD = errorThresold;
            mInputNum = inputNum;
            mOutputNum = outputNum;
        }

        public bool Trained
        {
            get { return mTrained; }
        }

        public double Error
        {
            get { return mError; }
        }

        public double Output
        {
            get { return mOutput; }
        }

        public List<List<double[]>> DataSets
        {
            set
            {
                mDataSets = new List<List<double[]>>();
                mDataSets = value;
            }
        }

        public void calculate(int index)
        {
          forwardPass(mDataSets[2][index]);
        }

        private void forwardPass(double[] dataSet)
        {
            mXValues = new double[mInputNum];
            mTValues = new double[mOutputNum];
            Array.Copy(dataSet, mXValues, mInputNum);
            Array.Copy(dataSet, mInputNum, mTValues,
              0, mOutputNum);
            mOutput = mNetwork.compute(mXValues);
        }

        public string[] executeEpoch()
        {
            double validationErrorAvg = 0.0, trainingErrorAvg = 0.0;
            mTrained = true;
            mErrorCount = 0;
            mDataSets[0].Shuffle();
            for (int i = 0; i < mDataSets[0].Count; i++)
            {
                train(i);
                trainingErrorAvg += mError;
            }
            for (int i = 0; i < mDataSets[1].Count; i++)
            {
                validate(i);
                validationErrorAvg += mError;
            }
            if (validationErrorAvg > ERROR_THRESOLD)
            {
                mTrained = false;
            }
            trainingErrorAvg = trainingErrorAvg / mDataSets[0].Count;
            validationErrorAvg = validationErrorAvg / mDataSets[1].Count;
            return new string[] { trainingErrorAvg.ToString("f8"), validationErrorAvg.ToString("f8") };
        }

        private void train(int index)
        {
            if (mOutput != 0.0 && mError > ERROR_THRESOLD)
            {
                mPropagation.learn(mOutput, mRawError);
                mErrorCount++;
            }
            forwardPass(mDataSets[0][index]);
            calcError(mTValues[0], mOutput);
        }

        public void validate(int index)
        {
            forwardPass(mDataSets[1][index]);
            calcError(mTValues[0], mOutput);
        }

        private void calcError(double target, double output)
        {
            mError = bound(Math.Pow((target - output),2));
            mRawError = (target - output);
        }
        private double bound(double d)
        {
            const double TooSmall = -1.0E20;
            const double TooBig = 1.0E20;
            if (d < TooSmall)
            {
                return TooSmall;
            }
            return d > TooBig ? TooBig : d;
        }
    }
}
