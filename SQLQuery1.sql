CREATE DATABASE QuanLySach

use QuanLySach
--- tạo bảng
CREATE TABLE Staff (
    NameStaff nvarchar(255),
	DateOfBirth date,
	PhoneNumber int,
    UserName nvarchar(255) PRIMARY KEY ,
    Pass nvarchar(255)
 );

CREATE TABLE KhoSach (
   [Loại Sách] nvarchar(255)  ,
  [Tên Sách] nvarchar(255) PRIMARY KEY,
   [Tác Giả] nvarchar(255),
  [Nhà Xuất Bản] nvarchar(255),
  [Số Lượng] int ,
  [Giá Tiền] int
);

CREATE TABLE Timkiem (
   [Loại Sách] nvarchar(255)  ,
   [Tên Sách] nvarchar(255) PRIMARY KEY,
   [Tác Giả] nvarchar(255)
); 

CREATE TABLE Mua (
   [Loại Sách] nvarchar(255)  ,
  [Tên Sách] nvarchar(255) PRIMARY KEY,
  [Số Lượng] int ,
  [Tiền Lãi] int,
  [Ngày mua] date 
);

CREATE TABLE Thongke (
   [Loại Sách] nvarchar(255)  ,
  [Tên Sách] nvarchar(255) PRIMARY KEY,
  [Số Lượng] int ,
  [Tiền Lãi] int,
  [Ngày tháng] date 
);

Create table Client
(
	ID int IDENTITY(1, 1) PRIMARY KEY,
	NameClient nvarchar(255),
	Email nvarchar(255),
	Pass nvarchar(255),
	DateOfBirth date,
	PhoneNumber int
)

----- thêm dữ liệu vào bảng 
insert into Client values(N'Nguyễn Thanh Qui','thanhqui123@gmail.com','123','2000-01-01',0123456789)
insert into Client values(N'Nguyễn Thanh Quyền','thanhquyen@gmail.com','123','2000-01-01',087663343)

insert into Staff values(N'Nguyễn Thanh Qui','2000-01-01',0123456789,'Qui','123')
insert into Staff values(N'Nguyễn Thanh Quyền','2000-10-01',033244455,'Quyen','123')

INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Truyện Tranh ', 'Naruto', 'Ba Đình', N'Hà Nội', 10, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Truyện Tranh ', N'7 viên ngọc rồng', N'Nguyễn Văn chung', N'Hà Nội', 15, 150000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Công Nghệ ', N'Giáo Trình Kỹ Thuật Audio Và Video ', N'Nguyễn Tấn Phước', N'TP HCM', 5, 100000);
		INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Công Nghệ', N'Công Nghệ CNC', N'Vũ Văn Hùng', N'TP HCM', 2, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Thiếu Nhi', N'Conan', N'Ngô Trần Ái', N'TP HCM', 5, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Thiếu Nhi', N'doraemon', N'Ngô Tiền', N'TP HN', 5, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Văn học nghệ thuật', N'Văn Học Mới', N'Nguyễn Thanh Qui', N'TP HCM', 2, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Văn học nghệ thuật ', N' Hai Thế Giới', N'VĂN AN', N'TP HCM', 5, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Giáo trình ', N' Mạng Máy Tính', N'Nguyễn Thanh Quyền', N'TP HCM', 5, 100000);
	INSERT INTO KhoSach
    ([Loại Sách], [Tên Sách], [Tác Giả], [Nhà Xuất Bản], [Số Lượng], [Giá Tiền])
VALUES
    (N'Giáo trình ', N' Lập Trình Mạng ', N'Đỗ Văn Viên', N'TP HCM', 4, 100000);

----------- truy vấn cơ bản

	select *from Client
   
    drop table Staff
	
    select* from KhoSach

	delete from KhoSach where [Tên Sách] = 'AAB';

	drop table Client

	select SUM([Giá Tiền]) as 'Thành Tiền' ,[Tên Sách]
    from KhoSach
	--Where [Tên Sách]= N'Hai Thế Giới' 
   group by [Tên Sách]

   select NameClient from Client where Email='thanhquyen@gmail.com'