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

var baseCardPaymentMethod = {
    type: 'CARD',
    parameters: {
        allowedAuthMethods: getllowedAuthMethods(),
        allowedCardNetworks: ["AMEX", "DISCOVER", "INTERAC", "JCB", "MASTERCARD", "VISA"]
    }
};

function getCardPaymentMethod() {
    baseCardPaymentMethod.parameters.allowedAuthMethods = getllowedAuthMethods();
    return baseCardPaymentMethod;
}

var cardPaymentMethodGateway = Object.assign(
    {},
    getCardPaymentMethod(),
    {
        tokenizationSpecification: tokenizationSpecificationGateway
    }
);

var cardPaymentMethodDirect = Object.assign(
    {},
    getCardPaymentMethod(),
    {
        tokenizationSpecification: tokenizationSpecificationDirect
    }
);

function getGoogleIsReadyToPayRequest() {
    return Object.assign(
        {},
        baseRequest,
        {
            allowedPaymentMethods: [getCardPaymentMethod()]
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

function getllowedAuthMethods() {
    var authMethods = document.getElementById('allowedAuthMethods').value;
    if (authMethods == 'CRYPTO') {
        return ["CRYPTOGRAM_3DS"];
    }
    if (authMethods == 'PAN') {
        return ["PAN_ONLY"];
    }
    return ["PAN_ONLY", "CRYPTOGRAM_3DS"];
}

function addGooglePayButton() {
    const paymentsClient = getGooglePaymentsClient();
    var button = paymentsClient.createButton({ onClick: onGooglePaymentButtonClicked });
    var googleButtonDiv = getAndClearGooglePayDiv();
    googleButtonDiv.appendChild(button);
}

function getPaymentClientWithConfiguration() {
    const paymentsClient = getGooglePaymentsClient();
    paymentsClient.isReadyToPay(getGoogleIsReadyToPayRequest())
        .then(function (response) {
            if (response.result) {
                addGooglePayButton();
            }
            else {
                logToDiv('Failed to call addGooglePayButton() paymentsClient.isReadyToPay response was false. (Perhaps the getGoogleIsReadyToPayRequest() configuration is now invalid.)', 'response-logs');
                getAndClearGooglePayDiv();
            }
        })
        .catch(function (err) {
            console.error(err);
            logToDiv(err, 'response-logs');
            getAndClearGooglePayDiv();
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

function getGooglePayDiv() {
    return document.getElementById('googlepay-button');
}

function getAndClearGooglePayDiv() {
    var googlePayDiv = getGooglePayDiv();
    googlePayDiv.innerHTML = '';
    return googlePayDiv;
}