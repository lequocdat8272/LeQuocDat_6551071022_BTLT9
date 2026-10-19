USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_TraSua')
BEGIN
    CREATE DATABASE QL_TraSua;
END
GO

USE QL_TraSua;
GO

IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('MonUong', 'U') IS NOT NULL DROP TABLE MonUong;
IF OBJECT_ID('DanhMucMon', 'U') IS NOT NULL DROP TABLE DanhMucMon;
GO

CREATE TABLE DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);

CREATE TABLE MonUong (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1,
    MaDM INT NOT NULL,
    CONSTRAINT FK_MonUong_DanhMucMon FOREIGN KEY (MaDM) REFERENCES DanhMucMon(MaDM)
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,0) NOT NULL DEFAULT 0,
    HinhThucTT NVARCHAR(20) NOT NULL,
    DaThanhToan BIT NOT NULL DEFAULT 0
);

CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL,
    MaMon INT NOT NULL,
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaMon),
    CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietHoaDon_MonUong FOREIGN KEY (MaMon) REFERENCES MonUong(MaMon)
);
GO

INSERT INTO DanhMucMon (TenDM) VALUES 
(N'Trà sữa'),
(N'Trà trái cây'),
(N'Topping'),
(N'Đồ ăn vặt');

INSERT INTO MonUong (TenMon, GiaBan, DangBan, MaDM) VALUES
(N'Trà sữa trân châu', 35000, 1, 1),
(N'Trà sữa matcha', 40000, 1, 1),
(N'Hồng trà sữa', 32000, 1, 1),
(N'Trà sữa khoai môn', 38000, 1, 1),
(N'Trà sữa socola', 38000, 1, 1),
(N'Trà đào cam sả', 35000, 1, 2),
(N'Trà vải hạt sen', 38000, 1, 2),
(N'Trà chanh dây nhiệt đới', 32000, 1, 2),
(N'Trà xoài macchiato', 42000, 1, 2),
(N'Trân châu đen', 5000, 1, 3),
(N'Trân châu trắng', 5000, 1, 3),
(N'Thạch phô mai', 8000, 1, 3),
(N'Pudding trứng', 7000, 1, 3),
(N'Bánh tráng trộn', 20000, 1, 4),
(N'Khô gà lá chanh', 25000, 1, 4),
(N'Khoai tây lắc phô mai', 25000, 1, 4);
GO
