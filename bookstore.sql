create table category
(
	cat_ID int NOT NULL AUTO_INCREMENT,
	name varchar(255) NOT NULL,
	PRIMARY KEY pk_cat (cat_ID)
)

create table product
(
    	pd_ID int NOT NULL AUTO_INCREMENT,
    	cat_ID int NOT NULL,
    	title varchar2(255),
    	price int,
    	thumbnail varchar(255),
	discount int,
	des longtext,
	created_at datetime,
	updated_at datetime,
	quantity int,
    	PRIMARY KEY pk_pd (pd_ID),
	FOREIGN KEY fk_pd_cat (cat_ID) REFERENCES category(cat_ID)
)

create table `user`
(
	user_ID int NOT NULL AUTO_INCREMENT,
	fullname varchar(255),
	username varchar(255),
	password varchar(255),
	email varchar(255),
	address varchar(255),
	phone varchar(255),
	role int,
	PRIMARY KEY pk_user (user_ID)
)
INSERT INTO `user` (`fullname`, `username`, `password`, `email`, `phone`, `address`, `role`) VALUES
('Nguyễn Thanh Tú', 'admin', 'admin','thanhtu101102@gmail.com', '0358461911', 'Quận 12', 0),
('Lê Vinh', 'khach', 'khach','levinh@gamil.com', '0345678912', 'Thủ Đức', 1);
create table `order`
(
	od_ID int NOT NULL AUTO_INCREMENT,
	user_ID int NOT NULL,
	fullname varchar(100),
	email varchar(100),
	phone varchar(100),
	address varchar(255),
	order_date datetime,
	status varchar(30),
	PRIMARY KEY pk_od (od_ID),
	FOREIGN KEY fk_od_user (user_ID) REFERENCES user(user_ID)
)

create table order_detail
(
	dt_ID int NOT NULL PRIMARY KEY AUTO_INCREMENT,
	pd_ID int,
	od_id int,
	quantity int,
	price int,
	FOREIGN KEY fk_oddt_pd (pd_ID) REFERENCES product(pd_ID),
	FOREIGN KEY fk_oddt_od (od_ID) REFERENCES `order`(od_ID)
)




