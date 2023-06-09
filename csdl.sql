USE [master]
GO
/****** Object:  Database [DBHocLapTrinh]    Script Date: 6/6/2023 4:31:09 PM ******/
CREATE DATABASE [DBHocLapTrinh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBHocLapTrinh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DBHocLapTrinh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBHocLapTrinh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DBHocLapTrinh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBHocLapTrinh] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBHocLapTrinh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBHocLapTrinh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBHocLapTrinh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBHocLapTrinh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBHocLapTrinh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBHocLapTrinh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBHocLapTrinh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBHocLapTrinh] SET  MULTI_USER 
GO
ALTER DATABASE [DBHocLapTrinh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBHocLapTrinh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBHocLapTrinh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBHocLapTrinh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBHocLapTrinh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBHocLapTrinh] SET QUERY_STORE = OFF
GO
USE [DBHocLapTrinh]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Courses]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsFree] [bit] NOT NULL,
	[CourseTypeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTypes]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTypes](
	[CourseTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CourseTypes] PRIMARY KEY CLUSTERED 
(
	[CourseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseVideos]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseVideos](
	[CourseVideoId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[VideoName] [nvarchar](max) NULL,
	[VideoUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CourseVideos] PRIMARY KEY CLUSTERED 
(
	[CourseVideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/6/2023 4:31:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202305151356096_new-db', N'HocLapTrinhAspNet.Migrations.Configuration', 0x1F8B0800000000000400DD5CCD6EE4B811BE07D8771074CA065EB7EDB96C8CEE5D78EDF1C6C8F807D39E416E065BA2DBC24A5447647B6D0479B21CF24879859022A5A6F82351BFDDB3D8C3F650AA6291FC8A2C96EAF3FFFEF3DFF9CF6F49ECBDC20C47295AF8A7C727BE07519086115A2FFC2D79FEE147FFE79FBEFBD3FC6398BC795F8BF73EB0F7A824C20BFF8590CDF96C86831798007C9C444196E2F4991C07693203613A3B3B39F9EBECF47406A90A9FEAF2BCF9E72D225102F37FD07F5EA628801BB205F16D1AC2188B76FA64996BF5EE4002F1060470E1FF2D0D3E81CD6316A1970BBCB983E498CBF8DE451C016ACF12C6CFBE07104A0920D4DAF32F182E4996A2F572431B40FCF8BE81F4BD671063284671BE7BDD754027676C40B39D60A12AD86292262D159E7E10333453C53BCDB35FCE209DC38F74AEC93B1B753E8F0BFF32DD666CE86A57E79771C65EB34FF231173DF2B4178E4A70500CB1FF8EBCCB6D4CB6195C20B82519888FBC87ED2A8E82BFC3F7C7F4378816681BC7B2A1D454FAACD2409B1EB2740333F2FE193E57CCBF097D6F56959EA9E2A5B026C9877983C88733DFBBA38680550C4B4C4853B22469067F85086680C0F001100233BAA43721CC6755B3C1D823FB5DF449A1487DCBF76EC1DB2788D6E465E1D39FBE771DBDC1B06811767C411175452A44B22D6CEAEA2601EBF17BB98238C8A20D47E6C87D3D6451508EE80A06510262DF7BC8E82FB15DFDE87BCB00B095332D63C37CE1EB0C96EA7F49D31802D45A0B5F60A6A319568AA63BF01AAD73945975FADE6718E7AFE09768C3F7B6E3DDE327FE93EE7DD7599A7C4EE38A70F1F4E911646B48A875A9F59525FD7FD0DAC4AF5108535C6364FEC253B1DFA846CA4F2D46565E696BE47D16D23DC9685EFEC86098DCAE9954796832663EDBEDB50E3B305FE1CEBB307BE91076E202FCDD766337D7196E4766FD8CB31F37384B9D9FB470E6027735CE5CE0B6073473BFEB81CD5CFE10C0991BD21D9DA5F8B40143EBB344D1929B3D49D491F7F4258B2777A7614E1DB337190FA64EDE941F199DFC2897DCAF07E52674F19D52702AAFA1573C87FEA6F0BC7CE857741065DC4A7F3F46CC135B6A7AA473130F1C0277F129A75049F523631CE56A0C5B4DA329ECC15311D5ED2C919AB5984D7ED62B64E34675706426B85F3F2EBCA3AD1BBB79D5705E7C4D554F72687D4C4034C289A55E5F01C6BFA759387E472F298277DB64C5103A725F176198418C47EF8779EF7037EA9A9BA0C39EA26E6EA6FDC6D512A6C168077BF0C43457CCD8B56A3B9BF4A8D7C6C62DEAB0B131C1FD6E6C0548DA6E6C6EE01A6E639BF8BE2950D405642AD40DF8EB04B23BF83BEE043226B85F90310BBA80AC909B2CB11191F88F9265BE4C11A1A31EB81F1B5A2F304E83285F042D35556665AAF67E44A1D79CA2E1C657D33C741414A8D18642939A4203786D2E6A7597A780AA5BD5FB174D2F8534CC1896404CE71753278910D1F11FA120DA80B871788A64EB04215B8FB237F5C915DC40C480DF3813439851F6A6B878D38CCD6712745C1055C94CD4AFBA394DA1AEBAC8D3352D7DAD726748E950ED01299309EE6B39089C4C53DCD78409A054B990DBD6D97C3BDFADB0484CB903C7FC656422C8983A9F0C2CA6A9FC0660225F6C6C8B6ABCE5ECD694E73CDCCF2B6322A635E63A21C43012973532A7465AC1C330E87E3D4F800DE91E605B4BD3A560B794FCD2E88E0CD33DB61E6703E1421F86CBE2982F96AD60A18FB85FC783A382C7C22CD2A6123013064837ADAB551E86BF11C3C58D0E4CDCDDB088B4D59567CA9790A89F407711B8726E68D03129C83BB42AE1E1B593A2A272C1A24984550DAA8AAC91A6446C740DE2E21EAE49736F68106640310973C76C10E6B7714D96372BB2127A4CABB1FB6A2DBD68FFB6ADC2DAE91E559AAFC0407312A79B93A64D1FF3AC3A68E709A97E78B44D88FD12E07A0DD08650C0B971468C81FF283352FD6CA4CF853D8A6D8E6325830B1FAC19B931721D65CC955CB23E646B44D6189349D68A5DA366BCA628AC71C63A8C564E26EA83B585184D418664A9D8E36A866A082B9AA6AA66A0457EA83C13CB67F3192F44160DF399A562797E0B369B08ADA50A66D1E22D79F9F2E50FCBF615BD09D7310BB0A1B0B7B4B6EC89A4195843E529C37908AFA30C932B40C00A30B7BC0C13ED35630460394F8A2EAB87BCBE5EC54153BC5F146135D611198226A1E39A8E3161E1569E36D5DC5917F4583539884166FDEE7F99C6DB04355DDE9A34F164BFAE8BB7BB6B13995659916872D751A9D69535551EB8EB13E508B226D1D4625CA2EEB63230D1D676AE8B949E3EDBB6641F735E05415AA8ADE155D94054F8B7700E1EB90CE82079CCDBD549CCC2C34FB94DE3AE1653D6B66B3DB0C51351D680ABC7EF195D97CF225DBF7E6545A3BE80965AC9669D436C9E52C9A2AC4A6A6EA92B2F4AD454E5AD07832B6B30D80151FCD2D91E4B1639DBDC96B57DF2D45A2A05EBF414F92F598D2D2766D7321CFEA4C23D6D64BCB9C5BE2695EE557636A9FD6030688BD13B4030CF5CB447A0596C5CE0EC6ACD643DBB56774DA2984C56239A5AC45565A95825B42A5B5B68926BC12ACAE407EEFACA7A2F5957D9E8AEA7486CCA6A6CC9CEBDB902BF700EE20A791EAEBD2B98C58699549B16DD0D0E2CFACAF39283AC8A4993C3AA98C5ACF3290A7F2A336A2C22AAD322CA792AC7076F9AF60A5996E2540F58D1383146B40C8DFA4AD97B99A951323273911D69269A6BE912FE0AABBE4F5F6928992DFCE53B263039662F1C2FFF195FC6513E29C50BB70045CF10135E7FE69F9D9C9E292CF5C3618CCF300E63437649A78D57576B62C676C4E6B7B150AE13F3432ED244AF200B5E40F6E704BC7D2FEB6B5D22D74B93816CDD4B5F854D128E4BA85E4564103275BEE2DAF7C71B14C2B785FFAF5CF0DCBBF9C7932C7BE4E561FBB977E2FDBBC1882E94DDCE1E30245376144F50C9B12DD0D68960DA792687A5758EB8AB7405722B10EB9D6B04D05EFB864AF21C03168634C4B42CC5514050A550B942804BF502C05ED1A7912043FA9B0C4382EC796CB5E3FB7580E33064BB51C0A8F2EB7AED09150E5DBFA844E1C9F553A673E17AE953F86EBD74556947AE1EC9A5C60869F464C394B4AB51203E76F0A26702A624118D13F3C9BCA103B9F828FC9F015672208ECF60A49E7D3078F641D9F9C3F2733A911F8CE578DD693D3DF0B017AECDB7409B7062D70C020151253C114162EA65B77D8E3EB80577E5C9F462C64CBBD696EFB0A3D05FDCD7F95B60BCF422B938A164405ECB5454166738ED9DBDA297B8AA6B652283D4B052F8379F851FAED831CD834E5BBDB89DB2D2C058B17762243AD4515A9A182DF6AECC140233E7C54E7931E9B7149C9BE83056368C49AFB9BCDB4494B1F2644C6A8D55E7ED283426B50742AEB1B0691CA82306C94326CE38986B0FC82DA59607C38AE936C48AEF4AB57F07447CD1F81B7B1AD040DC168DCED248DC699C8061F82B7A15043D8BA53FCA4F63001CAD772AD89FE84730A89CC2E53B37E8392D8201C5A2E21525BF730B0908E9117D9191E81904843E0E20C6F91F79F90AE26D9E5F5EC1F006DD6FC9664BE89061B28A2B7F0387051575FDE7249DAACDF3FBFC5B3A1E6208D4CC887DD6B847BF6CA3382CEDBE3624642D2A58B42212796C2D094BE8ADDF4B4D7729725424A6AF0CB21E61B289A9327C8F96E01576B18D42EF135C83E0BD2866B12B695E88EAB4CFAF22B0CE4082858E9D3CFD27C57098BCFDF47F97A65DE99B620000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [CourseName], [Image], [Description], [Price], [IsFree], [CourseTypeId]) VALUES (1, N'Lập trình C++', N'638198375689156662cpp-can-ban-va-nen-tang-lap-trinh.png', N'<p>Ng&ocirc;n ngữ C++ l&agrave; g&igrave;? Học C++ bạn c&oacute; thể l&agrave;m được g&igrave;? Đ&acirc;y l&agrave; những c&acirc;u hỏi rất cơ bản v&agrave; c&oacute; thể nhiều bạn đ&atilde; biết c&acirc;u trả lời. Nhưng liệu bạn đ&atilde; thực sự hiểu được bản chất của vấn đề ở đ&acirc;y? Bằng việc c&oacute; c&acirc;u trả lời cho c&aacute;c c&acirc;u hỏi n&agrave;y, FPT Software Academy sẽ gi&uacute;p bạn biết được rằng bạn c&oacute; n&ecirc;n học lập tr&igrave;nh C++ hay kh&ocirc;ng?</p>

<p>&nbsp;</p>

<h2><strong>1.&nbsp;Ng&ocirc;n ngữ C++ l&agrave; g&igrave;?</strong></h2>

<p><a href="https://fsoft-academy.edu.vn/tin-tuc-su-kien/su-khac-biet-giua-ngon-ngu-lap-trinh-c-va-c/">Ng&ocirc;n ngữ lập tr&igrave;nh C++</a>&nbsp;l&agrave; một ng&ocirc;n ngữ lập tr&igrave;nh hướng đối tượng(OOP &ndash; Object-oriented programming) được ph&aacute;t triển bởi Bjarne Stroustrup. C++ l&agrave; ng&ocirc;n ngữ lập tr&igrave;nh được ph&aacute;t triển tr&ecirc;n n&ecirc;n tảng của ng&ocirc;n ngữ lập tr&igrave;nh C. Do đ&oacute;, C++ c&oacute; song song cả 2 phong c&aacute;ch(style) lập tr&igrave;nh hướng cấu tr&uacute;c giống C v&agrave; c&oacute; th&ecirc;m phong c&aacute;ch hướng đối tượng. Trong nhiều trường hợp, C++ sử dụng kết hợp cả 2 style tr&ecirc;n. Do đ&oacute;, n&oacute; được xem l&agrave; một ng&ocirc;n ngữ&nbsp;&ldquo;lai tạo&rdquo;.</p>

<p>Ng&ocirc;n ngữ C++ l&agrave; một ng&ocirc;n ngữ lập tr&igrave;nh cấp trung. Bởi v&igrave; n&oacute; c&oacute; c&aacute;c t&iacute;nh chất của cả ng&ocirc;n ngữ lập tr&igrave;nh bậc thấp(Pascal, C&hellip;) v&agrave; ng&ocirc;n ngữ lập tr&igrave;nh bậc cao(C#, Java, Python&hellip;).</p>

<p>Ng&ocirc;n ngữ lập tr&igrave;nh C++(C plus plus) c&oacute; đu&ocirc;i mở rộng l&agrave;&nbsp;.cpp</p>

<p>&nbsp;</p>

<h2><strong>2. Điểm mạnh của ng&ocirc;n ngữ C++ l&agrave; g&igrave;?</strong></h2>

<p><img alt="Điểm mạnh của C++ là gì?" src="https://lh6.googleusercontent.com/uObrytairhZawU3tfjHfKyYaUJIiQSora0BdcZJ_O35vWhGEuaIHrV3GxqdaG3ScknNR8YiQaoDYGLXqMJ4m80P7JZU2BW4HTagGR4F9ln5c0m1MW20hjLxXKeywoEJQqXmXCe52" style="height:600px; width:1200px" /></p>

<p>&nbsp;</p>

<p>N&oacute;i đến C++ th&igrave; kh&ocirc;ng thể kh&ocirc;ng nhắc đến những điểm mạnh của n&oacute; dưới đ&acirc;y:</p>

<ul>
	<li><strong>T&iacute;nh phổ biến</strong>&nbsp;: C++ l&agrave; một trong những ng&ocirc;n ngữ lập tr&igrave;nh phổ biến tr&ecirc;n thế giới.</li>
	<li><strong>T&iacute;nh thực thi nhanh</strong>: Nếu bạn r&agrave;nh C++ th&igrave; bạn c&oacute; thể lập tr&igrave;nh nhanh. Một trong những mục ti&ecirc;u của C++ l&agrave; khả năng thực thi. V&agrave; nếu bạn cần th&ecirc;m c&aacute;c t&iacute;nh năng cho chương tr&igrave;nh, C++ cho ph&eacute;p bạn d&ugrave;ng ng&ocirc;n ngữ Assembly (Hợp ngữ) &ndash; Ng&ocirc;n ngữ lập tr&igrave;nh bậc thấp nhất &ndash; để giao tiếp trực tiếp với phần cứng của m&aacute;y t&iacute;nh.</li>
	<li><strong>Thư viện đầy đủ</strong>: C&oacute; rất nhiều t&agrave;i nguy&ecirc;n cho người lập tr&igrave;nh bằng C++, bao gồm cả đồ hoạ API, 2D, 3D, vật l&yacute; c&aacute;c thiết bị &acirc;m thanh hỗ trợ gi&uacute;p cho lập tr&igrave;nh vi&ecirc;n dễ d&agrave;ng thực thi.</li>
	<li><strong>Đa m&ocirc; h&igrave;nh</strong>: C++ cho ph&eacute;p bạn lập tr&igrave;nh theo cấu tr&uacute;c tuyến t&iacute;nh, hướng chức năng, hướng đối tượng đa dạng tuỳ theo y&ecirc;u cầu của người lập tr&igrave;nh</li>
</ul>

<p>C++ đ&aacute;ng để học v&agrave; cần phải học khi bắt đầu muốn trở th&agrave;nh một lập tr&igrave;nh vi&ecirc;n đ&uacute;ng nghĩa. C++ l&agrave; căn bản v&agrave; l&agrave; nền tảng định hướng cho việc tiếp cận sau n&agrave;y với c&aacute;c ng&ocirc;n ngữ lập tr&igrave;nh kh&aacute;c. Vậy bạn nghĩ sao? Ch&uacute;ng ta c&ugrave;ng bắt tay v&agrave;o học lập tr&igrave;nh C++ ngay n&agrave;o!</p>
', CAST(150000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Image], [Description], [Price], [IsFree], [CourseTypeId]) VALUES (3, N'Làm website với PHP', N'638200974134676724download.png', N'<p>Lập tr&igrave;nh website PHP</p>
', CAST(200000.00 AS Decimal(18, 2)), 0, 4)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Image], [Description], [Price], [IsFree], [CourseTypeId]) VALUES (4, N'Lập trình Android', N'638216643302495032download (18).jpg', N'<h2>GIỚI THIỆU</h2>

<p>Nếu bạn l&agrave; người mới bắt đầu về lập tr&igrave;nh hoặc muốn bắt đầu từ m&ocirc;n ng&ocirc;n ngữ n&agrave;o đ&oacute; để định h&igrave;nh nền m&oacute;ng sự ph&aacute;t triển tương lai cho ng&agrave;nh c&ocirc;ng nghệ th&ocirc;ng tin th&igrave; kh&ocirc;ng thể n&agrave;o bỏ qua c&aacute;c ng&ocirc;n ngữ nền tảng như Java, C, C++ &hellip;</p>

<p>Kh&oacute;a học lập tr&igrave;nh android sẽ gi&uacute;p cho c&aacute;c bạn tiếp cận ng&ocirc;n ngữ Java một c&aacute;ch dễ hiễu qua c&aacute;c ứng dụng thực tế như App Freaking Math, App đo&aacute;n số ngẫu nhi&ecirc;n, App nghe nhạc, App chat &hellip;</p>

<p>Kh&oacute;a học b&aacute;m s&aacute;t v&agrave;o thực tiễn để gi&uacute;p cho học vi&ecirc;n c&oacute; thể thoải m&aacute;i ph&aacute;t triển &yacute; tưởng v&agrave; thực hiện n&oacute;</p>

<p><a href="https://khoapham.vn/khoapham.vn#"><img alt="android" src="https://khoapham.vn/public/images/android/android-1.png" /></a></p>

<h2>MỤC TI&Ecirc;U KH&Oacute;A HỌC</h2>

<p>Ho&agrave;n tất kh&oacute;a học, học vi&ecirc;n đủ khả năng:</p>

<p>- Nắm vững kĩ năng lập tr&igrave;nh Android tr&ecirc;n bất k&igrave; thiết bị n&agrave;o</p>

<p>- Biết c&aacute;ch tự đăng k&iacute; t&agrave;i khoản upload ứng dụng &amp; tự kiếm tiền bằng app do ch&iacute;nh m&igrave;nh thiết kế</p>

<p>- Nắm r&otilde; quy tr&igrave;nh hoạt động của Google Play Store</p>

<p>- Nắm r&otilde; c&aacute;ch quản l&yacute; dữ liệu tr&ecirc;n mọi nền: SQLite, Android kết nối PHP&amp;MySQL. jSON Parse, XML Parser. Gi&uacute;p học vi&ecirc;n l&agrave;m chủ c&ocirc;ng nghệ c&aacute;c ứng dụng c&oacute; dữ liệu động một c&aacute;ch chuy&ecirc;n nghiệp.</p>

<p>- Học vi&ecirc;n đủ khả năng ứng tuyển vị tr&iacute; lập tr&igrave;nh Android tại c&aacute;c doanh nghiệp phần mềm.</p>

<p>- Nếu chăm chỉ học, c&oacute; thể tự th&agrave;nh lập nh&oacute;m, c&ocirc;ng ty lập tr&igrave;nh Android.</p>
', CAST(0.00 AS Decimal(18, 2)), 1, 2)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseTypes] ON 

INSERT [dbo].[CourseTypes] ([CourseTypeId], [TypeName]) VALUES (1, N'Lập trình cơ bản')
INSERT [dbo].[CourseTypes] ([CourseTypeId], [TypeName]) VALUES (2, N'Lập trình ứng dụng')
INSERT [dbo].[CourseTypes] ([CourseTypeId], [TypeName]) VALUES (4, N'Lập trình website')
SET IDENTITY_INSERT [dbo].[CourseTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseVideos] ON 

INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (1, 1, N'Bài 1 : Làm quen với C++', N'https://www.youtube.com/embed/74B6PXO97Tw')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (2, 3, N'Chương 1: Làm quen với PHP', N'https://www.youtube.com/embed/JHhgnaoNBtA')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (3, 1, N'Bài 2 : Toán tử cơ bản C++', N'https://www.youtube.com/embed/y-_fNgvSfjc')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (4, 3, N'Chương 2: Lập trình cơ bản với lệnh PHP', N'https://www.youtube.com/embed/SK02FR9IWs0')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (5, 1, N'Bài 3 : Cấu trúc rẽ nhánh trong C++', N'https://www.youtube.com/embed/QH-nyFW3c0s')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (6, 1, N'Bài 4 : Vòng lặp trong C++', N'https://www.youtube.com/embed/O0Q5K0m6mvY')
INSERT [dbo].[CourseVideos] ([CourseVideoId], [CourseId], [VideoName], [VideoUrl]) VALUES (8, 4, N'Bài 1: Cài đặt Android Studio Preview', N'https://www.youtube.com/embed/2CKuiSp_uOQ')
SET IDENTITY_INSERT [dbo].[CourseVideos] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsId], [Title], [Image], [Content]) VALUES (2, N'Tại sao nên học khóa học lập trình ngắn hạn?', N'638216649166715232khoa-hoc-lap-trinh-2.jpg', N'<p>C&aacute;c kh&oacute;a học lập tr&igrave;nh ngắn hạn gần đ&acirc;y đang được rất nhiều bạn quan t&acirc;m, kh&ocirc;ng chỉ c&aacute;c bạn đang theo học chuy&ecirc;n ng&agrave;nh CNTT m&agrave; c&ograve;n cả những người muốn chuyển ng&agrave;nh. Vậy tại sao n&ecirc;n tham gia kh&oacute;a học lập tr&igrave;nh n&agrave;y, c&ugrave;ng VTI Academy t&igrave;m hiểu qua b&agrave;i viết dưới đ&acirc;y</p>

<h2><strong>1. Tại sao bạn n&ecirc;n tham tham gia c&aacute;c kh&oacute;a học lập tr&igrave;nh ngắn hạn?</strong></h2>

<ul>
	<li>
	<h3>Đối với những người đ&atilde; c&oacute; kiến thức nền tảng về CNTT</h3>
	</li>
</ul>

<p>Những bạn sinh vi&ecirc;n chuy&ecirc;n ng&agrave;nh CNTT tại c&aacute;c trường Đại học, Cao đẳng&hellip; l&agrave; những bạn c&oacute; nhu cầu tham gia kh&oacute;a học lập tr&igrave;nh rất cao. Một trong những l&yacute; do khiến c&aacute;c bạn ấy theo học chương tr&igrave;nh n&agrave;y c&oacute; thể kể đến đ&oacute; l&agrave;: kiến thức trong trường lan man, kh&oacute; hiểu, c&agrave;ng học c&agrave;ng nản, kh&ocirc;ng được join v&agrave;o c&aacute;c dự &aacute;n thực tế để thực h&agrave;nh tốt hơn, c&aacute;c c&ocirc;ng nghệ ở trường dạy kh&ocirc;ng được update theo s&aacute;t với sự thay đổi từng ng&agrave;y của ng&agrave;nh CNTT&hellip;</p>

<p>V&igrave; thế m&agrave; khi ra trường, c&aacute;c bạn thường kh&oacute; xin được việc hoặc phải đi thực tập kh&ocirc;ng lương. Hiện&nbsp;nay chỉ c&oacute; khoảng 16.500 sinh vi&ecirc;n (chiếm gần 30%) trong tổng số 55.000 sinh vi&ecirc;n chuy&ecirc;n ng&agrave;nh CNTT đ&aacute;p ứng được những kỹ năng v&agrave; y&ecirc;u cầu của doanh nghiệp cần.&nbsp;Tham gia c&aacute;c kh&oacute;a học lập tr&igrave;nh gi&uacute;p c&aacute;c bạn &ocirc;n lại kiến thức cũ đồng thời học th&ecirc;m được những điều mới. Sau một thời gian ngắn c&aacute;c bạn đ&atilde; c&oacute; thể tự tin apply v&agrave;o c&aacute;c doanh nghiệp v&agrave; tập đo&agrave;n CNTT với mức lương mong muốn.</p>

<p><img alt="" src="https://vtiacademy.edu.vn/upload/images/khoa-hoc-lap-trinh-1.jfif" /></p>

<ul>
	<li>
	<h3>Đối với những người chưa c&oacute; kiến thức nền tảng về CNTT</h3>
	</li>
</ul>

<p>Trong bối cảnh dịch bệnh, nhiều người đ&atilde; bị rơi v&agrave;o cảnh thất nghiệp hoặc bị cắt giảm lương. V&igrave; thế họ chuyển ng&agrave;nh sang lập tr&igrave;nh bởi đ&acirc;y l&agrave; c&ocirc;ng việc được đ&aacute;nh gi&aacute; l&agrave; &iacute;t biến động v&agrave; c&oacute; thu nhập cao. Một lập tr&igrave;nh vi&ecirc;n mới ra trường, thu nhập khởi điểm từ 400$-500$/th&aacute;ng v&agrave; c&oacute; thể l&ecirc;n tới 2000$-3000$/th&aacute;ng nếu c&oacute; từ 5 năm kinh nghiệm trở l&ecirc;n hoặc đảm nhiệm c&oacute; vị tr&iacute; cao như: nh&oacute;m trưởng, quản l&yacute;&hellip;</p>

<p>Hơn nữa ng&agrave;nh n&agrave;y đang thiếu hụt nh&acirc;n lực trầm trọng.&nbsp;Theo b&aacute;o c&aacute;o thị trường nh&acirc;n lực CNTT Việt Nam năm 2021 của TopDev, trong 5 năm trở lại đ&acirc;y, nhu cầu nh&acirc;n lực CNTT tại Việt Nam kh&ocirc;ng ngừng tăng cao. Trong năm 2021, Việt Nam cần 450.000 nh&acirc;n lực CNTT, tuy nhi&ecirc;n, tổng số lập tr&igrave;nh vi&ecirc;n hiện tại ở Việt Nam hiện l&agrave; 430.000, c&oacute; nghĩa l&agrave; 20.000 vị tr&iacute; lập tr&igrave;nh vi&ecirc;n sẽ kh&ocirc;ng được lấp đầy trong tương lai gần.&nbsp;</p>

<p>&nbsp;Nhu cầu tham gia c&aacute;c kh&oacute;a học lập tr&igrave;nh cũng tăng l&ecirc;n từ đ&acirc;y. Chỉ trong một thời gian ngắn từ 6-8 th&aacute;ng c&aacute;c bạn sẽ được học c&aacute;c kiến thức từ cơ bản cho tới n&acirc;ng cao đ&aacute;p ứng được y&ecirc;u cầu của nh&agrave; tuyển dụng. Sau khi tốt nghiệp, c&aacute;c bạn c&oacute; thể chuyển ng&agrave;nh lập tr&igrave;nh th&agrave;nh c&ocirc;ng với mức lương khởi điểm v&ocirc; c&ugrave;ng cao.</p>

<h2><strong>2. Những ti&ecirc;u ch&iacute; lựa chọn một kh&oacute;a học lập tr&igrave;nh</strong></h2>

<ul>
	<li>
	<h3>Uy t&iacute;n</h3>
	</li>
</ul>

<p>Đầu ti&ecirc;n, c&aacute;c bạn n&ecirc;n chọn những trung t&acirc;m đ&agrave;o tạo về lập tr&igrave;nh uy t&iacute;n. C&oacute; thể t&igrave;m hiểu bằng c&aacute;ch l&ecirc;n c&aacute;c trang chủ của đơn vị n&agrave;y tham khảo, t&igrave;m kiếm tr&ecirc;n Google từ kh&oacute;a li&ecirc;n quan tới t&ecirc;n trung t&acirc;m hoặc hỏi người th&acirc;n, bạn b&egrave;&hellip;Tham khảo th&ecirc;m cả những th&ocirc;ng tin từ&nbsp;tới c&aacute;c học vi&ecirc;n đ&atilde; tốt nghiệp cũng l&agrave; một c&aacute;ch hay m&agrave; bạn n&ecirc;n biết.</p>

<ul>
	<li>
	<h3>Kiến thức</h3>
	</li>
</ul>

<p>Một trong những th&agrave;nh c&ocirc;ng của kh&oacute;a học lập tr&igrave;nh ngắn hạn được đ&aacute;nh gi&aacute; dựa tr&ecirc;n kiến thức v&agrave; điều kiện học: Gi&aacute;o tr&igrave;nh đầy đủ, kiến thức dễ hiểu v&agrave; s&aacute;t thực tế, cung cấp những nền tảng lập tr&igrave;nh để người học dễ d&agrave;ng c&oacute; th&ecirc;m nhiều kiến thức v&agrave; vận dụng sau khi ho&agrave;n th&agrave;nh.</p>

<ul>
	<li>
	<h3>Giảng vi&ecirc;n</h3>
	</li>
</ul>

<p>Đội ngũ giảng dạy phải l&agrave; những người đ&atilde; hoặc đang đảm nhiệm c&aacute;c vị tr&iacute; li&ecirc;n quan đến lập tr&igrave;nh, c&oacute; kinh nghiệm l&agrave;m việc l&acirc;u năm trong ng&agrave;nh CNTT. Họ sẽ biết r&otilde; một lập tr&igrave;nh vi&ecirc;n cần l&agrave;m những g&igrave; v&agrave; doanh nghiệp cần g&igrave; ở lập tr&igrave;nh vi&ecirc;n để chỉ dạy cho bạn.</p>

<ul>
	<li>
	<h3>Cam kết&nbsp;</h3>
	</li>
</ul>

<p>&nbsp;Nh&agrave; tuyển dụng lu&ocirc;n quan t&acirc;m đến kiến thức v&agrave; kinh nghiệm của ứng vi&ecirc;n. V&igrave; vậy đối với những người tham gia c&aacute;c kh&oacute;a học lập tr&igrave;nh ngắn hạn th&igrave; vấn đề xin việc đ&ocirc;i khi sẽ gặp nhiều kh&oacute; khăn. Bạn n&ecirc;n chọn cho m&igrave;nh 1 trung t&acirc;m uy t&iacute;n cam kết việc l&agrave;m cho bạn sau khi ho&agrave;n th&agrave;nh kh&oacute;a học.</p>
')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Password], [PhoneNumber], [Address], [RoleId]) VALUES (1, N'Admin', N'admin@gmail.com', N'25f9e794323b453885f5181f1b624db', N'0122341449', N'Sai Gon', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Password], [PhoneNumber], [Address], [RoleId]) VALUES (8, N'Lê Viết Thịnh', N'nguyen@gmail.com', N'827ccbeea8a706c4c34a16891f84e7b', N'0394083746', N'Hà Nội', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.CourseTypes_CourseTypeId] FOREIGN KEY([CourseTypeId])
REFERENCES [dbo].[CourseTypes] ([CourseTypeId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.CourseTypes_CourseTypeId]
GO
ALTER TABLE [dbo].[CourseVideos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseVideos_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CourseVideos] CHECK CONSTRAINT [FK_dbo.CourseVideos_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [DBHocLapTrinh] SET  READ_WRITE 
GO
