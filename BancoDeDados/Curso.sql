create table Curso(
id int primary key,
nome varchar(40),
descricao ntext, 
codCursoNecessario int, 
constraint fkCurso foreign key(codCursoNecessario) references Curso(id)
)


insert into curso values (0,'-','',0)
insert into curso values (1, 'Informática', 'Desenvolvimento de aplicativos computacionais, técnicas avançadas de desenvolvimento de sistemas de alta complexidade e atenção constante à qualidade, ampla possibilidade de trabalho.', 0)
insert into curso values (2, 'Eletroeletrônica', 'Conhecimentos nas áreas de Eletricidade, Máquinas e Instalações Elétricas, Sistemas de Potência, Eletrônica, Automação Industrial, Sistemas Digitais, Sistemas de Controle e Noções de Telecomunicações, atuando em indústrias, centros de pesquisas e empresas de média e alta tecnologia.', 0)
insert into curso values (3, 'Tecnologia em Alimentos', 'Profissional que atua entre o Engenheiro de Alimentos e os operadores de produção na planta de processamento, gerenciando dados para o desenvolvimento de novos produtos, alta relação com química', 0)
insert into curso values (4, 'Mecatrônica', 'Atua nas áreas industrial e de serviços, integrando os sistemas produtivos com os sistemas computacionais de controle, suporte e apoio ao ambiente de manufatura.', 0)
insert into curso values (5, 'Meio Ambiente', 'Atuação focada no desenvolvimento sustentável e na prevenção da poluição, interferindo nos ciclos de vida do produto, desde a aquisição de matéria prima, seu processamento e reciclabilidade, dentro dos princípios de adequação à Legislação Ambiental. Atua em todas as organizações empresariais, hospitalares e governamentais.', 0)
insert into curso values (6, 'Medicina', 'Profissionais com conhecimentos, habilidades e atitudes para o exercício da medicina numa postura ética, numa visão humanística, com senso de responsabilidade social e compromisso com a cidadania; aptos à orientação para a proteção, promoção da saúde e prevenção das doenças.', 0)
insert into curso values (7, 'Enfermagem', 'Aprendizado em funcionamento de unidades de saúde, conceitos de administração hospitalar, psicologia, saneamento, saúde pública, farmacologia; atua em estabelecimentos de saúde, hospitais, consultórios médicos, clínicas médicas, laboratórios, etc..', 0)
insert into curso values (8, 'Biologia', 'Dedicação ao estudo de diferente formas de vida, com objetivo de estudar a origem, evolução, estrutura e funcionamento dos seres vivos e analisar sua relação com o meio ambiente; atua em desde zoológicos e reservas naturais até industria de alimentos.', 0)
insert into curso values (9, 'Engenharia Química', 'Engenharia química é a área/profissão que dedica-se à concepção, desenvolvimento, dimensionamento, melhoramento e aplicação dos Processos e dos seus Produtos. Neste âmbito inclui-se a análise econômica, dimensionamento, construção, operação, controle e gestão das Unidades Industriais que concretizam esses Processos, assim como a investigação e formação nesses domínios', 0)
insert into curso values (10, 'Engenharia Elétrica', 'O engenheiro elétrico é responsável por planejar, construir e manter sistemas capazes de gerar, transmitir e distribuir energia elétrica. Seu objetivo é levar energia elétrica a toda a população de forma segura e com qualidade.', 0)
insert into curso values (11, 'Engenharia da Computação', 'curso legau', 0)
insert into curso values (12, 'Direito', 'curso legau', 0)
insert into curso values (13, 'Fotografia', 'curso legau', 0)
insert into curso values (14, 'Artes Cênicas', 'curso legau', 0)
insert into curso values (15, 'Administração', 'curso legau', 0)
insert into curso values (16, 'Culinária', 'curso legau', 0)
insert into curso values (17, 'Chefe de culinária', 'curso legau', 0)
insert into curso values (18, 'Pedagogia', 'curso legau', 0)
insert into curso values (19, 'Edição', 'curso legau', 0)
insert into curso values (20, 'Matemática', 'curso legau', 0)
insert into curso values (21, 'Qualidade', 'curso legau', 0)


create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso1 foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Personagem(id)
)

drop table CursoJogador

select * from CursoJogador
select * from Usuario


select * from curso
select * from Personagem
select * from usuario
delete from Usuario 
delete from Curso where id=5 or id=6
delete from Emprego
delete from CursoJogador
delete from emprego
delete from Personagem