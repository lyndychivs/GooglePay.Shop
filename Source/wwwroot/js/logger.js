function logToDiv(log, divId) {
    logToString = JSON.stringify(log);
    var container = document.getElementById(divId);
    var logElement = document.createElement('pre');
    logElement.innerHTML = logToString;
    container.appendChild(logElement);
}