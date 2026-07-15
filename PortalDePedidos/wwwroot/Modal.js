
function AlertaFallo(msj) {
    //console.log(msj);
    document.getElementById("msjModalFallo").innerText = msj;
    $('#modalFallo').modal('show')
}

function AlertaExito(msj) {
    //console.log(msj);
    document.getElementById("msjModalExito").innerText = msj;
    $('#modalExito').modal('show')
}

function AlertaDeuda(msj) {
    //console.log(msj);
    document.getElementById("msjModalDeuda").innerText = msj;
    $('#modalDeuda').modal('show')
}

function CerrarAlertaDeuda() {
    $('#modalDeuda').modal('hide')
}

function AlertaArticulo(msj) {
    // Mostrar el mensaje en el modal
    document.getElementById("msjModalArt").innerText = msj;

    // Mostrar el modal
    $('#modalArt').modal('show');

    // Ocultar el modal después de 1 segundo (1000 milisegundos)
    setTimeout(function () {
        $('#modalArt').modal('hide');
    }, 2000);
}

function AlertaAbrir(id) {

    // Mostrar el modal
    $(id).modal('show');

}

function AlertaCerrar(id) {

    // Mostrar el modal
    $(id).modal('hide');

}