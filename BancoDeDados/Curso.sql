create table Curso(
id int primary key,
nome varchar(20),
descricao ntext, 
codCursoNecessario int, 
constraint fkCurso foreign key(codCursoNecessario) references Curso(id)
)

update Curso set nome='-' where id=0
select * from curso
drop table curso
insert into curso values (0, '','',0)
insert into curso values (1, 'Informática', 'curso legau', 0)


create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso1 foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Personagem(id)
)

drop table CursoJogador

select * from Usuario