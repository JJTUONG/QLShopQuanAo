USE master
GO

IF DB_ID('dbQLShopQuanAo') IS NOT NULL
    DROP DATABASE dbQLShopQuanAo
GO

CREATE DATABASE dbQLShopQuanAo
GO

USE dbQLShopQuanAo
GO

/* ====== TẠO BẢNG ====== */

-- 1. Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH NVARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(50),
    SDT NVARCHAR(15),
    DiaChi NVARCHAR(100)
)
GO

-- 2. Bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP NVARCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(100),
    Loai NVARCHAR(30),
    Size NVARCHAR(10),
    Gia INT CHECK (Gia > 0),
    SoLuong INT CHECK (SoLuong >= 0)
)
GO

-- 3. Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    MaTK NVARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(50),
    VaiTro NVARCHAR(20),
    TrangThai BIT
)
GO

-- 4. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD NVARCHAR(10) PRIMARY KEY,
    NgayLap DATE,
    MaKH NVARCHAR(10),
    TongTien INT DEFAULT 0,
    MaTK NVARCHAR(10),

    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK)
)
GO

-- 5. Bảng Chi Tiết Hóa Đơn
CREATE TABLE CTHoaDon (
    MaHD NVARCHAR(10),
    MaSP NVARCHAR(10),
    SoLuong INT,
    DonGia INT,

    PRIMARY KEY (MaHD, MaSP),

    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO


/* ====== THÊM DỮ LIỆU MẪU ====== */

-- Khách hàng
INSERT INTO KhachHang VALUES
(N'KH01', N'ĐẶNG J TƯỜNG', N'0909123456', N'Cần Thơ'),
(N'KH02', N'Trần Thị B', N'0912345678', N'Vĩnh Long')
GO

-- Sản phẩm
INSERT INTO SanPham VALUES
(N'SP01', N'Áo thun nam', N'Áo', N'M', 150000, 50),
(N'SP02', N'Quần jean nữ', N'Quần', N'L', 250000, 30),
(N'SP03', N'Áo sơ mi', N'Áo', N'L', 180000, 40),
(N'SP04', N'Áo Polo', N'Áo', N'L', 400000, 10),
(N'SP05', N'Áo ba lỗ', N'Áo', N'XXL', 100000, 20)
GO

-- Tài khoản
INSERT INTO TaiKhoan VALUES
(N'TK01', N'admin', N'123', N'QuanLy', 1),
(N'TK02', N'admin2', N'123', N'QuanLy', 1)
GO


/* ====== TRIGGER TRỪ SỐ LƯỢNG KHI BÁN ====== */

CREATE TRIGGER trg_TruSoLuong
ON CTHoaDon
AFTER INSERT
AS
BEGIN
    UPDATE sp
    SET sp.SoLuong = sp.SoLuong - i.SoLuong
    FROM SanPham sp
    JOIN inserted i ON sp.MaSP = i.MaSP
END
GO
