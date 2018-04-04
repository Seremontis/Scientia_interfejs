Create database Ewidencja_SI


use Ewidencja_SI
Create table Osoby(
ID_osoby smallint not null primary key IDENTITY(1,1),
Imie nvarchar(20) not null,
Nazwisko nvarchar(40) not null,
Nr_albumu nvarchar(6),
Ranga nvarchar(30) not null CHECK(Ranga='Admin' or Ranga='Cz³onek' or Ranga='Goœæ'),
Logg varchar(20),
Haslo varchar(20),
Data_dolaczenia date,
Telefon nvarchar(15),
E_mail nvarchar(70),
Opis nvarchar(200),
Czy_aktywny bit not null --czy aktualnie dzia³a w kole
)

insert into Osoby values('Wojtek','Kochañski',null,'Admin','wojtus','haslo123','2018-12-13','231312','3213"@dwad.pl','dwawdaddhfwjh',1)

Select * from Osoby

Create table Zasoby(
ID_zasobu smallint not null primary key IDENTITY(1,1),
Nazwa nvarchar(30) not null,
Kod nvarchar(30),
Opis nvarchar(200),--specyfikacja
Kategoria nvarchar(20) not null CHECK(Kategoria='Laptopy i tablety' OR Kategoria='PC stacjonarny' OR Kategoria='Telefony' OR Kategoria='Smartwatche' OR Kategoria='Inne' ),
Stan_techniczny nvarchar(100),
Czy_wypozyczalny bit not null,--zepsuty,sprawny,za drogi itp.
Status_wypozyczenia bit not null
)
Insert into Zasoby values('Laptop Kasi','','super szybki mega super','Laptopy i tablety','sprawny',1,0)

Select * from Zasoby

Create table Wypozyczenia(
ID_wypozyczenia int not null primary key IDENTITY(1,1),
ID_osoby smallint not null foreign key references Osoby(ID_osoby),
ID_zasobu smallint not null foreign key references Zasoby(ID_zasobu),
Data_wypozyczenia date not null,
Data_zwrot date, --przewidywana
aktualne bit --pokazuje czy dane s¹ aktualne czy historyczne
)
Insert into Wypozyczenia values(1,1,'2017-02-22','2017-03-22',0)

Select * from Wypozyczenia

Select * from Osoby inner join Wypozyczenia ON Osoby.ID_osoby=Wypozyczenia.ID_osoby inner join Zasoby ON Wypozyczenia.ID_zasobu=Zasoby.ID_zasobu


