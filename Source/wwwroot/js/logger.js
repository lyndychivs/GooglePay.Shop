function logToDiv(log, divId) {
    logToString = JSON.stringify(log);
    var container = document.getElementById(divId);
    var logElement = document.createElement('pre');
    logElement.innerHTML = logToString;
    container.appendChild(logElement);
}

function clearLogs() {
    var requestDiv = document.getElementById('request-logs');
    requestDiv.innerHTML = '';

    var responseDiv = document.getElementById('response-logs');
    responseDiv.innerHTML = '';

    console.clear();
}