-----------------------------
-----------Kategorija-------

create proc ReadCategory
@IDKategorija int
as 
 select IDKategorija,Naziv FROM Kategorija
 where IDKategorija = @IDKategorija
go

create proc ReadCategories
as 
 select * FROM Kategorija
go

create proc CreateKategorija
@Naziv nvarchar(50),
@IDKategorija int out
as
	insert into Kategorija values (@Naziv)
	set @IDKategorija = SCOPE_IDENTITY();
go

create proc DeleteKategorija
@IDKategorija int
as
	delete from Stavka where ProizvodID IN (select IDProizvod from Proizvod 
													inner join  Potkategorija on Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija 
													where Potkategorija.KategorijaID = @IDKategorija)
	delete from Proizvod where IDProizvod IN  (select IDProizvod from Proizvod 
													inner join  Potkategorija on Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija 
													where Potkategorija.KategorijaID = @IDKategorija)
	delete from Potkategorija where KategorijaID = @IDKategorija
	
	delete from Kategorija where IDKategorija = @IDKategorija
go

create proc UpdateCategory
@Naziv nvarchar(50),
@IDKategorija int
as
	update Kategorija  
	set 
		Naziv = @Naziv
		where IDKategorija = @IDKategorija
go
-----------------------------
---------Potkategorija-------

create proc ReadSubcategory
@IDPotkategorija int
as 
	select p.IDPotkategorija, p.Naziv, Kategorija.Naziv as Kategorija, Kategorija.IDKategorija as IDKategorija FROM Potkategorija as p
	inner join Kategorija on p.KategorijaID = Kategorija.IDKategorija
	where IDPotkategorija = @IDPotkategorija
 go

create proc ReadSubcategories
as 
	select p.IDPotkategorija, p.Naziv, Kategorija.Naziv as Kategorija, Kategorija.IDKategorija as IDKategorija FROM Potkategorija as p
	inner join Kategorija on p.KategorijaID = Kategorija.IDKategorija
go

create proc CreatePotkategorija
@Naziv nvarchar(50),
@KategorijaID int,
@IDPotkategorija int out
as
	insert into Potkategorija values (@KategorijaID, @Naziv)
	set @IDPotkategorija = SCOPE_IDENTITY();
go

create proc DeletePotkategorija
@IDPotkategorija int 
as

	delete from Stavka where ProizvodID IN (select IDProizvod from Proizvod where PotkategorijaID = @IDPotkategorija)
	delete from Proizvod where IDProizvod IN  (select IDProizvod from Proizvod where PotkategorijaID = @IDPotkategorija)
	delete from Potkategorija where IDPotkategorija = @IDPotkategorija
go

create proc UpdateSubcategory
@Naziv nvarchar(50),
@KategorijaID int,
@IDPotkategorija int
as
	update Potkategorija  
	set 
		Naziv = @Naziv,
		KategorijaID = @KategorijaID
		where IDPotkategorija = @IDPotkategorija
go

-----------------------------
-----------Proizvod----------

create proc ReadProduct
	@IDProizvod int
as
	select IDProizvod as IDProizvod, IDPotkategorija as PotkategorijaID,Proizvod.Naziv, BrojProizvoda, Boja, cast(MinimalnaKolicinaNaSkladistu as int) as MinimalnaKolicinaNaSkladistu, cast(CijenaBezPDV as int) as CijenaBezPDV, Potkategorija.Naziv as Potkategorija from Proizvod
	left join Potkategorija on Proizvod.PotkategorijaID=Potkategorija.IDPotkategorija
	where IDProizvod=@IDProizvod
go

create proc ReadAllProducts
as
begin
	select IDProizvod as IDProizvod, IDPotkategorija as PotkategorijaID,Proizvod.Naziv, BrojProizvoda, Boja, cast(MinimalnaKolicinaNaSkladistu as int) as MinimalnaKolicinaNaSkladistu, cast(CijenaBezPDV as int) as CijenaBezPDV, Potkategorija.Naziv as Potkategorija from Proizvod
	left join Potkategorija on Proizvod.PotkategorijaID=Potkategorija.IDPotkategorija
