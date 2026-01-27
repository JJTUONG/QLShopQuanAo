-- 1. Tạo Database (Nếu chưa có)
CREATE DATABASE QLShopQuanAo;
GO

-- 2. Sử dụng Database này
USE QLShopQuanAo;
GO

-- 3. Tạo bảng KhachHang
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KhachHang]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[KhachHang](
        [MaKH] NVARCHAR(20) NOT NULL,   -- Tương ứng public string MaKH
        [TenKH] NVARCHAR(50) NOT NULL,  -- Tương ứng public string TenKH
        [SDT] NVARCHAR(15) NULL,        -- Tương ứng public string SDT
        [DiaChi] NVARCHAR(200) NULL,    -- Tương ứng public string DiaChi
        
        -- Tạo khóa chính cho MaKH để không bị trùng lặp
        CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED ([MaKH] ASC)
    );
END
GO

-- 4. Thêm một vài dữ liệu mẫu để test
INSERT INTO KhachHang (MaKH, TenKH, SDT, DiaChi) VALUES (N'KH001', N'Nguyễn Văn A', N'0901234567', N'Hà Nội');
INSERT INTO KhachHang (MaKH, TenKH, SDT, DiaChi) VALUES (N'KH002', N'Trần Thị B', N'0987654321', N'TP.HCM');
INSERT INTO KhachHang (MaKH, TenKH, SDT, DiaChi) VALUES (N'KH003', N'Lê Văn C', N'0912345678', N'Đà Nẵng');
GO

-- Xem thử kết quả
SELECT * FROM KhachHang;