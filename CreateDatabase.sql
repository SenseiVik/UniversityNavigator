CREATE DATABASE [UniversityNavigator];
GO

USE [UniversityNavigator]
GO
/****** Object:  Table [dbo].[Audience]    Script Date: 05/24/2020 1:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audience](
	[AudienceId] [varchar](30) NOT NULL,
	[Floor] [int] NOT NULL,
	[Building] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AudienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudienceImage]    Script Date: 05/24/2020 1:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudienceImage](
	[Audience] [varchar](30) NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Audience] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudienceQuickSearch]    Script Date: 05/24/2020 1:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudienceQuickSearch](
	[Audience] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Audience] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AudienceImage]  WITH CHECK ADD  CONSTRAINT [FK_AudienceImageRef] FOREIGN KEY([Audience])
REFERENCES [dbo].[Audience] ([AudienceId])
GO
ALTER TABLE [dbo].[AudienceImage] CHECK CONSTRAINT [FK_AudienceImageRef]
GO
ALTER TABLE [dbo].[AudienceQuickSearch]  WITH CHECK ADD  CONSTRAINT [FK_AudienceQuickSearch] FOREIGN KEY([Audience])
REFERENCES [dbo].[Audience] ([AudienceId])
GO
ALTER TABLE [dbo].[AudienceQuickSearch] CHECK CONSTRAINT [FK_AudienceQuickSearch]
GO
/****** Object:  Trigger [dbo].[AudienceOnInsertTrigger]    Script Date: 05/24/2020 1:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[AudienceOnInsertTrigger]
on [dbo].[Audience]
after insert
as
begin
	set nocount on;
	insert into AudienceQuickSearch(Audience)
	select i.AudienceId from inserted as i
end

GO
ALTER TABLE [dbo].[Audience] ENABLE TRIGGER [AudienceOnInsertTrigger]
GO
