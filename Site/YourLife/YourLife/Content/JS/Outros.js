
function suicidioTexto() {
$('#txt1').hide();
$('.lbl1').html("");
$('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
$('.modal').modal();
$.post('/Jogo/Suicidio');
Response.redirect("/Jogo/EscolhaPersonagem");
}

function terminarRel() {
    $('#txt1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $('.modal').modal();
}

function demissao(){
    $('#txt1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão? ");
    $('.modal').modal();
}


function Obituario() {
    var motivoMorte = "Você encontrou uma corda e um ventilador, fez o que acreditava que deveria ser feito";
    var descricao = "Seu funeral foi composto pelos seus familiares e amigos. Ninguém sabia ao certo os motivos do que você fez, "
                    +"apenas sabiam que você havia decididio dar um fim a sua própria vida.Mas fazer o que, essas coisas acontecem, o que nos resta apenas é tentar novamente...";
    $('#cabecalho').html("Obituário");
    $('#txt1').html(descricao);

}

















//-----------------------------------------------------


$(document).ready(function () {
    $('.modal').modal();
});