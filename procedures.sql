USE [AgendClients]
GO

/****** Object:  StoredProcedure [dbo].[insertArea]    Script Date: 18/06/2021 15:15:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[insertArea]
@id int = null output,
@nameArea varchar (50)
as 
begin
insert into area(
nameArea
)
values (
@nameArea
)
set @id = SCOPE_IDENTITY()
end
GO

/****** Object:  StoredProcedure [dbo].[insertClientUser]    Script Date: 18/06/2021 15:15:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[insertClientUser]
@id int = null output,
@email varchar (50),
@pass varchar (50)

as 
begin
insert into clientUser(
email,
pass
)
values (
@email,
@pass
)
set @id = SCOPE_IDENTITY()
end;
GO

/****** Object:  StoredProcedure [dbo].[insertContact]    Script Date: 18/06/2021 15:15:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[insertContact]
@id int = null output,
@firstName VARCHAR(50),
@secondName varchar (50),
@gen char (1),
@idCountry int ,
@city varchar(50),
@cIntern bit,
@idOrg int ,
@idArea int ,
@dateAdmission datetime,
@active bit,
@direction varchar(50),
@phone varchar (50),
@cel varchar(50),
@email varchar (50),
@skype varchar (50)
as 
begin
insert into contacts(
firstName,
secondName,
gen,
idCountry, 
city,
cIntern, 
idOrg,
idArea, 
dateAdmission,
active, 
direction, 
phone,
cel,
email, 
skype
)
values (
@firstName,
@secondName, 
@gen,
@idCountry, 
@city,
@cIntern, 
@idOrg,
@idArea, 
@dateAdmission,
@active, 
@direction, 
@phone,
@cel,
@email, 
@skype )
set @id = SCOPE_IDENTITY()
end
GO

/****** Object:  StoredProcedure [dbo].[insertCountry]    Script Date: 18/06/2021 15:15:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[insertCountry]
@id int = null output,
@countryName varchar (50),
@abbrevation varchar(50)
as 
begin
insert into country(
countryName,
abbrevation
)
values (
@countryName,
@abbrevation)
set @id = SCOPE_IDENTITY()
end
GO

/****** Object:  StoredProcedure [dbo].[insertOrg]    Script Date: 18/06/2021 15:15:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[insertOrg]
@id int = null output,
@nameOrg varchar (50)

as 
begin
insert into org(
nameOrg


)
values (
@nameOrg)
set @id = SCOPE_IDENTITY()
end;
GO


