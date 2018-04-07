----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/08/2017 01:24:32 PM
-- Design Name: 
-- Module Name: ID_EX - Behavioral
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

entity ID_EX is
  Port ( 
        enable : in std_logic;
        
        MemToReg : in std_logic; --WB
        RegWrite : in std_logic; --WB
        MemWrite : in std_logic; --M
        Branch : in std_logic; --M
        ALUOp : in std_logic_vector(2 downto 0); --EX
        ALUSrc : in std_logic; --EX
        RegDst : in std_logic; --EX
        nxtInstructiune : in std_logic_vector(15 downto 0);
        RD1 : in std_logic_vector(15 downto 0);
        RD2 : in std_logic_vector(15 downto 0);
        Ext_Imm : in std_logic_vector(15 downto 0);
        func : in std_logic_vector(2 downto 0);
        sa : in std_logic;
        RA : in std_logic_vector(2 downto 0);
        RB : in std_logic_vector(2 downto 0);
        
        clk : in std_logic;
        
        MemToRegOUT : out std_logic; --WB
        RegWriteOUT : out std_logic; --WB
        MemWriteOUT : out std_logic; --M
        BranchOUT : out std_logic; --M
        ALUOpOUT : out std_logic_vector(2 downto 0); --EX
        ALUSrcOUT : out std_logic; --EX
        RegDstOUT : out std_logic; --EX
        nxtInstructiuneOUT : out std_logic_vector(15 downto 0);
        RD1OUT : out std_logic_vector(15 downto 0);
        RD2OUT : out std_logic_vector(15 downto 0);
        Ext_ImmOUT : out std_logic_vector(15 downto 0);
        funcOUT : out std_logic_vector(2 downto 0);
        saOUT : out std_logic;
        RAOUT : out std_logic_vector(2 downto 0);
        RBOUT : out std_logic_vector(2 downto 0)
  );
end ID_EX;

architecture Behavioral of ID_EX is

begin

    process(clk, enable)
    begin
        if(rising_edge(clk)) then
            if(enable = '1') then
                MemToRegOUT <= MemToReg;
                RegWriteOUT <= RegWrite;
                MemWriteOUT <= MemWrite;
                BranchOUT <= Branch;
                ALUOpOUT <= ALUOp;
                ALUSrcOUT <= ALUSrc;
                RegDstOUT <= RegDst;
                nxtInstructiuneOUT <= nxtInstructiune;
                RD1OUT <= RD1;
                RD2OUT <= RD2;
                Ext_ImmOUT <= Ext_Imm;
                funcOUT <= func;
                saOUT <= sa;
                RAOUT <= RA;
                RBOUT <= RB;
            end if;
        end if;
    end process;

end Behavioral;
