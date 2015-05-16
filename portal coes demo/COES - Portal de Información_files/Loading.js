/// <reference path="../coes/utils.js" />
angular.module('Loading', [])
    .config(function ($httpProvider) {
        $httpProvider.responseInterceptors.push('LoadingHttpInterceptor');
        var spinnerFunction = function (data, headersGetter) {            
            //alert('start spinner');
            $('#loading').show();
            return data;
        };
        $httpProvider.defaults.transformRequest.push(spinnerFunction);
    })
    .factory('LoadingHttpInterceptor', function ($q, $window) {
        return function (promise) {
            return promise.then(function (response) {               
                //alert('stop spinner');
                $('#loading').hide();
                return response;

            }, function (response) {                
                //alert('stop spinner');
                $('#loading').hide();
                return $q.reject(response);
            });
        };
    });