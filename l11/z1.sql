use testXML
go
declare @xdoc xml
set @xdoc = '<?xml version="1.0"?>
<lista></lista>';

set @xdoc.modify('insert <student><nazwisko>Abacki</nazwisko><imie>Adam<imie/></student> into (/lista)[1]');
set @xdoc.modify('insert <student><nazwisko>Babacki</nazwisko><imie>Adam<imie/></student> into (/lista)[1]');
set @xdoc.modify('insert <student><nazwisko>Cabacki</nazwisko><imie>Adam<imie/></student> into (/lista)[1]');
set @xdoc.modify('insert <student><nazwisko>Dadacki</nazwisko><imie>Adam<imie/></student> into (/lista)[1]');
set @xdoc.modify('insert <student><nazwisko>Ebacki</nazwisko><imie>Adam<imie/></student> into (/lista)[1]');
set @xdoc.modify('insert <grupa>4</grupa> as last into (/lista/student)[1]');
set @xdoc.modify('insert <grupa>4</grupa> as last into (/lista/student)[2]');
set @xdoc.modify('insert <grupa>4</grupa> as last into (/lista/student)[3]');
set @xdoc.modify('insert <grupa>4</grupa> as last into (/lista/student)[4]');
set @xdoc.modify('insert <grupa>4</grupa> as last into (/lista/student)[5]');
select T.c.query('.') results from @xdoc.nodes('lista/student') T(c)

--select @xdoc