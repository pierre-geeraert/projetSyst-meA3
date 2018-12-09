
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

