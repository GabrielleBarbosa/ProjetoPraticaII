create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo
drop table AcontecimentoFixo


------------------------------------------------------------------------------------------------------------------------

create table AcontecimentoAleatorio
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha2 foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoAleatorio
drop table AcontecimentoAleatorio

-- 1 a 15

insert into AcontecimentoAleatorio values (1, 'Você tem uma festa no final de semana e uma prova segunda... Irá à festa ou estudará para a prova?', 1)