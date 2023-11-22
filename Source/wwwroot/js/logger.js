function updateElementInnerHtml(text, id) {
    var container = document.getElementById(id);
    container.innerHTML = text;
}

function updateElementInnerHtmlWithJson(jsonAsObject, id) {
    jsonAsString = JSON.stringify(jsonAsObject, null, 4);
    var container = document.getElementById(id);
    container.innerHTML = jsonAsString;
}

function clearLogs() {
    var requestDiv = document.getElementById('request-log');
    requestDiv.innerHTML = '';

    var responseDiv = document.getElementById('response-log');
    responseDiv.innerHTML = '';

    var responseTokenDiv = document.getElementById('token-log');
    responseTokenDiv.innerHTML = '';

    var responseTokenB64Div = document.getElementById('token-b64-log');
    responseTokenB64Div.innerHTML = '';

    console.clear();
}