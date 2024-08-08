namespace GooglePay.Shop.Models
{
    public class DecryptionResponse
    {
        /// <summary>
        /// Gets or sets the Decrypted Data returned by the GooglePay Decryption API.
        /// </summary>
        public string DecryptedData { get; set; } = null!;
    }
}