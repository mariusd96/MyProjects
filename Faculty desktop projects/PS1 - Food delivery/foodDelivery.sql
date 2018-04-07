drop database if exists foodDelivery;

create database if not exists foodDelivery;
use foodDelivery;

create table if not exists Cont
(
    username varchar(32) not null,
    pass varchar(32) not null,
    rol char not null,
    
    primary key(username)
);

insert into Cont values 
('admin', 'admin', 'A'), 
('mariusd96', 'developer', 'C'),
('utcluj', 'PSLab', 'C'),
('bogdanC', 'pizza', 'C'),
('ricardo96', 'salad', 'C');

create table if not exists Client
(
	idClient int auto_increment,
    username varchar(32) not null,
    nume varchar(32) not null,
    prenume varchar(32) not null,
    cnp varchar(13) not null,
    adresaLivrare varchar(256) not null,
    nrTelefon varchar(10) not null,
    email varchar(64) not null,
    eClientLoial char not null,
    
    primary key(idClient),
    constraint cont_client foreign key(username) references Cont(username) on delete cascade on update cascade
);
insert into Client(username, nume, prenume, cnp, adresaLivrare, nrTelefon, email, eClientLoial) values
('mariusd96', 'Dulau', 'Marius', '1960730260062', 'Str. Observatorului 34, Camin 4', '0773329248', 'mariusdulau@yahoo.com', 'Y'),
('utcluj', 'UTCN', 'Calculatoare', '2930602260532', 'Str. George Baritiu nr. 26-28, ', '0264401219', 'mariusdulau@yahoo.com', 'N'),
('bogdanC', 'Costea', 'Bogdan', '1930122304953', 'Str. Observatorului 34, Camin 4', '0743565656', 'mariusdulau@yahoo.com', 'N'),
('ricardo96', 'Ardelean', 'Richard', '1920902057177', 'Str. Observatorului 34, Camin 7', '0770106978', 'mariudulau@yahoo.com', 'N');

create table if not exists CategoriiProdus
(
	categorie varchar(32) primary key
);
insert into CategoriiProdus values ('pizza'), ('salată'), ('paste');

create table if not exists Produs
(
	idProdus int auto_increment,
    categorie varchar(32) not null,
    nume varchar(64) not null,
    descriere varchar(2048),
    gramaj int not null,
    pret double not null,
    
    primary key(idProdus),
    constraint categorie_produs foreign key(categorie) references CategoriiProdus(categorie) on delete cascade on update cascade
);

insert into Produs(categorie, nume, descriere, gramaj, pret) values
('pizza', 'Pizza Chicken', 'sos pizza, oregano, mozzarella, piept de pui, smântână, usturoi, gogoșari', 700, 24.0),
('salată', 'Salată grecească', 'salată verde, ceapă roșie, roșii, ardei gras, castraveți, mărar, telemea, măsline, lămâie', 300, 15.0),
('pizza', 'Specialitatea Casei', 'sos pizza, oregano, mozzarella, carne tocată din piept de pui, ceapă, usturoi, gogoşari', 1900, 45.5),
('pizza', 'Pizza Salami', 'sos pizza, oregano, mozzarella, salam, ciuperci, măsline', 450, 18.5),
('pizza', 'Pizza Margherita', 'sos pizza, oregano, mozzarella, busuioc', 500, 10.5),
('salată', 'Comoara piratului', 'salată verde, roșii, ardei, porumb, piept de pui prăjit, cartofi prăjiti, sos de smântână cu maioneză, fâșii de foccacia', 350, 13.0),
('paste', 'Penne quattro formaggi', 'parmesan, gorgonzola, caşcaval afumat, mozzarella', 350, 19.5);

create table if not exists Comanda
(
	idComanda int auto_increment,
    idClient int not null,
    dataComanda datetime not null,
	pretTotal double not null,
    modalitatePlata varchar(32) not null,
    
    primary key(idComanda),
    constraint client_comanda foreign key(idClient) references Client(idClient) on delete cascade on update cascade
);

insert into Comanda(idClient, dataComanda, pretTotal, modalitatePlata) values
(1, '2018-03-19', 39.0, 'cash'),
(2, '2018-03-21', 44.5, 'cash');

create table if not exists DetaliiComanda
(
	idComanda int not null,
    numeProdus varchar(64) not null,
    pret double not null,
    cantitate int not null,
    
    foreign key(idComanda) references Comanda(idComanda) on delete cascade on update cascade
);

insert into DetaliiComanda values
(1, 'Pizza Chicken', 24.0, 1),
(1, 'Salată grecească', 15.0, 1),
(2, 'Pizza Salami', 18.5, 1),
(2, 'Comoara piratului', 13.0, 2);