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
insert into Escolha values(34,'Ir na casa dele','Não ir',59,60)
insert into Escolha values(35, 'Ir na festa','Não participar',65,66)

select * from AcontecimentoAleatorio

-- de 16 a 30
insert into Escolha values(61, 'Aceitar', 'Negar e manter a amizade', 10, 11)
insert into Escolha values(62, 'Aceitar', 'Negar e manter a amizade', 12, 11)
insert into Escolha values(63, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 13, 14)
insert into Escolha values(64, 'Insistir para continuarem juntos', 'Aceitar sua escolha', 14, 14)
insert into Escolha values(65, 'Ir à festa mesmo assim', 'Ficar em casa descansando', 15, 16)
insert into Escolha values(66, 'Ir beber', 'Não ir', 42, 43)
insert into Escolha values(67, 'Ir ao cinema', 'Shopping', 44, 45)
insert into Escolha values(68, 'Namorada', 'Pais', 48, 49)
insert into Escolha values(69, 'Agredi-lo','Render-se',50,51)
insert into Escolha values(70, 'Agredi-lo','Render-se',52,51)
insert into Escolha values(71, 'Sim','Não',53,54)
insert into Escolha values(72, 'Sim','Não',61,62)
insert into Escolha values(73, 'Sair mais cedo do trabalho','Trabalhar',63,64)

-- de 31 a 60
insert into Escolha values(101, 'Ficar em casa', 'Ir trabalhar', 29, 31)
insert into Escolha values(102, 'Ficar em casa', 'Ir trabalhar', 29, 30)
insert into Escolha values(103, 'Ficar em casa', 'Ir trabalhar', 32, 31)
insert into Escolha values(104, 'Trabalhar a autoestima!', 'Ignorar seus sentimentos', 33, 34)
insert into Escolha values(105, 'Comprar','Não comprar',46,47)
insert into Escolha values(106, 'Ir ao enterro','Não ir',55,56)
insert into Escolha values(107, 'Ficar','Não ficar',57,58)
insert into Escolha values(108, 'Comprar mais','Não comprar',67,68)
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

insert into Consequencia values(19, 'pontos', 14, 'F', 'S', 17, 'Você encontrou a bola!Mas se machucou um pouco')
insert into Consequencia values(20, 'pontos',  0, 'S', 'F', 19, 'Infelizmente você deixou a bola pra trás, mas não se machucou.')
insert into Consequencia values(21, 'pontos', -15, 'F', 'S', 34, 'Você se machucou ao tropeçar em uma raiz de árvore!Infelizmente teve que voltar sem a bola')

insert into Consequencia values(22,'pontos',23,'I','S',26,'Conseguiu garantir um resultado mediano. Mas que cansaço!')
insert into Consequencia values(23,'pontos',23,'S','I',27,'Pelo menos você está bem descansado, mas não teve bons resultados...')

insert into Consequencia values(24,'pontos',12,'F','S',20,'Você gritou com eles de volta, mas isso te deixou meio mal...')
insert into Consequencia values(25,'pontos',-25,'F','S',3,'Não retrucou, apenas foi para o seu quarto')

insert into Consequencia values(26,'pontos',20,'F','S',-4,'Ele gostou de você!')
insert into Consequencia values(27,'pontos',0,'F','S',0,'Muito fofo, não?')
insert into Consequencia values(28,'pontos',-25,'F','S',21,'O cachorro mordeu sua mão')

insert into Consequencia values(29,'demissao', 0, '', '', 0, 'Seu chefe não quis nem ouvir suas desculpas, três dias seguidos em casa é no olho da rua!')
insert into Consequencia values(30,'pontos', 25, 'I', 'S', 20, 'Você compareceu ao trabalho e melhorou mesmo assim... Até que não foi tão ruim')
insert into Consequencia values(31,'pontos', 20, 'I', 'S', 50, 'Você compareceu ao trabalho e não melhorou por mais duas semanas! Descansar teria te feito muito melhor')
insert into Consequencia values(32,'pontos', 25, 'S', 'I', 10, 'Você não compateceu ao trabalho, e tudo bem! Melhorou bastante')

insert into Consequencia values(33,'pontos', 20, 'F', 'I', 0, 'Um tempo pra si mesmo(a) era tudo que você precisava!')
insert into Consequencia values(34,'pontos', 0, 'I', 'F', 20, 'Acumular tudo dentro de si parece o melhor, mas os sentimentos ainda estão aí...')

insert into Consequencia values(35,'pontos',30, 'F', 'I',1,'')

