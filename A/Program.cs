using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StreamReader reader = File.OpenText("D:/рабочий стол/Kontest/Kontest/A/input.txt");
            StreamReader reader = File.OpenText("input.txt");
            string line = "";
            var intList = new List<BigInteger>();
            BigInteger outPutNum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string concat = String.Concat(line.Where(symbol => Char.IsNumber(symbol)));
                if (concat.Length > 0)
                {
                    BigInteger curInt = BigInteger.Parse(concat);

                    intList.Add(curInt);
                    outPutNum = outPutNum + curInt;
                }
            }

            var outPutCharArr = outPutNum.ToString().ToCharArray();

            string output = "[";

            for (var i = 0; i < outPutCharArr.Length; i++)
            {
                output = output + outPutCharArr[i];
                if (i != outPutCharArr.Length - 1)
                {
                    output = output + ", ";
                }
            }

            output = output + "]";

            //Console.Write(output);
            //File.WriteAllText("D:/рабочий стол/Kontest/Kontest/A/output.txt", output);
            File.WriteAllText("output.txt", output);


            //Console.ReadKey();
        }
    }
}
