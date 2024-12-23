window.copyToClipboard = (text) => {
    navigator.clipboard.writeText(text).then(() => {
        console.log("Text copied to clipboard");
    }).catch((err) => {
        console.error("Error copying to clipboard: ", err);
    });
};
