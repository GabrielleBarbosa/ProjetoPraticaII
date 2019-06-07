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
insert into Escolha values(1, 'Tirar a carta', 'N�o tirar a carta', 3, 5)
insert into Escolha values(2, 'Tirar a carta', 'N�o tirar a carta', 4, 5)
insert into Escolha values(3, 'Sair para uma festa e comemorar', 'Procurar um plano de carreira', 6, 7)


-- Acontecimento aleat�rio

-- at� 15 anos
insert into Escolha values(20, 'Ir � festa', 'Estudar', 1, 2)
insert into Escolha values(21, 'Jogar video game', 'Estudar', 8, 9)
insert into Escolha values(22, 'Empurrar de volta', 'Ignorar e continuar brincando', 17, 18)
insert into Escolha values(23, 'Ir atr�s', 'Desistir', 19, 20)
insert into Escolha values(24,'Estudar','Ir dormir',22,23)
insert into Escolha values(25,'Gritar de volta','Ir para o quarto',24,25)
insert into Escolha values(26,'Fazer carinho','Passar reto',26,27)
insert into Escolha values(27,'Fazer carinho','Passar reto',28,27)
insert into Escolha values(28,'Ok','',35,35)
insert into Escolha values(29,'Verificar','Ignorar e ir dormir',36,37)
insert into Escolha values(30,'Atravessar correndo','Procurar uma faixa de pedestres e ir andando',38,39)
insert into Escolha values(31,'Atravessar correndo','Procurar uma faixa de pedestres e ir andando',41,40)
insert into Escolha values(32,'Atravessar correndo','Procurar uma faixa de pedestres e ir andando',41,39)
insert into Escolha values(33,'Atravessar correndo','Procurar uma faixa de pedestres e ir andando',38,40)
insert into Escolha values(34,'Ir na casa dele','N�o ir',59,60)
insert into Escolha values(35, 'Ir na festa','N�o participar',65,66)

select * from AcontecimentoAleatorio

-- de 16 a 30
insert into Escolha values(61, 'Aceitar', 'Negar e manter a amizade', 10, 11)
insert into Escolha values(62, 'Aceitar', 'Negar e manter a amizade', 12, 11)
insert into Escolha values(63, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 13, 14)
insert into Escolha values(64, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 14, 14)
insert into Escolha values(65, 'Ir � festa mesmo assim', 'Ficar em casa descansando', 15, 16)
insert into Escolha values(66, 'Ir beber', 'N�o ir', 42, 43)
insert into Escolha values(67, 'Ir ao cinema', 'Shopping', 44, 45)
insert into Escolha values(68, 'Namorada', 'Pais', 48, 49)
insert into Escolha values(69, 'Agredi-lo','Render-se',50,51)
insert into Escolha values(70, 'Agredi-lo','Render-se',52,51)
insert into Escolha values(71, 'Sim','N�o',53,54)
insert into Escolha values(72, 'Sim','N�o',61,62)
insert into Escolha values(73, 'Sair mais cedo do trabalho','Trabalhar',63,64)

-- de 31 a 60
insert into Escolha values(101, 'Ficar em casa', 'Ir trabalhar', 29, 31)
insert into Escolha values(102, 'Ficar em casa', 'Ir trabalhar', 29, 30)
insert into Escolha values(103, 'Ficar em casa', 'Ir trabalhar', 32, 31)
insert into Escolha values(104, 'Trabalhar a autoestima!', 'Ignorar seus sentimentos', 33, 34)
insert into Escolha values(105, 'Comprar','N�o comprar',46,47)
insert into Escolha values(106, 'Ir ao enterro','N�o ir',55,56)
insert into Escolha values(107, 'Ficar','N�o ficar',57,58)
insert into Escolha values(108, 'Comprar mais','N�o comprar',67,68)
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

insert into Consequencia values(1, 'pontos', 50, 'F','I', 50, 'Voc� foi � festa, se divertiu muito, mas foi mal na prova, como esperado.')
insert into Consequencia values(2, 'pontos', 50, 'I', 'F', 50, 'A prova foi um sucesso, infelizmente agora todos os seus amigos n�o param de falar da festa em que voc� n�o foi.')

insert into Consequencia values(3, 'carteira', 1, '', '', 0, 'Parab�ns! Agora voc� pode dirigir!')
insert into Consequencia values(4, 'carteira', 0, '', '', 0, 'Quem sabe na pr�xima... N�o saber dirigir n�o � o fim do mundo!')
insert into Consequencia values(5, 'carteira', 0, '', '', 0, 'N�o saber dirigir n�o � o fim do mundo, n�o � mesmo?')

