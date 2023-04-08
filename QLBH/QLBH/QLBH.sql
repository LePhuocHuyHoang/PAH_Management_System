CREATE DATABASE QLBH
GO
USE QLBH

create table DANGNHAP
(
    ID    int primary key,
    TAIKHOAN   nchar(20) not null,
	MATKHAU    nchar(20) not null,
)

go
create table KHACHHANG
(
    MaKH	varchar(10) primary key,
    TenKH	nvarchar(50) not null,
    DiaChi	nvarchar(200),
    SDT		nvarchar(100),
    NgaySinh	date,
    STK	nvarchar(100) not null
)
go

create table LOAIHANG
(
    MaLH    varchar(10) primary key,
    TenLH    nvarchar(50) not null,
)

go
create table HANG
(
    MaHang		varchar(10) primary key,
    TenHang		nvarchar(50) not null,
    DonVi		nvarchar(10),
    DonGia		numeric (15,0) not null,
    SoLuongTk    int not null,
    MaLH        varchar(10) foreign key references LOAIHANG(MaLH),
)
go

create table NHANVIEN
(
    MaNV varchar(10) primary key,
    TenNV nvarchar(50) not null,
    DiaChi nvarchar(200),
    NgaySinh date,
	SDT nvarchar(100)
)
go

create table NHACUNGCAP
(
    MaNCC varchar(10) primary key,
    TenNCC nvarchar(50) not null,
    DiaChi nvarchar(200), 
    SDT nvarchar(100), 
    STK nvarchar(100) not null
)
go

create table HOADON
(
    MaHD    varchar(10) primary key,
	ThoiGian    date,
	TongTienHang        numeric(15,0) not null, --tổng tiền hàng = tổng thành tiền tất cả mặt hàng của 1 hóa đơn
	VAT    numeric(15,0) not null, --VAT = 10% tổng tiền hàng
	TongTienTT    numeric(15,0) not null, --tổng tiền thanh toán = tổng tiền hàng - VAT
	MaKH    varchar(10) foreign key references KHACHHANG(MaKH) not null,
    MaNV    varchar(10) foreign key references NHANVIEN(MaNV) not null,
)
go

create table HOADONCHITIET
(
    MaHDCT    varchar(10) foreign key references HOADON(MaHD) not null, 
    SoLuongBan    int not null,
    ThanhTien    numeric(15,0) not null, --thành tiền = số lượng nhập * đơn giá
	MaHang    varchar(10) foreign key references HANG(MaHang) not null,
)
go

create table PHIEUNHAP
(
    MaPN            varchar(10) primary key,
    NgayNhap        date,
	TongTienHang    numeric(15,0) not null, --tổng tiền hàng = tổng thành tiền tất cả mặt hàng của 1 hóa đơn
	VAT                numeric(15,0) not null, --VAT = 10% tổng tiền hàng
    TongTienTT        numeric(15,0) not null, --tổng tiền thanh toán = tổng tiền hàng - VAT
	MaNCC            varchar(10) foreign key references NHACUNGCAP(MaNCC) not null,
	MaNV           varchar(10) foreign key  references NHANVIEN(MaNV) not null,
)
go

create table PHIEUNHAPCHITIET
(
    MaPNCT            varchar(10) foreign key references PHIEUNHAP(MaPN) not null,
    SoLuongNhap            int not null,
    ThanhTien        numeric(15,0) not null, 
	MaHang            varchar(10) foreign key references HANG (MaHang) not null
)
go

/*                                      INSERT DỮ LIỆU                                  */
--DANGNHAp
insert into DANGNHAP values ('1', 'admin','123456')
--bảng Nhân viên
insert into NHANVIEN values ('NV001', N'Lê Thị Phượng Hằng', N'THÔN MỸ CHÁNH, XÃ HẢI CHÁNH, HUYỆN HẢI LĂNG, QUẢN TRỊ', '2002/10/19','0943758563')
insert into NHANVIEN values ('NV002', N'Thi Thị Bích Thư', N'THÔN THANH QUÝT 1,THÀNH PHỐ TAM KỲ, QUẢNG NAM', '2001/01/14','0378845359')
insert into NHANVIEN values ('NV003', N'Nguyễn Thị Minh Tâm', N'18 TRẦN TÙNG VƯƠNG, PHƯỜNG VĨ DẠ, HUẾ', '2001/01/14','0913655784')
insert into NHANVIEN values ('NV004', N'Lê Phước Huy Hoàng', N'XÃ IABLANG, CHƯ SÊ, GIA LAI', '2002/07/04', '0357874555')
insert into NHANVIEN values ('NV005', N'Đỗ Nhật Huy', N'210 HÙNG VƯƠNG, HUẾ', '2002/09/26','0356764839')

