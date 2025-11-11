create table categories (
	id int primary key identity (1,1),
	category varchar(100) null,
	date DATE NULL
	
);
Select * from categories;

create table products (
	id int primary key identity (1,1),
	product_id varchar(100) null,
	product_name varchar(100) null,
	category Varchar(100) null,
	price float null,
	stock int null,
	status varchar(50) null,
	img_path varchar(255) null,
	date_insert Date NULL,
	
);
Select * from products;