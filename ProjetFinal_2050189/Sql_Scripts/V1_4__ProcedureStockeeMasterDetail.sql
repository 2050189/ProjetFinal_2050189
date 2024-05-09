-- Vue pour stocker l'info
USE ProjetFinal2050189

GO

CREATE VIEW VENTE.vw_MagasinVenteInfos
AS
	select m.MagasinID, m.Nom as [Nom magasin], p.ProduitID, p.Nom as [Nom produit], COUNT(d.ProduitID) AS [Nombre Vendu]
	FROM VENTE.Magasin m
	INNER JOIN VENTE.Achat a
	ON a.MagasinID = m.MagasinID
	INNER JOIN VENTE.Details d
	ON d.AchatID = a.AchatID
	INNER JOIN SOLDEJANEIRO.Produit p
	ON p.ProduitID = d.ProduitID
	GROUP BY m.MagasinID, m.Nom , p.ProduitID, p.Nom

-- PROCÉDURE 1

GO
CREATE PROCEDURE VENTE.usp_ProduitsVendusEtNombreVendusMagasin(@MagasinID int) -- JE CRÉE UNE PROCÉDURE POUR AFFICHER LES PRODUITS VENDUS ET LE NOMBRE SELON UN MAGASIN SPÉCIFIQUE
AS
BEGIN
	SELECT * FROM VENTE.vw_MagasinVenteInfos
	WHERE MagasinID = @MagasinID
END 
GO