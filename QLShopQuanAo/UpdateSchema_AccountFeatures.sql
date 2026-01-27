USE dbQLShopQuanAo
GO

-- 1. Thêm cột mới vào bảng TaiKhoan
-- Kiểm tra xem cột đã tồn tại chưa trước khi thêm
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'HoTen' AND Object_ID = Object_ID(N'TaiKhoan'))
BEGIN
    ALTER TABLE TaiKhoan ADD HoTen NVARCHAR(50) DEFAULT N'Chưa cập nhật'
END
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayTao' AND Object_ID = Object_ID(N'TaiKhoan'))
BEGIN
    ALTER TABLE TaiKhoan ADD NgayTao DATETIME DEFAULT GETDATE()
END
GO

-- 2. Tạo bảng Lịch Sử Đăng Nhập
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LichSuDangNhap]') AND type in (N'U'))
BEGIN
    CREATE TABLE LichSuDangNhap (
        MaLS INT IDENTITY(1,1) PRIMARY KEY,
        MaTK NVARCHAR(10),
        ThoiGianDangNhap DATETIME DEFAULT GETDATE(),
        TrangThai NVARCHAR(50), -- Thành công / Thất bại

        FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK)
    )
END
GO

-- 3. Cập nhật dữ liệu mẫu cho các cột mới nếu cần
UPDATE TaiKhoan SET HoTen = N'Quản Lý Viên', NgayTao = GETDATE() WHERE MaTK = 'TK01'
UPDATE TaiKhoan SET HoTen = N'Nhân Viên 1', NgayTao = GETDATE() WHERE MaTK = 'TK02'
GO
