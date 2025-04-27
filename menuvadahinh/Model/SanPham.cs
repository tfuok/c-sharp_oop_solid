public abstract class SanPham
{
    public static int countId = 1;
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }
    public SanPham() { }

    public SanPham(string ten, double gia)
    {
        MaSanPham = countId++;
        TenSanPham = ten;
        GiaGoc = gia;
    }

    public abstract double TinhGiaBan();

    // không bắt buộc ghi đè phương thức virtual
    public virtual void HienThiThongTin()
    {
        Console.Write($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá gốc: {GiaGoc}");
    }
}