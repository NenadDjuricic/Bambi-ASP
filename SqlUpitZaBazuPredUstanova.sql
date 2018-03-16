Create database PredskolskaUstanova
Go

Use PredskolskaUstanova
Go

Create table Sediste(
SedisteID int identity(1,1) not null,
Naziv nvarchar(30) not null)

Alter table Sediste
Add constraint PK_Sediste primary key (SedisteID)

Create table PredskolskaUstanova (
PredskolskaUstanovaID int identity(1,1) not null,
Naziv nvarchar(30) not null,
BrojTelefona nvarchar(20) not null,
Adresa nvarchar(30) not null,
PripadnostUstanove nvarchar(30) not null,
PIB nvarchar(20) not null,
SedisteID int not null)

Alter table PredskolskaUstanova
Add constraint PK_PredskolskaUstanova primary key (PredskolskaUstanovaID)

Alter table PredskolskaUstanova
Add constraint FK_PredskolskaUstanovaSediste foreign key (SedisteID)
References Sediste(SedisteID)

create table DnevnikRada (
DnevnikRadaID int identity (1,1) not null,
Datum datetime not null,
OpisRada nvarchar(50) not null) 

Alter table DnevnikRada
Add constraint PK_DnevnikRada primary key (DnevnikRadaID)

Create table VaspitnaGrupa(
VaspitnaGrupaID int identity(1,1) not null,
Naziv nvarchar (30) not null,
PredskolskaUstanovaID int not null,
DnevnikRadaID int not null)

Alter table VaspitnaGrupa
Add constraint PK_VaspitnaGrupa primary key (VaspitnaGrupaID)

Alter table VaspitnaGrupa 
Add constraint FK_VaspitnaGrupaPU foreign key (PredskolskaUstanovaID)
References PredskolskaUstanova (PredskolskaUstanovaID)

Alter table VaspitnaGrupa
Add constraint FK_VaspitnaGrupaDR foreign key (DnevnikRadaID)
References DnevnikRada (DnevnikRadaID)

Create table Vaspitac (
VaspitacID int identity(1,1) not null,
Ime nvarchar (15) not null,
Prezime nvarchar (15) not null,
BrojTelefona nvarchar (20) not null,
JMBG nvarchar (13) not null,
PredskolskaUstanovaID int not null,
VaspitnaGrupaID int not null,
DnevnikRadaID int not null)

Alter table Vaspitac 
Add constraint PK_Vaspitac primary key (VaspitacID)

Alter table Vaspitac
Add constraint FK_VaspitacPU foreign key (PredskolskaUstanovaID)
References PredskolskaUstanova (PredskolskaUstanovaID)

Alter table Vaspitac
Add constraint FK_VaspitacVG foreign key (VaspitnaGrupaID)
References VaspitnaGrupa (VaspitnaGrupaID)

Alter table Vaspitac
Add constraint FK_VaspitacDR foreign key (DnevnikRadaID)
References DnevnikRada (DnevnikRadaID)

Create table Domacinstvo (
DomacinstvoID int identity(1,1) not null,
BrojClanova int not null,
BrojDece int not null,
Adresa nvarchar(30) not null,
Telefon nvarchar(20) not null)

Alter table Domacinstvo
Add constraint PK_Domacinstvo primary key (DomacinstvoID)

Create table Dete (
DeteID int identity(1,1) not null,
Ime nvarchar(20) not null,
Prezime nvarchar(20) not null,
DatumRodjenja datetime not null,
JMBG nvarchar(13) not null,
ImeRoditelja nvarchar(30) not null,
DomacinstvoID int not null,
VaspitnaGrupaID int not null)

Alter table Dete 
Add constraint PK_Dete primary key (DeteID)

Alter table Dete
Add constraint FK_DeteD foreign key (DomacinstvoID)
References Domacinstvo (DomacinstvoID)

Alter table Dete
Add constraint FK_DeteVG foreign key (VaspitnaGrupaID)
References VaspitnaGrupa (VaspitnaGrupaID)

