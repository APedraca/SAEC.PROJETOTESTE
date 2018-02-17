$(document).ready(function () {
    google.charts.load('current', { packages: ['corechart', 'bar'] });
    google.charts.setOnLoadCallback(drawBasic);

    function drawBasic() {

        var data = new google.visualization.DataTable();
        data.addColumn('timeofday', 'Horas');
        data.addColumn('number', 'Quatidade de alunos');

        $.ajax({
            url: '/Grafico/AlunoHorarioData/',
            async: false,
            success: function (alunoHorario) {
                var result = [];
                $.each(alunoHorario,
                    function (index, element) {
                        result.push([{ v: [element.Hora, 0, 0], f: element.Hora + ':00' }, element.Quantidade]);
                    });
                data.addRows(result);
            }
        });

        var options = {
            height: 400,
            title: 'Alunos Cadastrados por Hora',
            hAxis: {
                title: 'Horas',
                format: 'H:mm',
                viewWindow: {
                    min: [0, 0, 0],
                    max: [23, 0, 0]
                }
            },
            vAxis: {
                title: 'Quantidade de alunos'
            }
        };

        var chart = new google.visualization.ColumnChart(
            document.getElementById('chart_div'));

        chart.draw(data, options);
    }
});