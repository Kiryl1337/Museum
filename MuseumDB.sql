Alter table Экспонаты
    drop constraint FK_Экспонаты_Вид,
    constraint FK_Экспонаты_Автор,
    constraint FK_Экспонаты_Залы
GO
Alter table Реставрация
    drop constraint FK_Реставрация_Экспонаты,
    constraint FK_Реставрация_Сотрудники
GO
Alter table Экскурсии
    drop constraint FK_Экскурсии_Сотрудники
GO
ALTER TABLE Сотрудники
	drop constraint FK_Сотрудники_Должность
GO
ALTER TABLE Отзыв
	drop constraint FK_Отзыв_Экскурсии
GO
ALTER TABLE Билеты
	drop constraint FK_Билеты_Экскурсии,
	constraint FK_Билеты_Посетители
	      
go
DROP TABLE Автор
GO
DROP TABLE Билеты
GO
DROP TABLE Вид_экспоната
GO
DROP TABLE Должность 
GO
DROP TABLE Залы
GO
DROP TABLE Отзыв
GO
DROP TABLE Реставрация
GO
DROP TABLE Сотрудники
GO
DROP TABLE Экскурсии
GO
DROP TABLE Экспонаты
GO
DROP TABLE Посетители
GO
CREATE TABLE Экспонаты
(
	Код int identity primary key,
	Название varchar(20) not null unique,
	[Код вида экспоната] int not null,
	[Код зала] int not null,
	[Код автора] int not null
)

GO
CREATE TABLE Экскурсии
(
	Код int identity primary key,
	Дата date not null,
	Название varchar(80) not null unique,
	Описание varchar(100) not null default 'Описание отсутствует.',
	[Код сотрудника] int not null,
	Цена money not null
)

GO
CREATE TABLE Сотрудники
(
	Код int identity primary key,
	ФИО varchar(50) not null check(ФИО like '% % %'),
	[Код должности] int not null ,
	Логин varchar(50) not null,
    Пароль varchar(50) not null
)

GO
CREATE TABLE Реставрация
(
	Код int identity primary key,
	Дата date not null,
	[Код экспоната] int not null,
	[Код сотрудника] int not null
)

GO
CREATE TABLE Отзыв
(
	Код int identity primary key,
	Текст varchar(100) not null ,
	[Код экскурсии] int not null
)

GO
CREATE TABLE Залы
(
	Код int identity primary key,
	Этаж smallint not null check(Этаж>=1 and Этаж<=5),
	[Площадь(м2)] smallint not null,
	Название varchar(30) not null  
	
)

GO
CREATE TABLE Должность
(
	Код int identity primary key,
	Название varchar(20) not null 
)

GO
CREATE TABLE Вид_экспоната
(
	Код int identity primary key,
	[Вид экспоната] varchar(30) not null
)

CREATE TABLE Билеты
(
	Код int identity primary key,
	Дата date not null,
	[Код экскурсии] int not null,
	[Код посетителя] int 
)

GO
CREATE TABLE Автор
(
	Код int identity primary key,
	ФИО varchar(50) not null ,
	Страна varchar(20) not null ,
	Специальность varchar(30) not null 
)
GO
CREATE TABLE Посетители
(
	Код int identity primary key,
	Фамилия varchar(50) not null ,
	Имя varchar(50) not null,
	Телефон varchar(20) not null,
	Логин varchar(50) not null,
    Пароль varchar(50) not null
)




-- Новое проверочное ограничение
GO
ALTER TABLE Залы
	add constraint Проверить_Площадь check([Площадь(м2)] > 0)
GO
-- Новое уникальное ограничение
ALTER TABLE Должность
add constraint Уникальное_Должность_Название unique(Название)
GO

ALTER TABLE Экспонаты
	add constraint FK_Экспонаты_Вид FOREIGN KEY([Код вида экспоната]) references Вид_экспоната,
	constraint FK_Экспонаты_Залы FOREIGN KEY([Код зала]) references Залы,
	constraint FK_Экспонаты_Автор FOREIGN KEY([Код автора]) references Автор