create table Prisutnost (
PrisutnostID int identity(1,1) not null,
DnevnikRadaID int not null,
Evidencija nvarchar(100) not null,
DeteID int not null)

--SLAB ENTITET

Alter table Prisutnost
Add constraint PK_Prisutnost primary key (PrisutnostID,DnevnikRadaID)

Alter table Prisutnost
Add constraint FK_PrisutnostDR foreign key (DnevnikRadaID)
References DnevnikRada (DnevnikRadaID)

Alter table Prisutnost 
Add constraint FK_PrisutnostD foreign key (DeteID)
References Dete (DeteID)
Go

--INSERT

Create procedure INS_Sediste(
@Naziv nvarchar(30))
as
begin
begin transaction
Insert into Sediste (Naziv) values (@Naziv)
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_PredskolskaUstanova(
@Naziv nvarchar(30),
@BrojTelefona nvarchar(20),
@Adresa nvarchar(30),
@PripadnostUstanove nvarchar(30),
@PIB nvarchar(20),
@SedisteID int
)
as
begin
begin transaction
Insert into PredskolskaUstanova(Naziv,BrojTelefona,Adresa,PripadnostUstanove,PIB,SedisteID) values (@Naziv,@BrojTelefona,@Adresa,@PripadnostUstanove,@PIB,@SedisteID)
if @@ERROR <> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_DnevnikRada(
@Datum datetime,
@OpisRada nvarchar(50)
)
as
begin
begin transaction
Insert into DnevnikRada(Datum,OpisRada) values (@Datum,@OpisRada)
if @@ERROR <> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_VaspitnaGrupa(
@Naziv nvarchar (30),
@PredskolskaUstanovaID int,
@DnevnikRadaID int
)
as
begin
begin transaction
Insert into VaspitnaGrupa(Naziv,PredskolskaUstanovaID,DnevnikRadaID) values (@Naziv,@PredskolskaUstanovaID,@DnevnikRadaID)
if @@ERROR<> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_Vaspitac(
@Ime nvarchar (15),
@Prezime nvarchar (15),
@BrojTelefona nvarchar(20),
@JMBG nvarchar(13),
@PredskolskaUstanovaID int,
@VaspitnaGrupaID int,
@DnevnikRadaID int
)
as
begin
begin transaction
Insert into Vaspitac(Ime,Prezime,BrojTelefona,JMBG,PredskolskaUstanovaID,VaspitnaGrupaID,DnevnikRadaID) values (@Ime,@Prezime,@BrojTelefona,@JMBG,@PredskolskaUstanovaID,@VaspitnaGrupaID,@DnevnikRadaID)
if @@ERROR <> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_Domacinstvo(
@BrojClanova int,
@BrojDece int,
@Adresa nvarchar(30),
@Telefon nvarchar(20)
)
as
begin
begin transaction
Insert into Domacinstvo(BrojClanova,BrojDece,Adresa,Telefon) values (@BrojClanova,@BrojDece,@Adresa,@Telefon)
if @@ERROR <> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_Dete(
@Ime nvarchar (20),
@Prezime nvarchar (20),
@DatumRodjenja datetime,
@JMBG nvarchar(13),
@ImeRoditelja nvarchar(30),
@DomacinstvoID int,
@VaspitnaGrupaID int
)
as 
begin
begin transaction
Insert into Dete(Ime,Prezime,DatumRodjenja,JMBG,ImeRoditelja,DomacinstvoID,VaspitnaGrupaID) values (@Ime,@Prezime,@DatumRodjenja,@JMBG,@ImeRoditelja,@DomacinstvoID,@VaspitnaGrupaID)
if @@ERROR <>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure INS_Prisutnost(
@DnevnikRadaID int,
@Evidencija nvarchar(100),
@DeteID int
)
as
begin
begin transaction
Insert into Prisutnost(DnevnikRadaID,Evidencija,DeteID) values (@DnevnikRadaID,@Evidencija,@DeteID)
if @@ERROR <> 0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

