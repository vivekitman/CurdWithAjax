USE [Employees]
GO
/****** Object:  StoredProcedure [dbo].[SpEmpDelete]    Script Date: 19-02-2024 05:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[SpEmpDelete]
 @id int
 
 
 As 
 begin

 Delete from  emp  where id=@id
 end

 USE [Employees]
GO
/****** Object:  StoredProcedure [dbo].[SpEmpDelete]    Script Date: 19-02-2024 05:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[SpEmpDelete]
 @id int
 
 
 As 
 begin

 Delete from  emp  where id=@id
 end

 USE [Employees]
GO
/****** Object:  StoredProcedure [dbo].[SPEmpSingleData]    Script Date: 19-02-2024 05:48:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[SPEmpSingleData](
@id int
)
as 
begin 
select * from emp where id = @id
end
