--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4
-- Dumped by pg_dump version 15.4

-- Started on 2024-05-12 20:27:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 222 (class 1255 OID 24737)
-- Name: calculate_total_price(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.calculate_total_price() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Расчет total_price перед вставкой новых данных в таблицу Contract_Products
    NEW.total_price := (SELECT price FROM Products WHERE product_id = NEW.product_id) * NEW.quantity;
    
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.calculate_total_price() OWNER TO postgres;

--
-- TOC entry 224 (class 1255 OID 24743)
-- Name: update_payment_status(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_payment_status() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER FUNCTION public.update_payment_status() OWNER TO postgres;

--
-- TOC entry 223 (class 1255 OID 24739)
-- Name: update_total_amount(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_total_amount() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Обновление total_amount в таблице Contracts при вставке новых данных в Contract_Products
    UPDATE Contracts
    SET total_amount = total_amount + NEW.total_price
    WHERE Contracts.contract_id = NEW.contract_id;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.update_total_amount() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 24691)
-- Name: clients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clients (
    client_id integer NOT NULL,
    client_name character varying(300) NOT NULL,
    phone character varying(30) NOT NULL
);


ALTER TABLE public.clients OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 24690)
-- Name: clients_client_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clients_client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.clients_client_id_seq OWNER TO postgres;

--
-- TOC entry 3369 (class 0 OID 0)
-- Dependencies: 214
-- Name: clients_client_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clients_client_id_seq OWNED BY public.clients.client_id;


--
-- TOC entry 221 (class 1259 OID 24719)
-- Name: contract_products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contract_products (
    contract_product_id integer NOT NULL,
    contract_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    total_price numeric(12,4)
);


ALTER TABLE public.contract_products OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 24718)
-- Name: contract_products_contract_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contract_products_contract_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contract_products_contract_product_id_seq OWNER TO postgres;

--
-- TOC entry 3370 (class 0 OID 0)
-- Dependencies: 220
-- Name: contract_products_contract_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contract_products_contract_product_id_seq OWNED BY public.contract_products.contract_product_id;


--
-- TOC entry 219 (class 1259 OID 24705)
-- Name: contracts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contracts (
    contract_id integer NOT NULL,
    client_id integer NOT NULL,
    date_signed date NOT NULL,
    total_amount numeric(12,4) NOT NULL,
    advance_payment numeric(12,4),
    payment_status character varying(30) DEFAULT 'не оплачено'::character varying NOT NULL,
    shipment_status character varying(30) DEFAULT 'не отгружено'::character varying NOT NULL,
    prepayment numeric(12,4) GENERATED ALWAYS AS ((total_amount * 0.3)) STORED,
    CONSTRAINT contracts_payment_status_check CHECK (((payment_status)::text = ANY ((ARRAY['не оплачено'::character varying, 'предоплата'::character varying, 'оплачено'::character varying])::text[]))),
    CONSTRAINT contracts_shipment_status_check CHECK (((shipment_status)::text = ANY ((ARRAY['не отгружено'::character varying, 'отгружено'::character varying])::text[])))
);


ALTER TABLE public.contracts OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 24704)
-- Name: contracts_contract_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contracts_contract_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contracts_contract_id_seq OWNER TO postgres;

--
-- TOC entry 3371 (class 0 OID 0)
-- Dependencies: 218
-- Name: contracts_contract_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contracts_contract_id_seq OWNED BY public.contracts.contract_id;


--
-- TOC entry 217 (class 1259 OID 24698)
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_name character varying(300) NOT NULL,
    price numeric(10,2) NOT NULL
);


ALTER TABLE public.products OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 24697)
-- Name: products_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.products_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.products_product_id_seq OWNER TO postgres;

--
-- TOC entry 3372 (class 0 OID 0)
-- Dependencies: 216
-- Name: products_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.products_product_id_seq OWNED BY public.products.product_id;


--
-- TOC entry 3191 (class 2604 OID 24694)
-- Name: clients client_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients ALTER COLUMN client_id SET DEFAULT nextval('public.clients_client_id_seq'::regclass);


--
-- TOC entry 3197 (class 2604 OID 24722)
-- Name: contract_products contract_product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_products ALTER COLUMN contract_product_id SET DEFAULT nextval('public.contract_products_contract_product_id_seq'::regclass);


--
-- TOC entry 3193 (class 2604 OID 24708)
-- Name: contracts contract_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contracts ALTER COLUMN contract_id SET DEFAULT nextval('public.contracts_contract_id_seq'::regclass);


--
-- TOC entry 3192 (class 2604 OID 24701)
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- TOC entry 3357 (class 0 OID 24691)
-- Dependencies: 215
-- Data for Name: clients; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.clients (client_id, client_name, phone) VALUES (1, 'Иванов Иван', '+1234567890');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (2, 'Петров Петр', '+0987654321');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (3, 'Сидорова Анна', '+111222333');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (4, 'Козлова Мария', '+777888999');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (5, 'Николаев Николай', '+555666777');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (6, 'Смирнова Елена', '+444333222');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (7, 'Васильев Василий', '+222333444');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (8, 'Кузнецова Ольга', '+123654789');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (9, 'Попов Дмитрий', '+987123456');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (10, 'Михайлов Алексей', '+456789123');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (13, 'Сидоренко Максим', '+79182842848');
INSERT INTO public.clients (client_id, client_name, phone) VALUES (14, 'Demi Murych', '+79990007799');


