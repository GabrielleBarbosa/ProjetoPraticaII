create table Curso(
id int primary key,
nome varchar(40),
descricao ntext, 
codCursoNecessario int, 
constraint fkCurso foreign key(codCursoNecessario) references Curso(id)
)

select * from curso
select * from Personagem
select * from usuario
delete from Usuario 
delete from Curso where id=5 or id=6
delete from Emprego
delete from CursoJogador
delete from emprego
delete from Personagem

insert into curso values (0,'-','',0)
insert into curso values (1, 'Inform�tica', 'Desenvolvimento de aplicativos computacionais, t�cnicas avan�adas de desenvolvimento de sistemas de alta complexidade e aten��o constante � qualidade, ampla possibilidade de trabalho.', 0)
insert into curso values (2, 'Eletroeletr�nica', 'Conhecimentos nas �reas de Eletricidade, M�quinas e Instala��es El�tricas, Sistemas de Pot�ncia, Eletr�nica, Automa��o Industrial, Sistemas Digitais, Sistemas de Controle e No��es de Telecomunica��es, atuando em ind�strias, centros de pesquisas e empresas de m�dia e alta tecnologia.', 0)
insert into curso values (3, 'Tecnologia em Alimentos', 'Profissional que atua entre o Engenheiro de Alimentos e os operadores de produ��o na planta de processamento, gerenciando dados para o desenvolvimento de novos produtos, alta rela��o com qu�mica', 0)
insert into curso values (4, 'Mecatr�nica', 'Atua nas �reas industrial e de servi�os, integrando os sistemas produtivos com os sistemas computacionais de controle, suporte e apoio ao ambiente de manufatura.', 0)
insert into curso values (5, 'Meio Ambiente', 'Atua��o focada no desenvolvimento sustent�vel e na preven��o da polui��o, interferindo nos ciclos de vida do produto, desde a aquisi��o de mat�ria prima, seu processamento e reciclabilidade, dentro dos princ�pios de adequa��o � Legisla��o Ambiental. Atua em todas as organiza��es empresariais, hospitalares e governamentais.', 0)
insert into curso values (6, 'Medicina', 'Profissionais com conhecimentos, habilidades e atitudes para o exerc�cio da medicina numa postura �tica, numa vis�o human�stica, com senso de responsabilidade social e compromisso com a cidadania; aptos � orienta��o para a prote��o, promo��o da sa�de e preven��o das doen�as.', 0)
insert into curso values (7, 'Enfermagem', 'Aprendizado em funcionamento de unidades de sa�de, conceitos de administra��o hospitalar, psicologia, saneamento, sa�de p�blica, farmacologia; atua em estabelecimentos de sa�de, hospitais, consult�rios m�dicos, cl�nicas m�dicas, laborat�rios, etc..', 0)
insert into curso values (8, 'Biologia', 'Dedica��o ao estudo de diferente formas de vida, com objetivo de estudar a origem, evolu��o, estrutura e funcionamento dos seres vivos e analisar sua rela��o com o meio ambiente; atua em desde zool�gicos e reservas naturais at� industria de alimentos.', 0)
insert into curso values (9, 'Engenharia Qu�mica', 'curso legau', 0)
insert into curso values (10, 'Engenharia El�trica', 'curso legau', 0)
insert into curso values (11, 'Engenharia da Computa��o', 'curso legau', 0)
insert into curso values (12, 'Direito', 'curso legau', 0)
insert into curso values (13, 'Fotografia', 'curso legau', 0)
insert into curso values (14, 'Cinema', 'curso legau', 0)
insert into curso values (15, 'Teatro', 'curso legau', 0)
insert into curso values (16, 'Administra��o', 'curso legau', 0)
insert into curso values (17, 'Culin�ria', 'curso legau', 0)
insert into curso values (18, 'Chefe de culin�ria', 'curso legau', 0)
insert into curso values (19, 'Pedagogia', 'curso legau', 0)
insert into curso values (20, 'Edi��o', 'curso legau', 0)
insert into curso values (21, 'Matem�tica', 'curso legau', 0)
insert into curso values (22, 'Qualidade', 'curso legau', 0)
insert into curso values (23, 'Artes', 'curso legau', 0)
insert into curso values (24, 'Engenharia de Alimentos', 'curso legau', 0)


create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso1 foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Personagem(id)
)

drop table CursoJogador

select * from Usuario