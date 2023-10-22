const baseRequest = {
    apiVersion: 2,
    apiVersionMinor: 0
};

const tokenizationSpecificationGateway = {
    type: 'PAYMENT_GATEWAY',
    parameters: {
        'gateway': 'example',
        'gatewayMerchantId': 'exampleGatewayMerchantId'
    }
};

const tokenizationSpecificationDirect = {
    type: 'DIRECT',
    parameters: {
        protocolVersion: 'ECv2',
        publicKey: 'BOdoXP+9Aq473SnGwg3JU1aiNpsd9vH2ognq4PtDtlLGa3Kj8TPf+jaQNPyDSkh3JUhiS0KyrrlWhAgNZKHYF2Y='
    }
};

const baseCardPaymentMethod = {
    type: 'CARD',
    parameters: {
        allowedAuthMethods: ["PAN_ONLY", "CRYPTOGRAM_3DS"],
        allowedCardNetworks: ["AMEX", "DISCOVER", "INTERAC", "JCB", "MASTERCARD", "VISA"]
    }
};

const cardPaymentMethodGateway = Object.assign(
    {},
    baseCardPaymentMethod,
    {
        tokenizationSpecification: tokenizationSpecificationGateway
    }
);

const cardPaymentMethodDirect = Object.assign(
    {},
    baseCardPaymentMethod,
    {
        tokenizationSpecification: tokenizationSpecificationDirect
    }
);

function getGoogleIsReadyToPayRequest() {
    return Object.assign(
        {},
        baseRequest,
        {
            allowedPaymentMethods: [baseCardPaymentMethod]
        }
    );
}

function getAllowedPaymentMethods() {
    var tokenType = document.getElementById('tokenization-specification-type').value;
    if (tokenType == 'DIRECT') {
        return cardPaymentMethodDirect;
    }
    return cardPaymentMethodGateway;
}

function addGooglePayButton() {
    const paymentsClient = getGooglePaymentsClient();
    const button = paymentsClient.createButton({ onClick: onGooglePaymentButtonClicked });
    document.getElementById('googlepay-button').appendChild(button);
}

function onGooglePayLoaded() {
    const paymentsClient = getGooglePaymentsClient();
    paymentsClient.isReadyToPay(getGoogleIsReadyToPayRequest())
        .then(function (response) {
            if (response.result) {
                addGooglePayButton();
            }
            else {
                logToDiv('Failed to call addGooglePayButton() isReadyToPay response was false.', 'response-logs');
            }
        })
        .catch(function (err) {
            console.error(err);
            logToDiv(err, 'response-logs');
        });
}

function getGoogleTransactionInfo() {
    return {
        countryCode: 'US',
        currencyCode: "USD",
        totalPriceStatus: "FINAL",
        totalPrice: document.getElementById('total-price').value
    };
}