--
-- TOC entry 3363 (class 0 OID 24719)
-- Dependencies: 221
-- Data for Name: contract_products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (1, 1, 1, 2, 3000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (2, 2, 2, 3, 2400.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (3, 3, 3, 5, 500.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (4, 4, 4, 1, 1200.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (5, 5, 5, 2, 4000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (6, 8, 6, 55, 55000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (7, 8, 1, 101, 150000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (9, 9, 3, 45, 4500.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (10, 9, 5, 100, 200000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (11, 10, 5, 1, 2000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (12, 11, 2, 3, 2400.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (13, 11, 4, 1, 1200.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (14, 11, 1, 1, 1500.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (15, 11, 5, 1, 2000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (16, 11, 3, 2, 200.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (17, 12, 6, 10, 10000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (18, 12, 1, 12, 18000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (19, 13, 8, 2, 1400.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (20, 13, 9, 3, 1200.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (21, 13, 10, 1, 2000.0000);
INSERT INTO public.contract_products (contract_product_id, contract_id, product_id, quantity, total_price) VALUES (23, 15, 11, 1, 700.0000);


--
-- TOC entry 3361 (class 0 OID 24705)
-- Dependencies: 219
-- Data for Name: contracts; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (2, 2, '2024-05-02', 2400.0000, 1000.0000, 'не оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (4, 4, '2024-05-04', 1200.0000, 3500.0000, 'не оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (5, 5, '2024-05-05', 4000.0000, 1500.0000, 'не оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (3, 3, '2024-05-03', 500.0000, 500.0000, 'оплачено', 'отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (8, 10, '2024-05-09', 207000.0000, 47567777.0000, 'оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (9, 8, '2024-05-10', 204500.0000, 4555.0000, 'не оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (1, 1, '2024-05-01', 3000.0000, 2000.0000, 'предоплата', 'отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (10, 9, '2024-05-12', 2000.0000, 0.0000, 'не оплачено', 'отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (11, 7, '2024-05-10', 7300.0000, 330040.0000, 'оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (12, 6, '2024-05-04', 28000.0000, 50000.0000, 'оплачено', 'не отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (13, 13, '2024-05-08', 4600.0000, 1000.0000, 'не оплачено', 'отгружено');
INSERT INTO public.contracts (contract_id, client_id, date_signed, total_amount, advance_payment, payment_status, shipment_status) VALUES (15, 14, '2024-05-04', 700.0000, 0.0001, 'не оплачено', 'отгружено');


--
-- TOC entry 3359 (class 0 OID 24698)
-- Dependencies: 217
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.products (product_id, product_name, price) VALUES (1, 'Ноутбук', 1500.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (2, 'Смартфон', 800.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (3, 'Наушники', 100.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (4, 'Фотоаппарат', 1200.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (5, 'Телевизор', 2000.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (6, 'Монитор', 1000.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (8, 'Клавиатура', 700.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (9, 'Компьютерная мышь', 400.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (10, 'Электро-самокат', 2000.00);
INSERT INTO public.products (product_id, product_name, price) VALUES (11, 'ES5-Справочник', 700.00);


--
-- TOC entry 3373 (class 0 OID 0)
-- Dependencies: 214
-- Name: clients_client_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clients_client_id_seq', 14, true);


--
-- TOC entry 3374 (class 0 OID 0)
-- Dependencies: 220
-- Name: contract_products_contract_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_products_contract_product_id_seq', 23, true);


--
-- TOC entry 3375 (class 0 OID 0)
-- Dependencies: 218
-- Name: contracts_contract_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contracts_contract_id_seq', 15, true);


--
-- TOC entry 3376 (class 0 OID 0)
-- Dependencies: 216
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_product_id_seq', 11, true);


--
-- TOC entry 3201 (class 2606 OID 24696)
-- Name: clients clients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clients
    ADD CONSTRAINT clients_pkey PRIMARY KEY (client_id);


--
-- TOC entry 3207 (class 2606 OID 24724)
-- Name: contract_products contract_products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_products
    ADD CONSTRAINT contract_products_pkey PRIMARY KEY (contract_product_id);


--
-- TOC entry 3205 (class 2606 OID 24712)
-- Name: contracts contracts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contracts
    ADD CONSTRAINT contracts_pkey PRIMARY KEY (contract_id);


--
-- TOC entry 3203 (class 2606 OID 24703)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- TOC entry 3212 (class 2620 OID 24738)
-- Name: contract_products calculate_total_price_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER calculate_total_price_trigger BEFORE INSERT ON public.contract_products FOR EACH ROW EXECUTE FUNCTION public.calculate_total_price();


--
-- TOC entry 3211 (class 2620 OID 24744)
-- Name: contracts update_payment_status_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER update_payment_status_trigger BEFORE INSERT OR UPDATE ON public.contracts FOR EACH ROW EXECUTE FUNCTION public.update_payment_status();


--
-- TOC entry 3213 (class 2620 OID 24740)
-- Name: contract_products update_total_amount_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER update_total_amount_trigger AFTER INSERT ON public.contract_products FOR EACH ROW EXECUTE FUNCTION public.update_total_amount();


--
-- TOC entry 3209 (class 2606 OID 24725)
-- Name: contract_products contract_products_contract_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_products
    ADD CONSTRAINT contract_products_contract_id_fk FOREIGN KEY (contract_id) REFERENCES public.contracts(contract_id) ON DELETE CASCADE;


--
-- TOC entry 3210 (class 2606 OID 24730)
-- Name: contract_products contract_products_product_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_products
    ADD CONSTRAINT contract_products_product_id_fk FOREIGN KEY (product_id) REFERENCES public.products(product_id) ON DELETE CASCADE;


--
-- TOC entry 3208 (class 2606 OID 24713)
-- Name: contracts contracts_client_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contracts
    ADD CONSTRAINT contracts_client_id_fk FOREIGN KEY (client_id) REFERENCES public.clients(client_id) ON DELETE CASCADE;


-- Completed on 2024-05-12 20:27:45

--
-- PostgreSQL database dump complete
--

