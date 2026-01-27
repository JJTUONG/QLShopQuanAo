# TÀI LIỆU GIẢI THÍCH CODE & CHỨC NĂNG (DÙNG ĐỂ BẢO VỆ ĐỒ ÁN)

Tài liệu này giải thích chi tiết các thay đổi và chức năng mới về **Quản lý Tài khoản & Thống kê** mà nhóm đã thực hiện. Sẵn sàng để trả lời câu hỏi của giảng viên.

---

## 1. Cơ sở dữ liệu (Database)

Giảng viên hỏi: *"Các em đã thay đổi gì trong Database để hỗ trợ tính năng lịch sử?"*

**Trả lời:**
Em đã thực hiện 2 thay đổi chính trong SQL Server:
1.  **Bảng `TaiKhoan`**: Thêm cột `HoTen` (để hiển thị tên đầy đủ) và `NgayTao` (để biết user tạo khi nào).
2.  **Tạo mới bảng `LichSuDangNhap`**:
    *   Mục đích: Lưu vết mỗi khi nhân viên đăng nhập thành công.
    *   Các cột: `MaLS` (tự tăng), `MaTK` (khóa ngoại nối với bảng TaiKhoan), `ThoiGian` (lưu giờ đăng nhập), `TrangThai`.

---

## 2. Các Form chức năng (Giao diện & Logic)

Đồ án triển khai theo quy trình **Drill-down** (Đi từ tổng quan đến chi tiết) qua 3 màn hình.

### Màn hình 1: Quản lý Tài khoản (`FrmTaiKhoang.cs`)
Đây là màn hình danh sách tổng.
*   **Chức năng**: Hiển thị danh sách tất cả tài khoản trong hệ thống.
*   **Kỹ thuật code**:
    *   Sử dụng `SqlDataAdapter` để đổ dữ liệu từ bảng `TaiKhoan` vào `DataGridView`.
    *   **Tìm kiếm**: Sử dụng câu lệnh SQL `LIKE` vơi cú pháp `WHERE TenDangNhap LIKE N'%keyword%'` để tìm theo tên gần đúng.
*   **Sự kiện chính**: Khi bấm nút **"Xem Lịch Sử"**, code sẽ lấy `MaTK` của dòng đang chọn và truyền sang Form 2 (`FrmLichSuTaiKhoan`).

### Màn hình 2: Thống kê tổng hợp (`FrmLichSuTaiKhoan.cs`)
Đây là màn hình Dashboard cho từng cá nhân.
*   **Chức năng**: Hiển thị 4 chỉ số quan trọng của nhân viên đó.
*   **Cách tính toán (SQL)**:
    1.  **Số lần đăng nhập**: `SELECT COUNT(*) FROM LichSuDangNhap WHERE MaTK = @MaTK`
    2.  **Lần đăng nhập cuối**: `SELECT MAX(ThoiGian) ...`
    3.  **Số đơn hàng đã bán**: `SELECT COUNT(*) FROM HoaDon WHERE MaTK = @MaTK`
    4.  **Tổng doanh thu**: `SELECT SUM(TongTien) FROM HoaDon WHERE MaTK = @MaTK`
*   **Điểm nhấn**: Sử dụng `ExecuteReader()` để đọc các giá trị đơn lẻ nhanh chóng mà không cần load cả bảng.

### Màn hình 3: Chi tiết bán hàng (`FrmChiTietBanHangTheoTaiKhoan.cs`)
Đây là màn hình chi tiết nhất, dùng để đối soát doanh thu.
*   **Chức năng**: Xem nhân viên đó đã bán những món gì, vào ngày nào.
*   **Kỹ thuật code (Quan trọng)**:
    *   Sử dụng câu lệnh **JOIN 3 bảng**: `HoaDon` (lấy ngày), `CTHoaDon` (lấy số lượng, đơn giá), `SanPham` (lấy tên sản phẩm).
    *   **Bộ lọc ngày tháng**: Sử dụng 2 `DateTimePicker` (Từ ngày - Đến ngày) để lọc dữ liệu trong câu SQL (`WHERE NgayLap >= @TuNgay AND NgayLap <= @DenNgay`).
    *   **Tính tổng tiền**: Dùng vòng lặp `foreach` duyệt qua `DataTable` để cộng dồn cột `ThanhTien`, hiển thị tổng doanh thu của đợt lọc.

---

## 3. Chức năng Đăng nhập (`FrmLogin.cs`)

Giảng viên hỏi: *"Làm sao hệ thống biết được ai đang đăng nhập để lưu lịch sử?"*

**Trả lời:**
Trong sự kiện `btnLogin_Click`:
1.  Sau kiểm tra `username/password` đúng trong DB.
2.  Câu lệnh `INSERT INTO LichSuDangNhap...` được gọi ngay lập tức với `MaTK` vừa lấy được.
3.  Hàm `GetDate()` của SQL được dùng để lấy thời gian thực chính xác tại máy chủ.

---

## 4. Tối ưu hóa Code (Refactoring)

Giảng viên hỏi: *"Code kết nối CSDL các em để ở đâu?"*

**Trả lời:**
Nhóm em không viết cứng (hardcode) chuỗi kết nối ở từng Form vì rất khó sửa chữa.
Thay vào đó, nhóm tạo một lớp chung tên là `DBConnect.cs` trong thư mục `Data`.
*   Tất cả các Form (`FrmMain`, `FrmLogin`, `FrmSanPham`...) đều gọi `DBConnect.GetConnection()`.
*   Khi đổi máy hoặc đổi Server, em chỉ cần sửa 1 dòng trong file này là toàn bộ dự án tự cập nhật theo.

---
*Chúc bạn bảo vệ thành công!*
