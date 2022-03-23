Alter table ���������
    drop constraint FK_���������_���,
    constraint FK_���������_�����,
    constraint FK_���������_����
GO
Alter table �����������
    drop constraint FK_�����������_���������,
    constraint FK_�����������_����������
GO
Alter table ���������
    drop constraint FK_���������_����������
GO
ALTER TABLE ����������
	drop constraint FK_����������_���������
GO
ALTER TABLE �����
	drop constraint FK_�����_���������
GO
ALTER TABLE ������
	drop constraint FK_������_���������,
	constraint FK_������_����������
	      
go
DROP TABLE �����
GO
DROP TABLE ������
GO
DROP TABLE ���_���������
GO
DROP TABLE ��������� 
GO
DROP TABLE ����
GO
DROP TABLE �����
GO
DROP TABLE �����������
GO
DROP TABLE ����������
GO
DROP TABLE ���������
GO
DROP TABLE ���������
GO
DROP TABLE ����������
GO
CREATE TABLE ���������
(
	��� int identity primary key,
	�������� varchar(20) not null unique,
	[��� ���� ���������] int not null,
	[��� ����] int not null,
	[��� ������] int not null
)

GO
CREATE TABLE ���������
(
	��� int identity primary key,
	���� date not null,
	�������� varchar(80) not null unique,
	�������� varchar(100) not null default '�������� �����������.',
	[��� ����������] int not null,
	���� money not null
)

GO
CREATE TABLE ����������
(
	��� int identity primary key,
	��� varchar(50) not null check(��� like '% % %'),
	[��� ���������] int not null ,
	����� varchar(50) not null,
    ������ varchar(50) not null
)

GO
CREATE TABLE �����������
(
	��� int identity primary key,
	���� date not null,
	[��� ���������] int not null,
	[��� ����������] int not null
)

GO
CREATE TABLE �����
(
	��� int identity primary key,
	����� varchar(100) not null ,
	[��� ���������] int not null
)

GO
CREATE TABLE ����
(
	��� int identity primary key,
	���� smallint not null check(����>=1 and ����<=5),
	[�������(�2)] smallint not null,
	�������� varchar(30) not null  
	
)

GO
CREATE TABLE ���������
(
	��� int identity primary key,
	�������� varchar(20) not null 
)

GO
CREATE TABLE ���_���������
(
	��� int identity primary key,
	[��� ���������] varchar(30) not null
)

CREATE TABLE ������
(
	��� int identity primary key,
	���� date not null,
	[��� ���������] int not null,
	[��� ����������] int 
)

GO
CREATE TABLE �����
(
	��� int identity primary key,
	��� varchar(50) not null ,
	������ varchar(20) not null ,
	������������� varchar(30) not null 
)
GO
CREATE TABLE ����������
(
	��� int identity primary key,
	������� varchar(50) not null ,
	��� varchar(50) not null,
	������� varchar(20) not null,
	����� varchar(50) not null,
    ������ varchar(50) not null
)




-- ����� ����������� �����������
GO
ALTER TABLE ����
	add constraint ���������_������� check([�������(�2)] > 0)
GO
-- ����� ���������� �����������
ALTER TABLE ���������
add constraint ����������_���������_�������� unique(��������)
GO

ALTER TABLE ���������
	add constraint FK_���������_��� FOREIGN KEY([��� ���� ���������]) references ���_���������,
	constraint FK_���������_���� FOREIGN KEY([��� ����]) references ����,
	constraint FK_���������_����� FOREIGN KEY([��� ������]) references �����
GO
ALTER TABLE ���������
	add constraint FK_���������_���������� FOREIGN KEY([��� ����������]) references ����������
GO
ALTER TABLE ����������
	add constraint FK_����������_��������� FOREIGN KEY([��� ���������]) references ���������
GO
ALTER TABLE �����������
	add constraint FK_�����������_��������� FOREIGN KEY([��� ���������]) references ���������,
		constraint FK_�����������_���������� FOREIGN KEY([��� ����������]) references ����������
GO
ALTER TABLE �����
	add constraint FK_�����_��������� FOREIGN KEY([��� ���������]) references ���������
GO
ALTER TABLE ������
	add constraint FK_������_��������� FOREIGN KEY([��� ���������]) references ���������,
	    constraint FK_������_���������� FOREIGN KEY([��� ����������]) references ����������


