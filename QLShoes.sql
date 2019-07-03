USE [QLShoes]
GO
/****** Object:  StoredProcedure [dbo].[sp_Account_Login]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Account_Login]
	@UserAdmin varchar(50),
	@MatKhauAdmin nvarchar(50)
AS
BEGIN
	declare @count int
	declare @res bit
	select @count = count(*) from QUANTRI where UserAdmin = @UserAdmin and MatKhauAdmin = @MatKhauAdmin
	if @count > 0
		set @res = -1
	else 
		set @res = 0
	select @res
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietDonHang]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ChiTietDonHang]
as 
begin
	
select DONHANG.MaDH, DONHANG.MaKH, KHACHHANG.TenKH, KHACHHANG.SDTKH,TenSP, Soluong,DONHANG.TongTien as 'Tổng tiền'
	from (KHACHHANG inner join DONHANG ON KHACHHANG.MaKH=DONHANG.MaKH) inner join CTHD on DONHANG.MaDH=CTHD.MaDH, SANPHAM
end

GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaDH] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Gia] [int] NULL,
	[TongTien]  AS ([Gia]*[Soluong]),
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NGAYDH] [datetime] NULL,
	[AdID] [int] NULL,
	[TongTien] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[EmailKH] [nvarchar](50) NOT NULL,
	[MatKhauKH] [varchar](50) NULL,
	[DiaChiKH] [nvarchar](100) NULL,
	[SDTKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAI]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI](
	[MaSP] [int] NOT NULL,
	[MaLoai] [int] NOT NULL,
	[TenLoai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QUANTRI]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUANTRI](
	[AdID] [int] IDENTITY(1,1) NOT NULL,
	[TenAdmin] [nvarchar](50) NULL,
	[EmailAdmin] [nvarchar](50) NOT NULL,
	[UserAdmin] [varchar](50) NULL,
	[MatKhauAdmin] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](100) NULL,
	[ChatLieu] [varchar](20) NULL,
	[TRANGTHAI] [nvarchar](50) NULL,
	[Mota] [nvarchar](100) NULL,
	[Motachitiet] [nvarchar](max) NULL,
	[DacDiem] [nvarchar](50) NULL,
	[GIA] [int] NULL,
	[HINHANH] [varchar](100) NULL,
	[HINHTONGHOP] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Loai_sp]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE VIEW [dbo].[Loai_sp] AS
	SELECT LOAI.MaSP, MaLoai, TenLoai,TenSP
	FROM LOAI,SANPHAM
GO
/****** Object:  View [dbo].[v_CTHD]    Script Date: 13-May-19 4:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create view [dbo].[v_CTHD]
as
SELECT        p.*, oop.MaKH , opp.TenKH, opp.SDTKH, opp.EmailKH, opp.DiaChiKH, op.TenSP
FROM            CTHD p 
LEFT  JOIN        DONHANG   oop ON oop.MaDH = p.MaDH
LEFT  JOIN        SANPHAM   op ON op.MaSP = p.MaSP
LEFT  JOIN        KHACHHANG  opp ON opp.MaKH = oop.MaKH


GO
INSERT [dbo].[CTHD] ([MaDH], [MaSP], [Soluong], [Gia]) VALUES (213, 30, 1, 300000)
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([MaDH], [MaKH], [NGAYDH], [AdID], [TongTien]) VALUES (213, 1, CAST(N'2019-05-13 16:37:20.920' AS DateTime), NULL, N'300000')
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (1, N'Bình Nguyễn', N'dkniken0601@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'212 Quận 7', 12121321)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (11, N'dấd', N'3@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'dsadsadas', 123124124)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (12, N'111', N'1@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'adsdsa', 12321321)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (13, N'ádasd', N'2@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'1', 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (14, N'sadsad', N'12@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'12312', 123213)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (15, N'sadsadas', N'123125412@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'31231', 12312421)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (18, N'asdsadasd', N'123456@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'12', 12)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [EmailKH], [MatKhauKH], [DiaChiKH], [SDTKH]) VALUES (19, N'sadasd', N'1234312@gmail.com', N'MUN1YUhhbmdEaWVuTWF5', N'12', 906873702)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
INSERT [dbo].[LOAI] ([MaSP], [MaLoai], [TenLoai]) VALUES (1, 1, N'Giày Nike')
INSERT [dbo].[LOAI] ([MaSP], [MaLoai], [TenLoai]) VALUES (2, 1, N'Giày Adidas')
SET IDENTITY_INSERT [dbo].[QUANTRI] ON 

INSERT [dbo].[QUANTRI] ([AdID], [TenAdmin], [EmailAdmin], [UserAdmin], [MatKhauAdmin]) VALUES (1, N'bình', N'dkniken1', N'dkniken1', N'MUN1YUhhbmdEaWVuTWF5')
INSERT [dbo].[QUANTRI] ([AdID], [TenAdmin], [EmailAdmin], [UserAdmin], [MatKhauAdmin]) VALUES (2, N'Bình NGuyễn', N'dkniken0601@gmail.com', N'dkniken', N'MUN1YUhhbmdEaWVuTWF5')
SET IDENTITY_INSERT [dbo].[QUANTRI] OFF
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (1, N'GIÀY NIKE ODYSSEY REACT "BLACK/WHITE"', N'Da Cao c?p', NULL, N'Dành cho Nam', N'Mẫu giày với công nghệ React mới nhất của Nike. Đôi giày phù hợp để bạn có thể hoạt động thể thao nhưng vẫn giữ được nét thời trang cao cấp khi bạn muốn 1 outfit đẹp để xuống phố. Form giày chuẩn và phù hợp cho mọi lứa tuổi. Nike Epic React Flyknit chính hãng giá tốt nhất thị trường chỉ có tại The Mix!', N'Hàng chính hãng', 2200000, N'12.jpeg', NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (2, N'GIÀY NIKE EPIC REACT FLYKNIT "BLACK/GREY"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'Mẫu giày với công nghệ React mới nhất và Flyknit trứ danh của Nike. Đôi giày phù hợp để bạn có thể hoạt động thể thao nhưng vẫn giữ được nét thời trang cao cấp khi bạn muốn 1 outfit đẹp để xuống phố. Form giày chuẩn và phù hợp cho mọi lứa tuổi. Nike Epic React Flyknit chính hãng giá tốt nhất thị trường chỉ có tại The Mix!', N'Hàng chính hãng', 2650000, N'a11.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (3, N'GIÀY NIKE AIR MAX 270 "CACTUS"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'Giày Nike Air Max 270 - Mẫu giày Nike chính hãng mới nhất với phối màu lạ mắt 😎😎 Quan trọng là giá vẫn rất mềm cho ae nhé! 🤤🤤Đây là một trong những dòng giày Nike mới được sản xuất dựa trên công nghệ đế Air nổi tiếng, với thiết kế hiện đại và cực kỳ êm ái !', N'Hàng chính hãng', 2500000, N'a12.jpeg', NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (4, N' GIÀY NIKE AIR MAX 1 JUST DO IT COLLECTION "WHITE/TOTAL ORANGE"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'Giày Nike AirMax 1 Just Do It là mẫu giày phiên bản Giới Hạn đối với dòng giày AirMax1.Với công nghệ đế Air tích hợp dưới đế giúp cho bạn khi di chuyển nhiều được êm ái và nhẹ nhàng hơn. Với phiên bản giới hạn chỉ có vài trăm đôi được sản xuất nên cái tên Nike AirMax1 Just Do It không ít người săn đón và về được Việt Nam vơi số lượng cực ít!!!', N'Hàng chính hãng', 3500000, N'n12.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (5, N'GIÀY NIKE ODYSSEY REACT "BLACK/WHITE"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'Giày Nike Odyssey React]Mẫu giày với công nghệ React mới nhất của Nike. Đôi giày phù hợp để bạn có thể hoạt động thể thao nhưng vẫn giữ được nét thời trang cao cấp khi bạn muốn 1 outfit đẹp để xuống phố. Form giày chuẩn và phù hợp cho mọi lứa tuổi. Nike Epic React Flyknit chính hãng giá tốt nhất thị trường chỉ có tại The Mix!', N'Hàng chính hãng', 2200000, N'n1.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (6, N'GIÀY NIKE EPIC REACT FLYKNIT "BLACK/GREY"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'Mẫu giày với công nghệ React mới nhất và Flyknit trứ danh của Nike. Đôi giày phù hợp để bạn có thể hoạt động thể thao nhưng vẫn giữ được nét thời trang cao cấp khi bạn muốn 1 outfit đẹp để xuống phố. Form giày chuẩn và phù hợp cho mọi lứa tuổi. Nike Epic React Flyknit chính hãng giá tốt nhất thị trường chỉ có tại The Mix!', N'Hàng chính hãng', 2650000, N'n2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (7, N'GIÀY ADIDAS ULTRA BOOST 4.0 "WHITE MULTI-COLOR"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nu', N'Giày Adidas Ultra BOOST được xem như là một "người anh" trong đại gia đình Ultra BOOST. Dù được ra mắt từ lâu nhưng sức hút của Ultra BOOST chưa bao giờ giảm sút. Không chỉ sở hữu cho mình những công nghệ hiện đại bậc nhất của Adidas, sản phẩm còn sở hữu vẻ bề ngoài tràn đầy năng lượng và cứng cáp. Bạn vừa có thể mang để tập luyện thể thao cũng vừa có thể mang đi chơi mà vẫn không kém sự nổi bật. ', N'Hàng chính hãng', 3600000, N'a12.jpeg', NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (8, N'GIÀY ADIDAS ULTRA BOOST 2.0 "GOLD MEDAL"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'Giày Adidas Ultra BOOST được xem như là một "người anh" trong đại gia đình BOOST. Dù được ra mắt từ lâu nhưng sức hút của Ultra BOOST chưa bao giờ giảm sút. Không chỉ sở hữu cho mình những công nghệ hiện đại bậc nhất của Adidas, sản phẩm còn sở hữu vẻ bề ngoài tràn đầy năng lượng và cứng cáp.', N'Hàng chính hãng', 4500000, N'a11.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (9, N'GIÀY ADIDAS SUPERSTAR "WHITE/BLUE" GOLD STAMP', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nu', N'- Mẫu giày Adidas Superstar bản kỷ niệm đã về với phối màu siêu đỉnh !- Hàng chính hãng 100% Full box, full tem tag. Bao check, bao test. Cam kết đền tiền x3 khi khách hàng phát hiện không chính hãng !', N'Hàng chính hãng', 1650000, N'a10.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (10, N'GIÀY ADIDAS ULTRA BOOST 2.0 "GOLD MEDAL"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'Giày Adidas Ultra BOOST được xem như là một "người anh" trong đại gia đình BOOST. Dù được ra mắt từ lâu nhưng sức hút của Ultra BOOST chưa bao giờ giảm sút. Không chỉ sở hữu cho mình những công nghệ hiện đại bậc nhất của Adidas, sản phẩm còn sở hữu vẻ bề ngoài tràn đầy năng lượng và cứng cáp. Bạn vừa có thể mang để tập luyện thể thao cũng vừa có thể mang đi chơi mà vẫn không kém sự nổi bật.', N'Hàng chính hãng', 4500000, N'a1.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (11, N'GIÀY ADIDAS VS PACE "GREY"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'- Một trong đôi giày addias thời trang bởi vẻ ngoài đơn giản nhưng đầy phong cách. Giày adidas VS Pace chắc sẽ là đôi giày các bạn không thể bỏ lỡ trong tủ giày của mình !Nếu để ý kỹ, ngoài thiết kế của đôi giày VS Pace vô cùng cơ bản thì chất liệu da của đôi giày adidas này lại cao cấp không kém các thương hiệu giày da lớn khác !- Hàng chính hãng 100% Full box, full tem tag. Bao check, bao test!', N'Hàng chính hãng', 500000, N'a2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (12, N'GIÀY ADIDAS VS PACE " BLUE NAVY"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'- Một trong đôi giày addias thời trang bởi vẻ ngoài đơn giản nhưng đầy phong cách. Giày adidas VS Pace chắc sẽ là đôi giày các bạn không thể bỏ lỡ trong tủ giày của mình !Nếu để ý kỹ, ngoài thiết kế của đôi giày VS Pace vô cùng cơ bản thì chất liệu da của đôi giày adidas này lại cao cấp không kém các thương hiệu giày da lớn khác !- Hàng chính hãng 100% Full box, full tem tag. Bao check, bao test!', N'Hàng chính hãng', 65000, N'a3.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (13, N'GIÀY ADIDAS EQT SUPPORT ADV "TRIPLE BLACK"', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nam', N'- Siêu phẩm đẹp nhất của dòng giày EQT Racing ADV đã về rồi nhé, với phong cách hiện đại kết hợp cùng phối màu triple black đầy mê hoặc hứa hẹn sẽ là một mẫu giày hot nhất năm nay nhé !- Cam kết hàng chính hãng 100%', N'Hàng chính hãng', 16000000, N'a4.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (14, N'Giày Converse Kids BREAKPOINT PINK/BLUE', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 960000, N'a5.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (15, N'Giày Converse Chuck Taylor All Star Special Low 551610C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 4500000, N'a6.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (16, N'Chuck Taylor All Star 70 Vintage Canvas 162054C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 700000, N'a5.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (17, N'Bộ sưu tập giày Converse Chuck Taylor 2 Low', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 1200000, N'a11.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (18, N'Giày Converse Chuck Taylor Low M7652C - 1986628', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 22222, N'n2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (19, N'Giày Converse Chuck 70s Hi 162404C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 800000, N'a2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (20, N'Giày Converse Star Player 144150C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 1800000, N'a12.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (21, N'Giày Converse Star Player 144145C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 320000, N'a12.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (22, N' Giày Converse Star Player 144151C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 800000, N'a3.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (23, N'Giày Converse Chuck 70s Vintage LES Suede 149444C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 450000, N'n2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (24, N'Giày Converse Chuck 70s Suede Low 162999C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 680000, N'a12.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (25, N' Giày Converse One Star Vintage Suede 162576C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 2000000, N'a11.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (26, N'Giày Converse Chuck 70s Suede Low 162376C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 5000000, N'a3.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (27, N'Giày Converse One Star Vintage Suede 162574C', N'Da Cao c?p', NULL, N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 950000, N'n2.jpeg', NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (28, N'Giày Converse Chuck Taylor 1970s 144757c 162057c ', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 1000000, N'n2.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (29, N'Giày Converse Chuck Taylor All Star 1970 162065C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 880000, N'a5.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (30, N' Giày Converse Chuck Taylor Classic M5039C', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 300000, N'a5.jpeg', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [ChatLieu], [TRANGTHAI], [Mota], [Motachitiet], [DacDiem], [GIA], [HINHANH], [HINHTONGHOP]) VALUES (31, N'Giày Converse Chuck 70 OX 160522C năng động', N'Da Cao c?p', N'Còn hàng', N'Dành cho Nữ', N'- Chất liệu cao cấp đảm bảo độ bền và thoải mái chân khi mang.- Thiết kế đơn giản nhưng không kém phần cá tính hợp thời trang.- Kiểu dáng trẻ trung, khỏe khoắn, đường may tỉ mỉ, miếng lót êm chân.', N'Hàng chính hãng', 2000000, N'a3.jpeg', N'')
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__KHACHHAN__7ED9643F93F7D4AC]    Script Date: 13-May-19 4:50:41 PM ******/
ALTER TABLE [dbo].[KHACHHANG] ADD UNIQUE NONCLUSTERED 
(
	[EmailKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__QUANTRI__250789F5CC87B57C]    Script Date: 13-May-19 4:50:41 PM ******/
ALTER TABLE [dbo].[QUANTRI] ADD UNIQUE NONCLUSTERED 
(
	[EmailAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_DONHANG] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DONHANG] ([MaDH])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_DONHANG]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_CTHD] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_SANPHAM_CTHD]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_KHACHHANG_DONHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_KHACHHANG_DONHANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_QUANTRI_DONHANG] FOREIGN KEY([AdID])
REFERENCES [dbo].[QUANTRI] ([AdID])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_QUANTRI_DONHANG]
GO
ALTER TABLE [dbo].[LOAI]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAI] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[LOAI] CHECK CONSTRAINT [FK_SANPHAM_LOAI]
GO
