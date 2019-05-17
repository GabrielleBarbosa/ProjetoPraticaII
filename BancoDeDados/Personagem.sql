create table Personagem
(
 id int identity(1,1) primary key,
 codUsuario int not null,
 constraint fkUsuario foreign key(codUsuario) references Usuario(id),
 nome varchar(25),
 idade int not null,
 sexo char not null,
 pontosSaude int not null,
 pontosInteligencia int not null,
 pontosRelacionamento int not null,
 pontosFelicidade int not null, 
 dinheiro money,
 parceiro int,
 constraint fkParceiro foreign key(parceiro) references Parceiro(id),
 codEmprego int not null,
 constraint fkEmprego foreign key(codEmprego) references Emprego(id)
)


select * from Personagem
drop table Personagem

insert into Personagem values('123','Vinchers',0,'M',0,0,0,0,0,'S',0)
insert into Personagem values('Gabs123',0,'F',0,0,0,0,0,'S',1)
insert into Personagem values('Janies',0,'F',0,0,0,0,0,'S',1)


create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Jogador(id)
)

drop table CursoJogador

select * from Usuario