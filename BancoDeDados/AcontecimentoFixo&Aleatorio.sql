create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo
drop table AcontecimentoFixo

insert into AcontecimentoFixo values (1, 'Voc� atingiu 16 anos! Est� na hora de decidir se ir� tirar sua carteira de motorista, � preciso muita responsabilidade e te custar� $1500', 1)
insert into AcontecimentoFixo values (2, 'Voc� atingiu 16 anos! Est� na hora de decidir se ir� tirar sua carteira de motorista, � preciso muita responsabilidade e te custar� $1500', 2)
insert into AcontecimentoFixo values (3, 'Voc� atingiu 18 anos! Agora voc� pode consumir bebidas alco�licas, mas tamb�m ser preso, viva a maioridade!', 3) 
insert into AcontecimentoFixo values (6, 'A idade chegou e voc� agora � idoso! Doen�as ficam mais frequentes, mas � a hora de aproveitar a vida! Sua aposentadoria estar� dispon�vel a partir deste momento... Voc� pode receber um sal�rio m�nimo ou calcular o sal�rio que receber� pelos anos contribu�dos!');

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

-- at� 15 anos	

insert into AcontecimentoAleatorio values (1, 'Voc� tem uma festa no final de semana e uma prova segunda... Ir� � festa ou estudar� para a prova?', 20)
insert into AcontecimentoAleatorio values (2, 'Jogar v�deo game ou estudar para a prova no dia seguinte?', 21)
insert into AcontecimentoAleatorio values (3, 'Seu amigo te empurrou', 22)
insert into AcontecimentoAleatorio values (4, 'Voc� estava jogando bola e perdeu ela no mato, vai procur�-la? Pode ser perigoso...',23) 
insert into AcontecimentoAleatorio values (5,'Esqueceu de estudar para a prova de matem�tica! O que fazer?',24)	
insert into AcontecimentoAleatorio values (6,'Seus pais est�o brigando com voc�!',25)
insert into AcontecimentoAleatorio values (7,'Um cachorrinho na rua!',26)
insert into AcontecimentoAleatorio values (8,'Um cachorrinho na rua!',27)
insert into AcontecimentoAleatorio values (9,)

-- entre 16 e 30 anos
insert into AcontecimentoAleatorio values (21, 'Seu melhor amigo tem sentimentos por voc� e te pediu em namoro', 41)
insert into AcontecimentoAleatorio values (22, 'Sua melhor amiga tem sentimentos por voc� e te pediu em namoro', 42)
insert into AcontecimentoAleatorio values (23, 'Seu namorado(a) terminou com voc� =(', 43)
insert into AcontecimentoAleatorio values (24, 'Seu namorado(a) terminou com voc� =(', 44)
insert into AcontecimentoAleatorio values (25, 'Voc� tem uma festa de anivers�rio e est� muito doente, mas ainda assim deseja muito ir... O que fazer?', 45)
insert into AcontecimentoAleatorio values (26, '', 11)


-- entre 31 e 60 anos
insert into AcontecimentoAleatorio values (41, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 61)
insert into AcontecimentoAleatorio values (42, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 62)
insert into AcontecimentoAleatorio values (43, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 63)
insert into AcontecimentoAleatorio values (44, 'A idade est� se mostrando no seu rosto, e isso te deixa inseguro(a) quanto � sua apar�ncia', 64)




-- a partir de 60 anos


select * from AcontecimentoAleatorio