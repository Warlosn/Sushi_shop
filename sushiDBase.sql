use master;
create database sushiDB;

use sushiDB;
Create table Products
( id_product int primary key,
product_name nvarchar(20) not null,
price money not null
);

create table Clients
( id_client int identity(1,1) primary key not null,
email nvarchar(40) not null,
firstname nvarchar(20) not null,
lastname nvarchar(20) not null,
adress nvarchar(20) not null,
phone_nubmer nvarchar(20) not null,
pasword nvarchar(20) not null
);


Create table Deliverymans
( id_deliveryman int primary key,
firstname nvarchar(20) not null,
phone_number int not null
);

Create table Orders
(
id_order int primary key,
id_client int foreign key references Clients(id_client),
id_product int foreign key references Products(id_product),
id_deliveryman int foreign key references Deliverymans(id_deliveryman),
price money
)
