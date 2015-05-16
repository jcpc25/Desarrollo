angular.module("COES", ['Loading','ngGrid', 'ngRoute', 'ngResource', 'COES.Generacion.Controller', 'COES.Generacion.Service', 'COES.Demanda.Controller', 'COES.Demanda.Service', 'COES.EventosSEIN.Controller', 'COES.EventosSEIN.Service', 'COES.Hidrologia.Controller', 'COES.Hidrologia.Service'
]).config(['$routeProvider', function ($routeProvider) {
  
    $routeProvider
		.when("/Generacion", {
		    templateUrl: "/style library/dashboard/templates/Generacion.html",
		    controller: "COESGeneracionController"
		})
        .when("/Demanda", {
            templateUrl: "/style library/dashboard/templates/Demanda.html",
            controller: "COESDemandaController"
        })
        .when("/EventosSEIN", {
            templateUrl: "/style library/dashboard/templates/EventosSEIN.html",
            controller: "COESEventosSEINController"
        })
        .when("/Hidrologia", {
            templateUrl: "/style library/dashboard/templates/Hidrologia.html",
            controller: "COESHidrologiaController"
        })   

}])



