USE [todoapp_db]
GO
/****** Object:  Table [dbo].[tareas]    Script Date: 24/10/2022 05:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tareas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](200) NOT NULL,
	[estadotarea] [bit] NOT NULL,
	[fechacreacion] [datetime2](7) NOT NULL,
	[fechafin] [datetime2](7) NULL,
	[notas] [text] NOT NULL,
	[prioridad] [int] NOT NULL,
 CONSTRAINT [PK_tareas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spconsultar]    Script Date: 24/10/2022 05:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spconsultar]
AS begin
	SELECT * from tareas;
end
GO
/****** Object:  StoredProcedure [dbo].[speliminar]    Script Date: 24/10/2022 05:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[speliminar]
@Id int

AS begin
DELETE FROM tareas
WHERE id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[spguardar]    Script Date: 24/10/2022 05:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spguardar]
	@titulo varchar(200),
	@estadotarea bit,
	@fechacreacion datetime2(7),		
	@fechafin datetime2(7),		
	@notas text,
	@prioridad int
AS begin
	INSERT into tareas(titulo, estadotarea, fechacreacion, fechafin, notas, prioridad)
	VALUES(@titulo, @estadotarea, @fechacreacion, @fechafin, @notas, @prioridad)
END
GO
/****** Object:  StoredProcedure [dbo].[spmodificar]    Script Date: 24/10/2022 05:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spmodificar]
	@id int,
	@titulo varchar(200),
	@estadotarea bit,
	@fechafin datetime2(7),
	@notas text,
	@prioridad int
AS BEGIN
	UPDATE tareas SET
	titulo = @titulo,
	estadotarea = @estadotarea,
	fechafin = @fechafin,
	notas = @notas,
	prioridad = @prioridad
	WHERE id = @id
END
GO
