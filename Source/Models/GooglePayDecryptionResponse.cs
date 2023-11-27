namespace Wallet.Models
{
    public class GooglePayDecryptionResponse
    {
        /// <summary>
        /// Gets or sets the Decrypted Data returned by the GooglePay Decryption API.
        /// </summary>
        public string DecryptedData { get; set; } = null!;
    }
}