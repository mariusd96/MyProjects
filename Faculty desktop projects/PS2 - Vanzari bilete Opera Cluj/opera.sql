drop database if exists opera;

create database if not exists opera;
use opera;

create table if not exists administrator
(
	user_admin varchar(32) not null,
    pass_admin varchar(32) not null,
    
    primary key(user_admin)
);

insert into administrator values
('admin1', 'firns1'),
('adminOpera', 'bjqhtrj'),
('adminX', 'ufxx123btwi');

create table if not exists casier
(
	nume varchar(64) not null,
    username varchar(32) not null,
    parola varchar(32) not null,
    
    primary key(username)
);

insert into casier values 
('Pop Cosmin', 'pop.cosmin', 'ajwin'),
('Ionescu Andreea', 'andreea.ionescu', 'anafqin');

#create table if not exists genSpectacol
#(
#	gen varchar(32) not null primary key
#);

#insert into genSpectacol values ('operă'), ('operetă'), ('balet');

create table if not exists spectacol
(
	idSpectacol int not null auto_increment,
	gen varchar(32) not null,
    titlu varchar(128) not null,
    regia varchar(128) not null,
    data_premiere datetime not null,
    numar_bilete int not null,
    
    primary key(idSpectacol)
    
    #constraint gen_spectacol foreign key(gen) references genSpectacol(gen) on delete cascade on update cascade
);

insert into spectacol(gen, titlu, regia, data_premiere, numar_bilete) values
('Operă', 'AIDA', 'Anghel Arbore', '2018-05-14 18:30:00', 200),
('Operă', 'Bărbierul din Sevilla', 'Emil Strugaru', '2018-04-27 19:00:00', 100),
('Operetă', 'Fata babei și fata moșului', 'Iulian Ioan Sandu', '2018-09-16 18:00:00', 5),
('Balet', 'Anotimpurile', 'Vasile Solomon', '2018-09-16 18:00:00', 50);

create table if not exists distributie_Opera_Opereta
(
	idActorOp int not null auto_increment,
	idSpectacol int not null,
    nume_actor varchar(64) not null,
    rol_actor varchar(64) not null,
    
    primary key(idActorOp),
    
    constraint distributie_spectacol foreign key(idSpectacol) references spectacol(idSpectacol) on delete cascade on update cascade
);

insert into distributie_Opera_Opereta(idSpectacol, nume_actor, rol_actor) values
(1, 'Carmen Gurban', 'Aida'),
(1, 'Sorin Lupu', 'Radames'),
(1, 'Andrada Ioana Roșu', 'Amneris'),
(1, 'Gelu Dobrea', 'Amonasro'),
(2, 'Geani Brad', 'Figaro'),
(2, 'Cristian Hodrea', 'Don Bartolo'),
(2, 'Adriana Feșteu', 'Rosina'),
(3, 'Anca Aluaș', 'Fata babei'),
(3, 'Oana Trîmbițaș', 'Fata moșului');

create table if not exists distributie_Balet
(
	idActorBalet int not null auto_increment,
	idSpectacol int not null,
    nume_actor varchar(64) not null,
    
    primary key(idActorBalet),
    
    constraint distributie_balet foreign key(idSpectacol) references spectacol(idSpectacol) on delete cascade on update cascade
);

insert into distributie_Balet(idSpectacol, nume_actor) values
(4, 'Andreea Jura'),
(4, 'Roxana Cociș'),
(4, 'Diana Groza');

create table if not exists bilet
(
	idBilet int not null auto_increment,
	idSpectacol int not null,
    rand int not null,
    coloana int not null,
    
    primary key(idBilet),
    
    constraint bilet_spectacol foreign key(idSpectacol) references spectacol(idSpectacol) on delete cascade on update cascade
);

insert into bilet(idSpectacol, rand, coloana) values
(1, 1, 1),
(1, 1, 2),
(1, 1, 5),
(1, 2, 1),
(2, 1, 1),
(3, 1, 1),
(3, 2, 2);