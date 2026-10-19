IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_ChiTieu')
BEGIN
    CREATE DATABASE QL_ChiTieu;
END
GO

USE QL_ChiTieu;
GO

IF OBJECT_ID(N'dbo.ChiTieu', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTieu (
        MaCT INT IDENTITY(1,1) PRIMARY KEY,
        NgayChi DATE NOT NULL,
        NoiDung NVARCHAR(100) NOT NULL,
        LoaiChi NVARCHAR(30) NOT NULL,
        SoTien DECIMAL(18,0) NOT NULL,
        GhiChu NVARCHAR(200) NULL
    );
END
GO

-- Xóa dữ liệu cũ nếu có và thêm dữ liệu mẫu
IF (SELECT COUNT(*) FROM dbo.ChiTieu) = 0
BEGIN
    INSERT INTO dbo.ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu)
    VALUES
        ('2026-10-01', N'Cơm trưa', N'Ăn uống', 35000, N'Ăn trưa cơm văn phòng'),
        ('2026-10-02', N'Xăng xe', N'Đi lại', 60000, N'Đổ xăng xe máy'),
        ('2026-10-03', N'Photo giáo trình', N'Học tập', 25000, N'Tài liệu môn C# WinForms'),
        ('2026-10-04', N'Xem phim', N'Giải trí', 90000, N'Vé xem phim rạp CGV'),
        ('2026-10-05', N'Trà sữa', N'Ăn uống', 40000, N'Trà sữa Tocotoco'),
        ('2026-10-06', N'Mua áo thun', N'Khác', 150000, N'Mua đồ dùng cá nhân'),
        ('2026-10-07', N'Tiền điện thoại', N'Khác', 100000, N'Nạp thẻ cào điện thoại'),
        ('2026-10-08', N'Ăn sáng', N'Ăn uống', 25000, N'Bánh mì xíu mại'),
        ('2026-10-10', N'Sách tham khảo', N'Học tập', 120000, N'Sách lập trình C# căn bản'),
        ('2026-10-12', N'Bảo dưỡng xe máy', N'Đi lại', 150000, N'Thay dầu nhớt máy'),
        ('2026-10-15', N'Cà phê cuối tuần', N'Giải trí', 55000, N'Họp nhóm bạn'),
        ('2026-10-18', N'Cà phê với bạn', N'Ăn uống', 45000, N'Gặp bạn thân');
END
GO
