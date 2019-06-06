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
insert into AcontecimentoFixo values (6, 'A idade chegou e você agora é idoso! Doenças ficam mais frequentes, mas é a hora de aproveitar a vida! Sua aposentadoria estará disponível a partir deste momento... Você pode receber um salário mínimo ou calcular o salário que receberá pelos anos contribuídos!');

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
insert into AcontecimentoAleatorio values (4, 'Você estava jogando bola e perdeu ela no mato, vai procurá-la? Pode ser perigoso...',23) 
insert into AcontecimentoAleatorio values (5,'Esqueceu de estudar para a prova de matemática! O que fazer?',24)	
insert into AcontecimentoAleatorio values (6,'Seus pais estão brigando com você!',25)
insert into AcontecimentoAleatorio values (7,'Um cachorrinho na rua!',26)
insert into AcontecimentoAleatorio values (8,'Um cachorrinho na rua!',27)
insert into AcontecimentoAleatorio values (9,'Seus pais vão viajar com você para a praia!',28)
insert into AcontecimentoAleatorio values (10,'Barulhos estranhos durante a noite na cozinha...',29)
insert into AcontecimentoAleatorio values (11,'Você está extremamente atrasado para os exames finais e se não chegar logo pode não conseguir fazer a prova. Está bem perto da escola mas ainda tem que atravessar uma estrada comprida.',30)
insert into AcontecimentoAleatorio values (12,'Você está extremamente atrasado para os exames finais e se não chegar logo pode não conseguir fazer a prova. Está bem perto da escola mas ainda tem que atravessar uma estrada comprida.',31)
insert into AcontecimentoAleatorio values (13,'Você está extremamente atrasado para os exames finais e se não chegar logo pode não conseguir fazer a prova. Está bem perto da escola mas ainda tem que atravessar uma estrada comprida.',32)
insert into AcontecimentoAleatorio values (14,'Você está extremamente atrasado para os exames finais e se não chegar logo pode não conseguir fazer a prova. Está bem perto da escola mas ainda tem que atravessar uma estrada comprida.',33)


-- entre 16 e 30 anos
insert into AcontecimentoAleatorio values (41, 'Seu melhor amigo tem sentimentos por você e te pediu em namoro', 61)
insert into AcontecimentoAleatorio values (42, 'Sua melhor amiga tem sentimentos por você e te pediu em namoro', 62)
insert into AcontecimentoAleatorio values (43, 'Seu namorado(a) terminou com você =(', 63)
insert into AcontecimentoAleatorio values (44, 'Seu namorado(a) terminou com você =(', 64)
insert into AcontecimentoAleatorio values (45, 'Você tem uma festa de aniversário e está muito doente, mas ainda assim deseja muito ir... O que fazer?', 65)
insert into AcontecimentoAleatorio values (46, 'Alguns amigos vão sair pra beber, vai com eles?', 11)


-- entre 31 e 60 anos
insert into AcontecimentoAleatorio values (81, 'Você pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho está esperando, vai descansar mais um dia?', 101)
insert into AcontecimentoAleatorio values (82, 'Você pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho está esperando, vai descansar mais um dia?', 102)
insert into AcontecimentoAleatorio values (83, 'Você pegou um resfriado severo e ficou de cama por dois dias. Seu trabalho está esperando, vai descansar mais um dia?', 103)
insert into AcontecimentoAleatorio values (84, 'A idade está se mostrando no seu rosto, e isso te deixa inseguro(a) quanto à sua aparência', 104)




-- a partir de 60 anos


select * from AcontecimentoAleatorio