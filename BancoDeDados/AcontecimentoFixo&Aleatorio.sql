create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo
drop table AcontecimentoFixo

insert into AcontecimentoFixo values (1, 'Você atingiu 16 anos! Está na hora de decidir se irá tirar sua carteira de motorista, é preciso muita responsabilidade e te custará $1500', 1)
insert into AcontecimentoFixo values (2, 'Você atingiu 16 anos! Está na hora de decidir se irá tirar sua carteira de motorista, é preciso muita responsabilidade e te custará $1500', 2)
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

-- até 15 anos	

insert into AcontecimentoAleatorio values (1, 'Você tem uma festa no final de semana e uma prova segunda... Irá à festa ou estudará para a prova?', 20)
insert into AcontecimentoAleatorio values (2, 'Jogar vídeo game ou estudar para a prova no dia seguinte?', 21)
insert into AcontecimentoAleatorio values (3, 'Seu amigo te empurrou', 22)
insert into AcontecimentoAleatorio values (4, 'Você estava jogando bola e perdeu ela no mato, vai procurá-la?Pode ser perigoso...'23) --não inserido
insert into AcontecimentoAleatorio values (5,)	
insert into AcontecimentoAleatorio values (6,)
insert into AcontecimentoAleatorio values (7,)
insert into AcontecimentoAleatorio values (8,)



insert into AcontecimentoAleatorio values (21, 'Seu melhor amigo tem sentimentos por você e te pediu em namoro', 41)
insert into AcontecimentoAleatorio values (22, 'Sua melhor amiga tem sentimentos por você e te pediu em namoro', 42)
insert into AcontecimentoAleatorio values (23, 'Seu namorado(a) terminou com você =(', 43)
insert into AcontecimentoAleatorio values (24, 'Seu namorado(a) terminou com você =(', 44)
insert into AcontecimentoAleatorio values (25, 'Você tem uma festa de aniversário e está muito doente, mas ainda assim deseja muito ir... O que fazer?', 45)
insert into AcontecimentoAleatorio values (26, '', 11)

select * from AcontecimentoAleatorio