Select * from categories;
select * from products;
create table orders (
	id int primary key identity (1,1),
	customer_id int null,
	product_id varchar(max) null,
	product_name varchar(100) null,
	category varchar(100) null,
	quality int null,
	origin_price float null,
	total_price float null,
	order_date Date NULL,

);select * from orders
CREATE TABLE customers (
    id INT PRIMARY KEY IDENTITY(1,1),
    customer_id int NULL,
    product_id varchar (Max) NULL,
    total_price float NULL,
    amount float NULL,
    change_amount float NULL,
    order_date DATE NULL
)

select * from customers
alter table customers
drop column product_id

