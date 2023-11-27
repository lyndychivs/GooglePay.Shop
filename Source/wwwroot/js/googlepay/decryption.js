function getElementValue(id) {
    return document.getElementById(id).value;
}

function submitForDecryption() {
    var privateKey = getElementValue('private-key');
    var encryptedToken = getElementValue('encrypted-token');

    var googlePayDecryptionRequest = "{ \"PrivateKey\": \"" + privateKey + "\", \"EncryptedToken\": \"" + encryptedToken + "\" }";

    PostDecryptionRequestToApi(googlePayDecryptionRequest);
}

function PostDecryptionRequestToApi(googlePayDecryptionRequest) {
    console.log('googlePayDecryptionRequest=' + googlePayDecryptionRequest);

    fetch('https://localhost:433/GooglePay/Decrypt', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: googlePayDecryptionRequest
    })
        .then(response => response.json())
        .then(response => updateElementInnerHtmlWithJson(response, 'response'))
}