using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Converters
{
    public class StringListConverter
    {
        protected string inputString;
        protected char delimeter;

        public StringListConverter(string inputString)
        {
            this.inputString = inputString;
        }

        public StringListConverter SetDelimeter(char delimeter)
        {
            this.delimeter = delimeter;
            return this;
        }

        public List<T> Get<T>()
        {
            List<T> list = new List<T>();
            string[] delimetedArray = inputString.Split(delimeter);
            foreach (var str in delimetedArray)
            {
                T val = StringConverter.ConvertString<T>(str);
                list.Add(val);
            }

            return list;
        }


    }
}
