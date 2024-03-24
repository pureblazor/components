export function copyToClipboard(text) {
    console.log('copying to clipboard...', text);
    navigator.clipboard.writeText(text).then(() => {
        console.log('Text copied to clipboard');
    }).catch(err => {
        console.error('Error copying text to clipboard:', err);
    });
}

export function getText(element) {
    console.log('getting text...', element && element.innerText);
    return element.innerText;
}

export function highlight() {
    console.log('highlighting...');
    try {
        window.Prism.highlightAll();
    } catch (err) {
        console.error('Error highlighting code:', err);
    }
}
