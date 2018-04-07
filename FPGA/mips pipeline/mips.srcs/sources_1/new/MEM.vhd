----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 04/10/2017 01:20:44 PM
-- Design Name: 
-- Module Name: MEM - Behavioral
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

entity MEM is
  Port ( 
        clk : in std_logic;
        MemWrite : in std_logic;
        ALURes : in std_logic_vector(15 downto 0);
        RD2 : in std_logic_vector(15 downto 0);
        MemData: out std_logic_vector(15 downto 0)   
  );
end MEM;

architecture Behavioral of MEM is

type reg_array is array(0 to 255) of std_logic_vector(15 downto 0);
signal matrice: reg_array := (x"FFFF", others => x"0000");

begin
    
    process(clk, MemWrite)
    begin
        if rising_edge(clk) then
            if(MemWrite = '1') then
                --matrice(conv_integer(ALURes)) <= RD2;
                matrice(conv_integer(ALURes(7 downto 0))) <= RD2;
            end if;
        end if;
    end process;
    
    --MemData <= matrice(conv_integer(ALURes));
    MemData <= matrice(conv_integer(ALURes(7 downto 0)));
end Behavioral;
