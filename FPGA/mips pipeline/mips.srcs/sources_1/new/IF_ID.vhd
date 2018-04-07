----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/08/2017 01:16:37 PM
-- Design Name: 
-- Module Name: IF_ID - Behavioral
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

entity IF_ID is
  Port ( 
        enable: in std_logic;
        next_instr: in std_logic_vector(15 downto 0); 
        instructiune: in std_logic_vector(15 downto 0);
        clk: in std_logic;
        next_instr2: out std_logic_vector(15 downto 0);
        instructiune2: out std_logic_vector(15 downto 0) 
  );
end IF_ID;

architecture Behavioral of IF_ID is

begin

    process(clk, enable)
    begin
        if rising_edge(clk) then
            if(enable = '1') then
                next_instr2 <= next_instr;
                instructiune2 <= instructiune;
            end if;
        end if;
    end process;

end Behavioral;
