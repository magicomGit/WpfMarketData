using WpfMarketData.Infrastructure.Constants;

namespace WpfMarketData.Infrastructure.Market
{
    public class MarketProcessor
    {
        public async void SubscribeToBinance()
        {

            var TickSubscription = await MarketData.BinanceSocketClient.UsdFuturesApi.SubscribeToTickerUpdatesAsync(SymbolInitialization.List, tick =>
            {
                if (tick.Data.Symbol == MarketData.Info.SelectedSymbol)
                {
                    MarketData.Info.Binance = tick.Data.LastPrice;
                }
            });

        }

        public async void SubscribeToBybit()
        {
            var result = await MarketData.BybitSocketClient.UsdPerpetualApi.SubscribeToTickerUpdatesAsync(SymbolInitialization.List, tick =>
            {
                if (tick.Data.LastPrice != null && tick.Data.Symbol == MarketData.Info.SelectedSymbol)
                {
                    MarketData.Info.Bybit = (decimal)tick.Data.LastPrice;

                }
            });

        }

        public async void SubscribeToKucoin(string simbol)
        {
            await MarketData.KucoinSocketClient.UnsubscribeAllAsync();

            var result = await MarketData.KucoinSocketClient.FuturesApi.SubscribeToTickerUpdatesAsync(simbol, tick =>
            {
                MarketData.Info.Kucoin = tick.Data.BestAskPrice;
            });


        }

        public async void SubscribeToBitGet()
        {


            var result = await MarketData.BitgetSocketClient.FuturesApi.SubscribeToTickerUpdatesAsync (SymbolInitialization.List, tick =>
            {
                if (tick.Data.LastTradePrice != null && tick.Data.Symbol == MarketData.Info.SelectedSymbol)
                {
                    MarketData.Info.Bitget = (decimal)tick.Data.LastTradePrice;

                }
            });


        }
    }
}
