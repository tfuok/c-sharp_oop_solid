class Program
{
    public static void Main(string[] args)
    {
        Service service = new();
        int choice = -1;
        while (choice != 5)
        {
            Console.WriteLine("_________________MENU_________________");
            Console.WriteLine("1/Thêm sản phẩm vào danh sách");
            Console.WriteLine("2/Hiển thị danh sách sản phẩm. ");
            Console.WriteLine("3/Tính tổng doanh thu dự kiến. ");
            Console.WriteLine("4/Xóa sản phẩm khỏi danh sách theo mã. ");
            Console.WriteLine("5/ Thoát");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    service.Add();
                    break;
                case 2:
                    service.Show();
                    break;
                case 3:
                    Console.WriteLine(service.TongDoanhThu());
                    break;
                case 4:
                    Console.WriteLine("Ma san pham can tim");
                    int input = int.Parse(Console.ReadLine());
                    service.Delete(input);
                    break;
                case 5:
                    Console.WriteLine("Bye");
                    return;
            }
        }
    }
}