INSERT INTO ����������(�������, ��� ,�������, �����, ������)
    VALUES  ('��������','����','+375445434422','o',1),
            ('��������','����','+375225434622','mark',123),
            ('���������','�����','+375449074466','roman',123),
            ('����','������','+375123451273','siarhei',123),
            ('��������','�������','+375472890305','vital',123),
            ('����������','������','+375594712108','andrey',123),
			('����������','�������','+3754457461249','vasua',123)

INSERT INTO ���������(��������)
    VALUES ('�����������'), ('�����������'),('��������'), ('��������'),('�������'), ('������')

INSERT INTO ����������(���,[��� ���������] , �����, ������)
    VALUES  ('�������� ���� ����������',1,'oleg',123),
            ('�������� ���� ������������',2,'mark',123),
            ('��������� ���� ����������',3,'oleg123',123),
            ('���� ������ ����������',4,'siarhei',123),
            ('�������� ������� �������������',5,'vital',123),
            ('���������� ������ ����������',6,'andrey',123),
			('���������� ������ ����������',3,'andr',123)
            
INSERT INTO ���������(����,��������, ��������, [��� ����������],����)
    VALUES ('2018-01-01','"����� ����� � ����������� �������� ��������"',default, 1,1.5), 
           ('2018-02-01','"���� � ���� ���� �����"','���������-�������������� ���������', 2,2.5),
		   ('2017-11-03','"�������� ������ �������"','��������� ��� ����������', 2,3.5), 
           ('2018-06-23','"������ ����� �������"','�������� ������� ������� �����������', 2,4.2), 
		   ('2018-05-09','"�� ������ � ������� �� ������"',default, 2,1.5), 
           ('2018-04-03','"�� ������ ������ ������, �� ������ ������ �������"','������������ ���������', 1,5.1), 
	       ('2018-10-02','"���� �������� ���������"','������-�������������� ���������', 1,6.0), 
	       ('2018-10-20','"������ �������� ����"','������������ ����������� ��������', 1,3.7)

INSERT INTO �����(���,������,�������������)
    VALUES ('����� ����� ��������','������', '����������'), 
           ('���������� ������ ����������','������', '��������'),
           ('��������� ���� ����������','�������', '��������'),
           ('����� ������� ����������','��������', '������'),
           ('�������� ������� ����������','������', '��������')

INSERT INTO ������(����,[��� ���������],[��� ����������])
    VALUES ('2018-01-01',1,1), 
	       ('2018-02-01',2,1), 
		   ('2018-03-04',3,2), 
		   ('2018-04-11',3,3), 
		   ('2018-02-11',4,4), 
		   ('2018-02-16',5,4), 
		   ('2018-01-02',7,6), 
		   ('2018-03-05',8,5), 
		   ('2018-02-21',6,4)

INSERT INTO ���_���������([��� ���������])
    VALUES  ('�����'), ('�������� ������'),('������������� ������'),('�������'),('������')

INSERT INTO ����(����, [�������(�2)], ��������)
    VALUES  (1,10,'������������'),
            (2,8,'���������������'),
            (3,15,'��������� �������'),
	        (4,12,'���������������'),
			(4,20,'���������������'),
            (1,10,'��������� �������')

INSERT INTO �����(�����,[��� ���������])
    VALUES  ('������ ���������',1),
            ('������ ���������',2),
            ('���� ����� �������������',3),
            ('��������� � ��������',4),
		    ('����� ��������� ��������',3),
            ('����� ����� � ������������ ��������� �����������',1),
            ('����� ���������� � ������ ������������ ����������',5),
            ('���������� ��� � ���������.',6),
			('���������� ��� � ���������.',8),
			('����� ������ �����, ���� ����������. ������ �� �������.',7)
		

INSERT INTO ���������(��������,[��� ���� ���������],[��� ����], [��� ������])
    VALUES  ('������ ��������',5,2,1),
            ('���� ������',1,2,1),
            ('��-47',3,1,2),
            ('�������',3,1,3),
            ('������� ���',4,3,5),
			('������� ���',4,5,5),
            ('���',2,4,5)

INSERT INTO �����������(����,[��� ���������],[��� ����������])
    VALUES  ('2018-01-02',1,1),
            ('2018-02-03',2,2),
            ('2018-02-03',3,3),
            ('2018-02-16',4,4),
            ('2018-03-04',2,5),
			('2018-01-04',5,6),
            ('2018-03-18',6,6),
            ('2018-02-02',3,7),
            ('2018-03-25',1,2)


