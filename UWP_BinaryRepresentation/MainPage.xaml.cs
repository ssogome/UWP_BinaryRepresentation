using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_BinaryRepresentation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public short BitToSet
        {
            get { return bitToSet; }
            set { SetBit(value); }
        }
        public short BitToClear
        {
            get { return bitToClear; }
            set { ClearBit(value); }
        }
        public short InputValue
        {
            get { return inputValue; }
            set { OutputValue = inputValue = value; }
        }
        public short OutputValue
        {
            get { return outputValue; }
             set
            {
                 outputValue = value;               
                OnPropertyChanged();
            }
        }
        private const int shortBitLength = 16;
        private short bitToSet=10;
        private short bitToClear=4;
        private short inputValue=255;
        private short outputValue;        

        public MainPage()
        {
            this.InitializeComponent();

            BitArrayBitwiseManipulation test = new BitArrayBitwiseManipulation();
            test.Manipulation();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetBit(short position)
        {
            if(position >= 0 && position <= shortBitLength)
            {
                OutputValue |= (short)(1 << position);
                bitToSet = position;
            }
        }

        private void ClearBit(short position)
        {
            if(position >= 0 && position <= shortBitLength)
            {
                OutputValue &= (short)~(1 << position);
                bitToClear = position;
            }
        }

        private void OuputBit(short output)
        {
            outputValue = output;
        }
    }            


}
