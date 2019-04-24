
function SalvarPersonagem(sexo) {

    var nome = $("#nome").val();
    var senha = $("#senha").val();
    var confirmaSenha = $("#confirmaSenha").val();

    if (nome != "") {
        if (senha != "" && senha == confirmaSenha) {

            if (ChecarNick()) {
                alert("sjuhegdjuhf");
            }
            else
                alert("aaaaaaaa");
        }
    }
}

function ChecarNick() {
    var url = $("#nome").data('request-url');
    $.post(url, {
        nome: $("#nome").val()
    },
        function (data) {
            if (data) {
                return false;
            }
            else
                return true;
        });
}
