using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWP_BinaryRepresentation
{
    public class ShortToBinaryConverterUsingUWPClasses : IValueConverter
    {
        public object Convert(object value, Type targetTypt, object parameter, string language)
        {
            string result = string.Empty;
            if (value != null)
            {
                short inputValue;
                if (short.TryParse(value.ToString(), out inputValue))
                {
                    var bytes = BitConverter.GetBytes(inputValue);
                    var bitArray = new BitArray(bytes);

                    for (var i = 0; i < bitArray.Length; i++)
                    {
                        result += BoolToBinaryString(bitArray[i]);
                    }
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private string IsBitSet(short value, int position)
        {
            return (value & (1 << position)) > 0 ? "1" : "0";
        }

        private string BoolToBinaryString(bool value)
        {
            return value ? "1" : "0";
        }
    }
}
