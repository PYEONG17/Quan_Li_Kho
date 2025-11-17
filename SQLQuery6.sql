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
CREATE TABLE customers (
    id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NULL,
    product_id INT NULL,
    total_price INT NULL,
    amount DECIMAL(18,2) NULL,
    change_amount DECIMAL(18,2) NULL,
    order_date DATE NULL
);

select * from customers;