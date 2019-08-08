// var nastyXSS = "<script>alert(\"Busted!\");</script>";
var nastyXSS = nastyFunction();

// document.body.appendChild(innerHTML(nastyXSS));
// document.body.appendChild(createTextNode(nastyXSS));
document.body.appendChild(textContent(nastyXSS));
// document.body.appendChild(innerHTMLStripped(nastyXSS));
// document.body.appendChild(innerHTMLEscaped(nastyXSS));

function innerHTML(input) {
    var element = document.createElement('div');
    element.innerHTML = '<b>' + input + '</b>';
    return element;
}

// This one is safe;
function createTextNode(input) {
    var element = document.createElement('div');
    var b = document.createElement('b');
    b.appendChild(document.createTextNode(input));
    element.appendChild(b);
    return element;
}

// This one is safe.
function textContent(input) {
    var element = document.createElement('div');
    var b = document.createElement('b');

    b.textContent = input;
    element.appendChild(b);
    return element;
}

// This one is safe.
function innerHTMLStripped(input) {
    var element = document.createElement('div');
    var b = document.createElement('b');

    b.innerHTML = input;

    for (var i = 0; i < b.childNodes.length; i++) {
        if (b.childNodes[i].nodeType !== Node.TEXT_NODE) {
            b.removeChild(b.childNodes[i]);
        }
    }

    element.appendChild(b);
    return element;
}

// This one deemed to be safe as well (it makes it impossible to inject the <script> tag through input text.
function innerHTMLEscaped(input) {
    var escaped = input
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');

    var element = document.createElement('div');
    element.innerHTML = '<b>' + escaped + '</b>';

    return element;
}