end
go

create proc CreateProizvod
@Naziv nvarchar(50),
@BrojProizvoda nvarchar(25),
@Boja nvarchar(50),
@MinimalnaKolicinaNaSkladistu smallint,
@CijenaBezPDV money,
@PotkategorijaID int,
@IDProizvod int out
as
	insert into Proizvod values (@Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicinaNaSkladistu, @CijenaBezPDV, @PotkategorijaID)
	set @IDProizvod = SCOPE_IDENTITY();
go

create proc DeleteProizvod
@IDProizvod int 
as
	delete from Stavka where ProizvodID = @IDProizvod
	delete from Proizvod where IDProizvod = @IDProizvod
go

create proc UpdateProduct
@Naziv nvarchar(50),
@BrojProizvoda nvarchar(25),
@Boja nvarchar(50),
@MinimalnaKolicinaNaSkladistu smallint,
@CijenaBezPDV money,
@PotkategorijaID int,
@IDProizvod int 
as
	update Proizvod  
	set 
		Naziv = @Naziv,
		@BrojProizvoda = @BrojProizvoda,
		Boja = @Boja,
		MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu,
		CijenaBezPDV = @CijenaBezPDV,
		PotkategorijaID = @PotkategorijaID
		where IDProizvod = @IDProizvod
go

-----------------------------
-----------Kupac-------------

create proc GetAllClients
as
begin
	select top 100 IDKupac,Ime,Prezime, Email,Telefon,Grad.Naziv as Grad, Drzava.Naziv as Drzava from Kupac
	inner join Grad on Kupac.GradID=Grad.IDGrad
	inner join Drzava on Grad.DrzavaID=Drzava.IDDrzava
end
go

create proc GetClient
	@IDClient int
as
begin
	select k.*, g.Naziv as Grad, d.Naziv as Drzava from Kupac as k
	inner join Grad as g on k.GradID = g.IDGrad
	inner join Drzava as d on g.DrzavaID = d.IDDrzava
	where k.IDKupac = @IDClient
end
go

create proc GetClientsByCity
	@IDGrad int
as
begin
	select top 50 k.*, g.Naziv as Grad, d.Naziv as Drzava from Kupac as k
    inner join Grad as g on k.GradID = g.IDGrad
    inner join Drzava as d on g.DrzavaID = d.IDDrzava
    where g.IDGrad = @IDGrad
end
go

create proc UpdateClient
	@IDKupac int,
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(50),
@GradID int
as
	Update kupac
    set 
        Ime = @Ime,
        Prezime = @Prezime,
        Email = @Email,
        Telefon = @Telefon,
        GradID = @GradID
    where 
        IDKupac = @IDKupac
go

-----------------------------
--------Drzava/grad----------

create proc GetCountries
as
begin
    select * from Drzava
end
go

create proc GetCountryCity
	@IDDrzava int
as
    select Grad.* from Grad
    inner join Drzava as d on DrzavaID = IDDrzava
    where IDDrzava = @IDDrzava
go
use AdventureWorksOBP2
-----------------------------
--------Komercijalist--------

create proc ReadCommercialist
@IDRacun int
as
    select  k.* from Komercijalist as k
    inner join Racun as r on k.IDKomercijalist = r.KomercijalistID
    where r.IDRacun = @IDRacun
go

create proc CountCommercialists
@IDRacun int
as
	select count(*) from Komercijalist as k
	inner join Racun as r on k.IDKomercijalist = r.KomercijalistID
    where r.IDRacun = @IDRacun
go
-----------------------------
-----Kreditna kartica--------

create proc ReadCreditCard
@IDRacun int
as
    select  k.IDKreditnaKartica, k.Tip, k.Broj, cast(k.IstekMjesec as int) as IstekMjesec, cast(k.IstekGodina as int) as IstekGodina  from KreditnaKartica as k
    inner join Racun as r on k.IDKreditnaKartica = r.KreditnaKarticaID
    where r.IDRacun = @IDRacun
