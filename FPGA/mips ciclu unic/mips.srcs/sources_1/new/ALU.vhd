----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 03/19/2017 08:47:16 PM
-- Design Name: 
-- Module Name: ALU - Behavioral
-- Project Name: 
-- Target Devices: 
-- Tool Versions: 
-- Description: 
-- 
-- Dependencies: 
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
-- 
----------------------------------------------------------------------------------


library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity ALU is
    Port ( sw : in STD_LOGIC_VECTOR (7 downto 0);
           sel : in STD_LOGIC_VECTOR (1 downto 0);
           digits : out STD_LOGIC_VECTOR (15 downto 0);
           dz : out STD_LOGIC);
end ALU;

architecture Behavioral of ALU is
signal x: std_logic_vector(15 downto 0):="0000";
signal y: std_logic_vector(15 downto 0):="0000";
signal z: std_logic_vector(15 downto 0):="0000";
signal rezultat: std_logic_vector(15 downto 0):="0000";
begin
    x(3 downto 0) <= sw(3 downto 0);
    y(3 downto 0) <= sw(7 downto 4);
    z(7 downto 0) <= sw(7 downto 0);
    process(sel, x, y, z)
    begin
        case sel is
            when "00" => rezultat <= x + y;
            when "01" => rezultat <= x - y;
            when "10" => z(15 downto 0) <= z(13 downto 0) & "00";
                               rezultat <= z;
            when "11" => z(15 downto 0) <= "00" & z(15 downto 2);
                               rezultat <= z;
            when others => rezultat <= x + y;
        end case;
    end process;
    
    digits <= rezultat;
    dz <= '1' when rezultat = x"FFFF" else '0';
end Behavioral;
