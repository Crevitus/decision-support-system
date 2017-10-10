using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class Car : IEnumerable<double>
    {
        private double mLength, mWidth, mHeight, mWheelBase, mBore, mStroke, mCompression,
            mIndex, mPrice, mFuelType, mAspiration, mNumDoor, mEngineLocation, mCurbWeight, mEngineSize, mHorsePower, mRPM, mCtyMPG, mHighMPG;

        public Car()
        { 
        }

        public IEnumerator<double> GetEnumerator()
        {
            yield return mFuelType;
            yield return mAspiration;
            yield return mNumDoor;
            yield return mEngineLocation;
            yield return mWheelBase;
            yield return mLength;
            yield return mWidth;
            yield return mHeight;
            yield return mCurbWeight;
            yield return mEngineSize;
            yield return mBore;
            yield return mStroke;
            yield return mCompression;
            yield return mHorsePower;
            yield return mRPM;
            yield return mCtyMPG;
            yield return mHighMPG;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Car(int index, string[] attributes)
        {
            mIndex = index;
            int[] convertedAtttributes = Utils.ConvertStringAttributes(new string[] { attributes[1], attributes[2], attributes[3], attributes[4] });
            mFuelType = convertedAtttributes[0];
            mAspiration = 100 * convertedAtttributes[0];
            mNumDoor = convertedAtttributes[0];
            mEngineLocation = convertedAtttributes[0];
            mWheelBase = Convert.ToDouble(attributes[5]);
            mLength = Convert.ToDouble(attributes[6]);
            mWidth = Convert.ToDouble(attributes[7]);
            mHeight = Convert.ToDouble(attributes[8]);
            mCurbWeight = Convert.ToDouble(attributes[9]);
            mEngineSize = Convert.ToDouble(attributes[10]);
            mBore = Convert.ToDouble(attributes[11]);
            mStroke = Convert.ToDouble(attributes[12]);
            mCompression = Convert.ToDouble(attributes[13]);
            mHorsePower = 1.5 * Convert.ToDouble(attributes[14]);
            mRPM = Convert.ToDouble(attributes[15]);
            mCtyMPG = Convert.ToDouble(attributes[16]);
            mHighMPG = Convert.ToDouble(attributes[17]);
            mPrice = Convert.ToDouble(attributes[18]);
        }

        public double Price
        {
            get { return mPrice; }
        }
    }
}
