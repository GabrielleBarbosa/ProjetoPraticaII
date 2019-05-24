
function suicidioTexto() {
$('#resposta1').attr('href', 'Suicidio');
$('#txt1').hide();
$('.lbl1').html("");
$('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
$('.modal').modal();
}

function terminarRel() {
    $('#txt1').hide();
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $.post('/Jogo/TerminarRelacionamento')
    $('.modal').modal();
}

function demissao(){
    $('#txt1').hide();
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão? ");
    $('.modal').modal();
}

function Obituario() {
    $('#txt1').hide();
    $('.lbl1').hide();
    var motivoMorte = "Você encontrou uma corda e um ventilador, fez o que acreditava que deveria ser feito";
    var descricao = "Seu funeral foi composto pelos seus familiares e amigos. Ninguém sabia ao certo os motivos do que você fez, "
                    +"apenas sabiam que você havia decididio dar um fim a sua própria vida.Mas fazer o que, essas coisas acontecem, o que nos resta apenas é tentar novamente...";
    $('#cabecalho').html("Obituário");
    $('#paragrafo').html(descricao);
    $('.modal').height('800');
    $('.modal').modal();

}

















//-----------------------------------------------------


$(document).ready(function () {
    $('.modal').modal();
});