create table MercadoJogador
(
id int identity(1,1) primary key, 
codJogador int,
constraint fkJogador foreign key(codJogador) references Personagem(id),
codMercado int,
constraint fkMercado foreign key (codMercado) references Mercado(id)
)
drop table MercadoJogador

select * from MercadoJogador