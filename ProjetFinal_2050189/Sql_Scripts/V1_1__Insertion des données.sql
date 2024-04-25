use ProjetFinal2050189
GO 

--AJOUT Magasins
INSERT INTO VENTE.Magasin(Nom, AProgrammePts)
VALUES('Sephora', 1),
	('Sol de Janeiro', 1),
	('Amazon', 0)
GO

--AJOUT Gammes
INSERT INTO SOLDEJANEIRO.Gamme (Nom, AnneeSortie, Cote, Note1, Note2, Note3, Couleur)
VALUES('Cheirosa 62', 2020, 4, 'Caramel sal�', 'Pistache', 'Vanille', 'Orange'),
	('Cheirosa 59', 2024, 3, 'Orchid�e vanille', 'Violette sucr�e', 'Bois de santal', 'Mauve'),
	('Cheirosa 40', 2021, 5, 'Prune ambr�e noire', 'Vanille', 'Cr�me de cassis', 'Magenta'),
	('Cheirosa 68', 2022, 2, 'Jasmin br�zilien', 'Pitaya', 'Vanille', 'Rose'),
	('Cheirosa 71', 2020, 4, 'Vanille caram�lis�e', 'Noix de macadame', 'F�ve de tonka', 'Brun')
	GO

--AJOUT Produits
INSERT INTO SOLDEJANEIRO.Produit (Nom, Format, GammeID)
VALUES('Brume Brazilian', 'Petit',1),
	('Brume Brazilian', 'Grand',1),
	('Brume Delicia Drench', 'Petit',2),
	('Brume Delicia Drench', 'Grand',2),
	('Brume Bom Dia', 'Petit',3),
	('Brume Bom Dia', 'Grand',3),
	('Brume Beija Flor', 'Petit',4),
	('Brume Beija Flor', 'Grand',4),
	('Brume Decadent', 'Petit',5),
	('Brume Decadent', 'Grand',5),
	('Parfum Brazilian', 'Petit', 1),
	('Parfum Brazilian', 'Grand', 1),
	('Beurre Delicia Drench', 'Petit', 2),
	('Beurre Delicia Drench', 'Grand', 2),
	('Cr�me Brazilian', 'Petit', 1),
	('Cr�me Brazilian', 'Grand', 1),
	('Cr�me Bom Dia', 'Petit', 3),
	('Cr�me Bom Dia', 'Grand', 3),
	('Cr�me Beija Flor', 'Petit', 4),
	('Cr�me Beija Flor', 'Grand', 4),
	('Exfoliant Brazilian', 'Petit', 1),
	('Exfoliant Brazilian', 'Grand', 1),
	('Exfoliant Bom Dia', 'Grand', 3),
	('Gel Brazilian', 'Petit', 1),
	('Gel Brazilian', 'Grand', 1),
	('Gel Bom Dia', 'Petit', 3),
	('Gel Bom Dia', 'Grand', 3),
	('Gel Beija Flor', 'Petit', 4),
	('Gel Beija Flor', 'Grand', 4)
	GO

--AJOUT Savon
INSERT INTO SOLDEJANEIRO.Savon(Texture, ProduitID)
values('Exfoliant',21),
('Exfoliant',22),
('Exfoliant',23),
('Gel',24),
('Gel',25),
('Gel',26),
('Gel',27),
('Gel',28),
('Gel',29)
GO

--AJOUT Vaporisateur
INSERT INTO SOLDEJANEIRO.Vaporisateur(Intensite, ProduitID)
values('Brume',1),
('Brume',2),
('Brume',3),
('Brume',4),
('Brume',5),
('Brume',6),
('Brume',7),
('Brume',8),
('Brume',9),
('Brume',10),
('Parfum', 11),
('Parfum', 12)
GO

--AJOUT Hydratant
INSERT INTO SOLDEJANEIRO.Hydratant(Epaisseur, ProduitID)
values('Beurre',13),
('Beurre',14),
('Cr�me',15),
('Cr�me',16),
('Cr�me',17),
('Cr�me',18),
('Cr�me',19),
('Cr�me',20)
GO

----AJOUT Achats (valeur MontantTotal sera MAJ pour la somme des Prixpaye)
INSERT INTO VENTE.Achat(MontantTotal, MagasinID)
VALUES(1, 1),
(1, 2),
(1, 2),
(1, 2),
(1, 1),
(1, 1),
(1, 3),
(1, 1),
(1, 1),
(1, 1),
(1, 2),
(1, 1),
(1, 1),
(1, 3),
(1, 3),
(1, 2),
(1, 3),
(1, 1),
(1, 2),
(1, 1)
	GO

----AJOUT Details
INSERT INTO VENTE.Details(PrixPaye, AchatID, ProduitID)
VALUES (45.23, 1, 7),
 (50.19, 10, 28),
 (42.30, 3, 23),
 (23.43, 20, 24),
 (57.04, 17, 8),
 (40.60, 9, 18),
 (38.64, 2, 7),
 (21.92, 6, 13),
 (22.63, 6, 18),
 (27.95, 15, 29),
 (28.03, 3, 26),
 (39.88, 1, 21),
 (51.28, 20, 6),
 (21.29, 19, 1),
 (37.92, 2, 22),
 (52.05, 12, 9),
 (54.23, 19, 11),
 (56.38, 17, 29),
 (52.07, 10, 21),
 (42.51, 11, 21),
 (42.23, 14, 4),
 (34.85, 16, 26),
 (29.24, 16, 9),
 (35.98, 12, 1),
 (34.10, 2, 4),
 (44.43, 19, 9),
 (59.71, 11, 13),
 (55.87, 10, 18),
 (22.96, 6, 16),
 (30.28, 16, 6),
 (29.07, 13, 7),
 (38.55, 8, 24),
 (35.44, 9, 5),
 (23.82, 18, 23),
 (57.62, 17, 1),
 (47.30, 7, 5),
 (23.91, 8, 18),
 (35.13, 13, 23),
 (41.74, 8, 10),
 (38.38, 11, 26),
 (43.11, 10, 15),
 (29.14, 1, 17),
 (28.92, 20, 7),
 (32.62, 14, 26),
 (57.57, 15, 26),
 (31.58, 3, 10),
 (49.57, 17, 14),
 (21.25, 3, 4),
 (28.16, 19, 26),
 (42.92, 6, 24)
GO

--MAJ La somme de details.Prixpaye pour achat.MontantTotal
UPDATE VENTE.Achat
SET MontantTotal = Query.tot
FROM (
	SELECT AchatID, SUM(PrixPaye) as tot 
	FROM VENTE.Details
	GROUP BY AchatID -- pour chaque achatID
	)AS Query
WHERE VENTE.Achat.AchatID = Query.AchatID --associer � chaque achatID