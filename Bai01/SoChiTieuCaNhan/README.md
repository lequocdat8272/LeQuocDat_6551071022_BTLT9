# HƯỚNG DẪN CÀI ĐẶT VÀ SỬ DỤNG ỨNG DỤNG "SỔ CHI TIÊU CÁ NHÂN"
**Công nghệ:** C# Windows Forms, .NET 10, Entity Framework Core Database First, Serilog, ConfigurationBuilder

---

## 1. Cấu trúc dự án
- `init_db.sql`: Script tạo cơ sở dữ liệu `QL_ChiTieu`, bảng `ChiTieu` và 12 bản ghi mẫu.
- `Models/`: Chứa `ChiTieu.cs` và `QlChiTieuContext.cs` được sinh tự động bằng EF Core Database First.
- `Config/`:
  - `AppConfig.cs`: Lớp cấu hình strongly-typed.
  - `AppConfigService.cs`: Đọc cấu hình JSON bằng `ConfigurationBuilder`.
- `FormChiTieu.cs` & `FormChiTieu.Designer.cs`: Giao diện và logic CRUD, tìm kiếm, lọc, tính tổng tiền.
- `Program.cs`: Cấu hình Serilog ghi file theo ngày vào thư mục `Logs/` và khởi chạy form.
- `appsettings.json`: Cấu hình môi trường Production.
- `appsettings.Development.json`: Cấu hình ghi đè môi trường Development.
- `appsettings.example.json`: File mẫu không chứa mật khẩu thực tế để bàn giao/chia sẻ.
- `.gitignore`: Bỏ qua các file cấu hình chứa mật khẩu nhạy cảm (`appsettings.json`, `appsettings.Development.json`).

---

## 2. Hướng dẫn chạy và kiểm thử trên máy phát triển
1. **Khởi tạo CSDL**:
   ```powershell
   sqlcmd -S localhost -U sa -P "SuperPass@123" -C -i init_db.sql
   ```
2. **Chạy ứng dụng**:
   ```powershell
   dotnet run
   ```

---

## 3. Hướng dẫn đóng gói và chuyển sang máy tính/laptop khác (Task 7)

### Bước 1: Đóng gói trên máy phát triển
Thực hiện lệnh đóng gói Framework-Dependent (win-x64):
```powershell
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```
Thư mục `./publish` sẽ chứa toàn bộ file thực thi `SoChiTieuCaNhan.exe`, các file thư viện `.dll` cần thiết, và các file cấu hình `appsettings.json`.

### Bước 2: Chuẩn bị trên máy tính/laptop của người dùng khác
1. **Cài đặt .NET Desktop Runtime**:
   - Máy đích cần cài đặt **.NET Desktop Runtime** (phiên bản tương ứng như .NET 10 / .NET 8 Windows x64).
   - Tải từ trang chủ Microsoft: https://dotnet.microsoft.com/download/dotnet
2. **Cơ sở dữ liệu**:
   - Đảm bảo máy đích có SQL Server (hoặc SQL Server Express / LocalDB).
   - Chạy script `init_db.sql` trên SQL Server của máy đích để tạo CSDL `QL_ChiTieu`.

### Bước 3: Triển khai không cần build lại code
1. Copy toàn bộ thư mục `publish` sang máy đích (qua USB, nén zip, mạng nội bộ...).
2. Mở file `publish/appsettings.json` bằng Notepad hoặc Text Editor bất kỳ.
3. Sửa chuỗi kết nối `DefaultConnection` cho phù hợp với máy đích:
   - Dùng Windows Authentication:
     ```json
     "DefaultConnection": "Server=localhost;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;"
     ```
   - Dùng SQL Server Authentication:
     ```json
     "DefaultConnection": "Server=TÊN_MÁY_HOẶC_IP;Database=QL_ChiTieu;User Id=sa;Password=MẬT_KHẨU;TrustServerCertificate=True;"
     ```
4. Lưu file `appsettings.json`.
5. Nháy đúp vào file `SoChiTieuCaNhan.exe` để mở ứng dụng.

---

## 4. Kiểm tra kết quả
- **Giao diện**: Hiển thị danh sách chi tiêu, lưới tự cập nhật sau khi Thêm / Sửa / Xóa.
- **Tìm kiếm / Lọc**: Lọc theo từ khóa nội dung, loại chi, khoảng thời gian "Từ ngày - Đến ngày", nhãn "Tổng chi: ... đ" tự động cập nhật chính xác.
- **Nhật ký thao tác (Logs)**: Thư mục `Logs/` bên cạnh file `.exe` sẽ tự động tạo file `log-yyyyMMdd.txt` ghi lại các hành động Thêm/Sửa/Xóa (kèm MaCT) và các lỗi truy cập CSDL (nếu có).
