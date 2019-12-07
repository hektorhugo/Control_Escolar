var informacion_navegacion = function () {
    function PrivateConstructor() {
        var titulo = null;
        var data = null;
        var tipo = null;
        this.setTitulo = function (valor) {
            titulo = valor
        }, this.getTitulo = function () {
            return titulo
        }
        this.setTipo = function (valor) {
            tipo = valor
        }, this.getTipo = function () {
            return tipo
        }
        this.setData = function (valor) {
            data = valor
        }, this.getData = function () {
            return data
        }
    }
    var instance = null;
    return new function () {
        this.getInstance = function () {
            return null == instance && (instance = new PrivateConstructor, instance.constructor = null), instance
        }
    }
}(),
singletonInstanceInformacion = informacion_navegacion.getInstance(),
goToByScroll = function (id) {
    id = id.replace("link", "");
    $('html,body').animate({
        scrollTop: $("#" + id).offset().top
    },
        'slow');
},
getInfoAjaxComplete = function (path, parameters, method, error, type) {
    $.ajaxSetup({
        async: !0
    }),

    $.ajax({
        type: "POST",
        url: directori + controller + path,
        processData: false,
        data: parameters,
        dataType: type,
        contentType: "application/json;multipart/form-data; charset=utf-8;text/csv;",
        beforeSend: function () {
            $("#BtnBuscar").prop("disabled", true);
            showProgress(true);
        },
        success: function (data) {
            data && eval(method + "(data)")
        },
        error: function (response) {

            swal("Ocurrio un error!", (error.trim().length > 0) ? error : response.responseJSON.message, "warning")

        },
        complete: function (response) {
            $("#BtnBuscar").prop("disabled", false);
            showProgress(false);
        }
    });
},
showProgress = function (show) {

    $("#divGris").attr("style", (show == true) ? "display:block" : "display:none");
},
Limpiar = function () {
    $('input').val('');
},
formatear_fecha = function (data) {
    var cSharpDate = (data != null) ? data : "";
    var stripedCsharpDate = cSharpDate.replace(/[^0-9 +]/g, '');
    var jsDate = new Date(parseInt(stripedCsharpDate));
    var mes = (jsDate.getMonth() + 1);
    mes = (mes < 10) ? '0' + mes : mes;
    var dia = jsDate.getDate();
    dia = (dia < 10) ? '0' + dia : dia;
    return dia + "/" + mes + "/" + jsDate.getFullYear();
},
showPanel = function (show) {
    $("#PanelRespuesta").attr("style", (show == true) ? "display:block" : "display:none");
},
conver_json = function (response) {
    try {
        response = JSON.parse(response)
        return response;
    }
    catch (err) {
        return response;
    }
},
roundToTwo = function (num) {
    return +(Math.round(num + "e+2") + "e-2");
},
hasExtension = function (element, exts) {
    return (new RegExp('(' + exts.join('|').replace(/\./g, '\\.') + ')$')).test(element);
},
validaCampos = function (form) {

    var count = 0;
    var nombreCampo = "";

    $("#" + form + " .requerido").each(function () {

        if (!$(this).val()) { count += 1; nombreCampo += $(this).attr('placeholder') + "\n "; }
    });

    if (count == 0) {
        return true;
    } else {
        var msg = "Es necesario llenar los siguientes campos: \n" + nombreCampo;

        swal({
            title: "Atención",
            text: msg,
            content: true,
            className: 'swal-wide',
            icon: "warning"
        });


        return false;
    }
},
JSONToCSVConvertor = function (JSONData, ReportTitle, ShowLabel) {
    //If JSONData is not an object then JSON.parse will parse the JSON string in an Object
    var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

    var CSV = 'sep=,' + '\r\n\n';

    //This condition will generate the Label/Header
    if (ShowLabel) {
        var row = "";

        //This loop will extract the label from 1st index of on array
        for (var index in arrData[0]) {

            //Now convert each value to string and comma-seprated
            row += index + ',';
        }

        row = row.slice(0, -1);

        //append Label row with line break
        CSV += row + '\r\n';
    }

    //1st loop is to extract each row
    for (var i = 0; i < arrData.length; i++) {
        var row = "";

        //2nd loop will extract each column and convert it in string comma-seprated
        for (var index in arrData[i]) {
            row += '"' + arrData[i][index] + '",';
        }

        row.slice(0, row.length - 1);

        //add a line break after each row
        CSV += row + '\r\n';
    }

    if (CSV == '') {
        alert("Invalid data");
        return;
    }

    //Generate a file name
    var fileName = "Control_Escolar";
    //this will remove the blank-spaces from the title and replace it with an underscore
    fileName += ReportTitle.replace(/ /g, "_");

    //Initialize file format you want csv or xls
    var uri = 'data:text/csv;charset=utf-8,' + escape(CSV);

    // Now the little tricky part.
    // you can use either>> window.open(uri);
    // but this will not work in some browsers
    // or you will not get the correct file extension    

    //this trick will generate a temp <a /> tag
    var link = document.createElement("a");
    link.href = uri;

    //set the visibility hidden so it will not effect on your web-layout
    link.style = "visibility:hidden";
    link.download = fileName + ".csv";

    //this part will append the anchor tag and remove it after automatic click
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
json_result = function (response) {
    try {
        return JSON.parse(response);
    }
    catch (err) {
        return response;
    }
};
$(document).ready(function () {
    // Jquery draggable
    /*$('.modal-dialog').draggable({
        handle: ".modal-header",
        start: function (e, ui) {
            $('.modal-backdrop').hide();
        },
        stop: function (e, ui) {
            $('.modal-backdrop').show();
        }
    });*/
    $('.modal-backdrop').hide();
    $(".modal-header").attr("style", "cursor: move;");

    $('input[type="text"]').each(function () {
        $(this).attr('type', 'search');
    });

    //Evita que los inputs de tipo numero convertidos a search permitan letras
    $('input[type="number"]').each(function () {
        $(this).attr('type', 'search');
        $(this).addClass('solonumeros');
    });

    $('input[type="search"]').on('input', function (evt) {
        $(this).val(function (_, val) {
            return val.toUpperCase();
        });
    });
    $('textarea').on('input', function (evt) {
        $(this).val(function (_, val) {
            return val.toUpperCase();
        });
    });
    setTimeout(function () {
        $('[data-toggle="tooltip"]').tooltip();
    }, 3000);

    $('.solonumeros').keyup(function (e) {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
});
