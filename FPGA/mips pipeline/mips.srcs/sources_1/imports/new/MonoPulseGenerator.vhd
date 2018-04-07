----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 02/27/2017 07:22:40 PM
-- Design Name: 
-- Module Name: MonoPulseGenerator - Behavioral
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

entity MonoPulseGenerator is
  Port ( 
    btn: in std_logic;
    clk: in std_logic;
    enable: out std_logic  
  );
end MonoPulseGenerator;

architecture Behavioral of MonoPulseGenerator is
signal counter2: std_logic_vector(15 downto 0):= (others => '0');
signal en1: std_logic := '0';
signal reg1: std_logic := '0';
signal reg2: std_logic := '0';
signal reg3: std_logic := '0';

begin

    process(clk)
    begin
        if rising_edge(clk) then
            counter2 <= counter2 + 1;
       end if;
    end process;

    en1 <= '1' when counter2 = x"FFFF" else '0';
    
    process(clk)
    begin
        if(rising_edge(clk)) then
            if(en1 = '1') then
                reg1 <= btn;
            end if;
        end if;
    end process;
    
    process(clk)
    begin
        if(rising_edge(clk)) then
            reg3 <= reg2;
        end if;
    end process;
    
    process(clk)
    begin
       if(rising_edge(clk)) then
          reg2 <= reg1;
       end if;
    end process;
    
    enable <= reg2 and (not reg3);

end Behavioral;
