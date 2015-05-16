/// <reference path="../coes/utils.js" />

angular.module('COES.EventosSEIN.Service', []).factory("COESEventosSEINService", function ($http, $q) {

    var srvCOES = {

        
        getEventosPortal: function (_idCausaEvento, _tipoEmpresa, _idEmpresa, _idArea, _idTipoEquipo, _tension, _interrupcion, _fechaInicio, _fechaFin, _nroPage, _nroItems, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getEventosPortal',
                type: 'GET',
                async: false,
                params: { idCausaEvento: _idCausaEvento, tipoEmpresa: _tipoEmpresa, idEmpresa: _idEmpresa, idArea: _idArea, idTipoEquipo: _idTipoEquipo, tension: _tension, interrupcion: _interrupcion, fechaInicio: _fechaInicio, fechaFin: _fechaFin, nroPage: _nroPage, nroItems: _nroItems }
            }).success(function (data) {

                for (var i = 0; i < data.length; i++) {
                    COES.utils.fixIsoDateTimeDates(data[i]);
                }

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        getTipoCausa: function () {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getTipoCausa',
                method: "GET",
                async: false
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getTipoEmpresa: function () {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getTipoEmpresa',
                method: "GET",
                async: false
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },
        
        getEmpresasSein: function (_idTipoEmpresa) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getEmpresasSein',
                method: "GET",
                async: false,
                params: { idTipoEmpresa: _idTipoEmpresa }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getAreas: function (_idEmpresa) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getAreas',
                method: "GET",
                async: false,
                params: { idEmpresa: _idEmpresa }
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getTipoEquipo: function () {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getTipoEquipo',
                method: "GET",
                async: false
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (data) {

            });

            return deferred.promise;
        },

        getEventosPortalChart: function (_idCausaEvento, _tipoEmpresa, _idEmpresa, _idArea, _idTipoEquipo, _tension, _interrupcion, _fechaInicio, _fechaFin, _nroPage, _nroItems, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/getEventosPortalChart',
                type: 'GET',
                async: false,
                params: { idCausaEvento: _idCausaEvento, tipoEmpresa: _tipoEmpresa, idEmpresa: _idEmpresa, idArea: _idArea, idTipoEquipo: _idTipoEquipo, tension: _tension, interrupcion: _interrupcion, fechaInicio: _fechaInicio, fechaFin: _fechaFin, nroPage: _nroPage, nroItems: _nroItems }
            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },

        exportEventosPortal: function (_idCausaEvento, _tipoEmpresa, _idEmpresa, _idArea, _idTipoEquipo, _tension, _interrupcion, _fechaInicio, _fechaFin, _nroPage, _nroItems, data) {

            var deferred = $q.defer();

            $http({
                url: '/_layouts/15/COES.Portal/COESService.svc/exportEventosPortal',
                type: 'GET',
                async: false,
                params: { idCausaEvento: _idCausaEvento, tipoEmpresa: _tipoEmpresa, idEmpresa: _idEmpresa, idArea: _idArea, idTipoEquipo: _idTipoEquipo, tension: _tension, interrupcion: _interrupcion, fechaInicio: _fechaInicio, fechaFin: _fechaFin, nroPage: _nroPage, nroItems: _nroItems }
            }).success(function (data) {

                deferred.resolve(data);

            }).error(function (data) {

            });

            return deferred.promise;
        },
             

    }

    return srvCOES;
});



