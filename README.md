# GooglePay.Shop
An ASP.NET Core Web API for Testing transactions on GooglePay.

Has the following functionality:
1. Perform GooglePay Demo Sale using ([PAN_ONLY/CRYPTOGRAM_3DS](https://developers.google.com/pay/api/web/reference/request-objects#PaymentMethodTokenizationSpecification)) using ([PAYMENT_GATEWAY/DIRECT](https://developers.google.com/pay/api/web/reference/request-objects#PaymentMethodTokenizationSpecification))
2. Perform GooglePay Demo Authorization using ([PAN_ONLY/CRYPTOGRAM_3DS](https://developers.google.com/pay/api/web/reference/request-objects#PaymentMethodTokenizationSpecification)) using ([PAYMENT_GATEWAY/DIRECT](https://developers.google.com/pay/api/web/reference/request-objects#PaymentMethodTokenizationSpecification))
3. Decrypt a GooglePay Token EncryptedToken with Private Key via Web UI
4. Decrypt a GooglePay Token EncryptedToken with Private Key via API