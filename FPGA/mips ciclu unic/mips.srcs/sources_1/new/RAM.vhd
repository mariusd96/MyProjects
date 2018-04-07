----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 03/19/2017 07:00:13 PM
-- Design Name: 
-- Module Name: RAM - Behavioral
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

entity RAM is
  Port ( 
          clk: in std_logic;
          RA: in std_logic_vector(3 downto 0);
          WD: in std_logic_vector(15 downto 0);
          WE: in STD_LOGIC;
          RD: out std_logic_vector(15 downto 0));
end RAM;

architecture Behavioral of RAM is

type reg_array is array(0 to 15) of std_logic_vector(15 downto 0);
signal matrice: reg_array := (x"0001", x"0002", x"0F05", x"1234", x"0404", x"4321", x"2112", others => x"0000");

begin
    process(clk, WE)
    begin
        if(rising_edge(clk)) then
            if(WE = '1') then
                matrice(conv_integer(RA)) <= WD;
                RD <= matrice(conv_integer(RA));
            else RD <= matrice(conv_integer(RA));
            end if;
        end if;
    end process;
end Behavioral;
