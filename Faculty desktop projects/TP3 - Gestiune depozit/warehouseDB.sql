drop database if exists warehouseDB;
create database if not exists warehouseDB;
use warehouseDB;

create table if not exists Account
(
	username varchar(45) not null,
    pass varchar(45) not null,
    role char not null,
    primary key(username)
);

insert into Account(username, pass, role) values ("admin", "admin", 'A'), ("utcluj", "PT_Lic", 'U');

create table if not exists Customer
(
	customerId int auto_increment,
    username varchar(45) not null,
    firstName varchar(45) not null,
    lastName varchar(45) not null,
    age int,
    address varchar(256),
    email varchar(45),
    phoneNumber varchar(10),
    primary key(customerId),
    constraint userCustomer foreign key(username) references Account(username) on delete cascade on update cascade
);

insert into Customer(username, firstName, lastName, age, address, email, phoneNumber) values ("utcluj", "UTCluj", "PT", 30, "Str. George Baritiu nr. 26", "ptLic@cs.utcluj.ro", "0364123456");

create table if not exists Product
(
	productId int auto_increment,
    productName varchar(45) not null,
    price double not null,
    primary key(productId)
);

insert into Product(productName, price) values 
("Arduino MEGA 2560", 70),
("Arduino UNO R3", 40),
("LED rosu", 0.5),
("LCD 2x16", 20),
("Breadboard 830 contacte", 25),
("Cablu Dupont", 0.5),
("Senzor cu ultrasunete", 10),
("Modul Shield LCD", 35),
("LED RGB", 2.25);

create table if not exists Stock
(
	productId int not null,
    quantity int not null,
    constraint ProductStock foreign key(productId) references Product(productID) on delete cascade
);

insert into Stock(productId, quantity) values 
(1, 10),
(2, 15),
(3, 100),
(4, 20),
(5, 30),
(6, 100),
(7, 30),
(8, 14),
(9, 18);

create table if not exists Orders
(
	orderId int auto_increment,
    customerId int not null,
    orderDate date not null,
    totalPrice double not null,
    primary key(orderId),
    constraint customerOrder foreign key(customerId) references Customer(customerId) on delete cascade
);
alter table Orders modify orderDate datetime;

insert into Orders(customerId, orderDate, totalPrice) values(1, '2017-04-11', 72.5);

create table if not exists OrderDetail
(
	orderId int not null,
    productId int not null,
    price double not null,
    quantity int not null,
    foreign key(orderId) references Orders(orderId) on delete cascade,
    constraint productOrder foreign key(productId) references Product(productId) on delete cascade
);

insert into OrderDetail(orderId, productId, price, quantity) values (1, 1, 70, 1), (1, 3, 0.5, 5);