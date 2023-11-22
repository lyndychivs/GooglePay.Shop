const baseRequest = {
    apiVersion: 2,
    apiVersionMinor: 0
};

var tokenizationSpecificationGateway = {
    type: 'PAYMENT_GATEWAY',
    parameters: {
        'gateway': getElementValue('tokenization-specification-parameters-gateway'),
        'gatewayMerchantId': getElementValue('tokenization-specification-parameters-gateway-merchant-id')
    }
};

var tokenizationSpecificationDirect = {
    type: 'DIRECT',
    parameters: {
        protocolVersion: getElementValue('tokenization-specification-parameters-protocol-version'),
        publicKey: getElementValue('tokenization-specification-parameters-public-key')
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
                updateElementInnerHtml('Failed to call addGooglePayButton() paymentsClient.isReadyToPay response was false. (Perhaps the getGoogleIsReadyToPayRequest() configuration is now invalid.)', 'response-log');
                getAndClearGooglePayDiv();
            }
        })
        .catch(function (err) {
            console.error(err);
            updateElementInnerHtml(err, 'response-log');
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

function copyTokenToClipboard() {
    var copyText = document.getElementById('token-log');
    navigator.clipboard.writeText(copyText.innerText);
}

function copyBase64TokenToClipboard() {
    var copyText = document.getElementById('token-b64-log');
    navigator.clipboard.writeText(copyText.innerText);
}

function renderAllowedTokenizationSpecificationParameters() {
    var specificationType = document.getElementById('tokenization-specification-type');

    if (specificationType.value == 'DIRECT') {
        setElementDisabledValue('tokenization-specification-parameters-gateway', true);
        setElementDisabledValue('tokenization-specification-parameters-gateway-merchant-id', true);
        setElementDisabledValue('tokenization-specification-parameters-protocol-version', false);
        setElementDisabledValue('tokenization-specification-parameters-public-key', false);
        return;
    }

    setElementDisabledValue('tokenization-specification-parameters-gateway', false);
    setElementDisabledValue('tokenization-specification-parameters-gateway-merchant-id', false);
    setElementDisabledValue('tokenization-specification-parameters-protocol-version', true);
    setElementDisabledValue('tokenization-specification-parameters-public-key', true);
}

function setElementDisabledValue(id, value) {
    document.getElementById(id).disabled = value;
}

function getElementValue(id) {
    return document.getElementById(id).value;
}

function updatePaymentGatewayGatewayValue() {
    var value = document.getElementById('tokenization-specification-parameters-gateway').value;
    tokenizationSpecificationGateway.parameters.gateway = value;
}

function updatePaymentGatewayMerchantIdValue() {
    var value = document.getElementById('tokenization-specification-parameters-gateway-merchant-id').value;
    tokenizationSpecificationGateway.parameters.gatewayMerchantId = value;
}

function updateDirectParametersProtocolVersionValue() {
    var value = document.getElementById('tokenization-specification-parameters-protocol-version').value;
    tokenizationSpecificationDirect.parameters.protocolVersion = value;
}

function updateDirectParametersPublicKeyValue() {
    var value = document.getElementById('tokenization-specification-parameters-public-key').value;
    tokenizationSpecificationDirect.parameters.publicKey = value;
}