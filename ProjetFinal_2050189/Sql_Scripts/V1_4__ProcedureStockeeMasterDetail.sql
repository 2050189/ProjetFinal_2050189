-- PROCÉDURE 1

GO
CREATE PROCEDURE VENTE.usp_ProduitsVendusEtNombreVendusMagasin(@MagasinID int) -- JE CRÉE UNE PROCÉDURE POUR AFFICHER LES PRODUITS VENDUS ET LE NOMBRE SELON UN MAGASIN SPÉCIFIQUE
AS
BEGIN
	SELECT m.Nom AS [Magasin], p.Nom AS [Produit], COUNT(d.ProduitID) AS [Nombre Vendu]
	FROM VENTE.Magasin m
	INNER JOIN VENTE.Achat a
	ON a.MagasinID = m.MagasinID
	INNER JOIN VENTE.Details d
	ON d.AchatID = a.AchatID
	INNER JOIN SOLDEJANEIRO.Produit p
	ON p.ProduitID = d.ProduitID
	WHERE m.MagasinID = @MagasinID
	GROUP BY p.Nom , m.nom
END 
GO