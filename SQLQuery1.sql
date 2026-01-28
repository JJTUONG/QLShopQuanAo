USE dbQLShopQuanAo;
GO

-- 1. Xóa bảng con trước (CTHoaDon) vì nó dính líu đến bảng cha
IF OBJECT_ID('dbo.CTHoaDon', 'U') IS NOT NULL
DROP TABLE dbo.CTHoaDon;

-- 2. Xóa bảng cha (HoaDon) cũ bị sai
IF OBJECT_ID('dbo.HoaDon', 'U') IS NOT NULL
DROP TABLE dbo.HoaDon;

-- 3. TẠO LẠI bảng HoaDon (Chuẩn ID tự tăng kiểu số)
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL, -- Quan trọng: int IDENTITY để tự tăng
	[NgayLap] [datetime] NULL,
	[MaKH] [nvarchar](50) NULL,          -- Lưu ý: Kiểu này phải khớp với bảng KhachHang của bạn
	[TongTien] [decimal](18, 0) NULL,
	[MaTK] [nvarchar](50) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED ([MaHD] ASC)
);

-- 4. TẠO LẠI bảng CTHoaDon
CREATE TABLE [dbo].[CTHoaDon](
	[MaHD] [int] NOT NULL,             -- Khớp kiểu int với bảng cha
	[MaSP] [nvarchar](10) NOT NULL,    -- Khớp kiểu với bảng SanPham
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
    [ThanhTien] [decimal](18, 0) NULL, -- Thêm cột này cho tiện
 CONSTRAINT [PK_CTHoaDon] PRIMARY KEY CLUSTERED ([MaHD] ASC, [MaSP] ASC)
);

-- 5. Tạo mối liên kết (Khóa ngoại) giữa 2 bảng
ALTER TABLE [dbo].[CTHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDon_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD]);

ALTER TABLE [dbo].[CTHoaDon] CHECK CONSTRAINT [FK_CTHoaDon_HoaDon];