go
DROP VIEW ������������������
go
CREATE VIEW ������������������(id,[�������� ���������], [��� ���������], [�������� ����], [��� ������])
as 
	Select ���������.���, ���������.��������, ���_���������.[��� ���������], ����.��������, �����.���
	From ���������,���_���������, ����, �����
	where ���������.[��� ���� ���������] = ���_���������.��� and ���������.[��� ������]=�����.��� and ���������.[��� ����]=����.���
go	
		
	
DROP VIEW �����������������
go
CREATE VIEW �����������������(id,  [��� ����������],[����� ������], [���� ���������] , [�������� ���������], [�������� ���������], [���� ���������])
as 
	Select ���������.���, ���, �����, CONVERT(VARCHAR(10), ���������.����, 111), ��������,���������.�������� , ����  from �����, ����������, ���������
                 where ����������.��� = ���������.[��� ����������]  and ���������.[���] = �����.[��� ���������] 
go	

	
DROP VIEW view�����
go
CREATE VIEW view�����(id,  [�����], [�������� ���������],[��� ���������])
as 
	Select �����.���,�����, ��������,[��� ���������] from (����� INNER JOIN ��������� on ���������.���=�����.[��� ���������])
go	

DROP VIEW view���������
go
CREATE VIEW view���������(id, [����], [�������� ���������],[�������� ���������],[��� ����������],[��� ����������], [���� ���������])
as 
	Select ���������.���, CONVERT(VARCHAR(10), ����, 111) as [����], �������� ,�������� , ��� ,[��� ����������], ���� from (��������� INNER JOIN ���������� on ����������.���=���������.[��� ����������])
go	

DROP VIEW view��������
go

CREATE VIEW view��������(id,[�������� ���������], [��� ���������] , [�������� ����],[��� ������], [��� ���� ���������], [��� ����], [��� ������])
as 
	Select ���������.���,���������.��������, [��� ���������] ,����.��������, ��� , [��� ���� ���������], [��� ����], [��� ������]  
	from ((��������� INNER JOIN ���_��������� on ���_���������.���=���������.[��� ���� ���������] ) 
           INNER JOIN ���� on ����.���=���������.[��� ����]) INNER JOIN ����� on �����.��� = ���������.[��� ������] 
go	

DROP VIEW view�����������
go
CREATE VIEW view�����������(id, [����] , [�������� ���������], [��� ����������], [��� ���������], [��� ����������] )
as 
	Select �����������.���, CONVERT(VARCHAR(10), �����������.����, 111) , [��������], ��� , [��� ���������], [��� ����������]  
	from (����������� INNER JOIN ���������� on ����������.���=�����������.[��� ����������] ) 
          INNER JOIN ��������� on ���������.���=�����������.[��� ���������]  
go	

DROP VIEW view�����
go
CREATE VIEW view�����(id, [����] ,[�������� ���������],[������� ����������], [��� ���������],[��� ����������] )
as 
	Select ������.���, CONVERT(VARCHAR(10), ������.����, 111), �������� ,�������, [��� ���������],[��� ����������] 
	from (������ INNER JOIN ��������� on ���������.���=������.[��� ���������]) Inner join ���������� on ����������.��� = ������.[��� ����������] 
go

DROP VIEW view���������
go
CREATE VIEW view���������(id, ���,[�������� ���������], [��� ���������], �����, ������ )
as 
	Select ����������.���, ���, �������� as [�������� ���������], [��� ���������], �����, ������ 
	from (���������� INNER JOIN ��������� on ���������.���=����������.[��� ���������])
go	

