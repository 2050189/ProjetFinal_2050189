-- VUE

GO
CREATE VIEW VENTE.vw_TypeDesProduits -- JE CRÉE UNE VUE POUR AVOIR LE TYPE DES PRODUITS (hydratant, savon ou vaporisateur)
AS
SELECT p.ProduitID, p.Nom, [Type de produit] =
CASE
	WHEN p.ProduitID in (SELECT h.ProduitID FROM SOLDEJANEIRO.Hydratant) THEN 'Hydratant'
	WHEN p.ProduitID in (SELECT S.ProduitID FROM SOLDEJANEIRO.Savon) THEN 'Savon'
	ELSE 'Vaporisateur'
	END
FROM SOLDEJANEIRO.Produit p
LEFT JOIN SOLDEJANEIRO.Hydratant h
ON p.ProduitID = h.ProduitID
LEFT JOIN SOLDEJANEIRO.Savon s
ON p.ProduitID = s.ProduitID
GO