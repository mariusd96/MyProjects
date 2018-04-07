----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/08/2017 02:17:59 PM
-- Design Name: 
-- Module Name: MEM_WB - Behavioral
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

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity MEM_WB is
  Port ( 
        enable : std_logic;
        
        MemToReg : in std_logic;
        RegWrite : in std_logic;
        ReadData : in std_logic_vector(15 downto 0);
        ALURes : in std_logic_vector(15 downto 0);
        instrMUX : in std_logic_vector(2 downto 0);
        
        clk : in std_logic;
        
        MemToRegOUT : out std_logic;
        RegWriteOUT : out std_logic;
        ReadDataOUT : out std_logic_vector(15 downto 0);
        ALUResOUT : out std_logic_vector(15 downto 0);
        instrMUXOUT : out std_logic_vector(2 downto 0)
  );
end MEM_WB;

architecture Behavioral of MEM_WB is

begin

    process(clk, enable)
    begin
        if(rising_edge(clk)) then
            if(enable = '1') then
                MemToRegOUT <= MemToReg;
                RegWriteOUT <= RegWrite;
                ReadDataOUT <= ReadData;
                ALUResOUT <= ALURes;
                instrMUXOUT <= instrMUX;
            end if;
        end if;
    end process;

end Behavioral;