create trigger trigger��������� on ���������
after delete 
as 
if exists (Select * from ���������� where [��� ���������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ���������, � �������� ���� ����������.', 16, 2)
  RETURN 
end
go

create trigger trigger���� on ����
after delete 
as 
if exists (Select * from ��������� where [��� ����] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ���, � �������� ���� ��������.', 16, 2)
  RETURN 
end
go

create trigger trigger����� on �����
after delete 
as 
if exists (Select * from ��������� where [��� ������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ������, � �������� ���� ��������.', 16, 2)
  RETURN 
end
go

create trigger trigger���������� on ����������
after delete 
as 
if exists (Select * from ����������� where [��� ����������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ����������, � �������� ���� �����������.', 16, 2)
  RETURN 
end

if exists (Select * from ��������� where [��� ����������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ����������, � �������� ���� ���������.', 16, 2)
  RETURN 
end
go

create trigger trigger���������� on ����������
after delete 
as 
if exists (Select * from ������ where [��� ����������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ����������, � �������� ���� �����.', 16, 2)
  RETURN 
end
go

create trigger trigger��������� on ���������
after delete 
as 
if exists (Select * from ����������� where [��� ���������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ��������, � �������� ���� �����������.', 16, 2)
  RETURN 
end
go

create trigger trigger��������� on ���������
after delete 
as 
if exists (Select * from ����� where [��� ���������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ���������, � ������� ���� �����.', 16, 2)
  RETURN 
end

if exists (Select * from ������ where [��� ���������] in (Select ��� from deleted))
begin
  ROLLBACK
  RAISERROR ('������ ������� ���������, � ������� ���� �����.', 16, 2)
  RETURN 
end
go
-- ��������� �������� ���������� ��� �������� ����� ���������
create trigger trg���_��������� on ���������
after delete 
as
begin
  delete from ���������
    where [��� ���� ���������] in (Select ��� from deleted)
end
go

-- ��������� �������� ������� ��� �������� ���������
create trigger trg��������� on �����
after delete 
as
begin
  delete from �����
    where [��� ���������] in (Select ��� from deleted)
end
go
go
drop procedure �������������������������������������
go
create proc �������������������������������������
as
Select ��������,���� , ����������.��� as [��� ������������], count(*) as [���������� ��������� �������]
  From ���������, ������, ����������
  Where ����������.���=���������.[��� ����������] and ���������.���=������.[��� ���������]
	Group by ���������.��������, ��� , ����
	Order by ���������.��������

go
drop procedure Update������
go
create proc Update������ (@Ticket_date date ,  @Excursion_id int, @Visitor_id int , @Ticket_id int )
as
Update ������ set ���� = @Ticket_date, [��� ���������]=@Excursion_id, [��� ����������]=@Visitor_id  where ��� = @Ticket_id

go

drop procedure Update����
go
create proc Update���� (@Room_floor smallint, @Room_square smallint, @Room_name varchar(50), @Room_id int)
as
Update ���� set ���� = @Room_floor, [�������(�2)] = @Room_square, �������� = @Room_name  where ��� = @Room_id
go

drop procedure Update�����������
go
create proc Update����������� ( @Restoration_date date, @Exhibit_id int, @Worker_id int, @Restoration_id int )
as
Update ����������� set ���� = @Restoration_date, [��� ���������] = @Exhibit_id, [��� ����������] = @Worker_id where ��� = @Restoration_id
go

drop procedure Update���������
go
create proc Update��������� (@Excursion_date date, @Excursion_name varchar(80), @Excursion_description varchar(100), @Worker_id int, @Excursion_cost money ,@Excursion_id int)
as
Update ��������� set ���� = @Excursion_date, �������� = @Excursion_name, ��������=@Excursion_description, [��� ����������]=@Worker_id, ����=@Excursion_cost where ��� = @Excursion_id
go

drop procedure Update�����
go
create proc Update����� ( @Comment_text varchar(100), @Excursion_id int , @Comment_id int )
as
Update ����� set ����� = @Comment_text, [��� ���������]=@Excursion_id where ��� = @Comment_id
go



drop function ExcursionDateBetween
go
create function ExcursionDateBetween(@date1 date, @date2 date, @worker_id int)
  returns table
as
return
Select  ����������.���, ���, ����� as [����� ������],CONVERT(VARCHAR(10), ����, 111) as ����, ��������, ���������.��������  from �����, ����������, ��������� 
                 where ����������.��� = ���������.[��� ����������]  and ���������.[���] = �����.[��� ���������] and ����������.���=@worker_id and ���� BETWEEN @date1 and @date2
go

drop function RestorationDateBetween
go
create function RestorationDateBetween(@date1 date, @date2 date, @worker_id int)
  returns table
as
return
Select  ����������.���, ���, �������� as [�������� ���������],CONVERT(VARCHAR(10), ����, 111) as ����  from ��������� , ����������, ����������� 
                 where ����������.��� = �����������.[��� ����������]  and ���������.[���] = �����������.[��� ���������] and ����������.���=@worker_id and ���� BETWEEN @date1 and @date2
go

