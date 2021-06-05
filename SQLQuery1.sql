CREATE DATABASE QuanLySach

use QuanLySach

CREATE TABLE DangNhap (
   TaiKhoan nvarchar(255) PRIMARY KEY ,
  MatKhau nvarchar(255)
 );

CREATE TABLE KhoSach (
   [Loại Sách] nvarchar(255) PRIMARY KEY ,
  [Tên Sách] nvarchar(255),
   [Tác Giả] nvarchar(255),
  [Nhà Xuất Bản] nvarchar(255),
  [Số Lượng] int ,
  [Giá Tiền] int
);

INSERT INTO Dangnhap (Taikhoan ,Matkhau) VALUES ('Admin' ,'Admin' );
INSERT INTO Dangnhap (Taikhoan ,Matkhau) VALUES ('Qui' ,'123' );

INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Truyện Tranh ', 'Naruto', 'Ba Đình', N'Hà Nội', 10, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Công Nghệ ', N'Lập Trình Mạng', 'Ba Ba', N'TP HCM', 50, 100000);
		INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Công Nghệ1', N'Lập Trình C', 'Vũ Văn Hùng', N'TP HCM', 2, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Thiếu Nhi', N'Conan', N'Ngô Trần Ái', N'TP HCM', 5, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Văn học nghệ thuật', N'Văn Học Mới', 'Thanh Qui', N'TP HCM', 2, 100000);

	select * from Dangnhap where Taikhoan='Admin' AND Matkhau='Admin'
    select * from Dangnhap
    select* from KhoSach

	delete from KhoSach where [Tên Sách] = 'Q1';

	drop table Dangnhap
	