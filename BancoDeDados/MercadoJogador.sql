create table MercadoJogador
(
codJogador int,
constraint fkJogador foreign key(codJogador) references Jogador(id),
codMercado int,
constraint fkMercado foreign key (codMercado) references Mercado(id)
)
drop table MercadoJogador

select * from MercadoJogador