using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối SQL

namespace QLShopQuanAo.Data
{
    internal class DBConnect
    {
        // 1. Hàm tạo kết nối (Đã chỉnh theo máy của bạn)
        public static SqlConnection GetConnection()
        {
            // Lưu ý: Initial Catalog là tên Database của bạn
            string connStr = @"Data Source=DESKTOP-7G8SM95\SQLEXPRESS;Initial Catalog=dbQLShopQuanAo;Integrated Security=True";
            return new SqlConnection(connStr);
        }

        // 2. Hàm lấy dữ liệu dạng bảng (Dùng cho SELECT)
        public static DataTable TruyVan(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    // Nếu lỗi thì throw ra để biết (hoặc return null)
                    throw new Exception("Lỗi truy vấn: " + ex.Message);
                }
            }
        }

        // 3. Hàm thực thi lệnh thêm/sửa/xóa (INSERT, UPDATE, DELETE)
        public static void ThucThi(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // 4. Hàm lấy 1 giá trị duy nhất (Ví dụ: Lấy ID vừa tạo)
        public static int LayMotGiaTri(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
                return 0;
            }
        }
    }
}
