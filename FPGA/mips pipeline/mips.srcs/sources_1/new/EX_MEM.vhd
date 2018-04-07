----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/08/2017 02:01:44 PM
-- Design Name: 
-- Module Name: EX_MEM - Behavioral
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

entity EX_MEM is
  Port (
        enable : in std_logic;
   
        MemtoReg : in std_logic; --WB
        RegWrite : in std_logic; --WB
        MemWrite : in std_logic; --M
        Branch : in std_logic; --M
        BranchAdr : in std_logic_vector(15 downto 0);
        ZeroFlag : in std_logic;
        ALURes : in std_logic_vector(15 downto 0);
        RD2 : in std_logic_vector(15 downto 0);
        instrMUX : in std_logic_vector(2 downto 0);
        
        clk : in std_logic;
        
        MemtoRegOUT : out std_logic;
        RegWriteOUT : out std_logic;
        MemWriteOUT : out std_logic;
        BranchOUT : out std_logic;
        BranchAdrOUT : out std_logic_vector(15 downto 0);
        ZeroFlagOUT : out std_logic;
        ALUResOUT : out std_logic_vector(15 downto 0);
        RD2OUT : out std_logic_vector(15 downto 0);
        instrMUXOUT : out std_logic_vector(2 downto 0)
  );
end EX_MEM;

architecture Behavioral of EX_MEM is

begin

    process(clk, enable)
    begin
        if(rising_edge(clk)) then
            if(enable = '1') then
                MemtoRegOUT <= MemToReg;
                RegWriteOUT <= RegWrite;
                MemWriteOUT <= MemWrite;
                BranchOUT <= Branch;
                BranchAdrOUT <= BranchAdr;
                ZeroFlagOUT <= ZeroFlag;
                ALUResOUT <= ALURes;
                RD2OUT <= RD2;
                instrMUXOUT <= instrMUX;
            end if;
        end if;
    end process;

end Behavioral;