GO
ALTER TABLE Экскурсии
	add constraint FK_Экскурсии_Сотрудники FOREIGN KEY([Код сотрудника]) references Сотрудники
GO
ALTER TABLE Сотрудники
	add constraint FK_Сотрудники_Должность FOREIGN KEY([Код должности]) references Должность
GO
ALTER TABLE Реставрация
	add constraint FK_Реставрация_Экспонаты FOREIGN KEY([Код экспоната]) references Экспонаты,
		constraint FK_Реставрация_Сотрудники FOREIGN KEY([Код сотрудника]) references Сотрудники
GO
ALTER TABLE Отзыв
	add constraint FK_Отзыв_Экскурсии FOREIGN KEY([Код экскурсии]) references Экскурсии
GO
ALTER TABLE Билеты
	add constraint FK_Билеты_Экскурсии FOREIGN KEY([Код экскурсии]) references Экскурсии,
	    constraint FK_Билеты_Посетители FOREIGN KEY([Код посетителя]) references Посетители


INSERT INTO Посетители(Фамилия, Имя ,Телефон, Логин, Пароль)
    VALUES  ('Кириянов','Олег','+375445434422','o',1),
            ('Николаев','Марк','+375225434622','mark',123),
            ('Сидоренко','Роман','+375449074466','roman',123),
            ('Зуев','Сергей','+375123451273','siarhei',123),
            ('Харламов','Виталий','+375472890305','vital',123),
            ('Алекандров','Андрей','+375594712108','andrey',123),
			('Алекандров','Василий','+3754457461249','vasua',123)

INSERT INTO Должность(Название)
    VALUES ('Экскурсовод'), ('Реставратор'),('Охранник'), ('Директор'),('Уборщик'), ('Кассир')

INSERT INTO Сотрудники(ФИО,[Код должности] , Логин, Пароль)
    VALUES  ('Кириянов Олег Николаевич',1,'oleg',123),
            ('Николаев Марк Владимирович',2,'mark',123),
            ('Сидоренко Олег Леонидович',3,'oleg123',123),
            ('Зуев Сергей Валерьевич',4,'siarhei',123),
            ('Харламов Виталий Владиславович',5,'vital',123),
            ('Алекандров Андрей Валерьевич',6,'andrey',123),
			('Алекандров Андрей Валерьевич',3,'andr',123)
            
INSERT INTO Экскурсии(Дата,Название, Описание, [Код сотрудника],Цена)
    VALUES ('2018-01-01','"Малая земля — легендарный плацдарм мужества"',default, 1,1.5), 
           ('2018-02-01','"Знай и люби свой город"','Культурно-информационная экскурсия', 2,2.5),
		   ('2017-11-03','"Золотыми руками рабочих"','Экскурсия для школьников', 2,3.5), 
           ('2018-06-23','"Помнят степи донские"','Изучение истории древних цивилизаций', 2,4.2), 
		   ('2018-05-09','"Мы отняли у Антанты ее солдат"',default, 2,1.5), 
           ('2018-04-03','"За каждым именем судьба, за каждым именем история"','Тематическая экскурсия', 1,5.1), 
	       ('2018-10-02','"Люди огненной профессии"','Научно-позновательная экскурсия', 1,6.0), 
	       ('2018-10-20','"Звезды зажигают люди"','Демонстрация современной живописи', 1,3.7)

INSERT INTO Автор(ФИО,Страна,Специальность)
    VALUES ('Васин Игорь Петрович','Россия', 'Архитектор'), 
           ('Алекандров Андрей Валерьевич','Англия', 'Художник'),
           ('Сидоренко Олег Леонидович','Франция', 'Писатель'),
           ('Васин Валерий Викторович','Германия', 'Кузнец'),
           ('Андреева Валерия Николаевна','Польша', 'Художник')

INSERT INTO Билеты(Дата,[Код экскурсии],[Код посетителя])
    VALUES ('2018-01-01',1,1), 
	       ('2018-02-01',2,1), 
		   ('2018-03-04',3,2), 
		   ('2018-04-11',3,3), 
		   ('2018-02-11',4,4), 
		   ('2018-02-16',5,4), 
		   ('2018-01-02',7,6), 
		   ('2018-03-05',8,5), 
		   ('2018-02-21',6,4)

