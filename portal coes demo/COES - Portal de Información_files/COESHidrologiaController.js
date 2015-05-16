/// <reference path="../coes/utils.js" />

angular.module('COES.Hidrologia.Controller', []).controller('COESHidrologiaController',
['$scope', '$location', '$window', 'COESHidrologiaService',
    function ($scope, $location, $window, srvCOES) {

        $scope.Data;

        var syesterday = COES.utils.dateYesterday();
        var today = new Date();
        var yesterday1 = new Date();
        yesterday1.setDate(today.getDate() - 1);
        yesterday1.setHours(0, 0, 0, 0);

        var yesterday = moment(yesterday1);


        $scope.dateTimeParam = syesterday + " - " + syesterday;

        $scope.Hidrologia;
        $scope.HidrologiaColumnDefs;
        $scope.HidrologiaChart;

        $scope.fechaInicio = yesterday.toISOString();
        $scope.fechaFin = yesterday.toISOString();

        $scope.exportHidrologia = function () {
            srvCOES.exportHidrologia($scope.fechaInicio, $scope.fechaFin).then(function (data) {
                window.open(data.FileURL);
            });
        }

        $scope.getHidrologia = function () {

            srvCOES.getHidrologia($scope.fechaInicio, $scope.fechaFin).then(function (data) {

                var objJson = $.parseJSON(data.data);

                for (var i = 0; i < objJson.length; i++) {
                    COES.utils.formatCurrencyCOES(objJson[i]);
                }

                $scope.Hidrologia = objJson;
                $scope.HidrologiaColumnDefs = data.columnDefs;
                console.log(data);
            });

        };

        $scope.getChartHidrologia = function (tipoGrafica) {

            if (tipoGrafica == "") {
                $(".btn-Data").hide();
                $(".btn-ChartVolumen").show();
                $(".btn-ChartNivel").show();

                $(".gridStyle").show();
                $(".info-Chart").hide();

            }
            else {
                $(".btn-Data").show();
                $(".btn-ChartVolumen").show();
                $(".btn-ChartNivel").show();

                $(".gridStyle").hide();
                $(".info-Chart").show();

                srvCOES.getChartHidrologia(tipoGrafica, $scope.fechaInicio, $scope.fechaFin).then(function (data) {
                    $scope.HidrologiaChart = data;
                    $scope.setChartHidrologia(tipoGrafica, data);

                    $scope.gridOptions = {
                        data: 'Hidrologia',
                        enableRowSelection: false,
                        enableColumnResize: true,
                        columnDefs: 'HidrologiaColumnDefs'
                    };
                });
            }
        };

        $scope.setChartHidrologia = function (tipoGrafica, data) {

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
                    data: serie
                };
            }



            $('#chartHidrologia').highcharts('StockChart', {

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
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0,
                    enabled: true
                },
                tooltip: {
                    pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y} ' + tipoGrafica + '</b><br/>',
                    valueDecimals: 2
                },
                series: seriesOptions
            });
        };

        $scope.init = function () {

            $(".btn-Data").hide();
            $(".info-Chart").hide();

            $scope.getHidrologia();

            $('#fecha').daterangepicker({ format: 'DD/MM/YYYY' , startDate: yesterday , endDate: yesterday}, function (start, end, label) {

                $scope.fechaInicio = start.toISOString2();
                $scope.fechaFin = end.toISOString2();
                $scope.getHidrologia();

            });

            $scope.nroItems = 25;

        };

        $scope.gridOptions = {
            data: 'Hidrologia',
            enableRowSelection: false,
            enableColumnResize: true,
            columnDefs: 'HidrologiaColumnDefs',

        };

        $scope.init();

    }])