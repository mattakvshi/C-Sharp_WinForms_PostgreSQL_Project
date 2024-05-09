CREATE TABLE Clients (
    client_id SERIAL PRIMARY KEY,
    client_name VARCHAR(300) NOT NULL,
    phone VARCHAR(30) NOT NULL
);

CREATE TABLE Products (
    product_id SERIAL PRIMARY KEY,
    product_name VARCHAR(300) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Contracts (
    contract_id SERIAL PRIMARY KEY,
    client_id INTEGER NOT NULL,
    date_signed DATE NOT NULL,
    total_amount DECIMAL(12, 4),
    advance_payment DECIMAL(12, 4),
    payment_status VARCHAR(30) NOT NULL CHECK (payment_status IN ('не оплачено', 'предоплата', 'оплачено')),
    shipment_status VARCHAR(30) NOT NULL CHECK (shipment_status IN ('не отгружено', 'отгружено')),
	
	
	CONSTRAINT contracts_client_id_fk FOREIGN KEY (client_id) REFERENCES Clients (client_id) ON DELETE CASCADE
);


-- Добавление значения по умолчанию к полю payment_status
ALTER TABLE Contracts
ALTER COLUMN payment_status SET DEFAULT 'не оплачено';

-- Добавление значения по умолчанию к полю shipment_status
ALTER TABLE Contracts
ALTER COLUMN shipment_status SET DEFAULT 'не отгружено';

-- Добавление вычисляемого поля prepayment к таблице Contracts
ALTER TABLE Contracts
ADD COLUMN prepayment DECIMAL(12, 4) GENERATED ALWAYS AS (total_amount * 0.3) STORED;

-- Изменение столбца total_amount, чтобы он был не NULL
ALTER TABLE Contracts
ALTER COLUMN total_amount SET NOT NULL;

CREATE TABLE Contract_Products (
    contract_product_id SERIAL PRIMARY KEY,
    contract_id INTEGER NOT NULL,
    product_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    total_price DECIMAL(12, 4),
	
	CONSTRAINT Contract_Products_contract_id_fk FOREIGN KEY (contract_id) REFERENCES Contracts (contract_id) ON DELETE CASCADE,
	CONSTRAINT Contract_Products_product_id_fk FOREIGN KEY (product_id) REFERENCES Products (product_id) ON DELETE CASCADE
);


-- Создание триггерной функции
CREATE OR REPLACE FUNCTION calculate_total_price()
RETURNS TRIGGER AS $$
BEGIN
    -- Расчет total_price перед вставкой новых данных в таблицу Contract_Products
    NEW.total_price := (SELECT price FROM Products WHERE product_id = NEW.product_id) * NEW.quantity;
    
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Создание триггера для вызова функции перед вставкой новых данных в Contract_Products
CREATE TRIGGER calculate_total_price_trigger
BEFORE INSERT ON Contract_Products
FOR EACH ROW
EXECUTE FUNCTION calculate_total_price();




-- Создание триггерной функции
CREATE OR REPLACE FUNCTION update_total_amount()
RETURNS TRIGGER AS $$
BEGIN
    -- Обновление total_amount в таблице Contracts при вставке новых данных в Contract_Products
    UPDATE Contracts
    SET total_amount = total_amount + NEW.total_price
    WHERE Contracts.contract_id = NEW.contract_id;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Создание триггера для вызова функции при вставке новых данных в Contract_Products
CREATE TRIGGER update_total_amount_trigger
AFTER INSERT ON Contract_Products
FOR EACH ROW
EXECUTE FUNCTION update_total_amount();



-- Trigger: update_payment_status_trigger

-- DROP TRIGGER IF EXISTS update_payment_status_trigger ON public.contracts;

CREATE OR REPLACE TRIGGER update_payment_status_trigger
    BEFORE INSERT OR UPDATE 
    ON public.contracts
    FOR EACH ROW
    EXECUTE FUNCTION public.update_payment_status();


-- FUNCTION: public.update_payment_status()

-- DROP FUNCTION IF EXISTS public.update_payment_status();

CREATE OR REPLACE FUNCTION public.update_payment_status()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
BEGIN
    IF NEW.advance_payment >= NEW.total_amount THEN
        NEW.payment_status = 'оплачено';
    ELSIF NEW.advance_payment < 0.3 * NEW.total_amount THEN
        NEW.payment_status = 'не оплачено';
    ELSE
        NEW.payment_status = 'предоплата';
    END IF;
    
    RETURN NEW;
END;
$BODY$;

ALTER FUNCTION public.update_payment_status()
    OWNER TO postgres;






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


SELECT 
    c.contract_id,
    cl.client_name,
    c.date_signed,
    string_agg(p.product_name || ' - ' || cp.quantity::text, ', ') AS product_details,
    c.total_amount,
    c.prepayment,
    c.advance_payment,
    c.payment_status,
    c.shipment_status
FROM 
    Contracts c
JOIN 
    Clients cl ON c.client_id = cl.client_id
JOIN 
    Contract_Products cp ON c.contract_id = cp.contract_id
JOIN 
    Products p ON cp.product_id = p.product_id
GROUP BY 
    c.contract_id, cl.client_name, c.date_signed, c.total_amount, c.prepayment, c.advance_payment, c.payment_status, c.shipment_status
ORDER BY 
    c.contract_id;

