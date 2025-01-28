// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#btnGuardar").on("click", function () {
    var tarea = {
        Titulo: $("#titulo").val(),
        Descripcion: $("#descripcion").val()
    };

    $.ajax({
        url: "/Tareas/CrearTarea", // Ruta del método en el controlador
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(tarea),
        success: function (response) {
            if (response.success) {
                location.reload(); // Recarga la página si la tarea se guarda con éxito
            } else {
                alert(response.message);
            }
        },
        error: function (error) {
            alert("Ocurrió un error al guardar la tarea.");
            console.log(error); // Muestra el error en la consola
        }
    });
});