insert into Consequencia values(6, 'pontos', 50, 'F', 'I', 50, 'Voc� se divertiu muito... Mas ser� que valeu a pena?')
insert into Consequencia values(7, 'carreira', 50, 'I', 'F', 50, '')

insert into Consequencia values(8, 'pontos', 50, 'F', 'I', 50, 'Voc� jogou video game a noite toda! Mas e os estudos?')
insert into Consequencia values(9, 'pontos', 50, 'I', 'F', 50, 'Estudar � o que te dar� futuro... Pena que n�o � o que te deixa feliz.')

insert into Consequencia values(10, 'namoro', 1, 'M', '', 0, 'Agora voc� est� namorando!!!')
insert into Consequencia values(11, 'namoro', 0, 'T', '', 0, 'Voc� escolheu manter sua amizade como est�, ser� que realmente voltar� a ser como antes?')
insert into Consequencia values(12, 'namoro', 1, 'F', '', 0, 'Agora voc� est� namorando!!!')

insert into Consequencia values(13, 'namoro', 1, '', '', 0, 'Ele(a) aceitou a nova chance! Tomara que as coisas melhorem...')
insert into Consequencia values(14, 'namoro', 0, '', '', 0, 'Todo relacionamento chega a um fim! Foque em coisas boas para n�o perder a esperan�a!')

insert into Consequencia values(15, 'pontos', 50, 'F', 'S', 50, 'A festa foi �tima pra sua felicidade! Agora para sua sa�de � outra hist�ria...')
insert into Consequencia values(16, 'pontos', 50, 'S', 'F', 50, 'Sua sa�de agradece a pequena pausa, infelizmente voc� est� arrependido porque teria se divertido muito.')

insert into Consequencia values(17, 'pontos', 10, 'F', 'S', 50, 'Voc� escolheu o caminho da viol�ncia e acabou machucado... Entretanto at� que te deixou um pouco feliz ter coragem de enfrent�-lo.')
insert into Consequencia values(18, 'pontos', 10, 'F', 'S', 40, 'N�o descer ao n�vel de seu amigo te fez se sentir superior, mas n�o o impediu de provoc�-lo de novo')

insert into Consequencia values(19, 'pontos', 14, 'F', 'S', 17, 'Voc� encontrou a bola!Mas se machucou um pouco')
insert into Consequencia values(20, 'pontos',  0, 'S', 'F', 19, 'Infelizmente voc� deixou a bola pra tr�s, mas n�o se machucou.')
insert into Consequencia values(21, 'pontos', -15, 'F', 'S', 34, 'Voc� se machucou ao trope�ar em uma raiz de �rvore!Infelizmente teve que voltar sem a bola')

insert into Consequencia values(22,'pontos',23,'I','S',26,'Conseguiu garantir um resultado mediano. Mas que cansa�o!')
insert into Consequencia values(23,'pontos',23,'S','I',27,'Pelo menos voc� est� bem descansado, mas n�o teve bons resultados...')

insert into Consequencia values(24,'pontos',12,'F','S',20,'Voc� gritou com eles de volta, mas isso te deixou meio mal...')
insert into Consequencia values(25,'pontos',-25,'F','S',3,'N�o retrucou, apenas foi para o seu quarto')

insert into Consequencia values(26,'pontos',20,'F','S',-4,'Ele gostou de voc�!')
insert into Consequencia values(27,'pontos',0,'F','S',0,'Muito fofo, n�o?')
insert into Consequencia values(28,'pontos',-25,'F','S',21,'O cachorro mordeu sua m�o')

insert into Consequencia values(29,'demissao', 0, '', '', 0, 'Seu chefe n�o quis nem ouvir suas desculpas, tr�s dias seguidos em casa � no olho da rua!')
insert into Consequencia values(30,'pontos', 25, 'I', 'S', 20, 'Voc� compareceu ao trabalho e melhorou mesmo assim... At� que n�o foi t�o ruim')
insert into Consequencia values(31,'pontos', 20, 'I', 'S', 50, 'Voc� compareceu ao trabalho e n�o melhorou por mais duas semanas! Descansar teria te feito muito melhor')
insert into Consequencia values(32,'pontos', 25, 'S', 'I', 10, 'Voc� n�o compateceu ao trabalho, e tudo bem! Melhorou bastante')

insert into Consequencia values(33,'pontos', 20, 'F', 'I', 0, 'Um tempo pra si mesmo(a) era tudo que voc� precisava!')
insert into Consequencia values(34,'pontos', 0, 'I', 'F', 20, 'Acumular tudo dentro de si parece o melhor, mas os sentimentos ainda est�o a�...')

insert into Consequencia values(35,'pontos',30, 'F', 'I',1,'')

