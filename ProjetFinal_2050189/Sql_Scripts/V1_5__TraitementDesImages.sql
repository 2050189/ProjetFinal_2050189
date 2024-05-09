ALTER TABLE SOLDEJANEIRO.Gamme ADD
Identifiant uniqueidentifier NOT NULL ROWGUIDCOL DEFAULT newid();
GO

ALTER TABLE SOLDEJANEIRO.Gamme ADD CONSTRAINT
UC_Gamme_Identifiant UNIQUE (Identifiant)
GO

ALTER TABLE SOLDEJANEIRO.Gamme ADD
Photo varbinary(max) FILESTREAM NULL;
GO

UPDATE SOLDEJANEIRO.Gamme
SET Photo = BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2050189\Desktop\ProjetFinal_2050189\ProjetFinal_2050189\images_TEST\Cheirosa62.jpg', SINGLE_BLOB) AS myfile
WHERE GammeID = 1

UPDATE SOLDEJANEIRO.Gamme
SET Photo = BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2050189\Desktop\ProjetFinal_2050189\ProjetFinal_2050189\images_TEST\Cheirosa71.jpg', SINGLE_BLOB) AS myfile
WHERE GammeID = 5