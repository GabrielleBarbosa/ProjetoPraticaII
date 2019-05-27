create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo
drop table AcontecimentoFixo

insert into AcontecimentoFixo values (1, 'Você atingiu 16 anos! Está na hora de decidir se irá tirar sua carteira de motorista, é preciso muita responsabilidade e te custará $1500', 2)
insert into AcontecimentoFixo values (2, 'Você atingiu 16 anos! Está na hora de decidir se irá tirar sua carteira de motorista, é preciso muita responsabilidade e te custará $1500', 4)
insert into AcontecimentoFixo values (3, 'Você atingiu 18 anos! Agora você pode consumir bebidas alcoólicas, mas também ser preso, viva a maioridade!', 3) 


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
insert into AcontecimentoAleatorio values (2, 'Jogar vídeo game ou estudar para a prova no dia seguinte?', 11)
insert into AcontecimentoAleatorio values (3, 'Seu amiguinho te empurrou', 10)

insert into AcontecimentoAleatorio values (21, 'Seu melhor amigo tem sentimentos por você e te pediu em namoro', 5)
insert into AcontecimentoAleatorio values (22, 'Sua melhor amiga tem sentimentos por você e te pediu em namoro', 6)
insert into AcontecimentoAleatorio values (23, 'Seu namorado(a) terminou com você =(', 7)
insert into AcontecimentoAleatorio values (24, 'Seu namorado(a) terminou com você =(', 8)
insert into AcontecimentoAleatorio values (25, 'Você tem uma festa de aniversário e está muito doente, mas ainda assim deseja muito ir... O que fazer?', 9)
insert into AcontecimentoAleatorio values (25, '', 11)