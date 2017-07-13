using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWP_BinaryRepresentation
{
     public class ShortToBinaryConverterUsingLSB: IValueConverter
    {
        //Using LSB
        private string IsBitSet(short value, int position)
        {
            return (value & (1 << position)) > 0 ? "1" : "0";
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var result = string.Empty;
            if(value != null)
            {
                short inputValue;
                if(short.TryParse(value.ToString(), out inputValue))
                {
                    const int bitCount = 16;
                    for(var i = 0; i < bitCount; i++)
                    {
                        result += IsBitSet(inputValue, i);
                    }
                }
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
