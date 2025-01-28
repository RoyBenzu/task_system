
$("#btnGuardar").on("click", function () {
    var tarea = {
        Titulo: $("#titulo").val(),
        Descripcion: $("#descripcion").val()
    };

    $.ajax({
        url: "/Tareas/CrearTarea",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(tarea),
        success: function (response) {
            if (response.success) {
                alert("Tarea guardada exitosamente");
                location.reload();
            } else {
                alert(response.message);
            }
        },
        error: function (error) {
            alert("Error al guardar la tarea");
            console.log(error);
        }
    });
});

$(document).on("click", ".btn-eliminar", function () {
    var Id = $(this).data("id"); // Obtener el Id de la tarea desde el botón

    console.log("Id enviado para eliminar:", Id); // Verifica qué Id se está enviando

    if (confirm("¿Estás seguro de que deseas eliminar esta tarea?")) {
        $.ajax({
            url: "/Tareas/EliminarTarea",
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify({ Id: Id }),
            success: function (response) {
                if (response.success) {
                    alert("Tarea eliminada exitosamente.");
                    location.reload();
                } else {
                    alert(response.message);
                }
            },
            error: function (error) {
                alert("Ocurrió un error al eliminar la tarea.");
                console.log(error);
            }
        });
    }
});

