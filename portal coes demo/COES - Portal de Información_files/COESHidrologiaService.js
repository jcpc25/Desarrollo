
angular.module('COES.Hidrologia.Service', []).factory("COESHidrologiaService", function ($http, $q) {

    var srvCOES = {
               
        
        exportHidrologia: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/exportHidrologia',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        getHidrologia: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getHidrologia',
                type: 'GET',
                async: false,
                headers: {
                    'Content-type': 'application/json'
                },
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }

            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        getChartHidrologia: function (_tipoGrafica, _fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getChartHidrologia',
                type: 'GET',
                async: false,
                headers: {
                    'Content-type': 'application/json'
                },
                params: { tipoGrafica: _tipoGrafica, fechaInicio: _fechaInicio, fechaFin: _fechaFin }

            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },                 

    }

    return srvCOES;
});



