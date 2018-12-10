CREATE TABLE Demande_client (ID_commandes int NOT NULL, PlaceID_Table int NOT NULL, RecetteID_Recette int NULL, PRIMARY KEY (ID_commandes));
CREATE TABLE Etape_Recette (ID_Etape int NOT NULL, nom varchar(255) NULL, temps int NULL, Ordre int NULL, RecetteID_Recette int NOT NULL, PRIMARY KEY (ID_Etape));
CREATE TABLE Ingredient (ID_Ingredient int NOT NULL, nom varchar(255) NULL, quantité int NULL, Stock_ingrédientID_Stock int NOT NULL, PRIMARY KEY (ID_Ingredient));
CREATE TABLE Ingredient_Etape_Recette (IngredientID_Ingredient int NOT NULL, Etape_RecetteID_Etape int NOT NULL, PRIMARY KEY (IngredientID_Ingredient, Etape_RecetteID_Etape));
CREATE TABLE Matériel_cuisine (ID_Materiel_cuisine int NOT NULL, nom varchar(255) NULL, quantité int NULL, Quantité_propre int NULL, PRIMARY KEY (ID_Materiel_cuisine));
CREATE TABLE Matériel_Etape_recette (Matériel_cuisineID_Materiel_cuisine int NOT NULL, Etape_RecetteID_Etape int NOT NULL, PRIMARY KEY (Matériel_cuisineID_Materiel_cuisine, Etape_RecetteID_Etape));
CREATE TABLE Matériel_salle (ID_Materiel_salle int NOT NULL, Nom varchar(255) NULL, quantité int NULL, Quantité_propre int NULL, PRIMARY KEY (ID_Materiel_salle));
CREATE TABLE Matériel_Table (Matériel_salleID_Materiel_salle int NOT NULL, PlaceID_Table int NOT NULL, PRIMARY KEY (Matériel_salleID_Materiel_salle, PlaceID_Table));
CREATE TABLE Place (ID_Table int NOT NULL, Etat_occupe bit NULL, type varchar(255) NULL, Etat_sale bit NULL, x int NULL, y int NULL, PRIMARY KEY (ID_Table));
CREATE TABLE Recette (ID_Recette int NOT NULL, Nom varchar(255) NULL, [Temps prépa] int NULL, [Nombre de personne] int NULL, type int NULL, PRIMARY KEY (ID_Recette));
CREATE TABLE Stock_ingrédient (ID_Stock int NOT NULL, Nom varchar(255) NULL, quantité int NULL, état int NULL, [date livraison] date NULL, PRIMARY KEY (ID_Stock));
ALTER TABLE Ingredient_Etape_Recette ADD CONSTRAINT FKIngredient829388 FOREIGN KEY (Etape_RecetteID_Etape) REFERENCES Etape_Recette (ID_Etape);
ALTER TABLE Matériel_Etape_recette ADD CONSTRAINT FKMatériel_E519515 FOREIGN KEY (Matériel_cuisineID_Materiel_cuisine) REFERENCES Matériel_cuisine (ID_Materiel_cuisine);
ALTER TABLE Matériel_Etape_recette ADD CONSTRAINT FKMatériel_E639671 FOREIGN KEY (Etape_RecetteID_Etape) REFERENCES Etape_Recette (ID_Etape);
ALTER TABLE Matériel_Table ADD CONSTRAINT FKMatériel_T959896 FOREIGN KEY (Matériel_salleID_Materiel_salle) REFERENCES Matériel_salle (ID_Materiel_salle);
ALTER TABLE Matériel_Table ADD CONSTRAINT FKMatériel_T658824 FOREIGN KEY (PlaceID_Table) REFERENCES Place (ID_Table);
ALTER TABLE Demande_client ADD CONSTRAINT commande FOREIGN KEY (PlaceID_Table) REFERENCES Place (ID_Table);
ALTER TABLE Demande_client ADD CONSTRAINT comporte FOREIGN KEY (RecetteID_Recette) REFERENCES Recette (ID_Recette);
ALTER TABLE Ingredient_Etape_Recette ADD CONSTRAINT Contenue FOREIGN KEY (IngredientID_Ingredient) REFERENCES Ingredient (ID_Ingredient);
ALTER TABLE Etape_Recette ADD CONSTRAINT [Se situe] FOREIGN KEY (RecetteID_Recette) REFERENCES Recette (ID_Recette);
ALTER TABLE Ingredient ADD CONSTRAINT Stocker FOREIGN KEY (Stock_ingrédientID_Stock) REFERENCES Stock_ingrédient (ID_Stock);

/*Upload data*/
BULK INSERT projet1.dbo.Place
FROM
'C:\Users\MSSQLSERVER\Documents\table_place.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);



BULK INSERT projet1.dbo.Matériel_salle
FROM
'C:\Users\MSSQLSERVER\Documents\table_matériel_salle.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

BULK INSERT projet1.dbo.Matériel_Table
FROM
'C:\Users\MSSQLSERVER\Documents\table_int_mat_salle.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);


