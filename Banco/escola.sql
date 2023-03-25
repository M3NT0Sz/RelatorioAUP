-- phpMyAdmin SQL Dump
-- version 4.1.4
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 25-Mar-2023 às 12:37
-- Versão do servidor: 5.6.15-log
-- PHP Version: 5.5.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `escola`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `alunos`
--

CREATE TABLE IF NOT EXISTS `alunos` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(100) NOT NULL,
  `rg` varchar(100) NOT NULL,
  `dn` datetime NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=15 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `professor`
--

CREATE TABLE IF NOT EXISTS `professor` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(200) NOT NULL,
  `datanasc` date NOT NULL,
  `formacao` varchar(200) NOT NULL,
  `endereco` varchar(200) NOT NULL,
  `cep` int(8) NOT NULL,
  `cidade` varchar(200) NOT NULL,
  `senha` varchar(200) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Extraindo dados da tabela `professor`
--

INSERT INTO `professor` (`codigo`, `nome`, `datanasc`, `formacao`, `endereco`, `cep`, `cidade`, `senha`) VALUES
(3, 'Matheus Mendes', '2023-03-21', 'Nenhum', 'Rua 01', 19200000, 'Pirapozinho', '1234');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=27 ;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`codigo`, `nome`, `email`, `senha`) VALUES
(22, 'PÃ£o', 'pao@outlook.com', '827ccb0eea8a706c4c34a16891f84e7b'),
(21, 'Matheus Mendes', 'matheusmendes2005@outlook.com', '827ccb0eea8a706c4c34a16891f84e7b'),
(25, 'aaa', 'aaa@hotmail.com', '47bce5c74f589f4867dbd57e9ca9f808'),
(26, 'Bola', 'matheusmendes2005@outlook.com', '1234');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
