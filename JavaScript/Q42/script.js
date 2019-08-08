// Copies the contents of one box into another
function copyContents(from, to) {
    for (var i = 0; i < from.childNodes.length; i++) {
        to.appendChild(from.childNodes[i]);
    }
}

// Create a box to copy
var referenceBox = document.createElement('div');

var link = document.createElement('a');
link.href = 'https://www.example.com/';
link.textContent = 'A link';

// referenceBox.appendChild(link); // lame implementation, commented out.

function getNewLinkInstance() {
    var link = document.createElement('a');
    link.href = 'https://www.example.com/';
    link.textContent = 'A link';
    return link;
}

// Add box copies to the document
for (var i = 0; i < 5; i++) {
    var newBox = document.createElement('div');
    referenceBox.appendChild(getNewLinkInstance());
    // The following line transfers (not copies!) a link from referenceBox to the newBox.
    copyContents(referenceBox, newBox);

    document.body.appendChild(newBox);
}
