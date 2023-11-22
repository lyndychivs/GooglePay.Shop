let paymentsClient = null;

function getGooglePaymentDataRequest() {
    const paymentDataRequest = Object.assign({}, baseRequest);
    paymentDataRequest.allowedPaymentMethods = [getAllowedPaymentMethods()];
    paymentDataRequest.transactionInfo = getGoogleTransactionInfo();
    paymentDataRequest.merchantInfo = {
        merchantId: '01234567890123456789',
        merchantName: 'Example Merchant'
    };
    paymentDataRequest.callbackIntents = ["PAYMENT_AUTHORIZATION"];

    return paymentDataRequest;
}

function getGooglePaymentsClient() {
    if (paymentsClient === null) {
        paymentsClient = new google.payments.api.PaymentsClient({
            environment: 'TEST',
            paymentDataCallbacks: {
                onPaymentAuthorized: onPaymentAuthorized
            }
        });
    }
    return paymentsClient;
}

function onPaymentAuthorized(paymentData) {
    return new Promise(function (resolve, reject) {
        processPayment(paymentData)
            .then(function () {
                resolve({ transactionState: 'SUCCESS' });

            })
            .catch(function () {
                resolve({
                    transactionState: 'ERROR',
                    error: {
                        intent: 'PAYMENT_AUTHORIZATION',
                        message: 'Insufficient funds, try again. Next attempt should work.',
                        reason: 'PAYMENT_DATA_INVALID'
                    }
                });
            });
    });
}

function onGooglePaymentButtonClicked() {
    const paymentDataRequest = getGooglePaymentDataRequest();
    paymentDataRequest.transactionInfo = getGoogleTransactionInfo();
    const paymentsClient = getGooglePaymentsClient();
    updateElementInnerHtmlWithJson(paymentDataRequest, 'request-log');
    paymentsClient.loadPaymentData(paymentDataRequest);
}

function processPayment(paymentData) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            console.log(paymentData);
            updateElementInnerHtmlWithJson(paymentData, 'response-log');
            updateElementInnerHtml(paymentData.paymentMethodData.tokenizationData.token, 'token-log');
            updateElementInnerHtml(btoa(paymentData.paymentMethodData.tokenizationData.token), 'token-b64-log');
            resolve({});
        }, 500);
    });
}