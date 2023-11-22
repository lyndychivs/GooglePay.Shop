let paymentsClient = null;

function getGooglePaymentsClient() {
    if (paymentsClient === null) {
        paymentsClient = new google.payments.api.PaymentsClient({ environment: 'TEST' });
    }
    return paymentsClient;
}

function getGooglePaymentDataRequest() {
    const paymentDataRequest = Object.assign({}, baseRequest);
    paymentDataRequest.allowedPaymentMethods = [getAllowedPaymentMethods()];
    paymentDataRequest.transactionInfo = getGoogleTransactionInfo();
    paymentDataRequest.merchantInfo = {
        merchantId: '01234567890123456789',
        merchantName: 'Example Merchant'
    };
    return paymentDataRequest;
}

function onGooglePaymentButtonClicked() {
    const paymentDataRequest = getGooglePaymentDataRequest();
    paymentDataRequest.transactionInfo = getGoogleTransactionInfo();
    const paymentsClient = getGooglePaymentsClient();
    updateElementInnerHtmlWithJson(paymentDataRequest, 'request-log');
    paymentsClient.loadPaymentData(paymentDataRequest)
        .then(function (paymentData) {
            processPayment(paymentData);
        })
        .catch(function (err) {
            console.error(err);
            updateElementInnerHtml(err, 'response-log');
        });
}

function processPayment(paymentData) {
    console.log(paymentData);
    updateElementInnerHtmlWithJson(paymentData, 'response-log');
    updateElementInnerHtml(paymentData.paymentMethodData.tokenizationData.token, 'token-log');
    updateElementInnerHtml(btoa(paymentData.paymentMethodData.tokenizationData.token), 'token-b64-log');
}