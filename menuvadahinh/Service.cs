using System.Text.Json;

public class Service
{
    public List<SanPham> list = new();

    private readonly string path = "C:\\Users\\Admin\\Documents\\dotnet03\\BanHangVoiMenuVaDaHinh\\menuvadahinh\\data.json";

    public Service()
    {
        // đọc file
        // nếu file không tồn tại thì không đọc
        if (File.Exists(path))
        {
            ReadData(path);
        }
        else
        {
            Console.WriteLine("File không tồn tại");
        }
    }
    public void Add()
    {
        int choice = -1;
        while (choice != 3)
        {
            Console.WriteLine("1/SP Dien tu");
            Console.WriteLine("2/SP Thoi trang");
            Console.WriteLine("3/SP Thuc pham");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Ten :");
            string ten = Console.ReadLine();
            Console.WriteLine("GiaGoc:");
            double giagoc = double.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    Console.WriteLine("ThueBaoHanh:");
                    double thue = double.Parse(Console.ReadLine());
                    DienTu kinhDoanh = new(ten, giagoc, thue);
                    list.Add(kinhDoanh);
                    Show();
                    SaveData(path);
                    return;
                case 2:
                    Console.WriteLine("GiamGia:");
                    double giamgia = double.Parse(Console.ReadLine());
                    ThoiTrang sx = new(ten, giagoc, giamgia);
                    list.Add(sx);
                    Show();
                    SaveData(path);
                    return;
                case 3:
                    Console.WriteLine("PhiVanChuyen:");
                    double phi = double.Parse(Console.ReadLine());
                    ThucPham vanPhong = new(ten, giagoc, phi);
                    list.Add(vanPhong);
                    Show();
                    SaveData(path);
                    return;
            }
        }
    }

    public void Show()
    {
        foreach (var SanPham in list)
        {
            SanPham.HienThiThongTin();
        }
    }

    public void Delete(int input)
    {
        SanPham a = list.Find(x => x.MaSanPham == input);
        if (a != null)
        {
            Console.WriteLine("R u sure?(Y/N)");
            string choice = Console.ReadLine();
            {
                if (choice == "Y" || choice == "y")
                {
                    list.Remove(a);
                    SaveData(path);
                    Show();
                }
                else if (choice == "N" || choice == "n")
                {
                    return;
                }
            }
        }
        else Console.WriteLine("San pham ko ton tai");
    }

    public double TongDoanhThu()
    {
        double tong = 0;
        // doanh thu là tổng giá bán
        foreach (SanPham item in list)
        {
            // gọi hàm tính giá bán
            tong += item.TinhGiaBan();// lấy ra giá từng sp , cộng dồn vào tổng
        }
        return tong;
    }

    public void ReadData(string path)
    {
        // lấy json từ file 
        var json = File.ReadAllText(path);
        // chuyể đổi json thành list<SanphamData>
        var sanPhamDataList = JsonSerializer.Deserialize<List<Data>>(json);
        // cần chuyển sanpham data về sanpham
        // duyệt từng phần tử trong danh sách
        List<SanPham> tmp = new List<SanPham>(); // chuyển đổi lưu tam ở đây
        foreach (var item in sanPhamDataList)
        {
            // kiểm tra loại sản phẩm
            // nếu loại =="ThoiTrang "-> 
            // nếu loại =="ThucPham "-> 
            // nếu loại =="DienTu "-> 
            switch (item.Loai)
            {
                case "ThoiTrang":
                    // chuyển đổi về sp tương ứng 
                    list.Add(new ThoiTrang(item.TenSanPham, item.GiaGoc, item.GiamGia ?? 0));
                    // thêm vào DanhSachSanPham
                    break;
                case "ThucPham":
                    list.Add(new ThucPham(item.TenSanPham, item.GiaGoc, item.PhiVanChuyen ?? 0));
                    break;
                case "DienTu":
                    list.Add(new DienTu(item.TenSanPham, item.GiaGoc, item.ThueBaoHanh ?? 0));
                    break;
            }
        }
    }

    public void SaveData(string path)
    {
        // convert tay , chuyển đổi sản phẩm trong danh sách thành SanPhamData
        List<Data> spData = new();
        spData = list.Select(sp =>
            {
                var spNew = new Data
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    GiaGoc = sp.GiaGoc,
                    Loai = sp.GetType().Name
                };
                // nếu là thời trang thì thêm thuộc tính giảm giá theo mùa
                if (sp is ThoiTrang)
                {
                    spNew.GiamGia = ((ThoiTrang)sp).GiamGia;
                }
                //dientu
                else if (sp is DienTu)
                {
                    spNew.ThueBaoHanh = ((DienTu)sp).ThueBaoHanh;
                }
                //thucpham
                else if (sp is ThucPham)
                {
                    spNew.PhiVanChuyen = ((ThucPham)sp).PhiVanChuyen;
                }
                return spNew;
            }).ToList();

        // thiếu gắn thuộc tính thêm , thue, giam gia...
        // lúc này có được ds theo kiểu spdata

        var json = JsonSerializer.Serialize(spData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
        Console.WriteLine("Save success");
    }
}