--UPDATE

Create procedure UPD_Sediste(
@SedisteID int,
@Naziv nvarchar(30)
)
as
begin
begin transaction
Update Sediste set Naziv=@Naziv where SedisteID=@SedisteID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go


Create procedure UPD_PredskolskaUstanova(
@PredskolskaUstanovaID int,
@Naziv nvarchar(30),
@BrojTelefona nvarchar(20),
@Adresa nvarchar(30),
@PripadnostUstanove nvarchar(30),
@PIB nvarchar(20),
@SedisteID int
)
as
begin
begin transaction
Update PredskolskaUstanova set Naziv=@Naziv, BrojTelefona=@BrojTelefona, Adresa=@Adresa, PripadnostUstanove=@PripadnostUstanove, PIB=@PIB, SedisteID=@SedisteID where PredskolskaUstanovaID=@PredskolskaUstanovaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_DnevnikRada(
@DnevnikRadaID int,
@Datum datetime,
@OpisRada nvarchar(50)
)
as
begin
begin transaction
Update DnevnikRada set Datum=@Datum, OpisRada=@OpisRada where DnevnikRadaID=@DnevnikRadaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_VaspitnaGrupa(
@VaspitnaGrupaID int,
@Naziv nvarchar (30),
@PredskolskaUstanovaID int,
@DnevnikRadaID int
)
as
begin
begin transaction
Update VaspitnaGrupa set Naziv=@Naziv , PredskolskaUstanovaID=@PredskolskaUstanovaID, DnevnikRadaID=@DnevnikRadaID where VaspitnaGrupaID=@VaspitnaGrupaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_Vaspitac(
@VaspitacID int,
@Ime nvarchar (15),
@Prezime nvarchar (15),
@BrojTelefona nvarchar(20),
@JMBG nvarchar(13),
@PredskolskaUstanovaID int,
@VaspitnaGrupaID int,
@DnevnikRadaID int
)
as
begin
begin transaction
Update Vaspitac set Ime=@Ime, Prezime=@Prezime, BrojTelefona=@BrojTelefona, JMBG=@JMBG, PredskolskaUstanovaID=@PredskolskaUstanovaID, VaspitnaGrupaID=@VaspitnaGrupaID, DnevnikRadaID=@DnevnikRadaID where VaspitacID=@VaspitacID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_Domacinstvo(
@DomacinstvoID int,
@BrojClanova int,
@BrojDece int,
@Adresa nvarchar(30),
@Telefon nvarchar(20)
)
as
begin
begin transaction
Update Domacinstvo set BrojClanova=@BrojClanova , BrojDece=@BrojDece, Adresa=@Adresa, Telefon=@Telefon where DomacinstvoID=@DomacinstvoID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_Dete(
@DeteID int,
@Ime nvarchar (20),
@Prezime nvarchar (20),
@DatumRodjenja datetime,
@JMBG nvarchar(13),
@ImeRoditelja nvarchar(30),
@DomacinstvoID int,
@VaspitnaGrupaID int
)
as 
begin
begin transaction
Update Dete set Ime=@Ime, Prezime=@Prezime, DatumRodjenja=@DatumRodjenja, JMBG=@JMBG, ImeRoditelja=@ImeRoditelja, DomacinstvoID=@DomacinstvoID, VaspitnaGrupaID=@VaspitnaGrupaID where DeteID=@DeteID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure UPD_Prisutnost(
@PristutnostID int,
@DnevnikRadaID int,
@Evidencija nvarchar(100),
@DeteID int
)
as
begin
begin transaction
Update Prisutnost set DnevnikRadaID=@DnevnikRadaID , Evidencija=@Evidencija, DeteID=@DeteID where PrisutnostID=@PristutnostID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

