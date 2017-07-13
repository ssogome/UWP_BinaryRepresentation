using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_BinaryRepresentation
{
    public   class BitArrayBitwiseManipulation
    {
        public void Manipulation()
        {
            byte a = 0;     // Binary: 0000
            byte b = 5;     // Binary: 0101
            byte c = 10;    // Binary: 1010

            //Create bit Array
            var aBitArray = new BitArray(new byte[] { a });
            var bBitArray = new BitArray(new byte[] { b });
            var cBitArray = new BitArray(new byte[] { c });

            //Bitwise alternative
            cBitArray.Or(aBitArray);
            DebugBitArrayValue(cBitArray);

            //Bitwise exclusive alternative
            cBitArray.Xor(bBitArray);
            DebugBitArrayValue(cBitArray);

            //Bitwise conjuction
            cBitArray.And(bBitArray);
            DebugBitArrayValue(cBitArray);

             
        }

        private static byte GetByteValueFromBitArray(BitArray bitArray)
        {
            var buffer = new byte[1];
            //Perform conversion
            ((ICollection)bitArray).CopyTo(buffer, 0);

            return buffer[0];
        }

        private static void DebugBitArrayValue(BitArray bitArray)
        {
            var value = GetByteValueFromBitArray(bitArray);
            var binaryValue = Convert.ToString(value, 2);
            var debugString = string.Format("{0} Binary: {1}", value, binaryValue);

            System.Diagnostics.Debug.WriteLine(debugString);
        }
    }    
}