insert into Consequencia values(36,'pontos',5, 'F', 'S',1,'Indo para a cozinha voc� encontra seu pai comendo doce escondido da sua m�e,ela vai ficar muito brava.')
insert into Consequencia values(37,'pontos',5, 'I', 'F',0,'N�o deve ser nada, melhor ignorar e n�o estar cansado amanh�')

insert into Consequencia values(38,'pontos',-50,'I','S',154,'Voc� tentou atravessar a rua correndo e um carro pegou em voc� de rasp�o, infelizmente quebrou um bra�o e foi parar no hospital. Pelo menos v�o te dar provas substitutivas...')
insert into Consequencia values(39,'pontos',50,'I','F',-5,'Voc� achou uma faixa de pedestres rapidamente e conseguiu chegar a tempo ')
insert into Consequencia values(40,'pontos',-73,'F','I',57,'Voc� demorou pra achar uma faixa, acabou chegando atrasado e n�o te permitiram entrar')
insert into Consequencia values(41,'pontos',60,'I','F',-49,'Voc� atravessou a rua correndo e chegou na escola. Nada de mau aconteceu, dessa vez...')

insert into Consequencia values(42,'pontos',23,'F','S',37,'Foi muito divertido, mas passou mal depois por conta da bebida e de estar doente')
insert into Consequencia values(43,'pontos',15,'S','F',6,'Voc� preferiu ficar em casa e descansar para se recuperar')


insert into Consequencia values(44,'pontos',29,'R','F',-20,'O filme foi muito divertido, na pr�xima talvez um jantar?')
insert into Consequencia values(45,'pontos',33,'R','F',-21,'O restaurante era muito bom, talvez um filme na pr�xima vez?')

insert into Consequencia values(46,'dinheiro',-500,'','',0,'Sua press�o est� voltando ao normal')
insert into Consequencia values(47,'pontos',-15,'F','S',35,'Sua press�o est� te fazendo passar mal')

insert into Consequencia values(48,'pontos',25,'R','F',23,'Sua namorada est� contente mas seus pais n�o est�o')
insert into Consequencia values(49,'pontos',23,'F','R',25,'Seus pais est�o contentes mas sua namorada n�o est�')

insert into Consequencia values(50,'pontos',-140,'F','S',250,'Ele te feriu com uma faca e voc� teve de ser levado ao hospital')
insert into Consequencia values(51,'pontos',-70,'F','S',50,'Ele levou seu celular e sua carteira, mas pelo menos voc� n�o se machucou')
insert into Consequencia values(52,'pontos',60,'F','S',7,'Voc� se meteu em uma briga e apagou o assaltante que foi preso pela pol�cia ')

insert into Consequencia values(53,'pontos',41,'F','S',49,'Foi extremamente satisfat�rio, mas isso n�o fez bem para sua sa�de')
insert into Consequencia values(54,'pontos',5,'F','I',10,'Sempre diga n�o �s drogas')

insert into Consequencia values(55,'pontos',5,'S','F',20,'O enterro foi muito tranquilo, voc� encontrou alguns parentes que n�o via h� muito tempo e pode se despedir de outro')
insert into Consequencia values(56,'pontos',0,'S','F',5,'Enterros podem ser tristes, de vez em quando � melhor n�o participar')

insert into Consequencia values(57,'pontos',31,'I','S',20,'Voc� ficou pra dar uma m�ozinha. Experi�ncia nunca � demais')
insert into Consequencia values(58,'pontos',20,'S','I',15,'Melhor descansar por hoje...')

insert into Consequencia values(59,'pontos',32,'F','S',20,'Passar o fim de semana com um amigo foi muito divertido, at� voltou para casa um pouco cansado')
insert into Consequencia values(60,'pontos',25,'I','F',29,'Melhor se comprometer com a escola')

insert into Consequencia values(61,'pontos',25,'F','S',25,'Se divertir um pouco sempre � v�lido')
insert into Consequencia values(62,'pontos',20,'S','F',15,'Sem muita disposi��o por hoje')

insert into Consequencia values(63,'pontos',25,'F','R',-25,'Pessoas importantes sempre em primeiro lugar')
insert into Consequencia values(64,'pontos',25,'I','R',35,'N�o posso correr riscos com o meu trabalho')

insert into Consequencia values(65,'pontos',25,'F','S',10,'Festa junina sempre � um evento muito legal, adoro participar!')
insert into Consequencia values(66,'pontos',10,'F','S',-5,'Ficar em casa pode ser melhor, menos cansativo')

insert into Consequencia values(67,'dinheiro',25,'','',0,'Sempre bom se cuidar!')
insert into Consequencia values(68,'pontos',-10,'F','S',40,'melhor guardar dinheiro')


select * from Consequencia

 select * from MercadoJogador
 select * from Personagem
 select * from Consequencia