go

create proc CountCreditCards
@IDRacun int
as
	select count(*) from KreditnaKartica as k
	inner join Racun as r on k.IDKreditnaKartica = r.KreditnaKarticaID
    where r.IDRacun = @IDRacun
go
-----------------------------
------------Racun------------

create proc ReadReceipt
@IDKupac int
as
    select IDRacun,DatumIzdavanja,
	BrojRacuna, Komentar,
	Broj,Ime +' '+Prezime as PunoIme,
	Stavka.UkupnaCijena as Cijena,
	Proizvod.Naziv as Proizvod,
	Potkategorija.Naziv as Potkategorija,
	Kategorija.Naziv as Kategorija
	from Racun
	left join Stavka on Stavka.RacunID=Racun.IDRacun
	left join Proizvod on Stavka.ProizvodID=Proizvod.IDProizvod
	left join Potkategorija on Proizvod.PotkategorijaID=Potkategorija.IDPotkategorija
	left join Kategorija on Potkategorija.KategorijaID=Kategorija.IDKategorija
	left join Komercijalist on Racun.KomercijalistID=Komercijalist.IDKomercijalist
	left join KreditnaKartica on Racun.KreditnaKarticaID=KreditnaKartica.IDKreditnaKartica 
    where KupacID = @IDKupac
go

create proc ReadReceiptDetails
@IDReceipt int
as
    select IDRacun,DatumIzdavanja, BrojRacuna, Komentar, Broj,Ime +' '+Prezime as PunoIme  from Racun
	left join Komercijalist ON Racun.KomercijalistID=Komercijalist.IDKomercijalist
	left join KreditnaKartica on Racun.KreditnaKarticaID=KreditnaKartica.IDKreditnaKartica 
    where IDRacun = @IDReceipt
go

-----------------------------
-----------Stavke------------

create proc ReadItemDetails
@IDRacun int
as
	select s.IDStavka, cast(s.Kolicina as int) as Kolicina, cast(s.CijenaPoKomadu as int) as CijenaPoKomadu, cast(s.PopustUPostocima as int) as PopustUPostocima, cast(s.UkupnaCijena as int) as UkupnaCijena, p.IDProizvod, p.Naziv as Produkt, p.BrojProizvoda, p.Boja, cast(p.MinimalnaKolicinaNaSkladistu as int) as MinimalnaKolicinaNaSkladistu, cast(p.CijenaBezPDV as int) as CijenaBezPDV, pk.IDPotkategorija, pk.Naziv as Potkategorija, k.IDKategorija, k.Naziv as Kategorija from Stavka as s
	inner join  Proizvod as p on s.ProizvodID = p.IDProizvod
	inner join  Potkategorija as pk on p.PotkategorijaID = pk.IDPotkategorija
	inner join  Kategorija as k on pk.KategorijaID = k.IDKategorija
	where s.RacunID = @IDRacun
go

-----------------------------
------Korisnicki racun-------

create table KorisnickiRacun
(
	IDKorisnickiRacun int constraint PK_ID primary key identity,
	KorisnickoIme nvarchar(50) not null,
	Lozinka nvarchar(50) not null
)
go

create proc CountUserAccounts
	@KorisnickoIme nvarchar(50),
	@Lozinka nvarchar(50)
as
	select Count(*) from KorisnickiRacun
	where KorisnickoIme=@KorisnickoIme and Lozinka=@Lozinka
go

create procedure CreateUserAccount 
   @KorisnickoIme nvarchar(50),
   @Lozinka nvarchar(50),
   @id int out
as  
if not exists(select*from KorisnickiRacun where KorisnickoIme=@KorisnickoIme)
	begin
		insert into KorisnickiRacun
		values (@KorisnickoIme, @Lozinka)
		set @id=SCOPE_IDENTITY()
	end
go

create proc ReadUserAccount
	@KorisnickoIme nvarchar(50)
as
	select*from KorisnickiRacun
	where KorisnickoIme=@KorisnickoIme
go