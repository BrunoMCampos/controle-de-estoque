CREATE DATABASE IF NOT EXISTS stock_control;

USE stock_control;

CREATE TABLE IF NOT EXISTS login (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	user VARCHAR(64) NOT NULL UNIQUE, 
	password VARCHAR(255) NOT NULL, 
    privileges VARCHAR(32) NOT NULL,
    reset_password BOOL NOT NULL DEFAULT FALSE);
    
INSERT 
	INTO login (user, password, privileges) 
	VALUES ('admin','$2a$12$BN1WBC3ys77AhCd2qZu8YejTcVIYwsZhEAdgP5OQar4YfnNWwMx.i','ADMINISTRATOR');
    
CREATE TABLE IF NOT EXISTS product (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(64) NOT NULL UNIQUE,
    description VARCHAR(255),
    cod VARCHAR (64),
    unit VARCHAR(25) NOT NULL,
    url_image VARCHAR(523));
    
CREATE TABLE IF NOT EXISTS stock (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	product_id INT NOT NULL,
    stock_amount DECIMAL(5,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (product_id) REFERENCES product (id) ON DELETE CASCADE);

CREATE TRIGGER 
	insert_product_stock 
AFTER INSERT ON product 
FOR EACH ROW 
	INSERT INTO stock (product_id, stock_amount) VALUES (NEW.id, 0);

INSERT INTO product (name, unit) VALUES ("teste", "PC");
INSERT INTO product (name, cod, unit) VALUES ("teste número 2", "CSF135", "M");

CREATE TABLE IF NOT EXISTS stock_update (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    stock_id INT NOT NULL,
    start_amount DECIMAL(5,2) NOT NULL,
    movement_type VARCHAR(10) NOT NULL,
    movement_amount DECIMAL(5,2) NOT NULL,
    end_amount DECIMAL(5,2) NOT NULL,
    reason VARCHAR(25) NOT NULL,
    justification VARCHAR (255),
    update_date_time DATETIME NOT NULL);
    
CREATE TRIGGER 
	update_stock
AFTER INSERT ON stock_update 
FOR EACH ROW 
	UPDATE stock SET stock_amount = NEW.end_amount WHERE id = NEW.stock_id;