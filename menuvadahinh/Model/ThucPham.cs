public class ThucPham : SanPham
{
    public double PhiVanChuyen { get; set; }

    public ThucPham() { }

    public ThucPham(string ten, double gia, double phivanchuyen) : base(ten, gia)
    {
        PhiVanChuyen = phivanchuyen;
    }
    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($", Phí vận chuyển: {PhiVanChuyen}");
    }
}
