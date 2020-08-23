use master
create database RoboCallSurvey
go

USE [RoboCallSurvey]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertisingCampaign](
	[Id] [int] NOT NULL,
	[AdvertisingText] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[ServiceDateStart] [datetime] NOT NULL,
	[ServiceDateEnd] [datetime] NOT NULL,
	[AskToConnect] [bit] NOT NULL,
	[ExtendedInfo] [nvarchar](max) NULL,
	[TellExtendedInfo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AdvertisingCampaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerCode] [nvarchar](max) NULL,
	[CallAttempt_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallAttempts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CallDateTime] [datetime] NOT NULL,
	[CallAttemptState] [int] NOT NULL,
	[RecordingName] [nvarchar](128) NULL,
	[CallTask_Id] [int] NULL,
 CONSTRAINT [PK_dbo.CallAttempts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[NextTryDateTime] [datetime] NULL,
	[InProcessing] [bit] NOT NULL,
	[Campaign_Id] [int] NOT NULL,
	[IsReady] [bit] NOT NULL DEFAULT ((0)),
	[Fullname] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CallTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallTaskAdvertising](
	[Id] [int] NOT NULL,
	[ClientId] [nvarchar](max) NULL,
	[ClientInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CallTaskAdvertising] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallTaskCheckup](
	[Id] [int] NOT NULL,
	[BirthDate] [datetime] NOT NULL DEFAULT ('1900-01-01T00:00:00.000'),
	[Document] [nvarchar](max) NULL,
	[OrgCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CallTaskCheckup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallTaskNotification](
	[Id] [int] NOT NULL,
	[ClientData] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CallTaskNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallTaskSurvey](
	[Id] [int] NOT NULL,
	[ClientData] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CallTaskSurvey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TurnedOn] [bit] NOT NULL,
	[Ready] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[ChangedDateTime] [datetime] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OrgName] [nvarchar](max) NULL,
	[MaxTries] [int] NOT NULL,
	[StartCallDateTime] [datetime] NOT NULL,
	[EndCallDateTime] [datetime] NOT NULL,
	[AskIfReadyToTalk] [bit] NOT NULL DEFAULT ((0)),
	[IdentifyByName] [bit] NOT NULL DEFAULT ((0)),
	[SendReportPolicy] [int] NOT NULL DEFAULT ((0)),
	[RetryInterval] [int] NOT NULL DEFAULT ((0)),
	[LastReportDate] [datetime] NULL,
	[RepeatQuestionTimes] [int] NOT NULL DEFAULT ((0)),
	[UseCustomGreeting] [bit] NOT NULL DEFAULT ((0)),
	[Phone] [nvarchar](max) NULL,
	[DialAccount_Id] [int] NULL,
	[OperatorAccount_Id] [int] NULL,
	[MaxThreads] [int] NOT NULL DEFAULT ((0)),
	[MaxSuccessfulCalls] [int] NOT NULL DEFAULT ((0)),
	[SuccessfulResultCode] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Campaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckupCampaign](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CheckupCampaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicAdvertisingCampaigns](
	[Clinic_Id] [int] NOT NULL,
	[AdvertisingCampaign_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClinicAdvertisingCampaigns] PRIMARY KEY CLUSTERED 
(
	[Clinic_Id] ASC,
	[AdvertisingCampaign_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clinics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Clinics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Priority] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masks](
	[QuestionType] [int] NOT NULL,
	[Preffix] [nvarchar](max) NULL,
	[Suffix] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Masks] PRIMARY KEY CLUSTERED 
(
	[QuestionType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationCampaign](
	[Id] [int] NOT NULL,
	[AdvertisingText] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NotificationCampaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnaires](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[ChangedDateTime] [datetime] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Locked] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Questionnaires] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChangeDateTime] [datetime] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[QuestionType] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Campaign_Id] [int] NULL,
	[Questionnaire_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[Working] [bit] NOT NULL,
	[StartWorking] [time](7) NOT NULL,
	[EndWorking] [time](7) NOT NULL,
	[StartWorkingWeekend] [time](7) NOT NULL,
	[EndWorkingWeekend] [time](7) NOT NULL,
	[EmailHost] [nvarchar](max) NULL,
	[EmailPort] [int] NOT NULL,
	[EmailLogin] [nvarchar](max) NULL,
	[EmailPassword] [nvarchar](max) NULL,
	[EmailFromAddress] [nvarchar](max) NULL,
	[EmailFromName] [nvarchar](max) NULL,
	[EmailSubject] [nvarchar](max) NULL,
	[EmailBcc] [nvarchar](max) NULL,
	[WorkDaysMask] [int] NOT NULL,
	[SendReportPolicy] [int] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[DefaultOperatorPhone] [nvarchar](max) NULL,
	[DefaultRetryInterval] [int] NOT NULL DEFAULT ((0)),
	[OrganizationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SipAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Server] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[SIPExtraParams] [nvarchar](max) NULL,
	[Prefix] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SipAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecificDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecificDate] [datetime] NOT NULL,
	[DateType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SpecificDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyCampaign](
	[Id] [int] NOT NULL,
	[RetryOnFail] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.SurveyCampaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
