using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.ForEnums
{

    /// <typeparam name="TEnum">MUST be an enum</typeparam>
    public class EnumSelectList<TEnum> : List<SelectListItem>
    {
        public EnumSelectList(Func<TEnum, string> toHumanReadableFunc, bool includeSelect = false)
        {
            if (includeSelect)
                addSelect();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                add((int)((dynamic)value), toHumanReadableFunc(value));
            }
        }

        private void add(int value, string text)
        {
            Add(new SelectListItem()
            {
                Text = text,
                Value = value.ToString()
            });
        }

        private void addSelect()
        {
            Add(new SelectListItem()
            {
                Text = "-- Select --",
                Value = ""
            });
        }
    }
}
