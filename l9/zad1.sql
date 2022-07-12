use testCLR;

create table test ( zespolona dbo.ComplexNumber);
insert into test (zespolona) values('27+27i');
select zespolona.sprzezona().ToString() from test;
select zespolona.modul() from test;
drop table test;