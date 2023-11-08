using Binance.Net.Clients;
using Bitget.Net.Clients;

using Bybit.Net.Clients;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMarketData.Infrastructure.ViewModel.Models;

namespace WpfMarketData.Infrastructure.Market
{
    public static class MarketData
    {
        //модель данных (MVVM)
        public static Info Info = new Info();

        //экземпляр класса обработчика данных получаемых с биржи
        public static MarketProcessor Processor = new MarketProcessor();


        //клиенты
        public static BinanceSocketClient BinanceSocketClient = new BinanceSocketClient();
        public static BybitSocketClient BybitSocketClient = new BybitSocketClient();
        public static KucoinSocketClient KucoinSocketClient = new KucoinSocketClient();
        public static BitgetSocketClient BitgetSocketClient = new BitgetSocketClient();






    }
}
