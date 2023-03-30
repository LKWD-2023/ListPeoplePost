$(() => {
    let num = 1;

    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row person-row" style='margin-bottom:10px;'>
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].firstname" placeholder="First Name"/>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].lastname" placeholder="Last Name"/>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].age" placeholder="Age"/>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-danger delete-row">Delete</button>
                </div>
            </div> `);
        num++;
    });

    $("#ppl-rows").on('click', '.delete-row', function () {
        const button = $(this);
        const row = button.closest('.row');
        row.remove();

        let counter = 0;

        $(".person-row").each(function () {
            const row = $(this);
            const inputs = row.find('input');

            inputs.each(function () {
                const input = $(this);
                const name = input.attr('name');
                const indexOfDot = name.indexOf('.');
                const attrName = name.substring(indexOfDot + 1);
                input.attr('name', `people[${counter}].${attrName}`);
            });

            counter++;
            num = counter;
        });

    })
});