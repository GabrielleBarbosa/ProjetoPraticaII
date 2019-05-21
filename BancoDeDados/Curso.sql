create table Curso(
id int primary key,
nome varchar(20),
descricao ntext, 
codCursoNecessario int, 
constraint fkCurso foreign key(codCursoNecessario) references Curso(id)
)

update Curso set nome='-' where id=0
select * from curso
select * from Personagem
select * from usuario
delete from Usuario 
alter table Curso alter column nome varchar (40)
delete from Curso
delete from CursoJogador
delete from emprego
delete from Personagem

insert into curso values (0,'','',0)
insert into curso values (1, 'Informática', 'Desenvolvimento de aplicativos computacionais, técnicas avançadas de desenvolvimento de sistemas de alta complexidade e atenção constante à qualidade, ampla possibilidade de trabalho', 0)
insert into curso values (2, 'Eletroeletrônica', 'Conhecimentos nas áreas de Eletricidade, Máquinas e Instalações Elétricas, Sistemas de Potência, Eletrônica, Automação Industrial, Sistemas Digitais, Sistemas de Controle e Noções de Telecomunicações, atuando em indústrias, centros de pesquisas e empresas de média e alta tecnologia', 0)
insert into curso values (3, 'Tecnologia em Alimentos', 'Profissional que atua entre o Engenheiro de Alimentos e os operadores de produção na planta de processamento, gerenciando dados para o desenvolvimento de novos produtos, alta relação com química', 0)
insert into curso values (4, 'Mecatrônica', 'Atua nas áreas industrial e de serviços, integrando os sistemas produtivos com os sistemas computacionais de controle, suporte e apoio ao ambiente de manufatura', 0)
insert into curso values (5, 'Meio Ambiente', 'curso legau', 0)
insert into curso values (6, 'Medicina', 'curso legau', 0)
insert into curso values (7, 'Enfermagem', 'curso legau', 0)
insert into curso values (8, 'Biologia', 'curso legau', 0)
insert into curso values (9, 'Engenharia Química', 'curso legau', 0)
insert into curso values (10, 'Engenharia Elétrica', 'curso legau', 0)
insert into curso values (11, 'Engenharia da Computação', 'curso legau', 0)
insert into curso values (12, 'Direito', 'curso legau', 0)
insert into curso values (13, 'Fotografia', 'curso legau', 0)
insert into curso values (14, 'Cinema', 'curso legau', 0)
insert into curso values (15, 'Teatro', 'curso legau', 0)
insert into curso values (16, 'Administração', 'curso legau', 0)
insert into curso values (17, 'Culinária', 'curso legau', 0)
insert into curso values (18, 'Chefe de culinária', 'curso legau', 0)
insert into curso values (19, 'Pedagogia', 'curso legau', 0)
insert into curso values (20, 'Edição', 'curso legau', 0)
insert into curso values (21, 'Matemática', 'curso legau', 0)
insert into curso values (22, 'Matemática', 'curso legau', 0)


create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso1 foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Personagem(id)
)

drop table CursoJogador

select * from Usuario