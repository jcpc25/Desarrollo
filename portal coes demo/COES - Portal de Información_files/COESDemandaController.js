/// <reference path="../coes/utils.js" />

angular.module('COES.Demanda.Controller', []).controller('COESDemandaController',
['$scope', '$location', '$window', 'COESDemandaService',
    function ($scope, $location, $window, srvCOES) {

        $scope.Data;

        var syesterday = COES.utils.dateYesterday();
        var today = new Date();
        var yesterday1 = new Date();
        yesterday1.setDate(today.getDate() - 1);
        yesterday1.setHours(0, 0, 0, 0);

        var yesterday = moment(yesterday1);


        $scope.dateTimeParam = syesterday + " - " + syesterday;

        $scope.demanda;
        $scope.demandaData;


        $scope.fechaInicio = yesterday.toISOString();
        $scope.fechaFin = yesterday.toISOString();

        $scope.exportDemanda = function () {
            srvCOES.exportDemanda($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                window.open(data.FileURL);
            });
        }

        $scope.setMedidoresApp = function (url) {
            $('#appMedidoresFrame').attr("src", url);
        }

        $('#SwitchDemanda').on('switchChange.bootstrapSwitch', function (e, data) {                     

            $scope.selectedSCADA = $('#SwitchDemanda').bootstrapSwitch('state');

            if ($scope.selectedSCADA == true) {
                $('.bootstrap-switch-label').html("Máxima Demanda");
                $('#DemandaMaxContainer').hide('slide', { direction: 'left' }, 1000);
                $('#DemandaContainer').show('slide', { direction: 'right' }, 1000);
            }
            else {
                $('.bootstrap-switch-label').html("Demanda");
                $('#DemandaContainer').hide('slide', { direction: 'left' }, 1000);
                $('#DemandaMaxContainer').show('slide', { direction: 'right' }, 1000);
            }

        });
               

        $scope.ObtenerDemandaDespachoxFechaxPrograma = function () {

            srvCOES.ObtenerDemandaDespachoxFechaxPrograma($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                $scope.demanda = data.chart;
                $scope.demandaData = data.Data;
                $scope.setChartDemanda("MW", data.chart)
            });

        };

        $scope.setChartDemanda = function (tipoGrafica, data) {

            var seriesOptions = [];
            var title = "";

            for (var i = 0; i < data.Series.length; i++) {

                var serie = [];
                title = data.Series[i].name + " - " + title;


                for (var k = 0; k < data.Series[i].data.length; k++) {

                    var seriePoint = [];
                    //var now = COES.utils.dateStringToDate(data.Series[i].data[k].Key)
                    var now = new Date(data.Series[i].data[k].Key);
                    var nowUTC = Date.UTC(now.getFullYear(), now.getMonth(), now.getDate(), now.getHours(), now.getMinutes(), now.getSeconds());

                    seriePoint.push(nowUTC);
                    seriePoint.push(data.Series[i].data[k].Value);
                    serie.push(seriePoint);
                }

                var dashStyle = "shortdot";

                if (data.Series[i].name != "Ejecutado") {
                    dashStyle = "shortdot";
                }
                else {
                    dashStyle = "";
                }

                seriesOptions[i] = {
                    name: data.Series[i].name,
                    data: serie,
                    type: 'spline',
                    dashStyle: dashStyle
                };
            }


            $('#chartDemanda').highcharts('StockChart', {

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
                    selected: 3,
                    allButtonsEnabled: true,
                    visible: false
                },
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    labels: {
                        formatter: function () {
                            return this.value + ' ' + tipoGrafica;
                        }
                    },
                    plotLines: [{
                        value: 0,
                        width: 2,
                        color: 'silver'
                    }]
                },

                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'top',
                    borderWidth: 0,
                    enabled: true
                },

                tooltip: {
                    pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y} ' + tipoGrafica + '</b><br/>',
                    valueDecimals: 2
                },
                colors: ['#33B8FF', '#3DD19D', '#FF7A33'],
                series: seriesOptions
            });
        };


        $scope.init = function () {

            $scope.ObtenerDemandaDespachoxFechaxPrograma();            
		
            $('#fecha').daterangepicker({ format: 'DD/MM/YYYY', startDate: yesterday , endDate: yesterday }, function (start, end, label) {
                $scope.fechaInicio = start.toISOString2();
                $scope.fechaFin = end.toISOString2();
                $scope.ObtenerDemandaDespachoxFechaxPrograma();
            });
        };


        $scope.gridOptions = {
            data: 'demandaData',
            enableRowSelection: false,
            enableColumnResize: true,
            columnDefs: [{ field: 'Fecha', displayName: 'Fecha', width: '175px' }, { field: 'ValorEjecutado', displayName: 'Ejecutado', width: '85px' }, { field: 'ValorProgramacionDiaria', displayName: 'Prg Diaria', width: '95px' }, { field: 'ValorProgramacionSemanal', displayName: 'Prg Semanal', width: '95px' }],
        };


        $scope.init();

    }])