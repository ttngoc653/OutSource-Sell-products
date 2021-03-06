Install this application on your computer using the installation wizard file in the Execute folder.
Note:
There are 2 installation files ("Execute\SellProductsSetup.msi" is the installation wizard file containing all the unencrypted files; "Execute\SellProductsSetup_Obfuscated.msi" is the installation wizard file containing the encrypted files) and only You need to install 1 file to be able to use it.

RUN APP:
- Run the file SellProducts.exe directly.
- If there is a SQL Server database connection string, go to the command line of the folder containing SellProducts.exe, type the following:
SellProducts.exe <database connection string>
Example: SellProducts.exe "Server=.;Database=SellProduct_DB;Trusted_Connection=True"


________________________________________________________________________________________________

Cài đặt ứng dụng này vào máy tính bằng tập tin thuật sĩ cài đặt trong thư mục Execute.
Lưu ý:
Có 2 file cài dặt ("Execute\SellProductsSetup.msi" là tệp thuật sĩ cài đặt chưa tất cá các file chưa mã hóa; "Execute\SellProductsSetup_Obfuscated.msi" lad tệp thuật sĩ cài đặt chứa các file đã mã hóa) và chỉ cần cài 1 tập tin là có thể xài được.

CHẠY ỨNG DỤNG:
- Chạy trực tiếp file SellProducts.exe.
- Nếu có chuỗi kết nối cơ sở dữ liệu SQL Server thì vào command line của thư mục chứa SellProducts.exe, gõ như sau:
SellProducts.exe <chuỗi kết nối với database>
Ví dụ: SellProducts.exe "Server=.;Database=SellProduct_DB;Trusted_Connection=True"


-----------------------------------------------------------------------------------------------------------------

THỐNG KÊ CHỨC NĂNG

## Các chức năng cơ sở (7 điểm)

### 1. Màn hình đăng nhập (0.5 điểm) => Có làm - thông tin đăng nhập: admin - admin

* Cho nhập username và password để đi vào màn hình chính. Có chức năng lưu username và password ở local để lần sau người dùng không cần đăng nhập lại. Password cần được mã hóa.

### 2. Màn hình dashboard (0.5 điểm) => Có làm

Cung cấp tổng quan về hệ thống, ví dụ:

- Có tổng cộng bao nhiêu sản phẩm đang bán => Xong
- Có tổng cộng bao nhiêu đơn hàng mới trong tuần / tháng  => Xong
- Liệt kê top 5 sản phẩm đang sắp hết hàng (số lượng < 5)  => Xong

### 3. Quản lí hàng hóa (1.5 điểm) => Có làm

Import dữ liệu gốc ban đầu (loại sản phẩm, danh sách các sản phẩm) từ tập tin Excel hoặc Access.  => Xong

Xem danh sách các sản phẩm theo loại sản phẩm có phân trang. => Xong

Cho phép thêm một loại sản phẩm, xóa một loại sản phẩm, hiệu chỉnh loại sản phẩm => Xong

Cho phép thêm một sản phẩm, xóa một sản phẩm, hiệu chỉnh thông tin sản  phẩm => Mà còn lỗi không cập nhật từ ngoài vào data grid

Cho phép tìm kiếm sản phẩm theo tên => Xong

Cho phép lọc lại sản phẩm theo khoảng giá => Xong

### 4. Quản lí các dơn hàng (1.5 điểm) => Đã làm

Tạo ra các đơn hàng => Xong (tạo từng đơn hàng)

Cho phép xóa một đơn hàng, cập nhật một đơn hàng (có xóa mà không cập nhật vì bị phần giao diện không tự động cập nhật giá tiền khi thay đổi số lượng sản phẩm)

Cho phép xem danh sách các đơn hàng có phân trang, xem chi tiết một đơn hàng => Đã làm

Tìm kiếm các đơn hàng từ ngày đến ngày => Có làm

### 5. Báo cáo thống kê (2 điểm)

Báo cáo doanh thu và lợi nhuận theo ngày đến ngày, theo tuần, theo tháng, theo năm (vẽ biểu đồ) => Không làm

Xem các sản phẩm và số lượng bán theo ngày đến ngày, theo tuần, theo tháng, theo năm (vẽ biểu đồ) => Không làm

### 6. Cấu hình (0.5 điểm)

Cho phép hiệu chỉnh số lượng sản phẩm mỗi trang => Có làm

Cho phép khi chạy chương trình lên thì mở lại màn hình cuối mà lần trước tắt => Có lưu ở DB nhưng chưa làm load 

### 7. Đóng gói thành file cài đặt (0.5 điểm) => Có làm

Cần đóng gói thành file exe để tự cài chương trình vào hệ thống

## Các chức năng gợi ý nâng cao (Tự chọn để được 3 điểm)

Sử dụng một thiết kế tốt lấy từ pinterest (0.5 điểm) => Không làm

### Làm rối mã nguồn (obfuscator) chống dịch ngược (0.5 điểm) => Có làm

Thêm chế độ dùng thử - cho phép xài full phần mềm trong 15 ngày. Hết 15 ngày (0.5 điểm) => Không làm

### Báo cáo các sản phẩm bán chạy trong tuần, trong tháng, trong năm (1 điểm) => Không làm

### Bổ sung khuyến mãi giảm giá (1 điểm) => Không làm

### Quản lí khách hàng (1 điểm) => Có làm

### Sử dụng giao diện Ribbon (0.5 điểm) => Đã làm

### Backup / restore database (0.5 điểm) => Đã làm

### Tổ chức theo mô hình 3 lớp (1 điểm) => Có làm

Chương trình có khả năng mở rộng động theo kiến trúc plugin (1 điểm) => Không làm

Sử dụng mô hình MVVM (1 điểm) => Có làm

### Cho phép tìm các sản phẩm sắp hết hàng (số lượng < 5) (0.5 điểm) => Không làm

Sử dụng DevExpress / Telerik  / Kendo UI  (1 điểm) => Không làm

Có khả năng cập nhật tính năng mới qua mạng sử dụng ClickOnce(0.5 điểm) => Không làm

Sử dụng thư viện WinUI mới (1 điểm) => Không làm

---------------------------------------------------------------------------------------------------------

Điểm yêu cầu: 7