var COES = {
    utils: {
        dateStringToDate: function (value) {
            var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;

            if (typeof value === 'string') {
                a = reMsAjax.exec(value);
                if (a) {
                    var b = a[1].split(/[-+,.]/);
                    return new Date(b[0] ? +b[0] : 0 - +b[1]);
                }
            }
            return value;
        },
        dateToday: function () {

            var value = new Date();
            var dd = value.getDate();
            var mm = value.getMonth() + 1;

            var yyyy = value.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }

            var res = dd + '/' + mm + '/' + yyyy;           
            return res;

        },
        dateYesterday: function () {

            var today = new Date();
            var value = new Date();
            value.setDate(today.getDate() - 1);


            var dd = value.getDate();
            var mm = value.getMonth() + 1;

            var yyyy = value.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }

            var res = dd + '/' + mm + '/' + yyyy;
            return res;

        },

        fixIsoDateTimeDates: function (object) {
            for (var prop in object) {
                object[prop] = COES.utils.dateStringToDate(object[prop]);

                if (object[prop] instanceof Date) {
                    object[prop] = object[prop].format("isoDateTime");
                }
            }
        },
        fixLongDates: function (object) {
            for (var prop in object) {
                object[prop] = COES.utils.dateStringToDate(object[prop]);

                if (object[prop] instanceof Date) {
                    object[prop] = object[prop].format("default");
                }
            }
        },
        fixDates: function (object) {
            for (var prop in object) {
                object[prop] = COES.utils.dateStringToDate(object[prop]);

                if (object[prop] instanceof Date) {
                    object[prop] = object[prop].format("isoDate");
                }
            }
        },
        fixshortDates: function (object) {
            for (var prop in object) {
                object[prop] = COES.utils.dateStringToDate(object[prop]);

                if (object[prop] instanceof Date) {
                    object[prop] = object[prop].format("ceDate");
                }
            }
        },

        fixNulls: function (object) {
            for (var prop in object) {
                if (object[prop] == "null") {
                    object[prop] = "";
                }
            }
        },

        fixDatesHour: function (object) {
            for (var prop in object) {
                object[prop] = COES.utils.dateStringToDate(object[prop]);

                if (object[prop] instanceof Date) {
                    object[prop] = object[prop].format("yyyy-mm-dd HH:MM:ss");
                }
            }
        },

        formatCurrency: function (object, format) {

            for (var propiedad in object) {

                if (typeof object[propiedad] === "number") {
                    var valor = object[propiedad].toString().replace(/,/g, "");
                    valor = parseFloat(valor);
                    valor = isNaN(valor) ? 0 : parseFloat(valor);
                    valor = $.formatCurrency(valor, format);
                    object[propiedad] = valor;
                }
            }
        },

        formatCurrencyCOES: function (object, format) {

            for (var propiedad in object) {

                if (typeof object[propiedad] === "number") {
                    var valor = object[propiedad].toString().replace(/,/g, "");
                    valor = parseFloat(valor);
                    valor = isNaN(valor) ? 0 : parseFloat(valor);
                    valor = $.formatCurrency(valor, format);


                    valor = valor.replaceAll('.', ' ');
                    object[propiedad] = valor;
                }
            }
        },
        formatCurrencyCOESSingle: function (object, format) {


            if (typeof object === "number") {
                //var valor = object.toString().replace(/,/g, "");
                var valor = object.toString();
                valor = parseFloat(valor);
                valor = isNaN(valor) ? 0 : parseFloat(valor);
                valor = $.formatCurrency(valor, format);
                
                return valor;
            }

        },

        daysInMonth: function (year, month) {
            return 32 - new Date(year, month, 32).getDate();
        },

        isNullOrUndefined: function (value) {
            return (value == null || value == undefined)
        },

        getParameterByName: function (name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.search);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        },
        getTipoGeneracion: function (tipo) {

            var tipoGeneracion = "";
            switch (tipo) {
                case "H":
                    tipoGeneracion = "Hidroeléctrica";
                    break;
                case "S":
                    tipoGeneracion = "Solar";
                    break;
                case "T":
                    tipoGeneracion = "Termoeléctrica";
                    break;
                case "E":
                    tipoGeneracion = "Eólica";
                    break;
                default:
                    tipoGeneracion = tipo;
                    break;
            }

            return tipoGeneracion;

        },
        getColorCombustible: function (name) {

            var color = "#fff";
            switch (name) {
                case 'AGUA':
                    color = '#6699FF';//(AZUL)
                    break;
                case 'GAS':
                    color = '#FF3300';//(ROJO)
                    break;
                case 'DIESEL':
                    color = '#477519'; //(VERDE OSCURO)
                    break;
                case 'RESIDUAL':
                    color = '#AC5930'; //(MARRON)
                    break;
                case 'BAGAZO':
                    color = '#FF9900'; //(NARANJA)
                    break;
                case 'EOLICA':
                    color = '#99CCFF'; //(CELESTE)
                    break;
                case 'BIOGAS':
                    color = '#70B870'; //(VERDE CLARO)
                    break;
                case 'CARBON':
                    color = '#515151'; //(GRIS OSCURO)
                    break;
                case 'SOLAR':
                    color = '#FFFF70'; //(AMARILLO)
                    break;
                case 'Hídrico':
                    color = '#6699FF';//(AZUL)
                    break;
                case 'Gas':
                    color = '#FF3300';//(ROJO)
                    break;
                case 'Diesel':
                    color = '#477519'; //(VERDE OSCURO)
                    break;
                case 'Residual':
                    color = '#AC5930'; //(MARRON)
                    break;                
                case 'Carbón':
                    color = '#515151'; //(GRIS OSCURO)
                    break;
                case 'Solar':
                    color = '#FFFF70'; //(AMARILLO)
                    break;
                case 'Otros':
                    color = '#F5B67F'; 
                    break;
            }

            return color;


        }



    }
}




if (!Date.prototype.toISOString) {
    (function () {

        function pad(number) {
            var r = String(number);
            if (r.length === 1) {
                r = '0' + r;
            }
            return r;
        }

        Date.prototype.toISOString = function () {
            return this.getUTCFullYear()
              + '-' + pad(this.getUTCMonth() + 1)
              + '-' + pad(this.getUTCDate())
              + 'T' + pad(this.getUTCHours())
              + ':' + pad(this.getUTCMinutes())
              + ':' + pad(this.getUTCSeconds())
              + '.' + String((this.getUTCMilliseconds() / 1000).toFixed(3)).slice(2, 5)
              + 'Z';
        };

    }());
}

String.prototype.replaceAll = function (str1, str2, ignore) {
    return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g, "\\$&"), (ignore ? "gi" : "g")), (typeof (str2) == "string") ? str2.replace(/\$/g, "$$$$") : str2);
}