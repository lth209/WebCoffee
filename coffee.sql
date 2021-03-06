-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th7 10, 2020 lúc 07:06 AM
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
-- Cấu trúc bảng cho bảng `activations`
--

CREATE TABLE `activations` (
  `id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `code` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `completed` tinyint(1) NOT NULL DEFAULT 0,
  `completed_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cart`
--

CREATE TABLE `cart` (
  `cartid` int(10) UNSIGNED NOT NULL,
  `matk` int(10) UNSIGNED NOT NULL,
  `total` float NOT NULL,
  `amount` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `cart`
--

INSERT INTO `cart` (`cartid`, `matk`, `total`, `amount`) VALUES
(17, 22, 162000, 4),
(30, 29, 224000, 6);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cartdetail`
--

CREATE TABLE `cartdetail` (
  `cartid` int(10) UNSIGNED NOT NULL,
  `masp` int(10) UNSIGNED NOT NULL,
  `quantity` int(5) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `cartdetail`
--

INSERT INTO `cartdetail` (`cartid`, `masp`, `quantity`) VALUES
(17, 1, 2),
(17, 4, 1),
(17, 17, 1),
(30, 1, 4),
(30, 4, 1),
(30, 40, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctdh`
--

CREATE TABLE `ctdh` (
  `ma_ctdh` int(10) UNSIGNED NOT NULL,
  `madh` int(10) NOT NULL,
  `masp` int(10) NOT NULL,
  `soluong` int(11) NOT NULL COMMENT 'số lượng',
  `gia` double NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `ctdh`
--

INSERT INTO `ctdh` (`ma_ctdh`, `madh`, `masp`, `soluong`, `gia`, `created_at`, `updated_at`) VALUES
(29, 22, 30, 3, 59000, '2019-12-05 07:38:55', '2019-12-05 07:38:55'),
(28, 22, 35, 5, 43000, '2019-12-05 07:38:55', '2019-12-05 07:38:55'),
(27, 21, 33, 2, 50000, '2019-12-04 09:57:18', '2019-12-04 09:57:18'),
(26, 21, 40, 5, 34000, '2019-12-04 09:57:18', '2019-12-04 09:57:18'),
(25, 20, 22, 3, 45000, '2019-12-04 09:34:41', '2019-12-04 09:34:41'),
(24, 20, 21, 5, 53000, '2019-12-04 09:34:41', '2019-12-04 09:34:41'),
(23, 19, 3, 2, 29000, '2019-12-04 07:52:20', '2019-12-04 07:52:20'),
(22, 19, 7, 1, 42000, '2019-12-04 07:52:20', '2019-12-04 07:52:20'),
(103, 56, 7, 1, 45000, '2020-06-30 10:06:08', '0000-00-00 00:00:00'),
(102, 18, 33, 3, 177000, '2020-06-29 12:32:26', '0000-00-00 00:00:00'),
(30, 23, 29, 5, 59000, '2019-12-05 07:41:02', '2019-12-05 07:41:02'),
(31, 23, 34, 4, 59000, '2019-12-05 07:41:02', '2019-12-05 07:41:02'),
(32, 24, 42, 5, 26000, '2017-07-19 07:47:40', '2017-07-19 07:47:40'),
(33, 24, 44, 4, 22000, '2017-07-19 07:47:40', '2017-07-19 07:47:40'),
(34, 24, 21, 2, 53000, '2017-07-19 07:47:40', '2017-07-19 07:47:40'),
(35, 25, 3, 2, 29000, '2017-08-01 07:48:41', '2017-08-01 07:48:41'),
(36, 25, 5, 4, 45000, '2017-08-01 07:48:41', '2017-08-01 07:48:41'),
(37, 26, 20, 4, 48000, '2018-06-20 07:50:21', '2018-06-20 07:50:21'),
(38, 26, 24, 5, 40000, '2018-06-20 07:50:21', '2018-06-20 07:50:21'),
(39, 27, 36, 2, 59000, '2018-06-20 07:51:37', '2018-06-20 07:51:37'),
(40, 27, 40, 4, 34000, '2018-06-20 07:51:37', '2018-06-20 07:51:37'),
(41, 27, 2, 2, 29000, '2018-06-20 07:51:37', '2018-06-20 07:51:37'),
(42, 28, 11, 4, 45000, '2019-12-05 08:54:13', '2019-12-05 08:54:13'),
(43, 28, 43, 3, 29000, '2019-12-05 08:54:13', '2019-12-05 08:54:13'),
(95, 18, 15, 1, 49000, '2020-06-26 09:26:43', '0000-00-00 00:00:00'),
(94, 18, 9, 1, 50000, '2020-06-26 09:21:58', '0000-00-00 00:00:00'),
(98, 52, 4, 1, 29000, '2020-06-29 12:18:06', '0000-00-00 00:00:00'),
(99, 52, 7, 1, 45000, '2020-06-29 12:18:06', '0000-00-00 00:00:00'),
(91, 51, 29, 2, 118000, '2020-06-22 10:27:50', '0000-00-00 00:00:00'),
(90, 51, 16, 3, 165000, '2020-06-22 10:27:50', '0000-00-00 00:00:00'),
(89, 50, 30, 1, 59000, '2020-06-22 10:16:35', '0000-00-00 00:00:00'),
(88, 50, 4, 1, 29000, '2020-06-22 10:16:35', '0000-00-00 00:00:00'),
(87, 49, 29, 1, 59000, '2020-06-22 10:10:34', '0000-00-00 00:00:00'),
(86, 49, 4, 1, 29000, '2020-06-22 10:10:34', '0000-00-00 00:00:00'),
(85, 48, 7, 1, 45000, '2020-06-22 10:07:29', '0000-00-00 00:00:00'),
(84, 48, 4, 1, 29000, '2020-06-22 10:07:29', '0000-00-00 00:00:00'),
(83, 47, 7, 1, 45000, '2020-06-22 09:20:46', '0000-00-00 00:00:00'),
(82, 47, 4, 2, 58000, '2020-06-22 09:20:46', '0000-00-00 00:00:00'),
(81, 45, 39, 1, 29000, '2020-06-22 09:16:52', '0000-00-00 00:00:00'),
(80, 45, 26, 3, 165000, '2020-06-22 09:16:52', '0000-00-00 00:00:00'),
(79, 45, 15, 1, 49000, '2020-06-22 09:16:52', '0000-00-00 00:00:00'),
(78, 44, 39, 1, 29000, '2020-06-22 08:37:39', '0000-00-00 00:00:00'),
(77, 44, 26, 3, 165000, '2020-06-22 08:37:39', '0000-00-00 00:00:00'),
(76, 44, 15, 1, 49000, '2020-06-22 08:37:39', '0000-00-00 00:00:00'),
(75, 43, 39, 1, 29000, '2020-06-22 08:35:24', '0000-00-00 00:00:00'),
(74, 43, 26, 3, 165000, '2020-06-22 08:35:24', '0000-00-00 00:00:00'),
(73, 43, 15, 1, 49000, '2020-06-22 08:35:24', '0000-00-00 00:00:00'),
(72, 42, 39, 1, 29000, '2020-06-22 08:30:26', '0000-00-00 00:00:00'),
(71, 42, 26, 3, 165000, '2020-06-22 08:30:26', '0000-00-00 00:00:00'),
(70, 42, 15, 1, 49000, '2020-06-22 08:30:26', '0000-00-00 00:00:00'),
(100, 54, 1, 1, 39000, '2020-06-29 12:21:31', '0000-00-00 00:00:00'),
(101, 54, 7, 1, 45000, '2020-06-29 12:21:31', '0000-00-00 00:00:00'),
(104, 56, 31, 1, 59000, '2020-06-30 10:06:09', '0000-00-00 00:00:00'),
(105, 56, 40, 1, 39000, '2020-06-30 10:06:09', '0000-00-00 00:00:00'),
(106, 18, 5, 1, 45000, '2020-06-30 10:08:25', '0000-00-00 00:00:00'),
(107, 57, 7, 1, 45000, '2020-06-30 10:14:08', '0000-00-00 00:00:00'),
(108, 57, 28, 1, 49000, '2020-06-30 10:14:08', '0000-00-00 00:00:00'),
(109, 58, 7, 1, 45000, '2020-06-30 10:28:20', '0000-00-00 00:00:00'),
(110, 58, 28, 1, 49000, '2020-06-30 10:28:20', '0000-00-00 00:00:00'),
(115, 26, 9, 8, 400000, '2020-07-04 20:50:35', '0000-00-00 00:00:00'),
(116, 27, 42, 6, 192000, '2020-07-04 20:51:00', '0000-00-00 00:00:00'),
(117, 26, 31, 17, 1003000, '2020-07-04 20:51:53', '0000-00-00 00:00:00'),
(118, 59, 4, 2, 58000, '2020-07-06 10:30:20', '0000-00-00 00:00:00'),
(119, 59, 11, 5, 250000, '2020-07-06 20:43:45', '0000-00-00 00:00:00'),
(120, 59, 42, 1, 32000, '2020-04-06 20:43:51', '0000-00-00 00:00:00'),
(121, 59, 24, 1, 45000, '2020-03-06 20:44:04', '0000-00-00 00:00:00'),
(122, 59, 2, 1, 29000, '2020-07-06 20:44:11', '0000-00-00 00:00:00'),
(123, 55, 12, 1, 45000, '2020-07-07 10:52:44', '0000-00-00 00:00:00'),
(124, 60, 4, 1, 29000, '2020-06-08 16:47:03', '0000-00-00 00:00:00'),
(125, 60, 7, 1, 45000, '2020-02-08 16:47:03', '0000-00-00 00:00:00'),
(126, 61, 1, 2, 78000, '2020-03-08 17:01:26', '0000-00-00 00:00:00'),
(127, 61, 7, 1, 45000, '2020-03-08 17:01:26', '0000-00-00 00:00:00'),
(128, 62, 7, 1, 45000, '2020-04-08 17:17:05', '0000-00-00 00:00:00'),
(129, 62, 37, 2, 58000, '2020-02-08 17:17:05', '0000-00-00 00:00:00'),
(130, 63, 23, 1, 45000, '2020-05-09 11:34:55', '0000-00-00 00:00:00'),
(131, 63, 29, 4, 236000, '2020-06-09 11:34:55', '0000-00-00 00:00:00'),
(132, 64, 26, 2, 110000, '2020-01-09 11:51:45', '0000-00-00 00:00:00'),
(133, 65, 4, 1, 29000, '2020-07-09 12:50:28', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cthd`
--

CREATE TABLE `cthd` (
  `ma_cthd` int(10) UNSIGNED NOT NULL,
  `mahd` int(10) NOT NULL,
  `masp` int(10) NOT NULL,
  `soluong` int(11) NOT NULL COMMENT 'số lượng',
  `gia` double NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `cthd`
--

INSERT INTO `cthd` (`ma_cthd`, `mahd`, `masp`, `soluong`, `gia`, `created_at`, `updated_at`) VALUES
(38, 36, 22, 3, 45000, '2017-01-04 09:35:17', '2017-12-04 09:35:17'),
(37, 35, 7, 1, 42000, '2019-12-04 07:53:33', '2019-12-04 07:53:33'),
(36, 35, 3, 2, 29000, '2019-12-04 07:53:33', '2019-12-04 07:53:33'),
(35, 34, 13, 1, 35000, '2019-12-04 07:30:14', '2019-12-04 07:30:14'),
(34, 34, 19, 2, 42000, '2019-12-04 07:30:14', '2019-12-04 07:30:14'),
(39, 36, 21, 5, 53000, '2017-12-04 09:35:17', '2017-12-04 09:35:17'),
(40, 37, 33, 2, 50000, '2017-12-04 14:06:17', '2017-12-04 14:06:17'),
(41, 37, 40, 5, 34000, '2017-12-04 14:06:17', '2017-12-04 14:06:17'),
(42, 38, 30, 3, 59000, '2017-12-05 07:43:12', '2017-12-05 07:43:12'),
(43, 38, 35, 5, 43000, '2017-12-05 07:43:12', '2017-12-05 07:43:12'),
(44, 39, 29, 5, 59000, '2017-12-05 07:43:19', '2017-12-05 07:43:19'),
(45, 39, 34, 4, 59000, '2017-12-05 07:43:19', '2017-12-05 07:43:19'),
(46, 40, 20, 4, 48000, '2018-06-20 07:52:33', '2018-06-20 07:52:33'),
(47, 40, 24, 5, 40000, '2018-06-20 07:52:33', '2018-06-20 07:52:33'),
(48, 41, 36, 2, 59000, '2018-06-20 07:52:41', '2018-06-20 07:52:41'),
(49, 41, 40, 4, 34000, '2018-06-20 07:52:41', '2018-06-20 07:52:41'),
(50, 41, 2, 2, 29000, '2018-06-20 07:52:41', '2018-06-20 07:52:41'),
(51, 42, 42, 5, 26000, '2017-07-20 07:53:13', '2017-07-20 07:53:13'),
(52, 42, 44, 4, 22000, '2017-07-20 07:53:13', '2017-07-20 07:53:13'),
(53, 42, 21, 2, 53000, '2017-07-20 07:53:13', '2017-07-20 07:53:13'),
(54, 43, 3, 2, 29000, '2017-08-02 07:53:51', '2017-08-02 07:53:51'),
(55, 43, 5, 4, 45000, '2017-08-02 07:53:51', '2017-08-02 07:53:51'),
(56, 44, 11, 4, 45000, '2019-12-07 00:58:25', '2019-12-07 00:58:25'),
(57, 44, 43, 3, 29000, '2019-12-07 00:58:25', '2019-12-07 00:58:25'),
(58, 54, 3, 1, 10000, '2020-06-05 08:22:34', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dknt`
--

CREATE TABLE `dknt` (
  `id` int(10) UNSIGNED NOT NULL,
  `email` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp(),
  `ngaydk` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `dknt`
--

INSERT INTO `dknt` (`id`, `email`, `created_at`, `updated_at`, `ngaydk`) VALUES
(1, 'admin1780@gmail.com', '2019-12-09 09:29:28', '2019-12-09 09:29:28', '2019-12-09');

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
(61, 31, '2020-02-09', 123000, 'ATM', NULL, '2020-07-10 03:35:49', '2020-07-08 17:01:26', 3, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn B'),
(62, 31, '2020-01-09', 103000, 'ATM', NULL, '2020-07-09 12:20:44', '2020-07-08 17:17:05', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(63, 31, '2020-07-09', 281000, 'ATM', NULL, '2020-05-09 11:34:55', '2020-07-09 11:34:55', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A'),
(64, 31, '2020-04-09', 110000, 'ATM', NULL, '2020-07-10 04:34:14', '2020-07-09 11:51:44', 0, '123 Nguyễn Thị Minh Khai,    TPHCM, VietNam', '0909090909', 'Lan Thảo', 'Nguyễn Văn A');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hoadon`
--

CREATE TABLE `hoadon` (
  `mahd` int(10) UNSIGNED NOT NULL,
  `makh` int(11) DEFAULT NULL,
  `ngaythanhtoan` date DEFAULT NULL,
  `tongtien` float DEFAULT NULL COMMENT 'tổng tiền',
  `httt` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'hình thức thanh toán',
  `ghichu` varchar(500) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Đang đổ dữ liệu cho bảng `hoadon`
--

INSERT INTO `hoadon` (`mahd`, `makh`, `ngaythanhtoan`, `tongtien`, `httt`, `ghichu`, `created_at`, `updated_at`) VALUES
(43, 28, '2017-08-02', 238000, 'ATM', NULL, '2017-08-02 07:53:51', '2017-08-02 07:53:51'),
(42, 28, '2017-07-20', 324000, 'COD', NULL, '2017-07-20 07:53:13', '2017-07-20 07:53:13'),
(41, 24, '2018-06-20', 312000, 'ATM', NULL, '2018-06-20 07:52:41', '2018-06-20 07:52:41'),
(40, 29, '2018-06-20', 392000, 'COD', NULL, '2018-06-20 07:52:33', '2018-06-20 07:52:33'),
(39, 27, '2017-12-05', 531000, 'ATM', NULL, '2017-12-05 07:43:19', '2017-12-05 07:43:19'),
(38, 26, '2017-12-05', 392000, 'COD', NULL, '2017-12-05 07:43:12', '2017-12-05 07:43:12'),
(37, 25, '2019-12-04', 270000, 'COD', NULL, '2019-12-04 14:06:17', '2019-12-04 14:06:17'),
(36, 24, '2019-12-04', 400000, 'ATM', NULL, '2019-12-04 09:35:17', '2019-12-04 09:35:17'),
(35, 21, '2019-12-04', 100000, 'COD', NULL, '2019-12-04 07:53:33', '2019-12-04 07:53:33'),
(34, 24, '2019-12-04', 119000, 'ATM', NULL, '2019-12-04 07:30:14', '2019-12-04 07:30:14'),
(44, 30, '2019-12-07', 267000, 'ATM', NULL, '2019-12-07 00:58:25', '2019-12-07 00:58:25'),
(45, 28, '2020-06-05', 20000, NULL, NULL, '2020-06-05 08:21:32', '2020-06-05 08:21:32');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE `khachhang` (
  `makh` int(10) UNSIGNED NOT NULL,
  `hoten` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `gioitinh` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `diachi` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `tenduong` varchar(100) COLLATE utf8_unicode_ci NOT NULL DEFAULT '23/54 Cách Mạng Tháng Tám',
  `country` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Việt Nam',
  `sodt` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `ghichu` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `matk` int(10) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `khachhang`
--

INSERT INTO `khachhang` (`makh`, `hoten`, `gioitinh`, `email`, `diachi`, `tenduong`, `country`, `sodt`, `ghichu`, `created_at`, `updated_at`, `matk`) VALUES
(17, 'Nguyễn Văn Chung', 'Nam', 'admin@gmail.com', 'TP-HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554019', NULL, '2019-12-05 14:11:38', '2019-11-26 13:34:56', 17),
(18, 'Trần Anh Tài', 'Nam', 'admin123@gmail.com', 'TP-HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554019', NULL, '2019-12-05 14:10:53', '2019-11-26 14:29:36', 18),
(19, 'Hoàng Minh Trị', 'Nam', 'admin1780@gmail.com', 'TP-HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554019', NULL, '2019-12-05 14:11:10', '2019-11-27 01:45:18', 21),
(21, 'Nguyễn Lan Anh', 'Nam', 'lanthao2211@gmail.com', 'TP-HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554019', NULL, '2020-06-22 10:04:26', '2019-11-28 17:00:18', 22),
(22, 'Nguyễn Thị Lan Anh', 'Nữ', 'lananh123@gmail.com', 'TP-HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554019', NULL, '2019-12-04 07:18:22', '2019-11-28 17:09:47', 23),
(24, 'Trần Lan Anh', 'Nữ', 'lananh123@gmail.com', 'Bến Cát - Bình Dương', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359458781', NULL, '2019-12-05 14:12:09', '2019-12-04 07:23:39', 26),
(25, 'Nguyễn Lan Anh', 'Nam', 'lananh123@gmail.com', 'Quận 4 - TP HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0354879587', NULL, '2019-12-05 14:12:31', '2019-12-04 09:57:18', 0),
(26, 'Trần Ngọc Thùy Vân', 'Nữ', 'Thuyvan1999@gmail.com', 'Quận 7 - TP HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0356548751', NULL, '2017-12-05 07:38:55', '2017-12-05 07:38:55', 0),
(27, 'Hoàng Thùy Dung', 'Nữ', 'Thuydung@gmail.com', 'Quận 8 - TP HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359554187', NULL, '2017-12-05 07:41:02', '2017-12-05 07:41:02', 0),
(28, 'Lê Anh Quân', 'Nam', 'Anhquan@gmail.com', 'Quận 3 - TP HCM', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0315421548', NULL, '2017-07-19 07:47:40', '2017-07-19 07:47:40', 0),
(29, 'Nguyễn Tấn Tài', 'Nam', 'Tantai@gmail.com', 'Dĩ An - Bình Dương', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0359874512', NULL, '2018-06-20 07:50:21', '2018-06-20 07:50:21', 0),
(30, 'Trần Hoàng Anh', 'Nam', 'Tranhoanganh@gmail.com', 'Thuận An - Bình Dương', '23/54 Cách Mạng Tháng Tám', 'Việt Nam', '0712365487', NULL, '2019-12-05 08:54:13', '2019-12-05 08:54:13', 0),
(31, 'Lan Thảo', 'Nu', 'lanthao2211@gmail.com', '   TPHCM', '123 Nguyễn Thị Minh Khai', 'VietNam', '0909090909', NULL, '2020-07-08 16:21:52', '2020-07-05 18:52:19', 29),
(32, 'Lan Thảo', 'Nu', 'abc@gmail.com', 'abc', 'asf', 'VietNam', '09090909', NULL, '2020-07-06 12:24:46', '2020-07-06 12:24:46', 30),
(33, 'thảo', 'nữ', 'fas@gmail.com', 'a', 'á', 'VietNam', '09090909', NULL, '2020-07-06 12:26:56', '2020-07-06 12:26:56', 31);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `loaisanpham`
--

CREATE TABLE `loaisanpham` (
  `maloaisp` int(10) UNSIGNED NOT NULL,
  `tenloaisp` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `mota` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `hinhanh` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `loaisanpham`
--

INSERT INTO `loaisanpham` (`maloaisp`, `tenloaisp`, `mota`, `hinhanh`, `created_at`, `updated_at`) VALUES
(1, 'Cà Phê', NULL, NULL, '2016-10-11 19:16:15', '2016-10-12 18:38:35'),
(2, 'Trà và Macchiato', NULL, NULL, '2016-10-11 19:16:15', '2016-10-12 18:38:35'),
(3, 'Thức uống đá xay', NULL, NULL, '2016-10-17 17:33:33', '2016-10-15 00:25:27'),
(4, 'Thức uống sinh tố', NULL, NULL, '2016-10-25 20:29:19', '2016-10-25 19:22:22'),
(5, 'Bánh và Snack', NULL, NULL, '2016-10-27 21:00:00', '2016-10-26 21:00:23');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phanhoi`
--

CREATE TABLE `phanhoi` (
  `maph` int(10) UNSIGNED NOT NULL,
  `hoten` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'tiêu đề',
  `email` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `vande` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'Vấn đề',
  `noidung` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'nội dung',
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp(),
  `ngayph` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `phanhoi`
--

INSERT INTO `phanhoi` (`maph`, `hoten`, `email`, `vande`, `noidung`, `created_at`, `updated_at`, `ngayph`) VALUES
(1, 'Tachibaba Kanade', 'Yuuta1780@gmail.com', 'Phản hồi về cà phê', 'Cà phê của bạn rất ngon, tuy nhiên bạn nên cho ra nhiều lựa chọn về độ ngọt của cà phê nhiều hơn nữa', '2019-12-09 09:14:10', '2019-12-09 09:14:10', '2019-12-09'),
(2, 'Tachibaba Kanade', 'Yuuta1780@gmail.com', 'Phản hồi về snack', 'Bạn nên bổ  sung thêm một số loại Snack khác nữa', '2019-12-09 09:16:31', '2019-12-09 09:16:31', '2019-12-09');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `quyen`
--

CREATE TABLE `quyen` (
  `maquyen` int(10) UNSIGNED NOT NULL,
  `tenquyen` varchar(40) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `quyen`
--

INSERT INTO `quyen` (`maquyen`, `tenquyen`, `created_at`, `updated_at`) VALUES
(1, 'Quản trị viên', '2019-12-01 13:29:03', '2019-12-01 13:29:03'),
(2, 'Khách hàng', '2019-12-01 13:29:25', '2019-12-01 13:29:25'),
(3, 'Thành viên', '2019-12-01 13:29:43', '2019-12-01 13:29:43');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `reminders`
--

CREATE TABLE `reminders` (
  `id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `code` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `completed` tinyint(1) NOT NULL DEFAULT 0,
  `completed_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `reminders`
--

INSERT INTO `reminders` (`id`, `user_id`, `code`, `completed`, `completed_at`, `created_at`, `updated_at`) VALUES
(27, 22, 'KFpurHwmljrteqpnw9OLp3TNjPLa0Uex', 0, NULL, '2019-12-19 03:56:43', '2019-12-19 03:56:43');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE `sanpham` (
  `masp` int(10) UNSIGNED NOT NULL,
  `tensp` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `maloaisp` int(10) UNSIGNED DEFAULT NULL,
  `mota` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `gia` float DEFAULT NULL,
  `giakm` float DEFAULT NULL,
  `hinhanh` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `dvt` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `moi` tinyint(4) DEFAULT 0,
  `tt` int(11) NOT NULL DEFAULT 1,
  `SellQuantity` int(10) UNSIGNED NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`masp`, `tensp`, `maloaisp`, `mota`, `gia`, `giakm`, `hinhanh`, `dvt`, `moi`, `tt`, `SellQuantity`, `created_at`, `updated_at`) VALUES
(1, 'AMERICANO', 1, 'Americano được pha chế bằng cách thêm nước vào một hoặc hai shot Espresso để pha loãng độ đặc của cà phê, từ đó mang lại hương vị nhẹ nhàng, không gắt mạnh và vẫn thơm nồng nàn.', 39000, 37000, 'americano_39k.jpg', 'ly', 0, 0, 15, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(2, 'BẠC SỈU', 1, 'Theo chân những người gốc Hoa đến định cư tại Sài Gòn, Bạc sỉu là cách gọi tắt của \"Bạc tẩy sỉu phé\" trong tiếng Quảng Đông, chính là: Ly sữa trắng kèm một chút cà phê.', 29000, 0, 'bacsiu_29k.jpg', 'ly', 0, 1, 10, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(3, 'CÀ PHÊ ĐEN', 1, 'Một tách cà phê đen thơm ngào ngạt, phảng phất mùi cacao là món quà tự thưởng tuyệt vời nhất cho những ai mê đắm tinh chất nguyên bản nhất của cà phê. Một tách cà phê trầm lắng, thi vị giữa dòng đời vồn vã.', 29000, 0, 'cafeden_29k.jpg', 'ly', 0, 1, 20, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(4, 'CÀ PHÊ SỮA', 1, 'Cà phê phin kết hợp cũng sữa đặc là một sáng tạo đầy tự hào của người Việt, được xem món uống thương hiệu của Việt Nam.', 29000, 0, 'cafesua_29k.jpg', 'ly', 0, 1, 18, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(5, 'CAPPUCINNO', 1, 'Cappucino được gọi vui là thức uống \"một-phần-ba\" - 1/3 Espresso, 1/3 Sữa nóng, 1/3 Foam.', 45000, 0, 'cappucinno_45k.jpg', 'ly', 0, 1, 0, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(6, 'CARAMEL MACCHIATO', 1, 'Vị thơm béo của bọt sữa và sữa tươi, vị đắng thanh thoát của cà phê Espresso hảo hạng, và vị ngọt đậm của sốt caramel.', 55000, 0, 'caramelmacchiato_55k.jpg', 'ly', 0, 1, 0, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(7, 'COLD BREW CAM SẢ', 1, '', 45000, 42000, 'cold_brew_cam_sa_45k.jpg', 'ly', 1, 1, 16, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(8, 'COLD BREW PHÚC BỒN TỬ', 1, '', 50000, 0, 'coldbrewphucbontu_50k.png', 'ly', 0, 1, 0, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(9, 'COLD BREW SỮA TƯƠI', 1, '', 50000, 0, 'coldbrewsuatuoi_50k.jpg', 'ly', 0, 1, 0, '2016-10-25 20:00:16', '2016-10-24 15:11:00'),
(11, 'COLD BREW SỮA TƯƠI MACCHIATO', 1, '', 50000, 45000, 'coldbresuatuoimacchiato_50k.jpg', 'ly', 0, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(12, 'COLD BREW TRUYỀN THỐNG', 1, '', 45000, 0, 'coldbrewtruyenthong_45k.jpg', 'ly', 0, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(13, 'ESPRESSO', 1, 'Một cốc Espresso nguyên bản được bắt đầu bởi những hạt Arabica chất lượng, phối trộn với tỉ lệ cân đối hạt Robusta, cho ra vị ngọt caramel, vị chua dịu và sánh đặc. Để đạt được sự kết hợp này, chúng tôi xay tươi hạt cà phê cho mỗi lần pha.', 35000, 0, 'espresso_35k.jpg', 'ly', 1, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(14, 'LATTE', 1, 'Khi chuẩn bị Latte, cà phê Espresso và sữa nóng được trộn lẫn vào nhau, bên trên vẫn là lớp foam nhưng mỏng và nhẹ hơn Cappucinno.', 45000, 0, 'latte_45k.jpg', 'ly', 0, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(15, 'MOCHA', 1, 'Cà phê Mocha được ví von đơn giản là Sốt Sô cô la được pha cùng một tách Espresso.', 49000, 0, 'mocha_49k.jpg', 'ly', 1, 1, 9, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(16, 'SÔ-CÔ-LA ĐÁ', 1, 'Cacao nguyên chất hoà cùng sữa tươi béo ngậy. Vị ngọt tự nhiên, không gắt cổ, để lại một chút đắng nhẹ, cay cay trên đầu lưỡi.', 55000, 0, 'iced_chocolate_55k.jpg', 'ly', 0, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(17, 'TRÀ CHERRY MACCHIATO', 2, '', 55000, 0, 'tracherrymacchiato_55k.jpg', 'ly', 0, 1, 0, '2016-10-11 19:00:00', '2016-10-26 19:24:00'),
(18, 'TRÀ ĐÀO CAM SẢ', 2, 'Vị thanh ngọt của đào Hy Lạp, vị chua dịu của Cam Vàng nguyên vỏ, vị chát của trà đen tươi được ủ mới mỗi 4 tiếng, cùng hương thơm nồng đặc trưng của sả chính là điểm sáng làm nên sức hấp dẫn của thức uống này. Sản phẩm hiện có 2 phiên bản Nóng và Lạnh phù hợp cho mọi thời gian trong năm.', 45000, 0, 'tradaocamsa_45k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(19, 'TRÀ ĐEN MACCHIATO', 2, 'Trà đen được ủ mới mỗi ngày, giữ nguyên được vị chát mạnh mẽ đặc trưng của lá trà, phủ bên trên là lớp Macchiato \"homemade\" bồng bềnh quyến rũ vị phô mai mặn mặn mà béo béo.', 42000, 0, 'tradenmacchiato_42k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(20, 'TRÀ GẠO RANG MACCHIATO', 2, 'Trà gạo rang, hay còn gọi là Genmaicha, hay Trà xanh gạo lứt có nguồn gốc từ Nhật Bản. Tại The Coffee House, chúng tôi nhấn nhá cho Genmaicha thêm lớp Macchiato để tăng thêm mùi vị cũng như trải nghiệm của chính bạn.', 48000, 0, 'tragaorangmacchiato_48k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(21, 'TRÀ MATCHA LATTE', 2, 'Với màu xanh mát mắt của bột trà Matcha, vị ngọt nhẹ nhàng, pha trộn cùng sữa tươi và lớp foam mềm mịn, Matcha Latte là thức uống yêu thích của tất cả mọi người khi ghé The Coffee House.', 59000, 53000, 'tramatchalatte_59k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(22, 'TRÀ MATCHA MACCHIATO', 2, 'Bột trà xanh Matcha thơm lừng hảo hạng cùng lớp Macchiato béo ngậy là một sự kết hợp tuyệt vời.', 45000, 0, 'tramatchamachiato_45k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(23, 'TRÀ OOLONG SEN AN NHIÊN', 2, '', 45000, 0, 'traoolongsenannhien_45k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(24, 'TRÀ OOLONG VẢI NHƯ Ý', 2, '', 45000, 40000, 'traoolongvainhuy_45k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(25, 'TRÀ PHÚC BỒN TỬ', 2, '', 49000, 0, 'traphucbontu_49k.png', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(26, 'TRÀ XOÀI MACCHIATO', 2, '', 55000, 0, 'traxoaimachiato_55k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(27, 'TRÀ XOÀI MACCHIATO 2', 2, '', 55000, 45000, 'traxoaimachiato2_55k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(28, 'CHANH SẢ ĐÁ XAY', 3, '', 49000, 0, 'chanhsadaxay_49k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(29, 'CHOCOLATE ĐÁ XAY', 3, 'Vị đắng của cà phê kết hợp cùng vị cacao ngọt ngàocủa sô-cô-la, vị sữa tươi ngọt béo, đem đến trải nghiệm vị giác cực kỳ thú vị.', 59000, 0, 'chocolate_daxay_59k.jpg', 'hộp', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(30, 'COOKIES ĐÁ XAY', 3, 'Những mẩu bánh cookies giòn rụm kết hợp ăn ý với sữa tươi và kem tươi béo ngọt, đem đến cảm giác lạ miệng gây thích thú. Một món uống phá cách dễ thương.', 59000, 0, 'cookies_ice_blended_59k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(31, 'ĐÀO VIỆT QUẤT ĐÁ XAY', 3, '', 59000, 0, 'daovietquatdaxay_59k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(32, 'MATCHA ĐÁ XAY', 3, 'Matcha thanh, nhẫn, và đắng nhẹ được nhân đôi sảng khoái khi uống lạnh. Nhấn nhá thêm những nét bùi béo của kem và sữa. Gây thương nhớ vô cùng!', 59000, 0, 'matchadaxay_59k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(33, 'ỔI HỒNG VIỆT QUẤT ĐÁ XAY', 3, '', 59000, 50000, 'oihongvietquatdaxay_59k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(34, 'PHÚC BỒN TỬ CAM ĐÁ XAY', 3, '', 59000, 0, 'phucbontucamdaxay_59k.png', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(35, 'SINH TỐ CAM XOÀI', 4, 'Vị mứt cam xoài hòa trộn độc đáo với sữa chua, cho cảm giác chua ngọt rất sướng. Điểm nhấn là những mẩu bánh cookie giòn tan giúp sự thưởng thức thêm thú vị.', 59000, 43000, 'sinhtocamxoai_59k.jpg', 'ly', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(36, 'SINH TỐ VIỆT QUẤT', 4, 'Mứt Việt Quất chua thanh, ngòn ngọt, phối hợp nhịp nhàng với dòng sữa chua bổ dưỡng. Là món sinh tố thơm ngon mà cả đầu lưỡi và làn da đều thích.', 59000, 0, 'sinhtovietquat_59k.jpg', 'ly', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(37, 'BÁNH BÔNG LAN TRỨNG MUỐI', 5, '', 29000, 0, 'banhbonglantrungmuoi_29k.jpg', 'cái', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(38, 'BÁNH CHOCOLATE', 5, '', 29000, 0, 'banhchocolate_29k.jpg', 'cái', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(39, 'BÁNH CROISSANT BƠ TỎI', 5, '', 29000, 0, 'banhcroissantbotoi_29k.jpg', 'cái', 0, 1, 15, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(40, 'BÁNH GẤU CHOCOLATE', 5, '', 39000, 34000, 'banhgauchocolate_39k.jpg', 'cái', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(41, 'BÁNH MATCHA', 5, '', 29000, 0, 'banhmatcha_29k.jpg', 'cái', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(42, 'BÁNH MÌ CHÀ BÔNG PHÔ MAI', 5, '', 32000, 26000, 'banhmichabongphomai_32k.jpg', 'cái', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(43, 'BÁNH PASSION CHEESE', 5, '', 29000, 0, 'banhpassioncheese_29k.jpg', 'cái', 1, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(44, 'BÁNH TIRAMISU', 5, '', 29000, 22000, 'banhtiramisu_29k.jpg', 'cái', 0, 1, 0, '2016-10-12 19:20:00', '2016-10-18 20:20:00'),
(66, 'Trà sữa trân châu đường đen', 1, 'Trà sữa chưa hết “hot”, mùa hè này lại rộ lên “phiên bản” mới với những nguyên liệu không hề mới mẻ - sữa tươi trân châu đường đen song lại rất đắt khách ở TP.HCM.', 26000, 24000, 'tra-sua-tran-chau-duong-den_36k.jpg', 'Ly', 0, 1, 0, '2019-11-30 14:01:37', '2019-11-30 14:01:37');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `slide`
--

CREATE TABLE `slide` (
  `id` int(11) NOT NULL,
  `link` varchar(100) NOT NULL,
  `hinhanh` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `slide`
--

INSERT INTO `slide` (`id`, `link`, `hinhanh`) VALUES
(1, '', 'banner1.jpg'),
(2, '', 'banner2.jpg'),
(3, '', 'banner3.jpg'),
(4, '', 'banner4.jpg'),
(5, '', 'banner5.jpg'),
(6, '', 'banner6.jpg');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tintuc`
--

CREATE TABLE `tintuc` (
  `matt` int(10) NOT NULL,
  `tieude` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'tiêu đề',
  `noidung` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'nội dung',
  `hinhanh` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'hình',
  `create_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `update_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `id` int(10) UNSIGNED NOT NULL,
  `tentk` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp(),
  `maquyen` int(10) DEFAULT NULL,
  `ttdn` int(2) NOT NULL DEFAULT 0,
  `hinhanh` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`id`, `tentk`, `email`, `password`, `remember_token`, `created_at`, `updated_at`, `maquyen`, `ttdn`, `hinhanh`) VALUES
(18, 'Yuuta', 'admin123@gmail.com', '$2y$10$Uu6QkXJ8pBHJsA.0MuBs5eHcARFyxjlvMN87cfcPG2RaBP3Gi553m', NULL, '2019-11-26 14:29:36', '2019-11-26 14:29:36', 2, 0, NULL),
(21, 'Yuuta', 'admin1780@gmail.com', '$2y$10$Hfb666GFeByGWp7AProKi.XZqiMsJ5H5TcotQo9h3rwmUTsmy6gl6', NULL, '2019-11-27 01:45:18', '2019-11-27 01:45:18', 2, 0, NULL),
(22, 'Lan Anh', 'quoctuan1780@gmail.com', '$2y$10$jCuFxQRFYNjJq1H8.cmGy.CeoYlNIXPYY28TX0sZ4j5QoXyy3fExm', NULL, '2019-11-28 17:00:18', '2019-11-28 17:00:18', 2, 0, 'Yuuta.jpg'),
(23, 'Yuuta', 'quoctuanlyoko@gmail.com', '$2y$10$y6qbjdlpxodZ8FWfyh1H7ORv5i0EP6UaKX/ZfBisdMn8jUJpkKjNe', NULL, '2019-11-28 17:09:47', '2019-11-28 17:09:47', 2, 0, NULL),
(26, 'Kanade', 'Yuuta1780@gmail.com', '$2y$10$PwU/GLD3CjTWzAMzlrFSuecv4Iyh8a40J2.RU5zSW0itLYrz/F5vK', NULL, '2019-12-04 07:23:39', '2019-12-04 07:23:39', 2, 1, NULL),
(27, 'Tường Vy', 'Tuongvy@gmail.com', '$2y$10$lbIp2hC2B9Rm9QAyqB2f6uB6/FK.DKTYEzzOs7o2TlTKWbmKbUJxG', NULL, '2019-12-05 07:58:31', '2019-12-05 07:58:31', 3, 0, 'Alita-Battle-Angel-17.jpg'),
(29, 'lanthao', 'lanthao2211@gmail.com', '25d55ad283aa400af464c76d713c07ad', NULL, '2020-07-05 18:52:19', '2020-07-05 18:52:19', 2, 0, NULL),
(30, 'test', 'abc@gmail.com', '25d55ad283aa400af464c76d713c07ad', NULL, '2020-07-06 12:24:46', '2020-07-06 12:24:46', 2, 0, NULL),
(31, 'test2', 'fas@gmail.com', '25d55ad283aa400af464c76d713c07ad', NULL, '2020-07-06 12:26:56', '2020-07-06 12:26:56', 1, 0, NULL);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `activations`
--
ALTER TABLE `activations`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cartid`),
  ADD KEY `fk_cart_acc` (`matk`);

--
-- Chỉ mục cho bảng `cartdetail`
--
ALTER TABLE `cartdetail`
  ADD PRIMARY KEY (`cartid`,`masp`),
  ADD KEY `fk_cart_sp` (`masp`);

--
-- Chỉ mục cho bảng `ctdh`
--
ALTER TABLE `ctdh`
  ADD PRIMARY KEY (`ma_ctdh`);

--
-- Chỉ mục cho bảng `cthd`
--
ALTER TABLE `cthd`
  ADD PRIMARY KEY (`ma_cthd`);

--
-- Chỉ mục cho bảng `dknt`
--
ALTER TABLE `dknt`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `donhang`
--
ALTER TABLE `donhang`
  ADD PRIMARY KEY (`madh`);

--
-- Chỉ mục cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`mahd`);

--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`makh`);

--
-- Chỉ mục cho bảng `loaisanpham`
--
ALTER TABLE `loaisanpham`
  ADD PRIMARY KEY (`maloaisp`);

--
-- Chỉ mục cho bảng `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `phanhoi`
--
ALTER TABLE `phanhoi`
  ADD PRIMARY KEY (`maph`);

--
-- Chỉ mục cho bảng `quyen`
--
ALTER TABLE `quyen`
  ADD PRIMARY KEY (`maquyen`);

--
-- Chỉ mục cho bảng `reminders`
--
ALTER TABLE `reminders`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`masp`);

--
-- Chỉ mục cho bảng `slide`
--
ALTER TABLE `slide`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `tintuc`
--
ALTER TABLE `tintuc`
  ADD PRIMARY KEY (`matt`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_email_unique` (`email`),
  ADD KEY `maquyen` (`maquyen`),
  ADD KEY `maquyen_2` (`maquyen`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `activations`
--
ALTER TABLE `activations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `cart`
--
ALTER TABLE `cart`
  MODIFY `cartid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT cho bảng `ctdh`
--
ALTER TABLE `ctdh`
  MODIFY `ma_ctdh` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=134;

--
-- AUTO_INCREMENT cho bảng `cthd`
--
ALTER TABLE `cthd`
  MODIFY `ma_cthd` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT cho bảng `dknt`
--
ALTER TABLE `dknt`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `donhang`
--
ALTER TABLE `donhang`
  MODIFY `madh` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `mahd` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `makh` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT cho bảng `loaisanpham`
--
ALTER TABLE `loaisanpham`
  MODIFY `maloaisp` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT cho bảng `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `phanhoi`
--
ALTER TABLE `phanhoi`
  MODIFY `maph` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `reminders`
--
ALTER TABLE `reminders`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `masp` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- AUTO_INCREMENT cho bảng `slide`
--
ALTER TABLE `slide`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `fk_cart_acc` FOREIGN KEY (`matk`) REFERENCES `users` (`id`);

--
-- Các ràng buộc cho bảng `cartdetail`
--
ALTER TABLE `cartdetail`
  ADD CONSTRAINT `fk_cart_sp` FOREIGN KEY (`masp`) REFERENCES `sanpham` (`masp`),
  ADD CONSTRAINT `fk_cartdetail_cart` FOREIGN KEY (`cartid`) REFERENCES `cart` (`cartid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
