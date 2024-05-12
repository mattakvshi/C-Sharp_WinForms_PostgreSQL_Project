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


-- Создание триггерной функции
CREATE OR REPLACE FUNCTION update_payment_status()
RETURNS TRIGGER AS
$$
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
$$
LANGUAGE plpgsql;

-- Создание триггера для таблицы Contracts
CREATE TRIGGER update_payment_status_trigger
BEFORE INSERT OR UPDATE ON Contracts
FOR EACH ROW
EXECUTE FUNCTION update_payment_status();