--bảng Nhà cung cấp
insert into NHACUNGCAP values ('NC001',N'CÔNG TY TNHH TUẤN LINH', N'57 Hàm Nghi, Phường Vĩnh Trung, Quận Thanh Khê, Thành Phố Đà Nẵng, Việt Nam','0236369129', N'114000009024 - Ngân Hàng TMCP Công Thương - CN Đà Nẵng')
insert into NHACUNGCAP values ('NC002',N'CÔNG TY TNHH TIN HỌC MEGA', N'130 Hàm Nghi, Phường Thạc Gián, Quận Thanh Khê, Thành phố Đà Nẵng, Việt Nam','0236368930', N'0041000141235 - TMCP Ngoại Thương Việt Nam - CN Đà Nẵng')

--bảng Khách hàng
insert into KHACHHANG values('KH001', N'Phạm Nguyễn Khánh Băng', N'03 Lý Thái Tổ', '0789092645', '2002/9/14', N'0789092645 - Ngân Hàng MB')
insert into KHACHHANG values('KH002', N'Nguyễn Tiến Đạt', N'44 Trần Nhân Tông', '0987331825', '2002/5/28', N'113000029373 - Ngân hàng VIETIN')
insert into KHACHHANG values('KH003', N'Nguyễn Ngọc Đức', N'32 Cầu Giấy', '0375860521', '2002/05/06', N'67910000217870 - Ngân hàng BIDV')
insert into KHACHHANG values('KH004', N'Đoàn Ngọc Hương Giang', N'98 Phan Huy Chú', '0944923476', '2002/05/11', N'0121000876577 - Ngân hàng Vietcombank')
insert into KHACHHANG values('KH005', N'Trần Thùy Giang', N'23 Nguyễn Du', '0359295741', '2002/05/10', N'5904201003986 - Ngân hàng AGRIBANK')
insert into KHACHHANG values('KH006', N'Lê Thị Hồng Hạnh', N'01 Phan Bội Châu', '0935618280', '2002/10/22', N'611704060532306 - Ngân hàng VIB')
insert into KHACHHANG values('KH007', N'Võ Văn Hậu', N'72 Hà Huy Tập', '0388590810', '2002/10/8', N'0388590810 - Ngân hàng MB')
insert into KHACHHANG values('KH008', N'Cao Thị Xuân Hiên', N'85 Lê Thánh Tông', '033754463', '2002/07/02', N'0121000817952 - Ngân hàng VCB')
insert into KHACHHANG values('KH009', N'Võ Hồ Hạnh Hoàng', N'87 Phan Châu Trinh', '0777910212', '2002/09/10', N'113000029141 - Ngân hàng VIETIN BANK')
insert into KHACHHANG values('KH010', N'Nguyễn Thị Kim Hồng', N'78 Hai Bà Trưng', '0357470791', '2002/11/18', N'0357470791 - Ngân hàng MB')

--bảng Loại hàng
insert into LOAIHANG values('LH001', N'Linh kiện máy tính' )
insert into LOAIHANG values('LH002', N'Giấy in, máy in bill' )
insert into LOAIHANG values('LH003', N'Linh kiện laptop' )
insert into LOAIHANG values('LH004', N'Màn hình laptop' )
insert into LOAIHANG values('LH005', N'Camera' )

