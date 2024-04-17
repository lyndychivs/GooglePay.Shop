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
    var requestDiv = document.getElementById('requestLog');
    requestDiv.innerHTML = '';

    var responseDiv = document.getElementById('responseLog');
    responseDiv.innerHTML = '';

    var responseTokenDiv = document.getElementById('responseToken');
    responseTokenDiv.innerHTML = '';

    var responseTokenB64Div = document.getElementById('responseTokenBase64Encoded');
    responseTokenB64Div.innerHTML = '';

    console.clear();
}