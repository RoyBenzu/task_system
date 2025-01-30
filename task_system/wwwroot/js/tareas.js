
$("#btnGuardar").on("click", function () {
    var tarea = {
        Titulo: $("#titulo").val(),
        Descripcion: $("#descripcion").val(),
        Responsable: $("#responsable").val()
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


$(document).on("click", ".btn-editar", function () {
    // Obtener los datos de la tarea
    var id = $(this).data("id");
    var titulo = $(this).closest("tr").find(".titulo").text();
    var descripcion = $(this).closest("tr").find(".descripcion").text();
    var responsable = $(this).closest("tr").find(".responsable").text();
    var estado = $(this).closest("tr").find(".estado").text().trim();

    // Asignar los datos al modal
    $("#editarId").val(id);
    $("#editarTitulo").val(titulo);
    $("#editarDescripcion").val(descripcion);
    $("#editarResponsable").val(responsable);
    $("#editarEstado").val(estado);

    // Mostrar el modal
    $("#modalEditarTarea").modal("show");
});

$("#btnActualizar").on("click", function () {
    var tarea = {
        Id: $("#editarId").val(),
        Titulo: $("#editarTitulo").val(),
        Descripcion: $("#editarDescripcion").val(),
        Responsable: $("#editarResponsable").val(),
        Estado: $("#editarEstado").val()
    };

    $.post("/Tareas/EditarTarea", tarea, function (response) {
        if (response.success) {
            location.reload();
        } else {
            alert(response.message);
        }
    });
});

// Cambiar color según estado seleccionado
$("#editarEstado").on("change", function () {
    var estado = $(this).val();
    var estadoBadge = $("#estadoBadge");

    if (estado === "Finalizado") {
        estadoBadge.removeClass("badge-warning").addClass("badge-success").text("Finalizado");
    } else {
        estadoBadge.removeClass("badge-success").addClass("badge-warning").text("En proceso");
    }
});




