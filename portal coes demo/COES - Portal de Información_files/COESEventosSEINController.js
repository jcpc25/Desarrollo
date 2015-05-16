/// <reference path="../coes/utils.js" />
angular.module('COES.EventosSEIN.Controller', []).controller('COESEventosSEINController',
['$scope', '$location', '$window', 'COESEventosSEINService',
    function ($scope, $location, $window, srvCOES) {

        $scope.Data;

        var stoday = COES.utils.dateToday();
        var today = new Date();
        $scope.dateTimeParam = stoday + " - " + stoday;

        $scope.EventosPortal;

        $scope.Causas;
        $scope.Tensiones = ["(TODOS)", 500, 220, 138, 60, 72.5, 50, 44, 33, 24, 22.9, 13.8, 13.2, 11.5, 10, 10.5];
        $scope.TipoEmpresas;
        $scope.Empresas;
        $scope.Areas;

        $scope.Interrupciones = [
            { name: '(TODOS)', value: "T" },
            { name: 'SI', value: "S" },
            { name: 'NO', value: "N" }
        ];
        $scope.TipoEquipos;

        $scope.selectedCausaEvento;
        $scope.selectedTension = "(TODOS)";
        $scope.selectedTipoEmpresa;
        $scope.selectedEmpresa;
        $scope.selectedArea = 0;
        $scope.selectedInterrupcion = $scope.Interrupciones[0];
        $scope.selectedTipoEquipo;

        $scope.idCausaEvento = 0;
        $scope.idTipoEmpresa = 0;
        $scope.idEmpresa = 0;
        $scope.idArea = 0;
        $scope.idTipoEquipo = 0;

        $scope.nroPage = 1;
        $scope.nroItems = 25;
        $scope.pageSizes = [25, 50, 100, 200];

        $scope.fechaInicio = today.toISOString();
        $scope.fechaFin = today.toISOString();

        $scope.exportEventosPortal = function () {

            $scope.idCausaEvento = $scope.selectedCausaEvento == undefined ? 0 : $scope.selectedCausaEvento.CAUSAEVENCODI;
            $scope.idTipoEmpresa = $scope.selectedTipoEmpresa == undefined ? 0 : $scope.selectedTipoEmpresa.TIPOEMPRCODI;
            $scope.idEmpresa = $scope.selectedEmpresa == undefined ? 0 : $scope.selectedEmpresa.EMPRCODI;
            $scope.idArea = $scope.selectedArea == undefined ? 0 : $scope.selectedArea.AREACODI;
            $scope.idTipoEquipo = $scope.selectedTipoEquipo == undefined ? 0 : $scope.selectedTipoEquipo.FAMCODI;
            $scope.tension = $scope.selectedTension == "(TODOS)" ? -1 : $scope.selectedTension;
            $scope.interrupcion = $scope.selectedInterrupcion == undefined ? "T" : $scope.selectedInterrupcion.value;

            srvCOES.exportEventosPortal(
                    $scope.idCausaEvento,
                    $scope.idTipoEmpresa,
                    $scope.idEmpresa,
                    $scope.idArea,
                    $scope.idTipoEquipo,
                    $scope.tension,
                    $scope.interrupcion,
                    $scope.fechaInicio,
                    $scope.fechaFin,
                    $scope.nroPage,
                    $scope.nroItems).then(function (data) {
                        window.open(data.FileURL);
                    });
        }

        $scope.getEventosPortal = function () {

            $(".data").show();
            $(".chart").hide();

            $scope.idCausaEvento = $scope.selectedCausaEvento == undefined ? 0 : $scope.selectedCausaEvento.CAUSAEVENCODI;
            $scope.idTipoEmpresa = $scope.selectedTipoEmpresa == undefined ? 0 : $scope.selectedTipoEmpresa.TIPOEMPRCODI;
            $scope.idEmpresa = $scope.selectedEmpresa == undefined ? 0 : $scope.selectedEmpresa.EMPRCODI;
            $scope.idArea = $scope.selectedArea == undefined ? 0 : $scope.selectedArea.AREACODI;
            $scope.idTipoEquipo = $scope.selectedTipoEquipo == undefined ? 0 : $scope.selectedTipoEquipo.FAMCODI;
            $scope.tension = $scope.selectedTension == "(TODOS)" ? -1 : $scope.selectedTension;
            $scope.interrupcion = $scope.selectedInterrupcion == undefined ? "T" : $scope.selectedInterrupcion.value;


            srvCOES.getEventosPortal(
                    $scope.idCausaEvento,
                    $scope.idTipoEmpresa,
                    $scope.idEmpresa,
                    $scope.idArea,
                    $scope.idTipoEquipo,
                    $scope.tension,
                    $scope.interrupcion,
                    $scope.fechaInicio,
                    $scope.fechaFin,
                    $scope.nroPage,
                    $scope.nroItems).then(function (data) {
                        $scope.EventosPortal = data;
                    });
        };

        $scope.getTipoCausa = function () {
            srvCOES.getTipoCausa().then(function (data) {
                $scope.Causas = data;
                $scope.selectedCausaEvento = $scope.Causas[1];
            });
        };

        $scope.getTipoEmpresa = function () {
            srvCOES.getTipoEmpresa().then(function (data) {
                $scope.TipoEmpresas = data;
                $scope.selectedTipoEmpresa = $scope.TipoEmpresas[2];
            });
        };

        $scope.$watch("selectedTipoEmpresa", function (newValue, oldValue) {
            if ($scope.selectedTipoEmpresa != undefined) {
                $scope.getEmpresasSein($scope.selectedTipoEmpresa.TIPOEMPRCODI);
            }
        });

        $scope.getEmpresasSein = function () {
            srvCOES.getEmpresasSein().then(function (data) {
                $scope.Empresas = data;
                $scope.selectedEmpresa = $scope.Empresas[0];
            });
        };

        //$scope.$watch("selectedEmpresa", function (newValue, oldValue) {
        //    if ($scope.selectedEmpresa != undefined) {
        //        $scope.getAreas($scope.selectedEmpresa.EMPRCODI);
        //    }           
        //});

        //$scope.getAreas = function (idEmpresa) {
        //    srvCOES.getAreas(idEmpresa).then(function (data) {
        //        $scope.Areas = data;
        //        $scope.selectedArea = $scope.Areas[0];
        //    });
        //};

        $scope.getTipoEquipo = function () {
            srvCOES.getTipoEquipo().then(function (data) {
                $scope.TipoEquipos = data;
                $scope.selectedTipoEquipo = $scope.TipoEquipos[1];
            });
        };

        $scope.setChart = function () {

            $scope.idCausaEvento = $scope.selectedCausaEvento == undefined ? 0 : $scope.selectedCausaEvento.CAUSAEVENCODI;
            $scope.idTipoEmpresa = $scope.selectedTipoEmpresa == undefined ? 0 : $scope.selectedTipoEmpresa.TIPOEMPRCODI;
            $scope.idEmpresa = $scope.selectedEmpresa == undefined ? 0 : $scope.selectedEmpresa.EMPRCODI;
            $scope.idArea = $scope.selectedArea == undefined ? 0 : $scope.selectedArea.AREACODI;
            $scope.idTipoEquipo = $scope.selectedTipoEquipo == undefined ? 0 : $scope.selectedTipoEquipo.FAMCODI;
            $scope.tension = $scope.selectedTension == "(TODOS)" ? -1 : $scope.selectedTension;
            $scope.interrupcion = $scope.selectedInterrupcion == undefined ? "T" : $scope.selectedInterrupcion.value;

            srvCOES.getEventosPortalChart(
                    $scope.idCausaEvento,
                    $scope.idTipoEmpresa,
                    $scope.idEmpresa,
                    $scope.idArea,
                    $scope.idTipoEquipo,
                    $scope.tension,
                    $scope.interrupcion,
                    $scope.fechaInicio,
                    $scope.fechaFin,
                    $scope.nroPage,
                    $scope.nroItems).then(function (data) {

                        $(".data").hide();
                        $(".chart").show();

                        var dataPie = [];
                        for (var i = 0; i < data.Chart1.length; i++) {
                            dataPie.push([data.Chart1[i].Name, parseFloat(data.Chart1[i].Value)]);
                        }

                        //////////////////////////////////////CHART1//////////////////////////////////////////
                        $('#chart1').highcharts({
                            chart: {
                                plotBackgroundColor: null,
                                plotBorderWidth: null,
                                plotShadow: false
                            },
                            title: {
                                text: 'title',
                                style: {
                                    color: '#fff'
                                }
                            },
                            tooltip: {
                                pointFormat: '{series.name}: <b>{point.y:.0f}</b>'
                            },
                            plotOptions: {
                                pie: {
                                    allowPointSelect: true,
                                    cursor: 'pointer',
                                    dataLabels: {
                                        enabled: true,
                                        color: '#000000',
                                        connectorColor: '#000000',
                                        format: '{point.percentage:.2f} %'
                                    },
                                    showInLegend: true
                                }
                            },
                            series: [{
                                type: 'pie',
                                name: 'Número de fallas',
                                data: dataPie
                            }]
                        });


                        //////////////////////////////////////CHART2//////////////////////////////////////////

                        $('#chart2').highcharts({
                            chart: {
                                type: 'column'
                            },
                            title: {
                                text: 'title',
                                style: {
                                    color: '#fff'
                                }
                            },
                            xAxis: {
                                categories: data.Chart2.Categorias,
                                title: {
                                    text: 'TIPO EQUIPO'
                                },
                            },
                            yAxis: {
                                min: 0,
                                title: {
                                    align: 'high',
                                    offset: 10,
                                    text: 'Duracion Minutos',
                                    rotation: 0,
                                    y: -15
                                },
                                stackLabels: {
                                    enabled: true,
                                    style: {
                                        fontWeight: 'bold',
                                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                    }
                                }
                            },
                            legend: {
                                align: 'right',
                                x: 0,
                                verticalAlign: 'top',
                                y: 20,
                                floating: true,
                                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                                borderColor: '#CCC',
                                borderWidth: 1,
                                shadow: false
                            },
                            tooltip: {
                                formatter: function () {
                                    return '<b>' + this.x + '</b><br/>' +
                                        this.series.name + ': ' + this.y + '<br/>' +
                                        'Total: ' + this.point.stackTotal;
                                }
                            },
                            plotOptions: {
                                column: {
                                    stacking: 'normal',
                                    dataLabels: {
                                        enabled: true,
                                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                        style: {
                                            textShadow: '0 0 3px black, 0 0 3px black'
                                        }
                                    }
                                }
                            },
                            series: data.Chart2.Series
                        });


                        //////////////////////////////////////CHART3/////////////////////////////////////////


                        $('#chart3').highcharts({
                            chart: {
                                type: 'column'
                            },
                            title: {
                                text: 'title',
                                style: {
                                    color: '#fff'
                                }
                            },
                            xAxis: {
                                categories: data.Chart3.Categorias,
                                title: {
                                    text: 'TENSIÓN'
                                },
                            },
                            yAxis: {
                                min: 0,
                                title: {
                                    align: 'high',
                                    offset: 10,
                                    text: 'Duracion Minutos',
                                    rotation: 0,
                                    y: -15
                                },
                                stackLabels: {
                                    enabled: true,
                                    style: {
                                        fontWeight: 'bold',
                                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                    }
                                }
                            },
                            legend: {
                                align: 'right',
                                x: 0,
                                verticalAlign: 'top',
                                y: 20,
                                floating: true,
                                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                                borderColor: '#CCC',
                                borderWidth: 1,
                                shadow: false
                            },
                            tooltip: {
                                formatter: function () {
                                    return '<b>' + this.x + '</b><br/>' +
                                        this.series.name + ': ' + this.y + '<br/>' +
                                        'Total: ' + this.point.stackTotal;
                                }
                            },
                            plotOptions: {
                                column: {
                                    stacking: 'normal',
                                    dataLabels: {
                                        enabled: true,
                                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                        style: {
                                            textShadow: '0 0 3px black, 0 0 3px black'
                                        }
                                    }
                                }
                            },
                            series: data.Chart3.Series
                        });


                        //////////////////////////////////////CHART4//////////////////////////////////////////
                        var dataColumn = [];
                        for (var i = 0; i < data.Chart4.length; i++) {
                            dataColumn.push([data.Chart4[i].Name, parseFloat(data.Chart4[i].Value)]);
                        }
                        $('#chart4').highcharts({
                            chart: {
                                type: 'column'
                            },
                            title: {
                                text: 'title',
                                style: {
                                    color: '#fff'
                                }
                            },
                            xAxis: {
                                type: 'category',
                                title: {
                                    text: 'TIPO EQUIPO'
                                }
                            },
                            yAxis: {
                                min: 0,
                                title: {
                                    align: 'high',
                                    offset: 10,
                                    text: 'MWh',
                                    rotation: 0,
                                    y: -15
                                }
                            },
                            legend: {
                                enabled: false
                            },
                            tooltip: {
                                pointFormat: 'Energia Interrumpida: <b>{point.y:.0f} MWh</b>'
                            },
                            series: [{
                                name: 'Tipo Equipo',
                                data: dataColumn,
                                dataLabels: {
                                    enabled: true,
                                    color: '#FFFFFF',
                                }
                            }]
                        });

                    });
        };


        $scope.nextPage = function () {
            if ($scope.EventosPortal.length == $scope.nroItems) {
                $scope.nroPage = parseInt($scope.nroPage) + 1;
                $scope.getEventosPortal();
            }
        };

        $scope.prevPage = function () {
            if ($scope.nroPage > 1) {
                $scope.nroPage = parseInt($scope.nroPage) - 1;
                $scope.getEventosPortal();
            }
        };

        $scope.gridOptions = {
            data: 'EventosPortal',
            columnDefs: [
                { field: 'CAUSAEVENABREV', displayName: 'Tipo de causa de falla CIER', width: '200px' },
                { field: 'EQUITENSION', displayName: 'Tensión (KV)', width: '100px' },
                { field: 'TIPOEMPRDESC', displayName: 'Tipo de Empresa', width: '125px' },
                { field: 'EMPRNOMB', displayName: 'Empresa', width: '125px' },
                { field: 'AREANOMB', displayName: 'Ubicación', width: '130px' },
                { field: 'FAMNOMB', displayName: 'Tipo de Equipo', width: '140px' },
                { field: 'EQUINOMB', displayName: 'Equipo', width: '125px' },
                { field: 'EVENINI', displayName: 'Inicio', width: '120px' },
                { field: 'EVENFIN', displayName: 'Final', width: '120px' },
                { field: 'INTERRUPCIONMW', displayName: 'Interrupción (MW)', width: '130px' },
                { field: 'DISMINUCIONMW', displayName: 'Disminución (MW)', width: '130px' },
                { field: 'DURACIONEVENTO', displayName: 'Duración (minutos)', width: '135px' },
                { field: 'ENERGIAINTERRUMPIDA', displayName: 'Energía No Suministrada (MWh)', width: '240px' },
                { field: 'EVENDESC', displayName: 'Descripción', width: '450px' },

            ],
            enableRowSelection: false,
            enableColumnResize: true,
            rowHeight: 80,
        };


        $scope.init = function () {

            $(".chart").hide();

            $scope.getTipoCausa();
            $scope.getTipoEmpresa();
            $scope.getEmpresasSein(0);
            //$scope.getAreas(0);
            $scope.getTipoEquipo();
            $scope.getEventosPortal();

            $('#fecha').daterangepicker({ format: 'DD/MM/YYYY' }, function (start, end, label) {
                $scope.fechaInicio = start.toISOString2();
                $scope.fechaFin = end.toISOString2();
            });

            $scope.nroItems = 25;
        };


        $scope.init();


    }])