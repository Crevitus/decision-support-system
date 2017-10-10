using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS
{
    class Utils
    {
        public static int[] ConvertStringAttributes(string[] stringAttributes)
        {
            int[] attributes = new int[4];
            if (stringAttributes[0] == "gas")
            {
                attributes[0] = 1;
            }
            else
            {
                attributes[0] = 2;
            }
            if (stringAttributes[1] == "std")
            {
                attributes[1] = 1;
            }
            else
            {
                attributes[1] = 2;
            }
            if (stringAttributes[2] == "two")
            {
                attributes[2] = 1;
            }
            else
            {
                attributes[2] = 2;
            }
            if (stringAttributes[3] == "front")
            {
                attributes[3] = 1;
            }
            else
            {
                attributes[3] = 2;
            }
            return attributes;
        }
    }
}
