export function showDialog(dotnet, id) {
    const dialog = document.querySelector("dialog#" + id);
    if (dialog) {
        dialog.showModal();

        dialog.addEventListener("close", (e) => {
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