--DELETE
Create procedure DEL_Sediste(
@SedisteID int
)
as
begin
begin transaction
Delete Sediste where SedisteID=@SedisteID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_PredskolskaUstanova(
@PredskolskaUstanovaID int
)
as
begin
begin transaction
Delete PredskolskaUstanova where PredskolskaUstanovaID=@PredskolskaUstanovaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_DnevnikRada(
@DnevnikRadaID int
)
as
begin
begin transaction
Delete DnevnikRada where DnevnikRadaID=@DnevnikRadaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go


Create procedure DEL_VaspitnaGrupa(
@VaspitnaGrupaID int
)
as
begin
begin transaction
Delete VaspitnaGrupa where VaspitnaGrupaID=@VaspitnaGrupaID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_Vaspitac(
@VaspitacID int
)
as
begin
begin transaction
Delete Vaspitac where VaspitacID=@VaspitacID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_Domacinstvo(
@DomacinstvoID int
)
as
begin
begin transaction
Delete Domacinstvo where DomacinstvoID=@DomacinstvoID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_Dete(
@DeteID int
)
as
begin
begin transaction
Delete Dete where DeteID=@DeteID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

Create procedure DEL_Prisutnost(
@PrisutnostID int
)
as
begin
begin transaction
Delete Prisutnost where PrisutnostID=@PrisutnostID
if @@ERROR<>0
begin
rollback transaction
end
else
begin
commit transaction
end
end
go

exec INS_Sediste 'Beograd'
exec INS_Sediste 'Novi sad'
exec INS_Sediste 'Nis'
exec INS_Sediste 'Kraljevo'

exec INS_PredskolskaUstanova 'Pcelica','011/22-33-444','Bajdina 32','Zvezdara','453543',1
exec INS_PredskolskaUstanova 'Leptir' , '011/23-22-333', 'Kralja Petra 2', 'Zemun','3232',1
exec INS_PredskolskaUstanova 'Zmaj' , '011/33-21-344', 'Milutinova 2', 'Novo Naselje', '2322', 2
exec INS_PredskolskaUstanova 'Lug' , '011/34-22-111', 'Bozina 21' , 'Medijana' , '3221', 3

exec INS_DnevnikRada '2017-09-22', 'Deca su bila mirna'
exec INS_DnevnikRada '2017-09-23','Nemirna Deca'
exec INS_DnevnikRada '2017-09-24', 'Redovno'
exec INS_DnevnikRada '2017-09-25', 'Mestimicno oblacno'


exec INS_VaspitnaGrupa 'Jaslice' ,1,1
exec INS_VaspitnaGrupa 'Mladja' ,2,2
exec INS_VaspitnaGrupa 'Starija' ,3,3
exec INS_VaspitnaGrupa 'Predskolska' ,4,4

exec INS_Vaspitac 'Jana','Milovanovic', '063/232-321','14323434',1,1,1
exec INS_Vaspitac 'Milica','Misic', '063/2322-321','1233',2,2,2
exec INS_Vaspitac 'Sanja','Simic', '063/776-321','231',3,3,3
exec INS_Vaspitac 'Marija','Jovic', '063/2566-321','554',4,4,4

exec INS_Domacinstvo 3,2,'Savska 22' , '011/2323-888'
exec INS_Domacinstvo 4,2,'Sarajevska 21' , '011/211-33'
exec INS_Domacinstvo 5,3,'Zmaj Jovina 32' , '021/655-3441'
exec INS_Domacinstvo 4,1,'Cika Ljubina 5' , '023/854-124'

exec INS_Dete 'Marko', 'Milic','2015-09-14','4324234','Dejan',1,1
exec INS_Dete 'Milica', 'Mitic','2014-10-23','31311','Marko',2,2
exec INS_Dete 'Vanja', 'Savic','2013-03-12','76986','Milos',3,3
exec INS_Dete 'Lazar', 'Lazic','2012-06-13','5756','Mitar',4,4

exec INS_Prisutnost 1,'Nije tu',1
exec INS_Prisutnost 2,'Nije tu',2
exec INS_Prisutnost 3,'Tu je',3
exec INS_Prisutnost 4,'Tu je',4

exec UPD_Prisutnost 2,2,'Tu je',2

exec DEL_Sediste 4