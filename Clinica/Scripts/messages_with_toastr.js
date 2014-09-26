toastr.options = {
    "closeButton": true,
    "debug": false,
    "positionClass": "toast-top-full-width", //"toast-top-right", "toast-bottom-right", "toast-bottom-left", "toast-top-left", "toast-bottom-full-width",
    "onclick": null,
    "showDuration": "200",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function MostrarMensaje(tipo, mensaje) {
    if (tipo == "ERROR") {
        toastr.error(mensaje);
    }
    else if (tipo == "SUCCESS") { //CORRECT
        toastr.success(mensaje);
    }
    else if (tipo == "WARNING") {
        toastr.warning(mensaje);
    }
    else if (tipo == "INFO") {
        toastr.info(mensaje);
    }
}