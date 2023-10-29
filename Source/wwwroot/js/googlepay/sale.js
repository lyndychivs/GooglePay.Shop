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
    logToDiv(paymentDataRequest, 'request-logs');
    paymentsClient.loadPaymentData(paymentDataRequest)
        .then(function (paymentData) {
            processPayment(paymentData);
        })
        .catch(function (err) {
            console.error(err);
            logToDiv(err, 'response-logs');
        });
}

function processPayment(paymentData) {
    console.log(paymentData);
    logToDiv(paymentData, 'response-logs');
}