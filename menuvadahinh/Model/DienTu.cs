public class DienTu : SanPham
{
    public double ThueBaoHanh { get; set; }

    public DienTu() { }

    public DienTu(string ten, double gia, double thue) : base(ten, gia)
    {
        ThueBaoHanh = thue;
    }
    public override double TinhGiaBan()
    {
        return GiaGoc + (GiaGoc * ThueBaoHanh / 100);
    }

    // không bắt buộc ghi đè phương thức virtual
    //ghi đè lại hiện thị thong tin cho đúng class DIEN TU
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($", Thuế bảo hành: {ThueBaoHanh}");
    }
}