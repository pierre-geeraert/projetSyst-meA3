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
