
USE [UMRRequestor]
GO

/****** Object:  Table [dbo].[Requests]    Script Date: 9/7/2025 5:50:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Requests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectTitle] [nvarchar](255) NOT NULL,
	[ProjectStatus] [varchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Reason] [nvarchar](max) NULL,
	[PIPP] [varchar](50) NULL,
	[UserStory] [nvarchar](max) NULL,
	[ITInstallDate] [datetime] NULL,
	[Ownership] [varchar](100) NULL,
	[SMEId] [varchar](50) NULL,
	[PriorityRanking] [varchar](100) NULL,
	[Contingency] [nvarchar](255) NULL,
	[Risk] [nvarchar](255) NULL,
	[BlueChip] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[Notes] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PIPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Requests] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO


