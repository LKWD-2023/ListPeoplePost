$(() => {
    $("#add-with-modal").on('click', function () {
        new bootstrap.Modal($("#add-person-modal")[0]).show();
    })
})