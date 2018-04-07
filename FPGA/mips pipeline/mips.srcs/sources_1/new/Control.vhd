----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 04/03/2017 01:10:17 PM
-- Design Name: 
-- Module Name: Control - Behavioral
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

entity Control is
  Port ( 
        instr : in std_logic_vector(2 downto 0);
        RegDst : out std_logic;
        ExtOp : out std_logic;
        ALUSrc : out std_logic;
        Branch : out std_logic;
        Jump : out std_logic;
        ALUOp : out std_logic_vector(2 downto 0);
        MemWrite: out std_logic;
        MemtoReg : out std_logic;
        RegWrite : out std_logic  
  );
end Control;

architecture Behavioral of Control is

signal RegDst2: std_logic := '0';
signal ExtOp2: std_logic := '0';
signal ALUsrc2: std_logic := '0';
signal Branch2: std_logic := '0';
signal Jump2: std_logic := '0';
signal ALUOp2: std_logic_vector(2 downto 0) := "000";
signal MemWrite2: std_logic := '0';
signal MemtoReg2: std_logic := '0';
signal RegWrite2: std_logic := '0';

begin								  
    process(instr)
    begin
        RegDst2 <= '0';
        ExtOp2 <= '0';
        ALUsrc2 <= '0';
        Branch2 <= '0';
        Jump2 <= '0';
        ALUOp2 <= "000";
        MemWrite2 <= '0';
        MemtoReg2 <= '0';
        RegWrite2 <= '0';
    
        case instr is
            when "000" => RegDst2 <= '1';
                          RegWrite2 <= '1';
                          ALUOp2 <= "010";  
            
            when "001" => RegWrite2 <= '1';
						  ALUSrc2 <= '1';
                          ALUOp2 <= "011";
                          ExtOp2 <= '1';  
                                        
            when "010" => RegWrite2 <= '1';
                          ALUSrc2 <= '1';
                          MemtoReg2 <= '1';
                          ALUOp2 <= "000";
                          ExtOp2 <= '1';
                          
            when "011" => ALUSrc2 <= '1';
                          MemWrite2 <= '1';
                          ALUOp2 <= "000";
                          ExtOp2 <= '1';
            
            when "100" => Branch2 <= '1';
						  ALUOp2 <= "001";
                          ExtOp2 <= '1';
                          
            when "101" => RegWrite2 <= '1';
						  ALUSrc2 <= '1';
                          ALUOp2 <= "101";
                          ExtOp2 <= '1';
                          
            when "110" => RegWrite2 <= '1';
                          ALUSrc2 <= '1';
						  ALUOp2 <= "100";
                          ExtOp2 <= '1';
            
            when others => Jump2 <= '1';
                           ALUOp2 <= "110"; 
        end case;
    end process;
    
    RegDst  <= RegDst2;
    ExtOp <= ExtOp2;
    ALUSrc <= ALUSrc2;
    Branch <= Branch2;
    Jump <= Jump2;
    ALUOp <= ALUOp2;
    MemWrite <= MemWrite2;
    MemtoReg <= MemtoReg2;
    RegWrite <= RegWrite2;
end Behavioral;