INSERT INTO Вид_экспоната([Вид экспоната])
    VALUES  ('Броня'), ('Холодное оружие'),('Огнестрельное оружие'),('Картина'),('Клинок')

INSERT INTO Залы(Этаж, [Площадь(м2)], Название)
    VALUES  (1,10,'Исторический'),
            (2,8,'Археологический'),
            (3,15,'Картинная галерея'),
	        (4,12,'Древнегреческий'),
			(4,20,'Древнегреческий'),
            (1,10,'Картинная галерея')

INSERT INTO Отзыв(Текст,[Код экскурсии])
    VALUES  ('Лучшая экскурсия',1),
            ('Плохая экскурсия',2),
            ('Было очень позновательно',3),
            ('Интересно и нескучно',4),
		    ('Музей старается меняться',3),
            ('Много людей и недовольство некоторых сотрудников',1),
            ('Много интересных и разных тематических экспозиций',5),
            ('Понравился зал с картинами.',6),
			('Понравился зал с картинами.',8),
			('Очень плохой музей, мало экспонатов. Никому не советую.',7)
		

INSERT INTO Экспонаты(Название,[Код вида экспоната],[Код зала], [Код автора])
    VALUES  ('Клинок Соломона',5,2,1),
            ('Шлем Ахилла',1,2,1),
            ('АК-47',3,1,2),
            ('Макарыч',3,1,3),
            ('Девятый вал',4,3,5),
			('Восьмой вал',4,5,5),
            ('Меч',2,4,5)

INSERT INTO Реставрация(Дата,[Код экспоната],[Код сотрудника])
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
DROP VIEW ПросмотрЭкспонатов
go
CREATE VIEW ПросмотрЭкспонатов(id,[Название экспоната], [Вид экспоната], [Название зала], [ФИО автора])
as 
	Select Экспонаты.Код, Экспонаты.Название, Вид_экспоната.[Вид экспоната], Залы.Название, Автор.ФИО
	From Экспонаты,Вид_экспоната, Залы, Автор
	where Экспонаты.[Код вида экспоната] = Вид_экспоната.Код and Экспонаты.[Код автора]=Автор.Код and Экспонаты.[Код зала]=Залы.Код
go	
		
	
DROP VIEW ПросмотрЭкскурсий
go
CREATE VIEW ПросмотрЭкскурсий(id,  [ФИО сотрудника],[Текст отзыва], [Дата экскурсии] , [Описание экскурсии], [Название экскурсии], [Цена экскурсии])
as 
	Select Экскурсии.Код, ФИО, Текст, CONVERT(VARCHAR(10), Экскурсии.Дата, 111), Описание,Экскурсии.Название , Цена  from Отзыв, Сотрудники, Экскурсии
                 where Сотрудники.Код = Экскурсии.[Код сотрудника]  and Экскурсии.[Код] = Отзыв.[Код экскурсии] 
go	

	
DROP VIEW viewОтзыв
go
CREATE VIEW viewОтзыв(id,  [Текст], [Название экскурсии],[Код экскурсии])
as 
	Select Отзыв.Код,Текст, Название,[Код экскурсии] from (Отзыв INNER JOIN Экскурсии on Экскурсии.Код=Отзыв.[Код экскурсии])
go	

DROP VIEW viewЭкскурсия
go
CREATE VIEW viewЭкскурсия(id, [Дата], [Описание экскурсии],[Название экскурсии],[ФИО сотрудника],[Код сотрудника], [Цена экскурсии])
as 
	Select Экскурсии.Код, CONVERT(VARCHAR(10), Дата, 111) as [Дата], Описание ,Название , ФИО ,[Код сотрудника], Цена from (Экскурсии INNER JOIN Сотрудники on Сотрудники.Код=Экскурсии.[Код сотрудника])
go	

DROP VIEW viewЭкспонат
go

