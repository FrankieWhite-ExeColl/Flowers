create table [dbo].[Flowers](
[Id]	INT	Identity (1,1) NOT NULL,
[Name]	VARCHAR (MAX) NULL,
[Flowering]	VARCHAR (MAX) NULL,
[Colour]	VARCHAR (MAX) NULL,
[Size]	INT NULL,
PRIMARY KEY CLUSTERED ([id] asc)
);