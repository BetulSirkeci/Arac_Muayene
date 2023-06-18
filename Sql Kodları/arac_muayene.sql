CREATE DATABASE arac_muayene;

USE arac_muayene;


CREATE TABLE sahip_bilgileri(
	sahip_TC	varchar(11)			primary key,
	ad			varchar(25)				not null,
	soyad		varchar(25)				not null,
	telefon		varchar(11)				not null,
	mail		varchar(25)		check (	mail like '%@gmail.com')not null,
	adres		varchar(50)				null,
);


CREATE TABLE sehir(
	sehir_id	int		primary key identity,
	ad			varchar(10)			not null
);


CREATE TABLE ilce(
	ilce_id		int		primary key identity,
	ilce_ad 			varchar(10)			not null,
	sehir_no	int					not null,

	foreign key (sehir_no) references sehir(sehir_id)
	  on delete cascade
      on update cascade
);


CREATE TABLE araclar(
	arac_plaka			varchar(9)				primary key,
	sahip_TC			varchar(11)					not null,
	marka				varchar(25)					not null,
	model				varchar(25)					not null,
	yil					varchar(4)					not null,
	ruhsat_no			varchar(25)					not null,

  foreign key (sahip_TC) references sahip_bilgileri(sahip_TC)
        on delete cascade
        on update cascade  
);


CREATE TABLE randevu(
	randevu_id			int		primary key		identity,
	sahip_TC			varchar(11)				not null,
	arac_plaka			varchar(9)				not null,
	randevu_saati		time					not null,
	randevu_tarih		date					not null,
	muayene_yer_il		int						not null,
	muayene_yer_ilce	int						not null,

	 foreign key (sahip_TC) references sahip_bilgileri(sahip_TC),

	 foreign key (arac_plaka) references araclar(arac_plaka),

	foreign key (muayene_yer_il) references sehir(sehir_id),
        
	foreign key (muayene_yer_ilce) references ilce(ilce_id)
        
);




