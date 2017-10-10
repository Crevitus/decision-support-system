using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DSS
{
    public partial class Form1 : Form
    {
        private List<string[]> testCarList;
        private bool isCBR = true, mDebugging = true;
        private ANNController mAnn;
        public Form1()
        {
            InitializeComponent();
            loadTestData(@"car test data.csv");
            clearLabels();
        }

        private void clearLabels()
        {
            lblActPrice.Text = "";
            lblPrice.Text = "";
            lblPercentage.Text = "";
            lblSinglePercentage.Text = "";
        }

        public void updateErrorStatus(string[] update, string err)
        {
            lblPrice.Text = "Avg Training Error: " + update[0];

            lblActPrice.Text = "Avg Validation Error: " + update[1];

            lblPercentage.Text = "Error num per epoch:  " + err;
        }

        public void updateComboBox(List<double[]> cars)
        {
            cmbSelect.Items.Clear();
            foreach (double[] car in cars)
            {
                cmbSelect.Items.Add(toString(car));
            }
        }

        private string toString(double[] array)
        {
            string stringData = "";
            for (int i = 0; i<array.Length; i++)
            {
                stringData +=" | " + array[i].ToString("f2");
            }
            return stringData;
        }


        private void loadTestData(string fileName)
        {
            testCarList = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool first = true;
                cmbSelect.Items.Clear();
                while (!parser.EndOfData)
                {
                    string carCase = "";
                    string[] fields = parser.ReadFields();
                    if (!first)
                    {
                        testCarList.Add(fields);
                        foreach (string field in fields)
                        {
                            carCase += " | " + field;
                        }
                        cmbSelect.Items.Add(carCase);
                    }
                    first = false;
                }
            }
        }
        private void btnGetPrice(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedItem == null)
            {
                return;
            }
            if (isCBR)
            {
                CBR cbr = new CBR();
                double[] prices = cbr.generatePrice(cmbSelect.SelectedIndex, testCarList[cmbSelect.SelectedIndex]);
                lblPrice.Text = "Price Generated: £" + prices[0].ToString();
                lblActPrice.Text = "Actual Price: £" + prices[1].ToString();
                lblSinglePercentage.Text = "Percentage difference: " + calcPercentage(prices).ToString("f2") + "%";
            }
            else
            {
                double[] prices = mAnn.getPrice(cmbSelect.SelectedIndex);
                lblPrice.Text = "Price Generated: £" + prices[0].ToString("f2");
                lblActPrice.Text = "Actual Price: £" + prices[1].ToString();
                lblSinglePercentage.Text = "Percentage difference: " + calcPercentage(prices).ToString("f2") + "%";
            }
        }

        private double calcPercentage(double[] prices)
        {
            double percentageDifference = (prices[1] / prices[0]) * 100;
            if (percentageDifference > 100)
            {
                percentageDifference = percentageDifference - 100;
            }
            else
            {
                percentageDifference = 100 - percentageDifference;
            }
            return percentageDifference;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (isCBR)
            {
                CBR cbr = new CBR();
                StringBuilder outputString;
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(@"TestOutput.csv"))
                    {
                        double avgPercentage = 0;
                        for (int i = 0; i < testCarList.Count; i++)
                        {
                            outputString = new StringBuilder();
                            double[] prices = cbr.generatePrice(i, testCarList[i]);
                            avgPercentage += calcPercentage(prices);
                            foreach (string attribute in testCarList[i])
                            {
                                outputString.Append(attribute + ",");
                            }
                            foreach (double price in prices)
                            {
                                outputString.Append(price.ToString() + ",");
                            }
                            outputFile.WriteLine(outputString + "," + calcPercentage(prices).ToString("f2"));
                        }
                        avgPercentage = avgPercentage / testCarList.Count;
                        outputFile.WriteLine(avgPercentage.ToString("f2"));
                        lblPercentage.Text = "Avg deviation from actual price: " + avgPercentage.ToString("f2") + "%";
                    }
                }
                catch (Exception)
                {
                    lblPercentage.Text = "File I/O Error Occured";
                }
            }
            else
            {
                double avgPercentage = 0.0;
                int count = 0;
                foreach(double[] prices in mAnn.test())
                {
                    avgPercentage += calcPercentage(prices);
                    count++;
                }
                avgPercentage = avgPercentage / count;
                lblPercentage.Text = "Avg deviation from actual price: " + avgPercentage.ToString("f2") + "%";
            }
        }

        private void btnCBR_Click(object sender, EventArgs e)
        {
            loadTestData(@"car test data.csv");
            clearLabels();
            isCBR = true;
            btnCBR.ForeColor = Color.Green;
            btnANN.ForeColor = Color.Gray;
            btnTrain.Visible = false;
            btnReset.Visible = false;
            btnSave.Visible = false;
            btnDebug.Visible = false;
            btnTest.Text = "Run Test";
        }

        private void btnANN_Click(object sender, EventArgs e)
        {
            mAnn = new ANNController(this);
            mAnn.loadANN(false);
            isCBR = false;
            clearLabels();
            btnCBR.ForeColor = Color.Gray;
            btnANN.ForeColor = Color.Green;
            btnDebug.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            mAnn.resetANN();
            clearLabels();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if(btnTrain.ForeColor == Color.Black)
            {
                btnTrain.ForeColor = Color.Green;
            }
            else
            {
                btnTrain.ForeColor = Color.Black;
            }
            mAnn.train();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mAnn.saveANN();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            if (mDebugging)
            {
                btnTrain.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = true;
                btnDebug.ForeColor = Color.Red;
                mDebugging = false;
            }
            else
            {
                btnTrain.Visible = false;
                btnReset.Visible = false;
                btnSave.Visible = false;
                btnDebug.ForeColor = Color.Gray;
                mDebugging = true;
            }
        }
    }
}
