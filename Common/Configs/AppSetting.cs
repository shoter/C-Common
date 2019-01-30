using Common.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Configs
{
    public class AppSetting
    {
        public string Value { get; set; }

        public bool? Boolean
        {
            get
            {
                if (Value == null)
                    return null;

                return Value.Trim().ToLower() == "true";
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public AppSetting(string value)
        {
            Value = value;
        }

        public int? Integer
        {
            get
            {
                int _return;

                if (int.TryParse(Value, out _return))
                    return _return;
                return null;
            }
        }

        /// <summary>
        /// Converts string in appsetting to List of values of desired type.
        /// </summary>
        /// <typeparam name="T">Type to which strings on list will be converted to.</typeparam>
        /// <param name="delimeter">character which delimits strings.</param>
        public List<T> ToList<T>(char delimeter)
        {
            return new StringListConverter(this.ToString())
                .SetDelimeter(delimeter)
                .Get<T>();
        }

        /// <summary>
        /// Function convert string which delimits it's values with some kind of delimeter. Delimeter is automatically detected
        /// </summary>
        /// <typeparam name="T">Type to which strings on list will be converted to.</typeparam>
        public List<T> ToList<T>()
        {
            char? delimeter = null;
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            foreach (var character in Value)
            {
                if ((character >= '0' && character <= '9'))
                    continue;
                if (character == decimalSeparator)
                    continue;
                delimeter = character;
                break;
            }

            if (delimeter.HasValue == false)
                throw new Exception("Delimeter could not be found");

            return ToList<T>(delimeter.Value);
        }

        public static implicit operator string(AppSetting x)
        {
            return x.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return Value == (obj as string);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return !String.IsNullOrEmpty(Value) ? Value.GetHashCode() : "".GetHashCode();
        }
    }
}
