use master;

create database pop_cul_db;

use pop_cul_db;

drop table ad_post;

drop table item;

drop table account;

create table account 
(
	id int identity (0000,1) not null,
    account_id as ('A' + right(replicate('0', 5) + cast(id as varchar(5)), 5)) persisted primary key,
	username varchar(25) not null,
	password varchar(25) not null,
	first_name varchar(50),
	last_name varchar(50),
	city char(25) not null,
	province char(2) not null,
	postal_code char(6) not null,
	phone char(13),
	email varchar(50)
);


create table item
(
	id int identity (0000,1) not null,
    item_id as ('I' + right(replicate('0', 5) + cast(id as varchar(5)), 5)) persisted primary key,
	account_id varchar(6) foreign key references account(account_id),
	item_name varchar(50) not null,
	item_category varchar(12) not null,
	item_desc varchar(500) not null,
	item_img varchar(50),
	item_city char(25) not null,
	item_phone char(13),
	item_price decimal(6,2)
);

create table ad_post
(
	id int identity (0000,1) not null,
    ad_id as ('AD' + right(replicate('0', 6) + cast(id as varchar(5)), 6)) persisted,
	account_id varchar(6) foreign key references account(account_id),
	item_id varchar(6) foreign key references item(item_id),
	constraint pk_ad_post primary key (account_id, item_id),
	post_title varchar(50),
	post_date date,
	post_expiry date
);