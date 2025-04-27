public class ThoiTrang : SanPham
{
    public double GiamGia { get; set; }

    public ThoiTrang() { }

    public ThoiTrang(string ten, double gia, double giamgia) : base(ten, gia)
    {
        GiamGia = giamgia;
    }
    public override double TinhGiaBan()
    {
        return GiaGoc * (1 - GiamGia / 100);
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($", Giảm giá: {GiamGia}");
    }
}
