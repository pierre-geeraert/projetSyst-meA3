
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


