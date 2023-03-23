function mostrarAlerta(controller, action, id, message) {
    Swal.fire({
        title: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc3545',
        confirmButtonText: 'Si, eliminar!',
        cancelButtonColor: '#6e7881',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `${controller}/${action}/${id}`;
        }
    })
}