CREATE VIEW viewЭкспонат(id,[Название экспоната], [Вид экспоната] , [Название зала],[ФИО автора], [Код вида экспоната], [Код зала], [Код автора])
as 
	Select Экспонаты.Код,Экспонаты.Название, [Вид экспоната] ,Залы.Название, ФИО , [Код вида экспоната], [Код зала], [Код автора]  
	from ((Экспонаты INNER JOIN Вид_экспоната on Вид_экспоната.Код=Экспонаты.[Код вида экспоната] ) 
           INNER JOIN Залы on Залы.Код=Экспонаты.[Код зала]) INNER JOIN Автор on Автор.Код = Экспонаты.[Код автора] 
go	

DROP VIEW viewРеставрация
go
CREATE VIEW viewРеставрация(id, [Дата] , [Название экспоната], [ФИО сотрудника], [Код экспоната], [Код сотрудника] )
as 
	Select Реставрация.Код, CONVERT(VARCHAR(10), Реставрация.Дата, 111) , [Название], ФИО , [Код экспоната], [Код сотрудника]  
	from (Реставрация INNER JOIN Сотрудники on Сотрудники.Код=Реставрация.[Код сотрудника] ) 
          INNER JOIN Экспонаты on Экспонаты.Код=Реставрация.[Код экспоната]  
go	

DROP VIEW viewБилет
go
CREATE VIEW viewБилет(id, [Дата] ,[Название экскурсии],[Фамилия посетителя], [Код экскурсии],[Код посетителя] )
as 
	Select Билеты.Код, CONVERT(VARCHAR(10), Билеты.Дата, 111), Название ,Фамилия, [Код экскурсии],[Код посетителя] 
	from (Билеты INNER JOIN Экскурсии on Экскурсии.Код=Билеты.[Код экскурсии]) Inner join Посетители on Посетители.Код = Билеты.[Код посетителя] 
go

DROP VIEW viewСотрудник
go
CREATE VIEW viewСотрудник(id, ФИО,[Название должности], [Код должности], Логин, Пароль )
as 
	Select Сотрудники.Код, ФИО, Название as [Название должности], [Код должности], Логин, Пароль 
	from (Сотрудники INNER JOIN Должность on Должность.Код=Сотрудники.[Код должности])
go	

