using System.Text.Json.Serialization;

namespace QuanLyNhaTro.Models;

public class ProvinceItem
{
    [JsonPropertyName("code")]
    public int code { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; } = string.Empty;

    [JsonPropertyName("division_type")]
    public string? division_type { get; set; }

    [JsonPropertyName("codename")]
    public string? codename { get; set; }

    [JsonPropertyName("phone_code")]
    public int? phone_code { get; set; }

    [JsonPropertyName("wards")]
    public List<WardItem>? wards { get; set; }

    public override string ToString() => name;
}

public class ProvinceDetailItem
{
    [JsonPropertyName("code")]
    public int code { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; } = string.Empty;

    [JsonPropertyName("division_type")]
    public string? division_type { get; set; }

    [JsonPropertyName("codename")]
    public string? codename { get; set; }

    [JsonPropertyName("phone_code")]
    public int? phone_code { get; set; }

    [JsonPropertyName("wards")]
    public List<WardItem> wards { get; set; } = new();

    public override string ToString() => name;
}

public class WardItem
{
    [JsonPropertyName("code")]
    public int code { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; } = string.Empty;

    [JsonPropertyName("division_type")]
    public string? division_type { get; set; }

    [JsonPropertyName("codename")]
    public string? codename { get; set; }

    [JsonPropertyName("province_code")]
    public int? province_code { get; set; }

    public override string ToString() => name;
}

public class RoomComboBoxItem
{
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = string.Empty;
    public decimal GiaThue { get; set; }
    public string TinhTrang { get; set; } = string.Empty;

    public string DisplayText => $"{TenPhong} - {GiaThue:N0} đ";

    public override string ToString() => DisplayText;
}

public class CustomerDisplayModel
{
    public int MaKhach { get; set; }
    public string HoTen { get; set; } = string.Empty;
    public string GioiTinh { get; set; } = string.Empty;
    public DateOnly NgaySinh { get; set; }
    public string SoDienThoai { get; set; } = string.Empty;
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = string.Empty;
    public decimal GiaThue { get; set; }
    public int? MaTinh { get; set; }
    public string TenTinh { get; set; } = string.Empty;
    public int? MaPhuongXa { get; set; }
    public string TenPhuongXa { get; set; } = string.Empty;
    public string QueQuan => string.IsNullOrWhiteSpace(TenPhuongXa) ? TenTinh : $"{TenPhuongXa} – {TenTinh}";
    public bool DaDangKyTamTru { get; set; }
}
