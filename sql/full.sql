CREATE DATABASE IF NOT EXISTS controle_de_estoque;

USE controle_de_estoque;

CREATE TABLE IF NOT EXISTS login (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	user VARCHAR(64) NOT NULL UNIQUE, 
	password VARCHAR(255) NOT NULL, 
    privileges VARCHAR(32) NOT NULL);
    
INSERT 
	INTO login (user, password, privileges) 
	VALUES ('admin','$2a$12$BN1WBC3ys77AhCd2qZu8YejTcVIYwsZhEAdgP5OQar4YfnNWwMx.i','ADMINISTRATOR');
    
CREATE TABLE IF NOT EXISTS produto (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(64) NOT NULL UNIQUE,
    descricao VARCHAR(255),
    codigo VARCHAR (64),
    unidade VARCHAR(25) NOT NULL,
    url_imagem VARCHAR(523));
    
CREATE TABLE IF NOT EXISTS estoque (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	produto_id INT NOT NULL,
    quantidade_estoque DECIMAL(5,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (produto_id) REFERENCES produto (id) ON DELETE CASCADE);

CREATE TRIGGER 
	insert_produto_estoque 
AFTER INSERT ON produto 
FOR EACH ROW 
	INSERT INTO estoque (produto_id, quantidade_estoque) VALUES (NEW.id, 0);

INSERT INTO produto (nome, unidade) VALUES ("teste", "PC");
INSERT INTO produto (nome, codigo, unidade) VALUES ("teste número 2", "CSF135", "M");

CREATE TABLE IF NOT EXISTS alteracao_estoque (
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    estoque_id INT NOT NULL,
    saldo_inicial DECIMAL(5,2) NOT NULL,
    movimentacao VARCHAR(10) NOT NULL,
    quantidade_movimentada DECIMAL(5,2) NOT NULL,
    saldo_final DECIMAL(5,2) NOT NULL,
    motivo VARCHAR(25) NOT NULL,
    justificativa VARCHAR (255));
    
CREATE TRIGGER 
	alterar_estoque
AFTER INSERT ON alteracao_estoque 
FOR EACH ROW 
	UPDATE estoque SET quantidade_estoque = NEW.saldo_final WHERE id = NEW.estoque_id;