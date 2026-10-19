IF DB_ID('QL_NhaTro') IS NOT NULL
BEGIN
    ALTER DATABASE QL_NhaTro SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_NhaTro;
END
GO

CREATE DATABASE QL_NhaTro;
GO

USE QL_NhaTro;
GO

CREATE TABLE PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL CONSTRAINT DF_PhongTro_TinhTrang DEFAULT N'Trống'
);
GO

CREATE TABLE KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL CONSTRAINT DF_KhachThue_DaDangKyTamTru DEFAULT 0,
    MaPhong INT NOT NULL,
    CONSTRAINT FK_KhachThue_PhongTro FOREIGN KEY (MaPhong) REFERENCES PhongTro(MaPhong) ON DELETE CASCADE
);
GO

-- Chèn dữ liệu mẫu 6 phòng
INSERT INTO PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'P01', 1500000, N'Đang thuê'),
(N'P02', 1600000, N'Đang thuê'),
(N'P03', 1800000, N'Đang thuê'),
(N'P04', 2000000, N'Đang thuê'),
(N'P05', 1700000, N'Đang thuê'),
(N'P06', 2200000, N'Trống');
GO

-- Chèn dữ liệu mẫu khách thuê
-- P01: MaPhong = 1, P02: MaPhong = 2, P03: MaPhong = 3, P04: MaPhong = 4, P05: MaPhong = 5, P06: MaPhong = 6
INSERT INTO KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Nguyễn Văn', N'Nam', '1998-05-10', '0912345678', 1, N'Thành phố Hà Nội', 10015, N'Phường Ba Đình', 0, 3),
(N'Nguyễn Văn An', N'Nam', '2004-05-12', '0912345678', 1, N'Thành phố Hà Nội', 10015, N'Phường Ba Đình', 1, 3),
(N'Trần Thị Bình', N'Nữ', '2000-08-20', '0876543210', 37, N'Tỉnh Ninh Bình', 13735, N'Phường Nam Định', 0, 1),
(N'Lê Văn Cường', N'Nam', '1999-03-15', '0901234567', 38, N'Tỉnh Thanh Hóa', 14212, N'Phường Điện Biên', 0, 2),
(N'Phạm Minh Đức', N'Nam', '1997-11-22', '0987654321', 38, N'Tỉnh Thanh Hóa', 14215, N'Phường Ba Đình', 0, 4),
(N'Hoàng Thị Dung', N'Nữ', '2001-09-05', '0765432109', 27, N'Tỉnh Bắc Ninh', 9445, N'Phường Suối Hoa', 0, 5);
GO
