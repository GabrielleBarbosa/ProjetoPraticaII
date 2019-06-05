create table Escolha
(
id int primary key,
opcao1 varchar(50),
opcao2 varchar(50),
consequencia1 int,
constraint fkConsequencia1 foreign key(consequencia1) references Consequencia(id),
consequencia2 int,
constraint fkConsequencia2 foreign key(consequencia2) references Consequencia(id)
)

drop table Escolha

-- Acontecimento fixo
insert into Escolha values(1, 'Tirar a carta', 'Não tirar a carta', 3, 5)
insert into Escolha values(2, 'Tirar a carta', 'Não tirar a carta', 4, 5)
insert into Escolha values(3, 'Sair para uma festa e comemorar', 'Procurar um plano de carreira', 6, 7)


-- Acontecimento aleatório

-- até 15 anos
insert into Escolha values(20, 'Ir à festa', 'Estudar', 1, 2)
insert into Escolha values(21, 'Jogar video game', 'Estudar', 8, 9)
insert into Escolha values(22, 'Empurrar de volta', 'Ignorar e continuar brincando', 17, 18)
insert into Escolha values(23, 'Ir atrás', 'Desistir', 19, 20)


-- de 15 a 30
insert into Escolha values(41, 'Aceitar', 'Negar e manter a amizade', 10, 11)
insert into Escolha values(42, 'Aceitar', 'Negar e manter a amizade', 12, 11)
insert into Escolha values(43, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 13, 14)
insert into Escolha values(44, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 14, 14)
insert into Escolha values(45, 'Ir à festa mesmo assim', 'Ficar em casa descansando', 15, 16)
------------------------------------------------------------------------------------------------------------------------

create table Consequencia
(
id int primary key,
assunto varchar(20),
pontosGanhos int,
tipoDoPontoGanho char,
tipoDoPontoPerdido char,
pontosPerdidos int,
resultado ntext
)
alter table consequencia add resultado ntext
drop table Consequencia

insert into Consequencia values(1, 'pontos', 50, 'F','I', 50, 'Você foi à festa, se divertiu muito, mas foi mal na prova, como esperado.')
insert into Consequencia values(2, 'pontos', 50, 'I', 'F', 50, 'A prova foi um sucesso, infelizmente agora todos os seus amigos não param de falar da festa em que você não foi.')

insert into Consequencia values(3, 'carteira', 1, '', '', 0, 'Parabéns! Agora você pode dirigir!')
insert into Consequencia values(4, 'carteira', 0, '', '', 0, 'Quem sabe na próxima... Não saber dirigir não é o fim do mundo!')
insert into Consequencia values(5, 'carteira', 0, '', '', 0, 'Não saber dirigir não é o fim do mundo, não é mesmo?')

insert into Consequencia values(6, 'pontos', 50, 'F', 'I', 50, 'Você se divertiu muito... Mas será que valeu a pena?')
insert into Consequencia values(7, 'carreira', 50, 'I', 'F', 50, '')

insert into Consequencia values(8, 'pontos', 50, 'F', 'I', 50, 'Você jogou video game a noite toda! Mas e os estudos?')
insert into Consequencia values(9, 'pontos', 50, 'I', 'F', 50, 'Estudar é o que te dará futuro... Pena que não é o que te deixa feliz.')

insert into Consequencia values(10, 'namoro', 1, 'M', '', 0, 'Agora você está namorando!!!')
insert into Consequencia values(11, 'namoro', 0, 'T', '', 0, 'Você escolheu manter sua amizade como está, será que realmente voltará a ser como antes?')
insert into Consequencia values(12, 'namoro', 1, 'F', '', 0, 'Agora você está namorando!!!')

insert into Consequencia values(13, 'namoro', 1, '', '', 0, 'Ele(a) aceitou a nova chance! Tomara que as coisas melhorem...')
insert into Consequencia values(14, 'namoro', 0, '', '', 0, 'Todo relacionamento chega a um fim! Foque em coisas boas para não perder a esperança!')

insert into Consequencia values(15, 'pontos', 50, 'F', 'S', 50, 'A festa foi ótima pra sua felicidade! Agora para sua saúde é outra história...')
insert into Consequencia values(16, 'pontos', 50, 'S', 'F', 50, 'Sua saúde agradece a pequena pausa, infelizmente você está arrependido porque teria se divertido muito.')

insert into Consequencia values(17, 'pontos', 10, 'F', 'S', 50, 'Você escolheu o caminho da violência e acabou machucado... Entretanto até que te deixou um pouco feliz ter coragem de enfrentá-lo.')
insert into Consequencia values(18, 'pontos', 10, 'F', 'S', 40, 'Não descer ao nível de seu amigo te fez se sentir superior, mas não o impediu de provocá-lo de novo')


--mexer aqui
insert into Consequencia values(19, 'pontos', 10, 'F', 'S', 50, 'Você encontrou a bola!')
insert into Consequencia values(20, 'pontos', 10, 'F', 'S', 50, 'Infelizmente você deixou a bola pra trás, mas não se machucou.')
insert into Consequencia values(21, 'pontos', 10, 'F', 'S', 50, 'Você se machucou ao tropeçar em uma raiz de árvore!')

select * from AcontecimentoAleatorio

