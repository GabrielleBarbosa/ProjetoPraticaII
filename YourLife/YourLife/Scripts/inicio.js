$(document).ready(() => {
    $("#")
})

function SalvarPersonagem(sexo) {
    var nome = $("#nome").val();
    var senha = $("#senha").val();
    var confirmaSenha = $("#confirmaSenha").val();

    if (nome != "") {
        if (senha != "" && senha == confirmaSenha) {

            if (!ViewBag.ExisteJogador(nome)) {
                ViewBag.Adiciona(nome, senha, sexo);
            }
        }
    }
}