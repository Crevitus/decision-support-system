using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace DSS
{
    class CBR
    {
        private const int NUM_OF_MATCHING_CASES = 6;
        private const int MAX_DISTANCE = 400;
        private List<Car> carCaseList;
        public double[] generatePrice(int index, string[] car)
        {
            int actPrice = selectCaseBase(index, car[0]);
            var carList = new List<string>(car);
            carList.RemoveAt(0);
            int tempPrice = (int)checkSimilarity(carList.ToArray());
            if (tempPrice == 0)
            {
                return new double[] { actPrice, actPrice };
            }
            else
            {
                return new double[] { checkSimilarity(carList.ToArray()), actPrice };
            }
        }
        private int selectCaseBase(int index, string manufacturer)
        {
            carCaseList = new List<Car>();
            int actPrice = 0;
            using (TextFieldParser parser = new TextFieldParser(@"car machine learning.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool first = true;
                Car carCase;
                int cnt = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (!first)
                    {
                        if (fields[0] == manufacturer && index != cnt)
                        {
                            carCase = new Car(cnt, fields);
                            carCaseList.Add(carCase);
                        }
                        else if(cnt == index)
                        {
                            carCase = new Car(cnt, fields);
                            actPrice = (int)carCase.Price;
                        }
                        cnt++;
                    }
                    first = false;
                }
            }
            return actPrice;
        }

        private double checkSimilarity(string[] carToCheck)
        {
            var similarities = new List<Tuple<int, Car>>();
            foreach (Car carCase in carCaseList)
            {
                int similarity = 0;
                for(int i = 0; i < carToCheck.Length; i++)
                {
                    int[] convertedAtttributes = Utils.ConvertStringAttributes(
                        new string[] { carToCheck[0], carToCheck[1], carToCheck[2], carToCheck[3]});
                    carToCheck[0] = convertedAtttributes[0].ToString();
                    carToCheck[1] = convertedAtttributes[1].ToString();
                    carToCheck[2] = convertedAtttributes[2].ToString();
                    carToCheck[3] = convertedAtttributes[3].ToString();
                    similarity += (int)Math.Round((carCase.ElementAt(i) - Convert.ToDouble(carToCheck[i])), MidpointRounding.AwayFromZero);
                }
                if (similarity < 0)
                {
                    similarity = similarity * (-1);
                }
                similarities.Add(Tuple.Create(similarity, carCase));
            }
            similarities.ToLookup(t => t.Item1, t => t.Item2);
            return calcPrice(similarities);
        }


        private double calcPrice(List<Tuple<int, Car>> similarities)
        {
            int tempAvg = 0;
            int count = 0;
            foreach (var car in similarities.OrderBy(i => i.Item1))
            {
                if (count <= NUM_OF_MATCHING_CASES && car.Item1 < MAX_DISTANCE)
                {
                    tempAvg += Convert.ToInt32(car.Item2.Price);
                    count++;
                }
            }
            if (count >= NUM_OF_MATCHING_CASES)
            {
                return (tempAvg / (NUM_OF_MATCHING_CASES));
            }
            else if (similarities.Count == 0)
            {
                return 0;
            }
            else if (count == 0 )
            {
                return similarities[0].Item2.Price;
            }
            else
            {
                return (tempAvg / (count));
            }
        }
    }
}
