
-- Вставки в таблицу Clients
INSERT INTO Clients (client_name, phone) VALUES ('Иванов Иван', '+1234567890');
INSERT INTO Clients (client_name, phone) VALUES ('Петров Петр', '+0987654321');
INSERT INTO Clients (client_name, phone) VALUES ('Сидорова Анна', '+111222333');
INSERT INTO Clients (client_name, phone) VALUES ('Козлова Мария', '+777888999');
INSERT INTO Clients (client_name, phone) VALUES ('Николаев Николай', '+555666777');
INSERT INTO Clients (client_name, phone) VALUES ('Смирнова Елена', '+444333222');
INSERT INTO Clients (client_name, phone) VALUES ('Васильев Василий', '+222333444');
INSERT INTO Clients (client_name, phone) VALUES ('Кузнецова Ольга', '+123654789');
INSERT INTO Clients (client_name, phone) VALUES ('Попов Дмитрий', '+987123456');
INSERT INTO Clients (client_name, phone) VALUES ('Михайлов Алексей', '+456789123');

-- Вставки в таблицу Products
INSERT INTO Products (product_name, price) VALUES ('Ноутбук', 1500.00);
INSERT INTO Products (product_name, price) VALUES ('Смартфон', 800.00);
INSERT INTO Products (product_name, price) VALUES ('Наушники', 100.00);
INSERT INTO Products (product_name, price) VALUES ('Фотоаппарат', 1200.00);
INSERT INTO Products (product_name, price) VALUES ('Телевизор', 2000.00);

-- Вставки в таблицу Contracts
INSERT INTO Contracts (client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (1, '2024-05-01', 0.00, 0.00, 'не оплачено', 'не отгружено');
INSERT INTO Contracts (client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (2, '2024-05-02', 0.00, 0.00, 'не оплачено', 'не отгружено');
INSERT INTO Contracts (client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (3, '2024-05-03', 0.00, 0.00, 'не оплачено', 'не отгружено');
INSERT INTO Contracts (client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (4, '2024-05-04', 0.00, 0.00, 'не оплачено', 'не отгружено');
INSERT INTO Contracts (client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (5, '2024-05-05', 0.00, 0.00, 'не оплачено', 'не отгружено');


Update Contracts set shipment_status='отгружено' WHERE contract_id = 1;

-- Вставки в таблицу Contract_Products
INSERT INTO Contract_Products (contract_id, product_id, quantity) VALUES (1, 1, 2);
INSERT INTO Contract_Products (contract_id, product_id, quantity) VALUES (2, 2, 3);
INSERT INTO Contract_Products (contract_id, product_id, quantity) VALUES (3, 3, 5);
INSERT INTO Contract_Products (contract_id, product_id, quantity) VALUES (4, 4, 1);
INSERT INTO Contract_Products (contract_id, product_id, quantity) VALUES (5, 5, 2);



SELECT * FROM Clients;
SELECT * FROM Products;
SELECT * FROM Contracts;
SELECT * FROM Contract_Products;

