Select * from categories;
select * from products;
create table orders (
	id int primary key identity (1,1),
	customer_id int null,
	product_id int null,
	product_name varchar(100) null,
	category varchar(100) null,
	quality int null,
	origin_price float null,
	total_price float null,
	order_date Date NULL,

);
alter table orders
add  customer_id int null;
select * from orders;
create table customers (
	id int primary key identity (1,1),
	customer_id int null,
	product_id int null,
	total_orders int null,
	amount float null,
	change float null,
	order_date Date NULL,
);
select * from customers;