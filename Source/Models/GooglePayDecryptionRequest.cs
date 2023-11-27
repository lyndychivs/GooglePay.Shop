namespace Wallet.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GooglePayDecryptionRequest
    {
        /// <summary>
        /// Gets or sets the GooglePay Private Key used for Decryption.
        /// This value must be the ECC Private Key Base64 encoded.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string PrivateKey { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Encrypted Token returned by GooglePay when performing a GooglePay Transaction.
        /// This value must only be the Token value.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string EncryptedToken { get; set; } = null!;
    }
}