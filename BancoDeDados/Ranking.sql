create table Ranking
(
id int identity(1,1) primary key,
nickName varchar(25),
pontos int
)

select * from Ranking
insert into Ranking values('Vinschers',120111)
insert into Ranking values('Gabs123', 9929)
insert into Ranking values('Janies', 543322)

alter table Ranking add id int identity(1,1) primary key 

drop table Ranking