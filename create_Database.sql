use master;
create database sushiDB;

use sushiDB;

--drop table category;
--drop table Clients;

create table category
(
category_id int  primary key identity(1,1),
category_name nvarchar(20)
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

Create table Products
( id_product int primary key identity(1,1),
product_name nvarchar(20) not null,
product_image varbinary(max),
price float not null,
category_id int
constraint FK_category_Products foreign key references category(category_id)
);






Create table Orders
(
id_order int primary key,
order_client_id int  constraint FK_order_client foreign  key references Clients(id_client),
all_price float
)

create table comments
(
Comment_id int primary key,
Comment_product_id int constraint FK_com_det_product foreign key references Products(id_product),
Comment_user_id int,
comment varchar(100)
);

create table order_details(
details_id int primary key,
detail_order_id int constraint FK_ord_det_orders foreign key references Orders(id_order),
details_product_id int constraint FK_ord_det_product foreign key references Products(id_product)
)