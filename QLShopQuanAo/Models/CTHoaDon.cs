using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Models
{
    internal class CTHoaDon
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }

        // Thuộc tính tiện dùng (không có trong SQL)
        public int ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
    }
}
