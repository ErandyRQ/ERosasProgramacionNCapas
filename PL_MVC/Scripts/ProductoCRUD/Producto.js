$(document).ready(function () {
    GetAll();
});

function showForm() {

    $('#ModalUpdate').modal('show');

    $('#txtNombre').val("")
    $('#txtPrecioUnitario').val("")
    $('#txtStock').val("")
    $('#txtDescripcion').val("")
    $('#txtProveedor').val("")
    $('#txtDepartamento').val("")

    var buttonU = document.getElementById("btnUpdate");
    buttonU.style.display = "none";

    var buttonA = document.getElementById("btnAdd");
    buttonA.style.display = "block";
   
}


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:16436/api/producto',
        success: function (result) { //200 OK 
             $('#producto tbody').empty();
            $.each(result.Objects, function (i, producto) {
                   var filas =
                       '<tr class="text-center">'
                       + '<td class="text-center"> <button class="btn btn-primary" onclick="GetById(' + producto.IdProducto + ')"><span class="glyphicon glyphicon-refresh" style="color:#FFFFFF"></span></button></td>'
                      + "<td  id='id' class='text-center'>" + producto.IdProducto + "</td>"
                       + "<td class='text-center'>" + producto.Nombre + "</td>"
                       + "<td class='text-center'>" + producto.PrecioUnitario + "</ td>"
                       + "<td class='text-center'>" + producto.Stock + "</ td>"
                       + "<td class='text-center'>" + producto.Descripcion + "</ td>"
                       + "<td class='text-center'>" + producto.Proveedor.IdProveedor + "</td>"
                       + "<td class='text-center'>" + producto.Departamento.IdDepartamento + "</td>"
                       //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                       + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + producto.IdProducto + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                       + "</tr>";
                   $("#producto tbody").append(filas); 
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}
function Eliminar(IdProducto) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:16436/api/producto/' + IdProducto,
        success: function (result) {
            
            alert(result.correct + "Producto eliminado");
            GetAll();
        },
        error: function (result) {
            alert('Ocurrio un error.' + result.responseJSON.ErrorMessage);
        }
    });
}

function GetById(IdProducto) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:16436/api/producto/' + IdProducto,
        success: function (result) {
            $('#txtIdProducto').val(result.Object.IdProducto);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtPrecioUnitario').val(result.Object.PrecioUnitario);
            $('#txtStock').val(result.Object.Stock);
            $('#txtDescripcion').val(result.Object.Descripcion);
            $('#txtProveedor').val(result.Object.Proveedor.IdProveedor);
            $('#txtDepartamento').val(result.Object.Departamento.IdDepartamento);

           
            var buttonU = document.getElementById("btnUpdate");
            buttonU.style.display = "block";

            var buttonA = document.getElementById("btnAdd");
            buttonA.style.display = "none";

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.ErrorMessage);
        }


    });

}

function Update() {
    var idProducto = $('#txtIdProducto').val();
    var nombre = $('#txtNombre').val()
    var precioUnitario = $('#txtPrecioUnitario').val()
    var stock = $('#txtStock').val()
    var descripcion = $('#txtDescripcion').val()
    var idProveedor = $('#txtProveedor').val()
    var idDepartamento = $('#txtDepartamento').val()

    var producto = {
        IdProducto: idProducto,
        Nombre: nombre,
        PrecioUnitario: precioUnitario,
        Stock: stock,
        Descripcion: descripcion,
        Proveedor: {
            IdProveedor: idProveedor
        },
        Departamento: {
            IdDepartamento: idDepartamento
        }
    }
    $.ajax({
        type: 'PUT',
        url: 'http://localhost:16436/api/producto/Update/',
        data: producto,
        success: function (result) {
            alert(result.correct + "Producto actualizado");

            $('#txtNombre').val("")
            $('#txtPrecioUnitario').val("")
            $('#txtStock').val("")
            $('#txtDescripcion').val("")
            $('#txtProveedor').val("")
            $('#txtDepartamento').val("")
            $('#ModalUpdate').modal('hide');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.ErrorMessage);
        }
    });

}

function Add() {
    var nombre = $('#txtNombre').val()
    var precioUnitario = $('#txtPrecioUnitario').val()
    var stock = $('#txtStock').val()
    var descripcion = $('#txtDescripcion').val()
    var idProveedor = $('#txtProveedor').val()
    var idDepartamento = $('#txtDepartamento').val()

    var producto = {
        Nombre: nombre,
        PrecioUnitario: precioUnitario,
        Stock: stock,
        Descripcion: descripcion,
        Proveedor: {
            IdProveedor: idProveedor
        },
        Departamento: {
            IdDepartamento: idDepartamento
        }
    }


    $.ajax({
        type: 'POST',
        url: 'http://localhost:16436/api/producto/',
        data: producto,
        success: function (result) {
            alert(result.correct + "Producto agregado");

            $('#txtNombre').val("")
            $('#txtPrecioUnitario').val("")
            $('#txtStock').val("")
            $('#txtDescripcion').val("")
            $('#txtProveedor').val("")
            $('#txtDepartamento').val("")
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.ErrorMessage);
        }
    });
}



function SoloLetras(e,lbl) {
    tecla = (document.all) ? e.keyCode : e.which;
    patron = /[A-Z a-z]/;
    tecla_final = String.fromCharCode(tecla);

    if (patron.test(tecla_final)) {
        //document.getElementById("txtNombre").style.borderColor = "#008000" //JS
        $('#' + event.target.id).css('border-color', 'green')
        $('#' + lbl.id).text('')                                           //JS JQUERY
    }
    else {
       // document.getElementById(e.target.id).style.borderColor = "#FF0000"
        $('#' + event.target.id).css('border-color', 'red')
        
        $('#' + lbl.id).text('Solo se aceptan letras')
        $('#' + lbl.id).css('color','red')

        
    }
   return patron.test(tecla_final);
}
function SoloNumeros(e, lbl) {
    tecla = (document.all) ? e.keyCode : e.which;
    patron = /[0-9]/;
    tecla_final = String.fromCharCode(tecla);

    if (patron.test(tecla_final)) {

        $('#' + event.target.id).css('border-color', 'green')
        $('#' + lbl.id).text('')
    }
    else {
       //document.getElementById(e.target.id).style.borderColor = "#FF0000"
        $('#' + event.target.id).css('border-color', 'red')

        $('#' + lbl.id).text('Solo se aceptan números') 
        $('#' + lbl.id).css('color', 'red')
    }
    return patron.test(tecla_final);
}

function SoloNumeroDecimal(e, lbl) {
    tecla = (document.all) ? e.keyCode : e.which;
    patron = /[0-9.]/;
    tecla_final = String.fromCharCode(tecla);

    if (patron.test(tecla_final)) {
        //document.getElementById("txtNombre").style.borderColor = "#008000" //JS
        $('#' + event.target.id).css('border-color', 'green')
        $('#' + lbl.id).text('')                                           //JS JQUERY
    }
    else {
        // document.getElementById(e.target.id).style.borderColor = "#FF0000"
        $('#' + event.target.id).css('border-color', 'red')

        $('#' + lbl.id).text('Solo se aceptan numeros')
        $('#' + lbl.id).css('color', 'red')


    }
    return patron.test(tecla_final);
}

function CantidadNumeros() {

}

