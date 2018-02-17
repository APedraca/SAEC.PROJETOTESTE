$(document).ready(function () {
    google.charts.load('current', { packages: ['corechart', 'bar'] });
    google.charts.setOnLoadCallback(drawBasic);

    function drawBasic() {

        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Cidade');
        data.addColumn('number', 'Quatidade de alunos');

        $.ajax({
            url: '/Grafico/AlunoCidadeData/',
            async: false,
            success: function (alunoHorario) {
                var result = [];
                $.each(alunoHorario,
                    function (index, element) {
                        result.push([element.Cidade, element.Quantidade]);
                    });
                data.addRows(result);
            }
        });

        var options = {
            height: 400,
            title: 'Alunos Cadastrados por Cidade',
            vAxis: {
                title: 'Quantidade de alunos'
            }
        };

        var chart = new google.visualization.ColumnChart(
            document.getElementById('chart_div'));

        chart.draw(data, options);
    }
});