--bảng Hàng
insert into HANG values('H001', N'Mainboard máy tính', N'cái', 1620000, 43, 'LH001')
insert into HANG values('H002', N'Phím, chuột', N'bộ', 390000, 35, 'LH001')
insert into HANG values('H003', N'Máy in tem xprinter 350BM chính hãng', N'cái', 1900000, 9, 'LH002')
insert into HANG values('H004', N'Dây HDMI 5m', N'cái', 150000, 45, 'LH001')
insert into HANG values('H005', N'Bàn phím laptop dell', N'cái', 325000, 13, 'LH003')
insert into HANG values('H006', N'Nguồn máy tính ximagtek 350W', N'cái', 450000, 2, 'LH001')
insert into HANG values('H007', N'LCD AOC 19.5 inch', N'cái', 2450000, 2, 'LH004')
insert into HANG values('H008', N'HDD 1TB Seagate', N'cái', 1050000, 5, 'LH001')
insert into HANG values('H009', N'CAMERA Imou F42P', N'cái', 980000, 5, 'LH005')
insert into HANG values('H010', N'Bàn phím laptop HP 11-K', N'cái', 380000, 19, 'LH003')

-- bảng Hóa đơn
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD001','2020-12-25',137190000,13719000,150909000,'KH001','NV001')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD002','2021-11-30',1350000,135000,1485000,'KH002','NV003')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD003','2021-12-29',6020000,602000,6622000,'KH004','NV005')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD004','2021-12-06',38200000,3820000,42020000,'KH008','NV004')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD005','2021-09-21',7055000,705500,7760500,'KH010','NV002')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD006','2021-12-21',5850000,585000,6435000,'KH006','NV001')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD007','2022-07-22',27340000,2734000,30074000,'KH007','NV005')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD008','2019-12-04',64120000,6412000,70532000,'KH003','NV004')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD009','2019-12-16',9640000,964000,10604000,'KH005','NV001')
INSERT INTO HOADON (MaHD,ThoiGian,TongTienHang,VAT,TongTienTT,MaKH,MaNV) VALUES ('HD010','2019-12-13',19000000,1900000,20900000,'KH009','NV002')
go 

-- bảng Hóa đơn chi tiết
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD001',83,134460000,'H001')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD003',4,3920000,'H009')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD008',14,5320000,'H010')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD004',6,900000,'H004')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD005',3,975000,'H005')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD009',8,7840000,'H009')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD010',10,19000000,'H003')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD001',7,2730000,'H002')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD002',9,1350000,'H004')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD006',3,3150000,'H008')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD008',17,41650000,'H007')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD007',2,1960000,'H009')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD004',12,12600000,'H008')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD005',16,6080000,'H010')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD007',18,18900000,'H008')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD008',7,17150000,'H007')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD009',4,1800000,'H006')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD003',14,2100000,'H004')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD004',13,24700000,'H003')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD006',6,2700000,'H002')
INSERT INTO HOADONCHITIET (MaHDCT,SoLuongBan,ThanhTien,MaHang) VALUES ('HD007',4,6480000,'H001')

--bảng Phiếu nhập 
insert into PHIEUNHAP values ('PN001','2022-1-24', 5400000, 540000, 4860000, 'NC001', 'NV001')
insert into PHIEUNHAP values ('PN002','2022-04-05', 19715000, 1971500, 17743500, 'NC002', 'NV002')
insert into PHIEUNHAP values ('PN003','2022-04-10', 4710000, 471000, 4239000, 'NC002', 'NV005')
insert into PHIEUNHAP values ('PN004','2022-10-19', 12400000, 1240000, 11160000, 'NC001', 'NV004')
go

--bảng Phiếu nhập chi tiết
insert into PHIEUNHAPCHITIET values ('PN001',5, 1700000, 'H002')
insert into PHIEUNHAPCHITIET values ('PN001',2, 3700000, 'H003')
insert into PHIEUNHAPCHITIET values ('PN002',6, 9420000, 'H001')
insert into PHIEUNHAPCHITIET values ('PN002',7, 1925000, 'H005')
insert into PHIEUNHAPCHITIET values ('PN002',9, 8370000, 'H009')
insert into PHIEUNHAPCHITIET values ('PN003',3, 4710000, 'H001')
insert into PHIEUNHAPCHITIET values ('PN004',1, 2400000, 'H007')
insert into PHIEUNHAPCHITIET values ('PN004',10, 10000000, 'H006')
