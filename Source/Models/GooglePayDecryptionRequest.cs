namespace Wallet.Models
{
    public class GooglePayDecryptionRequest
    {
        public string PrivateKey { get; set; }

        public string EncryptedToken { get; set; }
    }
}