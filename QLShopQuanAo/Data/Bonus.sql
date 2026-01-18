USE QLShopQuanAo;
GO

-- 1. Bảng Loại Khách (Để phân nhóm: VIP, Thường...)
CREATE TABLE LoaiKhach (
    MaLoai int IDENTITY(1,1) PRIMARY KEY,
    TenLoai nvarchar(50) NOT NULL
);

-- Thêm cột MaLoai vào bảng Khách Hàng của bạn
ALTER TABLE KhachHang ADD MaLoai int DEFAULT 1;

-- Thêm vài loại mẫu
INSERT INTO LoaiKhach VALUES (N'Khách Thường'), (N'Khách VIP'), (N'Khách Sỉ');

-- 2. Bảng Ghi Chú (Để note lại thông tin chăm sóc khách)
CREATE TABLE GhiChuKhachHang (
    MaGC int IDENTITY(1,1) PRIMARY KEY,
    NoiDung nvarchar(500),
    NgayGhi datetime DEFAULT GETDATE(),
    MaKH nvarchar(20), -- Liên kết với khách hàng
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE
);