export function showDialog(dotnet, id) {
    console.log('showing dialog');
    const dialog = document.querySelector("dialog#" + id);
    if (dialog) {
        console.log('dialog found');
        dialog.showModal();

        dialog.addEventListener("close", (e) => {
            console.log('closing dialog');
            dotnet.invokeMethodAsync('CloseAsync', dialog.returnValue)
                .then(data => {
                    console.log(data);
                });
        });
    }
}

export function closeDialog(dotnet, id) {
    const dialog = document.querySelector("dialog#" + id);
    if (dialog) {
        dialog.close();
    }
}
