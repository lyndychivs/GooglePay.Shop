namespace Wallet.Tests
{
    public abstract class GooglePay
    {
        private readonly string _walletUrl = "https://wallet.lyndychivs.com";

        protected string WalletUrl
        {
            get { return _walletUrl; }
        }
    }
}