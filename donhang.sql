-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th7 10, 2020 lúc 05:24 AM
-- Phiên bản máy phục vụ: 10.4.13-MariaDB
-- Phiên bản PHP: 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `coffee`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `donhang`
--

CREATE TABLE `donhang` (
  `madh` int(10) UNSIGNED NOT NULL,
  `makh` int(11) DEFAULT NULL,
  `ngaydat` date DEFAULT NULL,
  `tongtien` float DEFAULT NULL COMMENT 'tổng tiền',
  `httt` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'hình thức thanh toán',
  `ghichu` varchar(500) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp(),
  `tttt` int(2) NOT NULL DEFAULT 0 COMMENT 'Trạng thái thanh toán',
  `diachi` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `sdt` varchar(11) NOT NULL,
  `hoten` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `shipper` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_vietnamese_ci DEFAULT 'Nguyễn Văn A'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `donhang`
--

INSERT INTO `donhang` (`madh`, `makh`, `ngaydat`, `tongtien`, `httt`, `ghichu`, `created_at`, `updated_at`, `tttt`, `diachi`, `sdt`, `hoten`, `shipper`) VALUES
(21, 25, '2019-12-04', 270000, 'COD', 'Giao hàng vô hẻm số 3, Trần Hưng Đạo nha', '2019-12-04 14:06:17', '2019-12-04 09:57:18', 1, '', '', '', 'Nguyễn Văn A'),
(20, 24, '2019-12-04', 400000, 'ATM', 'Giao hàng trước 5h chiều ngày 5/12', '2019-12-04 09:35:17', '2019-12-04 09:34:41', 1, '', '', '', 'Nguyễn Văn A'),
(19, 21, '2019-12-04', 100000, 'COD', 'Giao hàng trước 5h nha', '2019-12-04 07:53:33', '2019-12-04 07:52:20', 1, '', '', '', 'Nguyễn Văn A'),
(18, 24, '2019-12-04', 84043, 'ATM', 'Giao hàng nhanh nha', '2020-07-04 19:17:27', '2019-12-04 07:29:31', 1, '', '0562243509', 'aaaaa', 'Nguyễn Văn A'),
(22, 26, '2017-12-05', 392000, 'COD', 'Giao hàng sớm nha', '2019-12-05 07:43:12', '2017-12-05 07:38:55', 1, '', '', '', 'Nguyễn Văn A'),
(23, 27, '2017-12-05', 531000, 'ATM', 'Giao tại đường số 7 xa lộ nha', '2019-12-05 07:43:19', '2017-12-05 07:41:02', 1, '', '', '', 'Nguyễn Văn A'),
(24, 28, '2017-07-19', 324000, 'COD', 'Giao tại hẻm số 5', '2017-07-20 07:53:13', '2017-07-19 07:47:40', 1, '', '', '', 'Nguyễn Văn A'),
(25, 28, '2017-08-01', 238000, 'ATM', NULL, '2017-08-02 07:53:51', '2017-08-01 07:48:41', 1, '', '', '', 'Nguyễn Văn A'),
(26, 29, '2018-06-20', 1225000, 'COD', 'Giao tại cổng chào nha', '2020-07-04 20:51:53', '2018-06-20 07:50:21', 1, '', '', '', 'Nguyễn Văn A'),
(27, 24, '2018-06-20', 388000, 'ATM', 'Giao tại địa chỉ 405 - Thuận An - Bình Dương', '2020-07-04 20:51:00', '2018-06-20 07:51:37', 1, '', '', '', 'Nguyễn Văn A'),
(28, 30, '2019-12-05', 267000, 'ATM', 'Giao tại đường số 5 đối diện cột đèn giao thông', '2019-12-07 00:58:25', '2019-12-05 08:54:13', 1, '', '', '', 'Nguyễn Văn A'),
(52, 21, '2020-06-29', 74000, 'ATM', NULL, '2020-06-29 12:18:06', '2020-06-29 12:18:06', 0, '', '', '', 'Nguyễn Văn A'),
(51, 21, '2020-06-22', 283000, 'ATM', 'Gửi cho Nguyên Ngu 2 chiếc sô cô la', '2020-06-22 10:27:50', '2020-06-22 10:27:50', 0, '', '', '', 'Nguyễn Văn A'),
(50, 21, '2020-06-22', 88000, 'ATM', NULL, '2020-06-22 10:16:35', '2020-06-22 10:16:35', 0, '', '', '', 'Nguyễn Văn A'),
(49, 21, '2020-06-22', 88000, 'ATM', NULL, '2020-06-22 10:10:33', '2020-06-22 10:10:33', 0, '', '', '', 'Nguyễn Văn A'),
(48, 21, '2020-06-22', 74000, 'ATM', NULL, '2020-06-22 10:07:29', '2020-06-22 10:07:29', 0, '', '', '', 'Nguyễn Văn A'),
(47, 21, '2020-06-22', 103000, 'ATM', NULL, '2020-06-22 09:20:46', '2020-06-22 09:20:46', 0, '', '', '', 'Nguyễn Văn A'),
(46, 21, '2020-06-22', 0, 'ATM', NULL, '2020-06-22 09:17:15', '2020-06-22 09:17:15', 0, '', '', '', 'Nguyễn Văn A'),
(45, 21, '2020-06-22', 243000, 'ATM', NULL, '2020-06-22 09:16:52', '2020-06-22 09:16:52', 0, '', '', '', 'Nguyễn Văn A'),
(44, 21, '2020-06-22', 243000, 'ATM', NULL, '2020-06-22 08:37:39', '2020-06-22 08:37:39', 0, '', '', '', 'Nguyễn Văn A'),
(43, 21, '2020-06-22', 243000, 'ATM', NULL, '2020-06-22 08:35:24', '2020-06-22 08:35:24', 0, '', '', '', 'Nguyễn Văn A'),
(42, 21, '2020-06-22', 243000, 'ATM', NULL, '2020-06-22 08:30:25', '2020-06-22 08:30:25', 0, '', '', '', 'Nguyễn Văn A'),
(53, 21, '2020-06-29', 0, 'ATM', NULL, '2020-06-29 12:20:05', '2020-06-29 12:20:05', 0, '', '', '', 'Nguyễn Văn A'),
(54, 21, '2020-06-29', 84000, 'ATM', NULL, '2020-06-29 12:21:31', '2020-06-29 12:21:31', 0, '', '', '', 'Nguyễn Văn A'),
(55, 21, '2020-06-29', 45000, 'ATM', NULL, '2020-02-07 10:52:44', '2020-06-29 12:22:15', 3, '23/54 Lê Trọng Tấn', '0562243509', 'Nguyễn Lan Thảo', 'Nguyễn Văn A'),
(56, 21, '2020-06-30', 143000, 'ATM', NULL, '2020-01-07 10:52:06', '2020-06-30 10:06:08', 2, 'TP-HCM', '0359554019', 'Nguy?n Lan Anh', 'Nguyễn Văn A'),
(57, 21, '2020-06-30', 94000, 'ATM', NULL, '2020-07-07 10:51:48', '2020-06-30 10:14:08', 2, 'TP-HCM', '12345667', 'Nguy?n Lan Anh', 'Nguyễn Văn A'),
(58, 21, '2020-06-30', 94000, 'ATM', NULL, '2020-07-06 12:32:50', '2020-06-30 10:28:20', 1, '23/54 Lê Trọng Tấn', '0902216524', 'Nguyễn Lan Anh', 'Nguyễn Văn A'),
(59, 31, '2020-07-06', 414000, 'ATM', NULL, '2020-07-06 20:44:11', '2020-07-06 10:30:20', 1, '123 Nguyễn Thị Minh Khai, TPHCM, VietNam', '0909090909', 'Nguyễn Lan Thảo', 'Nguyễn Văn A'),
(60, 31, '2020-07-08', 74000, 'ATM', NULL, '2020-07-08 16:57:31', '2020-07-08 16:47:02', 2, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(61, 31, '2020-02-09', 123000, 'ATM', NULL, '2020-07-09 12:20:50', '2020-07-08 17:01:26', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(62, 31, '2020-01-09', 103000, 'ATM', NULL, '2020-07-09 12:20:44', '2020-07-08 17:17:05', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(63, 31, '2020-07-09', 281000, 'ATM', NULL, '2020-05-09 11:34:55', '2020-07-09 11:34:55', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(64, 31, '2020-04-09', 110000, 'ATM', NULL, '2020-07-09 12:20:30', '2020-07-09 11:51:44', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(65, 31, '2020-07-09', 29000, 'ATM', NULL, '2020-07-09 12:50:28', '2020-07-09 12:50:28', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `donhang`
--
ALTER TABLE `donhang`
  ADD PRIMARY KEY (`madh`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `donhang`
--
ALTER TABLE `donhang`
  MODIFY `madh` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
