
angular.module('COES.Demanda.Service', []).factory("COESDemandaService", function ($http, $q) {

    var srvCOES = {
       
        ObtenerDemandaDespachoxFechaxPrograma: function (_fechaInicio, _fechaFin, data) {
            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/ObtenerDemandaDespachoxFechaxPrograma',
                type: 'GET',
                async: false,
                headers: {
                    'Content-type': 'application/json'
                },
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }

            }).success(function (data) {

                for (var i = 0; i < data.Data.length; i++) {
                    COES.utils.formatCurrencyCOES(data.Data[i]);
                }
                deferred.resolve(data);

            }).error(function (data) {

            });
            return deferred.promise;
        },
        exportDemanda: function (_fechaInicio, _fechaFin, result) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/exportDemanda',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },

    }

    return srvCOES;
});



