var controller = "Alumnos", Nombre_Archivo = "Alunnos",directori = "http://localhost:49879/";
asignareventos = function () {
    $("thead > tr").addClass("cabeceraTitulos");


    var table = $('#lista').DataTable();

    $('tr').off('click', '.eliminar');

    $('tr').on('click', '.eliminar', function () {
        singletonInstanceInformacion.setDATA(table.row($(this).parent()).data());

    });
}
ObtenerResultados = function (response) {

    $("#ObtenerResultados").html("");
    $("#ObtenerResultados").show();

    response = json_result(response);

    var mostrarPaginado = false;
 
    if (Object.keys(response).length > 10) {
        mostrarPaginado = true
    }

    for (var k in response) {
        
        response[k].FECHA_ALTA = (response[k].FECHA_ALTA == null) ? '-' : formatear_fecha(response[k].FECHA_ALTA);

    }


    //console.log(Object.keys(response).length);
    var tamanio = 4;
    var mostrar_convenio = false;
    //console.log(tamanio);
    var content = (mostrarPaginado == true) ? '<p title="Resultado Pagina Actual" alt="Resultado Pagina Actual">Resultado Pagina Actual:</p><p alt="Resultado Total" title="Resultado Total">Resultado Total:</p>' : '<p alt="Resultado Total" title="Resultado Total">Resultado Total:</p>';
  
    $("#ObtenerResultados").html($('<div>').addClass("table-responsive").append($('<table>').attr('id', 'lista').append($('<tbody>')).addClass("table")), $('<div>').addClass("Folio_Marcados").attr("id", "Folio_Marcados"));

    
    //console.log('1');
    var dataSet = [];
    $('#lista').DataTable({
        dom: 'lBfrtip',
        //responsive: true,
        paging: mostrarPaginado,
        pagingType: "numbers",
        searching: true,
        bLengthChange: true,
        bDestroy: true,
        bFilter: true,
        bInfo: false,
        ordering: true,
        data: response,
        defaultContent: "-",
        columns: [
             { "title": "Nombre", "data": "nombre" },
             { "title": "Apellido Paterno", "data": "apellidoPaterno" },
             { "title": "Apellido Materno", "data": "apellidoMaterno" },
             { "title": "Editar", "data": "idAlumno" },

        ],
        createdRow: function (row, data, dataIndex) {
            $(row).data('contenido', data);
            $(row).attr({
                'data-idAlumno': data.idAlumno,
            });
        },
        footerCallback: function (row, data, start, end, display) {
            
        },
        rowCallback: function (row, data, index, iDisplayIndexFull) {
        },
        initComplete: function (settings, json) {

            $("thead > tr").addClass("cabeceraTitulos");

        },
        buttons: [
                      { extend: 'copyHtml5', className: 'btn btn-md btn-primary', charset: 'utf-8', text: 'Copiar', title: Nombre_Archivo },
                      { extend: 'csvHtml5', className: 'btn btn-md btn-primary', charset: 'utf-8', text: 'CSV', title: Nombre_Archivo },
                      {
                          extend: 'excelHtml5',
                          customize: function (xlsx) {
                              var sheet = xlsx.xl.worksheets['sheet1.xml'];
                              var numrows = 2;
                              var clR = $('row', sheet);

                              //update Row
                              clR.each(function () {
                                  var attr = $(this).attr('r');
                                  var ind = parseInt(attr);
                                  ind = ind + numrows;
                                  $(this).attr("r", ind);
                              });

                              // Create row before data
                              $('row c ', sheet).each(function () {
                                  var attr = $(this).attr('r');
                                  var pre = attr.substring(0, 1);
                                  var ind = parseInt(attr.substring(1, attr.length));
                                  ind = ind + numrows;
                                  $(this).attr("r", pre + ind);
                              });

                              function Addrow(index, data) {
                                  var msg = '<row r="' + index + '">'
                                  for (var i = 0; i < data.length; i++) {
                                      var key = data[i].key;
                                      var value = data[i].value;
                                      msg += '<c t="inlineStr" r="' + key + index + '">';
                                      msg += '<is>';
                                      msg += '<t>' + value + '</t>';
                                      msg += '</is>';
                                      msg += '</c>';
                                  }
                                  msg += '</row>';
                                  return msg;
                              }


                              //insert
                              var r1 = Addrow(1, [{ key: 'E', value: Titulo }]);
                              sheet.childNodes[0].childNodes[1].innerHTML = r1 + sheet.childNodes[0].childNodes[1].innerHTML;



                          },
                          title: Nombre_Archivo, className: 'btn btn-md btn-primary', charset: 'utf-8'
                      },
                      {
                          extend: 'print',
                          customize: function (win) {

                              var last = null;
                              var current = null;
                              var bod = [];

                              var css = '@page { size: landscape; }',
                                  head = win.document.head || win.document.getElementsByTagName('head')[0],
                                  style = win.document.createElement('style');

                              style.type = 'text/css';
                              style.media = 'print';

                              if (style.styleSheet) {
                                  style.styleSheet.cssText = css;
                              }
                              else {
                                  style.appendChild(win.document.createTextNode(css));
                              }

                              head.appendChild(style);

                              $(win.document.body).find('h1').css('font-size', '15pt');
                              $(win.document.body).find('h1').css('text-align', 'center');
                              $(win.document.body).find('h1').html(Titulo);

                          },
                          title: Nombre_Archivo, className: 'btn btn-md btn-primary', charset: 'utf-8', text: 'Imprimir'
                      },
        ],
        language: { "sProcessing": "Procesando...", "sLengthMenu": "Mostrar _MENU_ registros", "sZeroRecords": "No se Encontraron Resultados", "sEmptyTable": "Ningún Dato Disponible en esta Tabla", "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros", "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros", "sInfoFiltered": "(filtrado de un total de _MAX_ registros)", "sInfoPostFix": "", "sSearch": "Buscar:", "sUrl": "", "sInfoThousands": ",", "sLoadingRecords": "Cargando...", "oPaginate": { "sFirst": "Primero", "sLast": "Último", "sNext": "Siguiente", "sPrevious": "Anterior" }, "oAria": { "sSortAscending": ": Activar para ordenar la columna de manera ascendente", "sSortDescending": ": Activar para ordenar la columna de manera descendente" } },
    });
    $("#CargandoInfo").hide();
    $("#ObtenerResultados").show();



    $('#lista > tbody  > tr >td').each(function () { if (Math.sign($(this).text()) == -1) { $(this).addClass('text-danger') } });


    // Hide a column
    var table = $('#lista').DataTable();

    table.on('length.dt', function (e, settings, len) {

    })
          .on('page.dt', function () {

          })
          .on('order.dt', function () {
          })
          .on('draw.dt', function () {
          });

    //  table.column(1).visible(false);


    $("#CambiarEstatus").hide();
    if (Object.keys(response).length > 0) {
        console.log(Object.keys(response).length);
        $("#CambiarEstatus").show();
    }
}
$(document).ready(function () {
    var Alumno = {
        idAlumno: 0,

    };
    getInfoAjaxComplete('/Consultar_Alumnos', JSON.stringify({ entidad: Alumno }), "ObtenerResultados", '¡No se pudo mostrar la información!');

});