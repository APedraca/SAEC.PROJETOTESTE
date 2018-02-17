$(document).ready(function () {
    var quantiadeDias = $("#quantidadeDias");
    var btnGerar = $("#btnGerar");

    btnGerar.on("click",
        function() {
            google.charts.load('current', { 'packages': ['line'] });
            google.charts.setOnLoadCallback(drawChart);
        });

    function drawChart() {

        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Day');
        data.addColumn('number', 'Quantidade de alunos');
         
        $.ajax({
            url: '/Grafico/AlunoDiasData?quantidadeDias=' + quantiadeDias.val(),
            async: false,
            success: function (alunoDias) {
                var result = [];
                $.each(alunoDias,
                    function (index, element) {
                        result.push([toJavaScriptDate(element.Dia), element.Quantidade]);
                    });
                data.addRows(result);
            }
        });

        var options = {
            height: 400,
            hAxis: {
                title: 'Dias',
                format: 'dd/MM/yyyy'
            }
        };

        var chart = new google.charts.Line(document.getElementById('chart_div'));

        chart.draw(data, google.charts.Line.convertOptions(options));
    }

    function toJavaScriptDate(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        return new Date(parseFloat(results[1]));
    }
});