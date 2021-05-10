use master;
create database Coursework;
use Coursework;
Create table Products
( id_product int primary key,
product_name nvarchar(20) not null,
price money not null
);
Create table Client
( id_client int primary key,
firstname nvarchar(20) not null,
lastname nvarchar(20) not null,
phone_nubmer int not null,
adress nvarchar(20)
);

Create table Deliveryman
( id_deliveryman int primary key,
firstname nvarchar(20) not null,
phone_number int not null
);

Create table Orders
(
id_order int primary key,
client int foreign key references Client(id_client),
product int foreign key references Products(id_product),
deliveryman int foreign key references Deliveryman(id_deliveryman)
)

