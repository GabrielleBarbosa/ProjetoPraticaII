create table Jogador
(
 nickName varchar(25) primary key,
 idade int not null,
 sexo char not null,
 pontosSaude int not null,
 pontosInteligencia int not null,
 pontosRelacionamento int not null,
 pontosFelicidade int not null, 
 dinheiro money,
 parceiro char not null,
 codEmprego int,
 constraint fkEmprego foreign key(codEmprego) references Emprego(codEmprego)
)


create table Ranking
(
nickName varchar(25),
constraint fkJogador foreign key(nickName) references Jogador(nickName),
pontos int
)

create table Escolha
(
codEscolha int primary key,
opcao1 varchar(50),
opcao2 varchar(50),
consequencia1 int,
constraint fkConsequencia1 foreign key(consequencia1) references Consequencia(codConsequencia),
consequencia2 int,
constraint fkConsequencia2 foreign key(consequencia2) references Consequencia(codConsequencia)

)

create table Consequencia
(
codConsequencia int primary key,
cenario varchar(20),
pontosGanhos int,
tipoDoPontoGanho varchar(20),
tipoDoPontoPerdido varchar(20),
pontosPerdidos int
)

create table Emprego
(
codEmprego int primary key,
pontosNecessarios int,
trabalho varchar(30),
salario money
)

create table AcontecimentoFixo
(
codAcontecimentoFixo int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(codEscolha)

)

create table AcontecimentoAleatorio
(
codAcontecimentoAleatorio int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha2 foreign key(codEscolha) references Escolha(codEscolha)
)

create table Mercado
(
codProduto int primary key,
compra ntext,
preco money
)

create table MercadoJogador
(
codJogador varchar(25),
constraint fkJogador2 foreign key(codJogador) references Jogador(nickName)
)
