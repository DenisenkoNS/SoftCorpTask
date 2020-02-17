using System;
using System.Collections.Generic;

namespace SoftCorpTask.Models
{
    public class RootObject
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; } 
        public List<Valute> Valute { get; set; }
    }
    public class Valute
    {

        public string ID { get; set; }
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Previous { get; set; }

    }
    public class ValuteCodes
    {
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public ValuteCodes(int numCode, string charCode)
        {
            NumCode = numCode;
            CharCode = charCode;
        }
    }
    public class ValuteCourse
    {
        public int NumCode { get; set; }
        public double Value { get; set; }
        public ValuteCourse(int numCode, double value)
        {
            NumCode = numCode;
            Value = value;
        }
    }

}
