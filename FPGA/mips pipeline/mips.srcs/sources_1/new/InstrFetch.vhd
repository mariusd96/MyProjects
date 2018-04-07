----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 03/20/2017 03:17:24 PM
-- Design Name: 
-- Module Name: InstrFetch - Behavioral
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

entity InstrFetch is
  Port (
        reset : in std_logic;
        WE : in std_logic;
        clk: in std_logic;
        branchAdr: in std_logic_vector(15 downto 0);
        jumpAdr: in std_logic_vector(15 downto 0);
        PCsrc: in std_logic;
        jump: in std_logic;
        next_instr: out std_logic_vector(15 downto 0); 
        instructiune: out std_logic_vector(15 downto 0) 
        );
end InstrFetch;

architecture Behavioral of InstrFetch is
type reg_array is array(0 to 255) of std_logic_vector(15 downto 0);

signal program : reg_array:=
(
    B"001_000_001_0001010", --addi $1, $0, 10
    --B"001_000_010_1111111", --addi $2, $0, -1
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"010_000_010_0000000", --lw $2, $0(0)
    
    B"001_000_011_0000000", --addi $3, $0, 0
    B"001_000_100_0000001", --addi $4, $0, 1
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    
    B"100_000_001_0010011", --beq $1, $0, 19
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    
    B"000_011_100_101_0_000", --add $5, $3, $4
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    
    B"000_010_101_110_0_000", --add $6, $2, $5
    B"000_000_011_010_0_000", --add $2, $0, $3
    B"000_000_100_011_0_000", --add $3, $0, $4
    B"000_000_110_100_0_000", --add $4, $0, $6
    
    B"110_001_001_0000001", --subi $1, $1, 1
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    B"000_000_000_000_0_010", --sll $0, $0, $0
    
    B"111_000_000_000_1000", --j 8   
    B"000_000_000_000_0_010", --sll $0, $0, $0
    
    B"011_010_110_0010100", --sw $6, 20($2)
    
    others => x"0000"
);

signal pc: std_logic_vector(15 downto 0):=x"0000";
signal pc2: std_logic_vector(15 downto 0):=x"0000";
signal mux1: std_logic_vector(15 downto 0):=x"0000";
signal mux2: std_logic_vector(15 downto 0):=x"0000";
begin
    
    process(clk)
    begin
        if reset = '1' then
            pc <= x"0000";
        else
            if WE = '1' and rising_edge(clk) then
                pc <= mux2;
            end if;
        end if;
    end process;
    
    pc2 <= pc + 1;
    
    mux1 <= branchAdr when PCsrc = '1' else pc2;
    mux2 <= mux1 when jump = '0' else jumpAdr;
    --pc <= mux2;
    
    instructiune <= program(conv_integer(pc(7 downto 0)));
    next_instr <= pc2;
    
end Behavioral;