create trigger triggerДолжность on Должность
after delete 
as 
if exists (Select * from Сотрудники where [Код должности] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить должность, у которого есть сотрудники.', 16, 2)
  RETURN 
end
go

create trigger triggerЗалы on Залы
after delete 
as 
if exists (Select * from Экспонаты where [Код зала] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить зал, у которого есть экспонат.', 16, 2)
  RETURN 
end
go

create trigger triggerАвтор on Автор
after delete 
as 
if exists (Select * from Экспонаты where [Код автора] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить автора, у которого есть экспонат.', 16, 2)
  RETURN 
end
go

create trigger triggerСотрудники on Сотрудники
after delete 
as 
if exists (Select * from Реставрация where [Код сотрудника] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить сотрудника, у которого есть реставрация.', 16, 2)
  RETURN 
end

if exists (Select * from Экскурсии where [Код сотрудника] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить сотрудника, у которого есть экскурсии.', 16, 2)
  RETURN 
end
go

create trigger triggerПосетители on Посетители
after delete 
as 
if exists (Select * from Билеты where [Код посетителя] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить посетителя, у которого есть билет.', 16, 2)
  RETURN 
end
go

create trigger triggerЭкспонаты on Экспонаты
after delete 
as 
if exists (Select * from Реставрация where [Код экспоната] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить экспонат, у которого есть реставрация.', 16, 2)
  RETURN 
end
go

create trigger triggerЭкскурсии on Экскурсии
after delete 
as 
if exists (Select * from Отзыв where [Код экскурсии] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить экскурсию, у которой есть отзыв.', 16, 2)
  RETURN 
end

if exists (Select * from Билеты where [Код экскурсии] in (Select Код from deleted))
begin
  ROLLBACK
  RAISERROR ('Нельзя удалить экскурсию, у которой есть билет.', 16, 2)
  RETURN 
end
go
-- Каскадное удаление экспонатов при удалении видов экспоната
create trigger trgВид_экспоната on Экспонаты
after delete 
as
begin
  delete from Экспонаты
    where [Код вида экспоната] in (Select Код from deleted)
end
go

-- Каскадное удаление отзывов при удалении экскурсии
create trigger trgЭкскурсия on Отзыв
after delete 
as
begin
  delete from Отзыв
    where [Код экскурсии] in (Select Код from deleted)
end
go
go
drop procedure КоличествоПроданныхБилетовНаЭкскурсию
go
create proc КоличествоПроданныхБилетовНаЭкскурсию
as
Select Название,Цена , Сотрудники.ФИО as [ФИО Экскурсовода], count(*) as [Количество проданных билетов]
  From Экскурсии, Билеты, Сотрудники
  Where Сотрудники.Код=Экскурсии.[Код сотрудника] and Экскурсии.Код=Билеты.[Код экскурсии]
	Group by Экскурсии.Название, ФИО , Цена
	Order by Экскурсии.Название

go
drop procedure UpdateБилеты
go
create proc UpdateБилеты (@Ticket_date date ,  @Excursion_id int, @Visitor_id int , @Ticket_id int )
as
Update Билеты set Дата = @Ticket_date, [Код экскурсии]=@Excursion_id, [Код посетителя]=@Visitor_id  where Код = @Ticket_id

go

drop procedure UpdateЗалы
go
create proc UpdateЗалы (@Room_floor smallint, @Room_square smallint, @Room_name varchar(50), @Room_id int)
as
Update Залы set Этаж = @Room_floor, [Площадь(м2)] = @Room_square, Название = @Room_name  where Код = @Room_id
go

drop procedure UpdateРеставрация
go
create proc UpdateРеставрация ( @Restoration_date date, @Exhibit_id int, @Worker_id int, @Restoration_id int )
as
Update Реставрация set Дата = @Restoration_date, [Код экспоната] = @Exhibit_id, [Код сотрудника] = @Worker_id where Код = @Restoration_id
go

drop procedure UpdateЭкскурсии
go
create proc UpdateЭкскурсии (@Excursion_date date, @Excursion_name varchar(80), @Excursion_description varchar(100), @Worker_id int, @Excursion_cost money ,@Excursion_id int)
as
Update Экскурсии set Дата = @Excursion_date, Название = @Excursion_name, Описание=@Excursion_description, [Код сотрудника]=@Worker_id, Цена=@Excursion_cost where Код = @Excursion_id
go

drop procedure UpdateОтзыв
go
create proc UpdateОтзыв ( @Comment_text varchar(100), @Excursion_id int , @Comment_id int )
as
Update Отзыв set Текст = @Comment_text, [Код экскурсии]=@Excursion_id where Код = @Comment_id
go



drop function ExcursionDateBetween
go
create function ExcursionDateBetween(@date1 date, @date2 date, @worker_id int)
  returns table
as
return
Select  Сотрудники.Код, ФИО, Текст as [Текст отзыва],CONVERT(VARCHAR(10), Дата, 111) as Дата, Описание, Экскурсии.Название  from Отзыв, Сотрудники, Экскурсии 
                 where Сотрудники.Код = Экскурсии.[Код сотрудника]  and Экскурсии.[Код] = Отзыв.[Код экскурсии] and Сотрудники.Код=@worker_id and Дата BETWEEN @date1 and @date2
go

drop function RestorationDateBetween
go
create function RestorationDateBetween(@date1 date, @date2 date, @worker_id int)
  returns table
as
return
Select  Сотрудники.Код, ФИО, Название as [Название экспоната],CONVERT(VARCHAR(10), Дата, 111) as Дата  from Экспонаты , Сотрудники, Реставрация 
                 where Сотрудники.Код = Реставрация.[Код сотрудника]  and Экспонаты.[Код] = Реставрация.[Код экспоната] and Сотрудники.Код=@worker_id and Дата BETWEEN @date1 and @date2
go

