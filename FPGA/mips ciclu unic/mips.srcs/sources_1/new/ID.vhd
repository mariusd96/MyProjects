----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 04/03/2017 01:04:21 PM
-- Design Name: 
-- Module Name: ID - Behavioral
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

entity ID is
  Port (
        clk : in std_logic;
        instr : in std_logic_vector(15 downto 0);
        WD : in std_logic_vector(15 downto 0); 
        WE: in std_logic;
        RegWr : in std_logic;
        RegDst : in std_logic;
        ExtOp : in std_logic;
        RD1:  out std_logic_vector(15 downto 0);
        RD2:  out std_logic_vector(15 downto 0);
        Ext_imm: out std_logic_vector(15 downto 0);
        func: out std_logic_vector(2 downto 0);
        sa: out std_logic
   );
end ID;

architecture Behavioral of ID is

component reg_file is
  Port (
        clk: in std_logic;
        RA: in std_logic_vector(2 downto 0);
        RB: in std_logic_vector(2 downto 0);
        WA: in std_logic_vector(2 downto 0);
        WD: in std_logic_vector(15 downto 0);
        WE: in STD_LOGIC;
        RD1: out std_logic_vector(15 downto 0);
        RD2: out std_logic_vector(15 downto 0));
end component;

signal mux1: std_logic_vector(2 downto 0) := "000";
signal ext : std_logic_vector(15 downto 0) := x"0000";
signal rdx1: std_logic_vector(15 downto 0) := x"0000";
signal rdx2: std_logic_vector(15 downto 0) := x"0000";
signal andSignal : std_logic:= '0';
begin
    mux1 <= instr(9 downto 7) when RegDst = '0' else instr(6 downto 4);
    andSignal <= WE and RegWr;
    rg1 : reg_file port map(clk, instr(12 downto 10), instr(9 downto 7), mux1, WD, andSignal, rdx1, rdx2); 
    
    RD1 <= rdx1;
    RD2 <= rdx2;
    Ext_imm(6 downto 0) <= instr(6 downto 0);
    Ext_imm(15 downto 7) <= (15 downto 7 => instr(6)) when ExtOp = '1' else (15 downto 7 => '0');
    func <= instr(2 downto 0);
    sa <= instr(3);
    

end Behavioral;
