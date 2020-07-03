-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2020-07-03 08:01:07
-- 伺服器版本： 10.4.8-MariaDB
-- PHP 版本： 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `csharp`
--

--
-- 傾印資料表的資料 `account`
--

INSERT INTO `account` (`id`, `account`, `password`) VALUES
(2, '1234', '0000'),
(3, '777', '888'),
(4, 'qaz123', '047c03d186515ccd9a82c459708f4ccc1c0da2d92bac9933e0fdb7ba0b49563f'),
(5, '123', 'a7ead57b221172613dde025f1aaba632e1b82b6915688451629a647b1b5ee083'),
(8, '12', 'f4bb01351e80f87af4ccd13045487c834e72d91a2160431338ba63ca06b3a0f2'),
(9, '13', '3c9cd190d89cd98b7c3cbb8de1b469d6e0ee66b342b45c1d67af919e92559693'),
(10, 'xyz', '1b22b287e53dd72e32059a696cb78da8c872f539da77deb5909093d6acaed860'),
(12, 'xyzz', 'ea956aca6ad60b2f12a5d32d3df927af122d4cc29da962617a001a665b9fb5de'),
(13, 'qwe', '1b22b287e53dd72e32059a696cb78da8c872f539da77deb5909093d6acaed860'),
(14, '555', '182b0e831445d4536ac51de8b9f841b6dff96764c70ef5ee3305ed9250a88481'),
(15, 'popo', '6d564741b470bcefd5010a9d980702fcc0ee1c7a2b7e998a044d4d1f7cf8a3b9'),
(16, 'qq', '8e5c745865b63917f137c4c3d19c8d700a8f944d2d5aa61c4a2763b9cfe768fd');

--
-- 傾印資料表的資料 `user`
--

INSERT INTO `user` (`id`, `name`, `gender`, `birthday`, `phone`, `address`) VALUES
(8, 'Anne', 'female', '2019-06-22', '0912345678', 'eee222'),
(9, 'Sai', 'male', '2018-12-12', '0988123456', 'weqwe12'),
(11, 'Hman', 'male', '1988-11-11', '0987962154', 'rqweqw'),
(12, 'coco', 'male', '1992-11-11', '0912345678', 'DD'),
(14, 'Foo', 'male', '1999-01-01', '0912345678', 'GGGGG');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
