Create table customers (
	id INT PRIMARY KEY IDENTITY(1,1),
	customer_id int NULL,
	total_price float NULL,
	amount float NULL,
	change_amount float NULL,
	order_date DATE NULL
)
Select * from customers