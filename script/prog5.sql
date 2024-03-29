USE [prog5]
GO
/****** Object:  StoredProcedure [dbo].[sp_a_Persona]    Script Date: 02/06/2021 0:49:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_a_Persona](@dni varchar(13), 
					@nombre varchar(50),
					@apellido varchar(50), 
					@curso varchar(30), 
					@anio int)as
insert into Personas(dni, nombre, apellido, curso, anio, fechaAlta)
values(@dni, @nombre, @apellido, @curso, @anio, getdate())
GO
/****** Object:  StoredProcedure [dbo].[sp_l_general_personas]    Script Date: 02/06/2021 0:49:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_l_general_personas] as
select * from Personas  
GO
/****** Object:  StoredProcedure [dbo].[sp_l_personas]    Script Date: 02/06/2021 0:49:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_l_personas](@dni varchar(13)) as
select * from Personas where dni = @dni 

GO
/****** Object:  Table [dbo].[Personas]    Script Date: 02/06/2021 0:49:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](13) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[curso] [varchar](30) NOT NULL,
	[anio] [int] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Personas_1] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
