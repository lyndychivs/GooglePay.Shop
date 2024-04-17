const baseRequest = {
    apiVersion: 2,
    apiVersionMinor: 0
};

var tokenizationSpecificationGateway = {
    type: 'PAYMENT_GATEWAY',
    parameters: {
        'gateway': getElementValue('tokenizationSpecificationParametersGateway'),
        'gatewayMerchantId': getElementValue('tokenizationSpecificationParametersGatewayMerchantId')
    }
};

var tokenizationSpecificationDirect = {
    type: 'DIRECT',
    parameters: {
        protocolVersion: getElementValue('tokenizationSpecificationParametersProtocolVersion'),
        publicKey: getElementValue('tokenizationSpecificationParametersPublicKey')
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
    var tokenType = getElementValue('tokenizationSpecificationType');
    if (tokenType == 'DIRECT') {
        return cardPaymentMethodDirect;
    }
    return cardPaymentMethodGateway;
}

function getllowedAuthMethods() {
    var authMethods = getElementValue('allowedAuthMethods');
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
                updateElementInnerHtml('Failed to call addGooglePayButton() paymentsClient.isReadyToPay response was false. (Perhaps the getGoogleIsReadyToPayRequest() configuration is now invalid.)', 'responseLog');
                getAndClearGooglePayDiv();
            }
        })
        .catch(function (err) {
            console.error(err);
            updateElementInnerHtml(err, 'responseLog');
            getAndClearGooglePayDiv();
        });
}

function getGoogleTransactionInfo() {
    return {
        countryCode: 'US',
        currencyCode: "USD",
        totalPriceStatus: "FINAL",
        totalPrice: getElementValue('totalPrice')
    };
}

function getGooglePayDiv() {
    return document.getElementById('googlePayButton');
}

function getAndClearGooglePayDiv() {
    var googlePayDiv = getGooglePayDiv();
    googlePayDiv.innerHTML = '';
    return googlePayDiv;
}

function copyTokenToClipboard() {
    var copyText = document.getElementById('responseToken');
    navigator.clipboard.writeText(copyText.innerText);
}

function copyBase64TokenToClipboard() {
    var copyText = document.getElementById('responseTokenBase64Encoded');
    navigator.clipboard.writeText(copyText.innerText);
}

function renderAllowedTokenizationSpecificationParameters() {
    var specificationType = getElementValue('tokenizationSpecificationType');

    if (specificationType == 'DIRECT') {
        setElementDisabledValue('tokenizationSpecificationParametersGateway', true);
        setElementDisabledValue('tokenizationSpecificationParametersGatewayMerchantId', true);
        setElementDisabledValue('tokenizationSpecificationParametersProtocolVersion', false);
        setElementDisabledValue('tokenizationSpecificationParametersPublicKey', false);
        return;
    }

    setElementDisabledValue('tokenizationSpecificationParametersGateway', false);
    setElementDisabledValue('tokenizationSpecificationParametersGatewayMerchantId', false);
    setElementDisabledValue('tokenizationSpecificationParametersProtocolVersion', true);
    setElementDisabledValue('tokenizationSpecificationParametersPublicKey', true);
}

function setElementDisabledValue(id, value) {
    document.getElementById(id).disabled = value;
}

function getElementValue(id) {
    return document.getElementById(id).value;
}

function updatePaymentGatewayGatewayValue() {
    var value = getElementValue('tokenizationSpecificationParametersGateway');
    tokenizationSpecificationGateway.parameters.gateway = value;
}

function updatePaymentGatewayMerchantIdValue() {
    var value = getElementValue('tokenizationSpecificationParametersGatewayMerchantId');
    tokenizationSpecificationGateway.parameters.gatewayMerchantId = value;
}

function updateDirectParametersProtocolVersionValue() {
    var value = getElementValue('tokenizationSpecificationParametersProtocolVersion');
    tokenizationSpecificationDirect.parameters.protocolVersion = value;
}

function updateDirectParametersPublicKeyValue() {
    var value = getElementValue('tokenizationSpecificationParametersPublicKey');
    tokenizationSpecificationDirect.parameters.publicKey = value;
}