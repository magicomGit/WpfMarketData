namespace WpfMarketData.Infrastructure.ViewModel.Models
{
    public class Info : BaseVM
    {

        private decimal _Binance { get; set; }
        public decimal Binance
        {
            get { return _Binance; }
            set
            {
                if (_Binance != value)
                {
                    _Binance = value;
                    OnPropertyChanged("Binance");
                }
            }
        }


        private decimal _Bybit { get; set; }
        public decimal Bybit
        {
            get { return _Bybit; }
            set
            {
                if (_Bybit != value)
                {
                    _Bybit = value;
                    OnPropertyChanged("Bybit");
                }
            }
        }


        private decimal _Kucoin { get; set; }
        public decimal Kucoin
        {
            get { return _Kucoin; }
            set
            {
                if (_Kucoin != value)
                {
                    _Kucoin = value;
                    OnPropertyChanged("Kucoin");
                }
            }
        }
        

        private decimal _Bitget { get; set; }
        public decimal Bitget
        {
            get { return _Bitget; }
            set
            {
                if (_Bitget != value)
                {
                    _Bitget = value;
                    OnPropertyChanged("Bitget");
                }
            }
        }

        public string SelectedSymbol = string.Empty;
    }
}