BULK INSERT projet1.dbo.Matériel_cuisine
FROM
'C:\Users\MSSQLSERVER\Documents\table_matériel_cuisine.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

BULK INSERT projet1.dbo.Stock_ingrédient
FROM
'C:\Users\MSSQLSERVER\Documents\table_stock.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

BULK INSERT projet1.dbo.Ingredient
FROM
'C:\Users\MSSQLSERVER\Documents\table_ingredients.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);


BULK INSERT projet1.dbo.Ingredient_Etape_Recette
FROM
'C:\Users\MSSQLSERVER\Documents\table_int_ingredient_etape.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);


BULK INSERT projet1.dbo.Etape_Recette
FROM
'C:\Users\MSSQLSERVER\Documents\table_étape.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

BULK INSERT projet1.dbo.Matériel_Etape_recette
FROM
'C:\Users\MSSQLSERVER\Documents\table_materiel_etape_recette.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);


BULK INSERT projet1.dbo.Recette
FROM
'C:\Users\MSSQLSERVER\Documents\table_recette.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

BULK INSERT projet1.dbo.Demande_client
FROM
'C:\Users\MSSQLSERVER\Documents\table_demande.csv'
WITH
(FIELDTERMINATOR=';',
ROWTERMINATOR='\n',
FIRSTROW=2);

/*Procédure*/


/*take hall's equipement*/
/*argument
@id_material_in ID material
@quantity_tool_removed  quantity of material you want to remove
*/

/*drop procedure Take_hall_tool*/

create procedure Take_hall_tool
@id_material_in int,
@quantity_tool_removed int
  as
begin
  update Matériel_salle
set Quantité_propre= Quantité_propre - @quantity_tool_removed
  where @id_material_in=ID_Materiel_salle
end;
go

/*give all x coord from all tables*/
/*no argument*/
create procedure table_coord_all_x
as
begin
  select x from Place;
end;
go


/*give all x coord from all tables*/
/*no argument*/
create procedure table_coord_all_y
as
begin
  select y from Place;
end;
go



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maxime,,Hollebecq>
-- Create date: <07/12/18,,>
-- Description:	<Procédure permettant d'update la table Commande en assignant les commandes à une table,,>
-- =============================================
CREATE PROCEDURE Table_commande @table int,  @recette int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Demande_client
	SET RecetteID_Recette = @recette
	WHERE PlaceID_Table = @table
END
GO

/*take kitchen's equipement*/
/*argument
@id_material_in ID material
@quantity_tool_removed  quantity of material you want to remove
*/

/*drop procedure Take_kitchen_tool*/

create procedure Take_kitchen_tool
@id_material_in int,
@quantity_tool_removed int
  as
begin
  update Matériel_cuisine
set Quantité_propre= Quantité_propre - @quantity_tool_removed
  where ID_Materiel_cuisine=@id_material_in
end;
go

/*make a recipe*/
/*argument
id_recipe_in ID of the recipe
*/
create procedure Make_recipe
@id_recipe_in int
  as
begin
  /*Loss of Kitchen tools*/
update projet1.dbo.Matériel_cuisine
set Quantité_propre = Quantité_propre-1
where ID_Materiel_cuisine in
      (select Matériel_cuisine.ID_Materiel_cuisine
      from projet1.dbo.Matériel_cuisine , projet1.dbo.Matériel_Etape_recette ,projet1.dbo.Etape_Recette
      where Etape_Recette.RecetteID_Recette=@id_recipe_in and Etape_Recette.ID_Etape=Matériel_Etape_recette.Etape_RecetteID_Etape and Matériel_Etape_recette.Matériel_cuisineID_Materiel_cuisine=Matériel_cuisine.ID_Materiel_cuisine);

/*Loss of food*/
update projet1.dbo.Stock_ingrédient
set quantité= quantité-1
where Stock_ingrédient.ID_Stock in
      (select Stock_ingrédient.ID_Stock
      from projet1.dbo.Stock_ingrédient ,projet1.dbo.Ingredient, projet1.dbo.Ingredient_Etape_Recette,projet1.dbo.Etape_Recette
      where Etape_Recette.RecetteID_Recette=@id_recipe_in and Etape_Recette.ID_Etape=Ingredient_Etape_Recette.Etape_RecetteID_Etape and Ingredient_Etape_Recette.IngredientID_Ingredient=Ingredient.ID_Ingredient and Ingredient.Stock_ingrédientID_Stock=Stock_ingrédient.ID_Stock);
end;

go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maxime,,Hollebecq>
-- Create date: <07/12/18,,>
-- Description:	<Procédure permettant d'update la table place en rendant la table à l'état propre ,,>
-- =============================================
CREATE PROCEDURE Table_sale @place int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Place
	SET Etat_sale = 0
	WHERE ID_Table = @place
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maxime,,Hollebecq>
-- Create date: <07/12/18,,>
-- Description:	<Procédure permettant d'update la table place en rendant la table à l'état sale ,,>
-- =============================================
CREATE PROCEDURE Table_sale @place int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Place
	SET Etat_sale = 1
	WHERE ID_Table = @place
END
GO

