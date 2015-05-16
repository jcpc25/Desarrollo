/// <reference path="../coes/utils.js" />


angular.module('COES.Generacion.Controller', []).controller('COESGeneracionController',
['$scope', '$location', '$window', 'COESGeneracionService',
    function ($scope, $location, $window, srvCOES) {

        $scope.Data;

        var syesterday = COES.utils.dateYesterday();
        var today = new Date();
        var yesterday1 = new Date();
        yesterday1.setDate(today.getDate() - 1);
        yesterday1.setHours(0, 0, 0, 0);

        var yesterday = moment(yesterday1);

        $scope.dateTimeParam = syesterday + " - " + syesterday;
        $scope.dateTimeParamMD = syesterday + " - " + syesterday;

        $scope.fechaSCADA = syesterday;
        $scope.fechaMedidores = syesterday;

        $scope.selectedGeneracion = true;
        $scope.initMDLoaded = false;

        $('#SwitchGeneracion').on('switchChange.bootstrapSwitch', function (e, data) {

            $('#exportSCADA').toggle();
            $('#exportMedidores').toggle();

            $scope.selectedGeneracion = $('#SwitchGeneracion').bootstrapSwitch('state');

            if ($scope.selectedGeneracion == true) {
                $('.bootstrap-switch-label').html("Medidores");

                $('#GeneracionMedidores').hide('slide', { direction: 'left' }, 1000);
                $('#GeneracionSCADA').show('slide', { direction: 'right' }, 1000);
            }
            else {

                $('.bootstrap-switch-label').html("SCADA");


                $('#GeneracionSCADA').hide('slide', { direction: 'left' }, 1000);
                $('#GeneracionMedidores').show('slide', { direction: 'right' }, 1000);

                if ($scope.initMDLoaded == false) {
                    $scope.initMD();
                    $scope.initMDLoaded = true;
                }

            }
        });

        $scope.exportGeneracionSCADA = function () {
            srvCOES.exportGeneracionSCADA($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                window.open(data.FileURL);
            });
        }

        $scope.exportGeneracionMedidores = function () {
            srvCOES.exportGeneracionMedidores($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                window.open(data.FileURL);
            });
        }


        /////////////////////////// GENERACION SCADA /////////////////////////////////

        $scope.generacion;
        $scope.generacionTipoGenCOES;
        $scope.generacionTotal;

        $scope.fechaInicio = yesterday.toISOString();
        $scope.fechaFin = yesterday.toISOString();

        $scope.getGeneracion = function () {

            srvCOES.getGeneracion($scope.fechaInicio, $scope.fechaFin).then(function (data) {

                $scope.generacion = data[0];

                var sum = data[1];

                $scope.generacionTotal = COES.utils.formatCurrencyCOESSingle(sum);
            });

        };

        $scope.getGeneracionTipoGen = function () {

            srvCOES.getGeneracionTipoGen($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                $scope.getGeneracionTipoGenBarChart(data);
            });
        };

        $scope.getGeneracionTipoGenCOES = function () {

            srvCOES.getGeneracionTipoGenCOES($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                $scope.generacionTipoGenCOES = data;
            });
        };

        $scope.getGeneracionTipoGenBarChart = function (data) {

            var options = {
                chart: {
                    type: 'bar',
                    renderTo: 'chartGeneracion',
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                xAxis: {
                    categories:
                        []
                },
                yAxis: {
                    min: 0,
                    labels: {
                        format: '{value} MWh'
                    },
                    title: {
                        text: ''
                    }
                },
                legend: {
                    backgroundColor: '#FFFFFF'
                },
                plotOptions: {
                    series: {
                        stacking: 'normal'
                    }
                },
                series: []
            };



            var chart = new Highcharts.Chart(options);

            chart.xAxis[0].setCategories(data.Categorias);

            for (var i = 0; i < data.Series.length; i++) {

                var colorSerie = '';

                if (data.Series[i].name == 'Hidroeléctrica') {
                    colorSerie = '#3498DB';
                }
                else if (data.Series[i].name == 'Solar') {
                    colorSerie = '#AB1A25';
                }
                else if (data.Series[i].name == 'Termoeléctrica') {
                    colorSerie = '#FFD700';
                }
                else if (data.Series[i].name == 'Eólica') {
                    colorSerie = '#69D080';
                }
                else if (data.Series[i].name == 'Hidráulica') {
                    colorSerie = '#3498DB';
                }
                else if (data.Series[i].name == 'Térmica') {
                    colorSerie = '#FFD700';
                }

                chart.addSeries({
                    name: data.Series[i].name,
                    data: data.Series[i].data,
                    color: colorSerie
                });
            }


        };

        $scope.changeChart = function (nombreEmpresa) {

            $('#chartGeneracion').hide();
            $("#chartGeneracionPie").show();
            $("#imgChart").show();
            var borderPie = 0;
            var generacionTipoGenEmpresa = $scope.generacionTipoGenCOES.filter(function (x) {
                return x.EMPRNOMB == nombreEmpresa;
            });

            var dataPie = [];
            for (var i = 0; i < generacionTipoGenEmpresa.length; i++) {
                dataPie.push([COES.utils.getTipoGeneracion(generacionTipoGenEmpresa[i].TIPOGEN), parseFloat(generacionTipoGenEmpresa[i].TOTALGEN)]);
            }
            if (dataPie.length > 1) {
                borderPie = 1;
            }

            $('#chartGeneracionPie').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: nombreEmpresa
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                plotOptions: {
                    pie: {
                        borderWidth: borderPie,
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: '{point.percentage:.3f} %'
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Generacion',
                    data: dataPie
                }]
            });

        };

        $scope.setChartTotal = function () {

            $('#chartGeneracion').hide();
            $("#chartGeneracionPie").show();
            $("#imgChart").show();



            var dataPie = [];
            for (var i = 0; i < $scope.generacion.length; i++) {
                dataPie.push([$scope.generacion[i].EMPRNOMB, parseFloat($scope.generacion[i].TOTALGEN)]);
            }

            $('#chartGeneracionPie').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: "Total Generación"
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: '<b>{point.name}</b>: {point.percentage:.3f} %'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Generacion',
                    data: dataPie
                }]
            });

        };

        $scope.getGeneracionTipoCombustible = function () {

            srvCOES.getGeneracionTipoCombustibleStock($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                $scope.StockChartTipoCombustible(data);
            });

        };

        $scope.StockChartTipoCombustible = function (data) {

            var seriesOptions = [];
            var title = "";


            for (var i = 0; i < data.Series.length; i++) {

                var serie = [];
                title = data.Series[i].name + " - " + title;

                for (var k = 0; k < data.Series[i].data.length; k++) {

                    var seriePoint = [];

                    var now = new Date(data.Series[i].data[k].Key);
                    var nowUTC = Date.UTC(now.getFullYear(), now.getMonth(), now.getDate(), now.getHours(), now.getMinutes(), now.getSeconds());

                    seriePoint.push(nowUTC);
                    seriePoint.push(data.Series[i].data[k].Value);
                    serie.push(seriePoint);
                }

                seriesOptions[i] = {
                    name: data.Series[i].name,
                    data: serie,
                    type: 'area',
                    color: COES.utils.getColorCombustible(data.Series[i].name)
                };
            }


            $('#chartCombustible').highcharts('StockChart', {
                chart: {
                    type: 'area'
                },
                rangeSelector: {
                    buttons: [
                        {
                            count: 1,
                            type: 'day',
                            text: 'D'
                        },
                        {
                            count: 1,
                            type: 'week',
                            text: 'S'
                        },
                        {
                            count: 1,
                            type: 'month',
                            text: 'M'
                        },
                        {
                            type: 'all',
                            text: 'Todo'
                        }
                    ],
                    selected: 0,
                    allButtonsEnabled: true,
                    visible: false

                },
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    labels: {
                        formatter: function () {
                            return this.value + ' MWh';
                        }
                    },
                    plotLines: [{
                        value: 0,
                        width: 2,
                        color: 'silver'
                    }]
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0,
                    enabled: true
                },
                tooltip: {
                    pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.percentage:.0f}%</b> ({point.y:,.3f} MWh)<br/>',
                    shared: true
                },
                plotOptions: {
                    area: {
                        stacking: 'percent',
                        lineColor: '#ffffff',
                        lineWidth: 1,
                        marker: {
                            lineWidth: 1,
                            lineColor: '#ffffff'
                        }
                    }
                },
                series: seriesOptions
            });


        };


        $scope.StackChart = function () {
            $("#chartGeneracion").show();
            $("#chartGeneracionPie").hide();
            $("#imgChart").hide();
        };

        $scope.init = function () {

            $("#imgChart").hide();
            $scope.getGeneracion();
            $scope.getGeneracionTipoGen();
            $scope.getGeneracionTipoGenCOES();
            $scope.getGeneracionTipoCombustible();

            $('#fecha').daterangepicker({ format: 'DD/MM/YYYY', startDate: yesterday, endDate: yesterday }, function (start, end, label) {

                $scope.fechaSCADA = end.format("DD/MM/YYYY");

                $scope.fechaInicio = start.toISOString2();
                $scope.fechaFin = end.toISOString2();

                $scope.getGeneracion();
                $scope.getGeneracionTipoGen();
                $scope.getGeneracionTipoGenCOES();
                $scope.getGeneracionTipoCombustible();
            });
        };

        $scope.init();


        /////////////////////////// GENERACION MEDIDORES /////////////////////////////////

        $scope.generacionMD;
        $scope.generacionTipoGenCOESMD;
        $scope.generacionTotalMD;

        $scope.fechaInicioMD = yesterday.toISOString();
        $scope.fechaFinMD = yesterday.toISOString();

        $scope.getGeneracionMD = function () {

            srvCOES.getGeneracionMD($scope.fechaInicioMD, $scope.fechaFinMD).then(function (data) {

                $scope.generacionMD = data[0];

                var sum = data[1];

                $scope.generacionTotalMD = COES.utils.formatCurrencyCOESSingle(sum);
            });

        };

        $scope.getGeneracionTipoGenMD = function () {

            srvCOES.getGeneracionTipoGenMD($scope.fechaInicioMD, $scope.fechaFinMD).then(function (data) {
                $scope.getGeneracionTipoGenBarChartMD(data);
            });
        };

        $scope.getGeneracionTipoGenCOESMD = function () {

            srvCOES.getGeneracionTipoGenCOESMD($scope.fechaInicioMD, $scope.fechaFinMD).then(function (data) {
                $scope.generacionTipoGenCOESMD = data;
            });
        };

        $scope.getGeneracionTipoGenBarChartMD = function (data) {

            var options = {
                chart: {
                    type: 'bar',
                    renderTo: 'chartGeneracionMD',
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                xAxis: {
                    categories:
                        []
                },
                yAxis: {
                    min: 0,
                    labels: {
                        format: '{value} MWh'
                    },
                    title: {
                        text: ''
                    }
                },
                legend: {
                    backgroundColor: '#FFFFFF'
                },
                plotOptions: {
                    series: {
                        stacking: 'normal'
                    }
                },
                series: []
            };

            var chart = new Highcharts.Chart(options);

            chart.xAxis[0].setCategories(data.Categorias);

            for (var i = 0; i < data.Series.length; i++) {

                var colorSerie = '';

                if (data.Series[i].name.toUpperCase()   == 'HIDROELÉCTRICA') {
                    colorSerie = '#3498DB';
                }
                else if (data.Series[i].name.toUpperCase() == 'SOLAR'  ) {
                    colorSerie = '#AB1A25';
                }
                else if (data.Series[i].name.toUpperCase()  == 'TERMOELÉCTRICA') {
                    colorSerie = '#FFD700';
                }
                else if (data.Series[i].name.toUpperCase() == 'EOLICA') {
                    colorSerie = '#69D080';
                }
                else if (data.Series[i].name.toUpperCase() == 'HIDRÁULICA') {
                    colorSerie = '#3498DB';
                }
                else if (data.Series[i].name.toUpperCase() == 'TÉRMICA') {
                    colorSerie = '#FFD700';
                }


                chart.addSeries({
                    name: data.Series[i].name,
                    data: data.Series[i].data,
                    color: colorSerie
                });
            }


        };

        $scope.changeChartMD = function (nombreEmpresa) {

            $('#chartGeneracionMD').hide();
            $("#chartGeneracionPieMD").show();
            $("#imgChartMD").show();

            var generacionTipoGenEmpresa = $scope.generacionTipoGenCOESMD.filter(function (x) {
                return x.EMPRNOMB == nombreEmpresa;
            });

            var borderPie = 0;
            var dataPie = [];
            for (var i = 0; i < generacionTipoGenEmpresa.length; i++) {
                dataPie.push([COES.utils.getTipoGeneracion(generacionTipoGenEmpresa[i].TIPOGENERACION), parseFloat(generacionTipoGenEmpresa[i].ENERGIA)]);

            }

            if (dataPie.length > 1) {
                borderPie = 1;
            }


            $('#chartGeneracionPieMD').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: nombreEmpresa
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                plotOptions: {
                    pie: {
                        borderWidth: borderPie,
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: '{point.percentage:.3f} %'
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Generacion',
                    data: dataPie
                }]
            });

        };

        $scope.setChartTotalMD = function () {

            $('#chartGeneracionMD').hide();
            $("#chartGeneracionPieMD").show();
            $("#imgChartMD").show();



            var dataPie = [];
            for (var i = 0; i < $scope.generacionMD.length; i++) {
                dataPie.push([$scope.generacionMD[i].EMPRNOMB, parseFloat($scope.generacionMD[i].ENERGIA.replaceAll(" ", "").replaceAll(",", "."))]);
            }

            $('#chartGeneracionPieMD').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: "Total Generación"
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y:.3f} MWh</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: '<b>{point.name}</b>: {point.percentage:.3f} %'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Generacion',
                    data: dataPie
                }]
            });

        };

        $scope.getGeneracionTipoCombustibleMD = function () {

            srvCOES.getGeneracionTipoCombustibleMDStock($scope.fechaInicioMD, $scope.fechaFinMD).then(function (data) {
                $scope.StockChartTipoCombustibleMD(data);
            });
        };

        $scope.StockChartTipoCombustibleMD = function (data) {

            var seriesOptions = [];
            var title = "";


            for (var i = 0; i < data.Series.length; i++) {

                var serie = [];
                title = data.Series[i].name + " - " + title;



                for (var k = 0; k < data.Series[i].data.length; k++) {

                    var seriePoint = [];

                    var now = new Date(data.Series[i].data[k].Key);
                    var nowUTC = Date.UTC(now.getFullYear(), now.getMonth(), now.getDate(), now.getHours(), now.getMinutes(), now.getSeconds());

                    seriePoint.push(nowUTC);
                    seriePoint.push(data.Series[i].data[k].Value);
                    serie.push(seriePoint);
                }

                seriesOptions[i] = {
                    name: data.Series[i].name,
                    data: serie,
                    type: 'area',
                    color: COES.utils.getColorCombustible(data.Series[i].name)
                };
            }


            $('#chartCombustibleMD').highcharts('StockChart', {
                chart: {
                    type: 'area'
                },
                rangeSelector: {
                    buttons: [
                        {
                            count: 1,
                            type: 'day',
                            text: 'D'
                        },
                        {
                            count: 1,
                            type: 'week',
                            text: 'S'
                        },
                        {
                            count: 1,
                            type: 'month',
                            text: 'M'
                        },
                        {
                            type: 'all',
                            text: 'Todo'
                        }
                    ],
                    selected: 0,
                    allButtonsEnabled: true,
                    visible: false

                },
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    labels: {
                        formatter: function () {
                            return this.value + ' MWh';
                        }
                    },
                    plotLines: [{
                        value: 0,
                        width: 2,
                        color: 'silver'
                    }]
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0,
                    enabled: true
                },
                tooltip: {
                    pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.percentage:.0f}%</b> ({point.y:,.3f} MWh)<br/>',
                    shared: true
                },
                plotOptions: {
                    area: {
                        stacking: 'percent',
                        lineColor: '#ffffff',
                        lineWidth: 1,
                        marker: {
                            lineWidth: 1,
                            lineColor: '#ffffff'
                        }
                    }
                },
                series: seriesOptions
            });



        };


        $scope.StackChartMD = function () {
            $("#chartGeneracionMD").show();
            $("#chartGeneracionPieMD").hide();
            $("#imgChartMD").hide();
        };

        $scope.initMD = function () {

            $("#imgChartMD").hide();
            $scope.getGeneracionMD();
            $scope.getGeneracionTipoGenMD();
            $scope.getGeneracionTipoGenCOESMD();
            $scope.getGeneracionTipoCombustibleMD();

            $('#fechaMD').daterangepicker({ format: 'DD/MM/YYYY', startDate: yesterday, endDate: yesterday }, function (start, end, label) {

                $scope.fechaMedidores = end.format("DD/MM/YYYY");

                $scope.fechaInicioMD = start.toISOString2();
                $scope.fechaFinMD = end.toISOString2();

                $scope.getGeneracionMD();
                $scope.getGeneracionTipoGenMD();
                $scope.getGeneracionTipoGenCOESMD();
                $scope.getGeneracionTipoCombustibleMD();
            });
            
            
        };

    }])