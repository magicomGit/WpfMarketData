using System.Windows;
using System.Windows.Controls;
using WpfMarketData.Infrastructure.Constants;
using WpfMarketData.Infrastructure.Market;

namespace WpfMarketData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //список манет
            CbSymbols.ItemsSource = SymbolInitialization.List;
            CbSymbols.SelectedIndex = 0;

            // активация подписок 
            MarketData.Processor.SubscribeToBinance();
            MarketData.Processor.SubscribeToBybit();
            MarketData.Processor.SubscribeToBitGet();
            

            //привязка данных (MVVM)
            StackData.DataContext = MarketData.Info;
        }

        private void CbSymbols_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var symbol = ((ComboBox)sender).SelectedItem.ToString();
            MarketData.Info.SelectedSymbol = symbol;
            MarketData.Info.Bybit = 0;
            MarketData.Info.Binance = 0;
            MarketData.Info.Kucoin = 0;
            MarketData.Info.Bitget = 0;

            //
            MarketData.Processor.SubscribeToKucoin(symbol);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //дизактивация подписок
            await MarketData.KucoinSocketClient.UnsubscribeAllAsync();
            await MarketData.BinanceSocketClient.UnsubscribeAllAsync();
            await MarketData.BybitSocketClient.UnsubscribeAllAsync();
            await MarketData.BitgetSocketClient.UnsubscribeAllAsync();
        }
    }
}
