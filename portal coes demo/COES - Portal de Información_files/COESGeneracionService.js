
angular.module('COES.Generacion.Service', []).factory("COESGeneracionService", function ($http, $q) {

    var srvCOES = {

        ///////////////// SCADA //////////////////////

        getGeneracion: function (_fechaInicio, _fechaFin, result) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracion',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {

                result = [];

                total = 0;
                for (var i = 0; i < data.length; i++) {
                    total += parseFloat(data[i].TOTALGEN);
                    COES.utils.formatCurrencyCOES(data[i]);
                }
                result.push(data);
                result.push(total);

                deferred.resolve(result, total);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        getGeneracionTipoGen: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoGen',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getGeneracionTipoGenCOES: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoGenCOES',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });


            return deferred.promise;
        },

        getGeneracionTipoCombustibleStock: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoCombustibleStock',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        exportGeneracionSCADA: function (_fechaInicio, _fechaFin, result) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/exportGeneracionSCADA',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },


        ///////////////// MEDIDORES //////////////////////

        getGeneracionMD: function (_fechaInicio, _fechaFin, result) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionMD',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {

                result = [];

                total = 0;
                for (var i = 0; i < data.length; i++) {
                    total += parseFloat(data[i].ENERGIA);
                    COES.utils.formatCurrencyCOES(data[i]);
                }
                result.push(data);
                result.push(total);

                deferred.resolve(result, total);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        getGeneracionTipoGenMD: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoGenMD',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getGeneracionTipoGenCOESMD: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoGenCOESMD',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });
            return deferred.promise;
        },

        getGeneracionTipoCombustibleMDStock: function (_fechaInicio, _fechaFin, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getGeneracionTipoCombustibleMDStock',
                type: 'GET',
                async: false,
                params: { fechaInicio: _fechaInicio, fechaFin: _fechaFin }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },
        
        exportGeneracionMedidores: function (_fechaInicio, _fechaFin, result) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/exportGeneracionMedidores',
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



