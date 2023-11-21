namespace Wallet.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GooglePayDecryptionRequest
    {
        [Required(AllowEmptyStrings=false)]
        public string PrivateKey { get; set; }

        [Required(AllowEmptyStrings=false)]
        public string EncryptedToken { get; set; }
    }
}