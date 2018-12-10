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


