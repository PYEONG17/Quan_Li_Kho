alter table orders
add  customer_id int null
select * from orders
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