

--schema vente
--CREATE SCHEMA VENTE
--GO 

----schema soldejaneiro (la marque)
--CREATE SCHEMA SOLDEJANEIRO
--GO

--table Magasin
CREATE TABLE VENTE.Magasin(
	MagasinID int IDENTITY(1,1),
	Nom nvarchar(25) not null,
	AProgrammePts Bit not null,
	CONSTRAINT PK_Magasin_MagasinID PRIMARY KEY (MagasinID)
);

--table Achat
CREATE TABLE VENTE.Achat(
	AchatID int IDENTITY(1,1),
	MontantTotal money not null,
	MagasinID int not null,
	CONSTRAINT PK_Achat_AchatID PRIMARY KEY (AchatID)
);

--table Details
CREATE TABLE VENTE.Details(
	DetailsID int IDENTITY(1,1),
	PrixPaye money not null,
	AchatID int not null,
	ProduitID int not null,
	CONSTRAINT PK_Details_DetailsID PRIMARY KEY (DetailsID)
);

--table Produit
CREATE TABLE SOLDEJANEIRO.Produit(
	ProduitID int IDENTITY(1,1),
	Nom nvarchar(50) not null,
	Format nvarchar(25) not null,
	GammeID int not null,
	CONSTRAINT PK_Produit_ProduitID PRIMARY KEY (ProduitID)
);

--table Gamme
CREATE TABLE SOLDEJANEIRO.Gamme(
	GammeID int IDENTITY(1,1),
	Nom nvarchar(25) not null,
	AnneeSortie int not null,
	Cote int not null,
	Note1 nvarchar(25) not null,
	Note2 nvarchar (25) not null,
	Note3 nvarchar (25) not null,
	Couleur nvarchar(25) not null,
	CONSTRAINT PK_Gamme_GammeID PRIMARY KEY (GammeID)
);

--table Hydratant
create table SOLDEJANEIRO.Hydratant(
	HydratantID int IDENTITY(1,1),
	Epaisseur nvarchar(10) not null,
	ProduitID int not null,
	CONSTRAINT PK_Hydratant_HydratantID PRIMARY KEY (HydratantID)
);

--table Vaporisateur
create table SOLDEJANEIRO.Vaporisateur(
	VaporisateurID int IDENTITY(1,1),
	Intensite nvarchar(10) not null,
	ProduitID int not null,
	CONSTRAINT PK_Vaporisateur_VaporisateurID PRIMARY KEY (VaporisateurID)
);

--table Savon
create table SOLDEJANEIRO.Savon(
	SavonID int IDENTITY(1,1),
	Texture nvarchar(10) not null,
	ProduitID int not null,
	CONSTRAINT PK_Savon_SavonID PRIMARY KEY (SavonID)
);
go


--FK ACHAT(MagasinID) de PK MAGASIN(MagasinID)
ALTER TABLE VENTE.Achat ADD CONSTRAINT FK_Achat_MagasinID 
FOREIGN KEY (MagasinID) REFERENCES VENTE.Magasin(MagasinID)
GO

--FK DETAILS(AchatID) de PK ACHAT(AchatID)
ALTER TABLE VENTE.Details ADD CONSTRAINT FK_Details_AchatID 
FOREIGN KEY (AchatID) REFERENCES VENTE.Achat(AchatID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--FK DETAILS(ProduitID) de PK PRODUIT(ProduitID)
ALTER TABLE VENTE.Details ADD CONSTRAINT FK_Details_ProduitID 
FOREIGN KEY (ProduitID) REFERENCES SOLDEJANEIRO.Produit(ProduitID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--FK PRODUIT(GammeID) de PK GAMME(GammeID)
ALTER TABLE SOLDEJANEIRO.Produit ADD CONSTRAINT FK_Produit_GammeID 
FOREIGN KEY (GammeID) REFERENCES SOLDEJANEIRO.Gamme(GammeID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--FK HYDRATANT(ProduitID) de PK PRODUIT(ProduitID)
ALTER TABLE SOLDEJANEIRO.Hydratant ADD CONSTRAINT FK_Hydratant_ProduitID 
FOREIGN KEY (ProduitID) REFERENCES SOLDEJANEIRO.Produit(ProduitID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--FK VAPORISATEUR(ProduitID) de PK PRODUIT(ProduitID)
ALTER TABLE SOLDEJANEIRO.Vaporisateur ADD CONSTRAINT FK_Vaporisateur_ProduitID 
FOREIGN KEY (ProduitID) REFERENCES SOLDEJANEIRO.Produit(ProduitID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--FK SAVON(ProduitID) de PK PRODUIT(ProduitID)
ALTER TABLE SOLDEJANEIRO.Savon ADD CONSTRAINT FK_Savon_ProduitID 
FOREIGN KEY (ProduitID) REFERENCES SOLDEJANEIRO.Produit(ProduitID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

--Nom de gamme unique
ALTER TABLE SOLDEJANEIRO.Gamme ADD CONSTRAINT UC_Gamme_Nom UNIQUE (Nom)
GO

--Texture de savon soit Gel ou Exfoliant
ALTER TABLE SOLDEJANEIRO.Savon ADD CONSTRAINT CK_Savon_Texture CHECK(Texture in ('Gel', 'Exfoliant'))
GO

--Epaisseur de hydratant soit Creme ou Beurre
ALTER TABLE SOLDEJANEIRO.Hydratant ADD CONSTRAINT CK_Hydratant_Epaisseur CHECK(Epaisseur in ('Beurre', 'Crème'))
GO

--Intensite de vaporisateur soit Brume ou Parfum
ALTER TABLE SOLDEJANEIRO.Vaporisateur ADD CONSTRAINT CK_Vaporisateur_Intensite CHECK(Intensite in ('Brume', 'Parfum'))
GO 

--Format de produit soit Petit ou Grand
ALTER TABLE SOLDEJANEIRO.Produit ADD CONSTRAINT CK_Produit_Format CHECK(Format in ('Petit', 'Grand'))
GO

--Cote de gamme est dans les limites [1,5]
ALTER TABLE SOLDEJANEIRO.Gamme ADD CONSTRAINT CK_Gamme_Cote CHECK(Cote>=1 AND Cote<=5)
GO

--Par défaut le magasin n'a pas de programme de points
ALTER TABLE VENTE.Magasin ADD CONSTRAINT DF_Magasin_AProgrammePts DEFAULT 0 FOR AProgrammePts
GO

