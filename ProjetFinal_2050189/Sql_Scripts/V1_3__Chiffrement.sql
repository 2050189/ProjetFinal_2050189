-- CHIFFREMENT

GO
CREATE MASTER KEY ENCRYPTION BY PASSWORD= 'Passw0rd!abc'

GO

CREATE CERTIFICATE MonCert WITH SUBJECT = 'Chiffrement';
GO

CREATE SYMMETRIC KEY Cle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE MonCert;
GO

OPEN SYMMETRIC KEY Cle DECRYPTION BY CERTIFICATE MonCert;

declare @Value varbinary(max) = ENCRYPTBYKEY(KEY_GUID('Cle'), VENTE.Detail.PrixPaye);

CLOSE SYMMETRIC KEY Cle;

GO

-- créer une nouvelle table Client

CREATE TABLE VENTE.Client(
	ClientID INT IDENTITY(1,1) NOT NULL,
	Prenom nvarchar(15) NOT NULL,
	NumeroTel VARBINARY(MAX) NOT NULL,
	CONSTRAINT PK_Client_ClientID PRIMARY KEY (ClientID)
)
GO

-- table pour recup les données dechiffrées

CREATE TABLE VENTE.ClientDechiffre(
	NumeroTel nvarchar(10) NOT NULL
)
GO

-- Insérer des données dans Client avec procédure

CREATE PROCEDURE VENTE.USP_AjouterClient(@Prenom nvarchar(15), @NumeroTel nvarchar(10))
AS
BEGIN

	-- On chiffre les données
	OPEN SYMMETRIC KEY Cle DECRYPTION BY CERTIFICATE Chiffrement
		DECLARE @NumeroChiffre varbinary(max) = EncryptByKey(KEY_GUID('Cle'), @NumeroTel)
	CLOSE SYMMETRIC KEY Cle

	-- On insert
	INSERT INTO VENTE.Client(Prenom, NumeroTel)
	VALUES(@Prenom,  @NumeroChiffre)
END
GO

-- récuperer num telephone dechiffré dans Client avec procédure
CREATE PROCEDURE VENTE.USP_RecupererNumClient(@ClientID int) 
AS
BEGIN
	OPEN SYMMETRIC KEY Cle DECRYPTION BY CERTIFICATE Chiffrement

		SELECT CONVERT(nvarchar(10), DECRYPTBYKEY(NumeroTel)) AS NumeroTel
		FROM VENTE.Client WHERE ClientID = @ClientID
	
	CLOSE SYMMETRIC KEY Cle
END
GO

-- mettre des clients 

EXEC VENTE.USP_AjouterClient @Prenom ='Marie', @NumeroTel='5148881111'
EXEC VENTE.USP_AjouterClient @Prenom ='Chantal', @NumeroTel='4503332222'
EXEC VENTE.USP_AjouterClient @Prenom ='Olivier', @NumeroTel='4189090909'
EXEC VENTE.USP_AjouterClient @Prenom ='Laurence', @NumeroTel='5141110000'
EXEC VENTE.USP_AjouterClient @Prenom ='David', @NumeroTel='4386667777'
EXEC VENTE.USP_AjouterClient @Prenom ='Paul', @NumeroTel='4504446666'
EXEC VENTE.USP_AjouterClient @Prenom ='Henri', @NumeroTel='4185558888'
EXEC VENTE.USP_AjouterClient @Prenom ='Suzanne', @NumeroTel='5140005555'
EXEC VENTE.USP_AjouterClient @Prenom ='Bruno', @NumeroTel='4387772222'



