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
 constraint fkEmprego foreign key(codEmprego) references Emprego(id),
 carteiraMotorista char not null 
)
alter table Personagem add codCursando int
alter table Personagem add constraint fkCursoFazendo foreign key(codCursando) references Curso(id)
alter table Personagem add anosCursando int 


select * from Personagem
select * from Usuario



select * from Personagem

