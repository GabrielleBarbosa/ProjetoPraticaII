create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo

select * from Usuario
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
insert into AcontecimentoAleatorio values (9,'Seus pais v�o viajar com voc� para a praia!',28)
insert into AcontecimentoAleatorio values (10,'Barulhos estranhos durante a noite na cozinha...',29)
insert into AcontecimentoAleatorio values (11,'Voc� est� extremamente atrasado para os exames finais e se n�o chegar logo pode n�o conseguir fazer a prova. Est� bem perto da escola mas ainda tem que atravessar uma estrada comprida.',30)
insert into AcontecimentoAleatorio values (12,'Voc� est� extremamente atrasado para os exames finais e se n�o chegar logo pode n�o conseguir fazer a prova. Est� bem perto da escola mas ainda tem que atravessar uma estrada comprida.',31)
insert into AcontecimentoAleatorio values (13,'Voc� est� extremamente atrasado para os exames finais e se n�o chegar logo pode n�o conseguir fazer a prova. Est� bem perto da escola mas ainda tem que atravessar uma estrada comprida.',32)
insert into AcontecimentoAleatorio values (14,'Voc� est� extremamente atrasado para os exames finais e se n�o chegar logo pode n�o conseguir fazer a prova. Est� bem perto da escola mas ainda tem que atravessar uma estrada comprida.',33)
insert into AcontecimentoAleatorio values (15,'Um amigo te chamou pra ir passar o fim de semana na casa dele, voc� vai?',34)
insert into AcontecimentoAleatorio values (16,'Festa junina na escola',35)

-- entre 16 e 30 anos.
insert into AcontecimentoAleatorio values (41, 'Seu melhor amigo tem sentimentos por voc� e te pediu em namoro', 61)
insert into AcontecimentoAleatorio values (42, 'Sua melhor amiga tem sentimentos por voc� e te pediu em namoro', 62)
insert into AcontecimentoAleatorio values (43, 'Seu namorado(a) terminou com voc� =(', 63)
insert into AcontecimentoAleatorio values (44, 'Seu namorado(a) terminou com voc� =(', 64)
insert into AcontecimentoAleatorio values (45, 'Voc� tem uma festa de anivers�rio e est� muito doente, mas ainda assim deseja muito ir... O que fazer?', 65)
insert into AcontecimentoAleatorio values (46, 'Voc� est� doente e alguns amigos v�o sair pra beber, vai com eles?', 66)
insert into AcontecimentoAleatorio values (47, 'Sua namorada deseja ir a um encontro',67)
insert into AcontecimentoAleatorio values (48, 'Sua namorada deseja sair com voc�^, mas faz tempo que seus pais querem te ver',68)
insert into AcontecimentoAleatorio values (49, 'Um homem apareceu de um beco e est� tentando te assaltar, ele n�o parece estar armado..',69)
insert into AcontecimentoAleatorio values (50, 'Um homem apareceu de um beco e est� tentando te assaltar, ele n�o  estar armado..',70)
insert into AcontecimentoAleatorio values (51, 'Ofere�eram-te maconha. Aceitas?',71)
insert into AcontecimentoAleatorio values (52, 'Ofere�eram vodka para voc� beber',72)
insert into AcontecimentoAleatorio values (53, 'Sua namorada disse estar um pouco mal e quer companhia, mas voc� precisa trabalhar.',73)

-- entre 31 e 60 anos
insert into AcontecimentoAleatorio values (81, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 101)
insert into AcontecimentoAleatorio values (82, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 102)
insert into AcontecimentoAleatorio values (83, 'Voc� pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho est� esperando, vai descansar mais um dia?', 103)
insert into AcontecimentoAleatorio values (84, 'A idade est� se mostrando no seu rosto, e isso te deixa inseguro(a) quanto � sua apar�ncia', 104)
insert into AcontecimentoAleatorio values (85, 'Voc� est� com a press�o muito alta, o rem�dio custa R$500',105)
insert into AcontecimentoAleatorio values (86, 'Um de seus parentes faleceu. Deseja comparecer ao enterro?',106)
insert into AcontecimentoAleatorio values (87, 'Voc� estava fazendo um beco de gar�om num restaurante e te pediram para ficar at� de madrugada? para ajudar nos eventos',107)
insert into AcontecimentoAleatorio values (88, 'Est� precisando repor o estoque de rem�dios',108)

select * from AcontecimentoAleatorio


-- a partir de 60 anos
insert into AcontecimentoAleatorio values (121, 'Voc� estava limpando a casa e acabou dando mau jeito na coluna', 141)
insert into AcontecimentoAleatorio values (122, 'Voc� estava indo para a fila preferencial do mercado e uma pessoa que n�o tem o direito de ir entrou na sua frente', 142)
insert into AcontecimentoAleatorio values (122, 'Voc� estava indo para a fila preferencial do mercado e uma pessoa que n�o tem o direito de ir entrou na sua frente', 143)

select * from AcontecimentoAleatorio