insert into Consequencia values(36,'pontos',5, 'F', 'S',1,'Indo para a cozinha você encontra seu pai comendo doce escondido da sua mãe,ela vai ficar muito brava.')
insert into Consequencia values(37,'pontos',5, 'I', 'F',0,'Não deve ser nada, melhor ignorar e não estar cansado amanhã')

insert into Consequencia values(38,'pontos',-50,'I','S',154,'Você tentou atravessar a rua correndo e um carro pegou em você de raspão, infelizmente quebrou um braço e foi parar no hospital. Pelo menos vão te dar provas substitutivas...')
insert into Consequencia values(39,'pontos',50,'I','F',-5,'Você achou uma faixa de pedestres rapidamente e conseguiu chegar a tempo ')
insert into Consequencia values(40,'pontos',-73,'F','I',57,'Você demorou pra achar uma faixa, acabou chegando atrasado e não te permitiram entrar')
insert into Consequencia values(41,'pontos',60,'I','F',-49,'Você atravessou a rua correndo e chegou na escola. Nada de mau aconteceu, dessa vez...')

insert into Consequencia values(42,'pontos',23,'F','S',37,'Foi muito divertido, mas passou mal depois por conta da bebida e de estar doente')
insert into Consequencia values(43,'pontos',15,'S','F',6,'Você preferiu ficar em casa e descansar para se recuperar')


insert into Consequencia values(44,'pontos',29,'R','F',-20,'O filme foi muito divertido, na próxima talvez um jantar?')
insert into Consequencia values(45,'pontos',33,'R','F',-21,'O restaurante era muito bom, talvez um filme na próxima vez?')

insert into Consequencia values(46,'dinheiro',-500,'','',0,'Sua pressão está voltando ao normal')
insert into Consequencia values(47,'pontos',-15,'F','S',35,'Sua pressão está te fazendo passar mal')

insert into Consequencia values(48,'pontos',25,'R','F',23,'Sua namorada está contente mas seus pais não estão')
insert into Consequencia values(49,'pontos',23,'F','R',25,'Seus pais estão contentes mas sua namorada não está')

insert into Consequencia values(50,'pontos',-140,'F','S',250,'Ele te feriu com uma faca e você teve de ser levado ao hospital')
insert into Consequencia values(51,'pontos',-70,'F','S',50,'Ele levou seu celular e sua carteira, mas pelo menos você não se machucou')
insert into Consequencia values(52,'pontos',60,'F','S',7,'Você se meteu em uma briga e apagou o assaltante que foi preso pela polícia ')

insert into Consequencia values(53,'pontos',41,'F','S',49,'Foi extremamente satisfatório, mas isso não fez bem para sua saúde')
insert into Consequencia values(54,'pontos',5,'F','I',10,'Sempre diga não às drogas')

insert into Consequencia values(55,'pontos',5,'S','F',20,'O enterro foi muito tranquilo, você encontrou alguns parentes que não via há muito tempo e pode se despedir de outro')
insert into Consequencia values(56,'pontos',0,'S','F',5,'Enterros podem ser tristes, de vez em quando é melhor não participar')

insert into Consequencia values(57,'pontos',31,'I','S',20,'Você ficou pra dar uma mãozinha. Experiência nunca é demais')
insert into Consequencia values(58,'pontos',20,'S','I',15,'Melhor descansar por hoje...')

insert into Consequencia values(59,'pontos',32,'F','S',20,'Passar o fim de semana com um amigo foi muito divertido, até voltou para casa um pouco cansado')
insert into Consequencia values(60,'pontos',25,'I','F',29,'Melhor se comprometer com a escola')

insert into Consequencia values(61,'pontos',25,'F','S',25,'Se divertir um pouco sempre é válido')
insert into Consequencia values(62,'pontos',20,'S','F',15,'Sem muita disposição por hoje')

insert into Consequencia values(63,'pontos',25,'F','R',-25,'Pessoas importantes sempre em primeiro lugar')
insert into Consequencia values(64,'pontos',25,'I','R',35,'Não posso correr riscos com o meu trabalho')

insert into Consequencia values(65,'pontos',25,'F','S',10,'Festa junina sempre é um evento muito legal, adoro participar!')
insert into Consequencia values(66,'pontos',10,'F','S',-5,'Ficar em casa pode ser melhor, menos cansativo')

insert into Consequencia values(67,'dinheiro',25,'','',0,'Sempre bom se cuidar!')
insert into Consequencia values(68,'pontos',-10,'F','S',40,'melhor guardar dinheiro')


select * from Consequencia

 select * from MercadoJogador
 select * from Personagem
 select * from Consequencia