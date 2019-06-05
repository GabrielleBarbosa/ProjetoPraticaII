create table EmpregoJogador(
	id int identity(1,1) primary key,
	anosTrabalhados int not null,
	codJogador int, 
	constraint fkJogador3 foreign key(codJogador) references Personagem(id),
	codEmprego int, 
	constraint fkEmprego2 foreign key(codEmprego) references Emprego(id)
)