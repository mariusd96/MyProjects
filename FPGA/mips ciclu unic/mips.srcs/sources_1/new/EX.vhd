----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 04/10/2017 01:00:47 PM
-- Design Name: 
-- Module Name: EX - Behavioral
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

entity EX is
  Port ( 
        pcNext : in std_logic_vector(15 downto 0);
        RD1: in std_logic_vector(15 downto 0);
        RD2: in std_logic_vector(15 downto 0);
        extImm: in std_logic_vector(15 downto 0);
        ALUSrc : in std_logic;
        sa: in std_logic;
        func: in std_logic_vector(2 downto 0);
        ALUOp: in std_logic_vector(2 downto 0);
        BranchAdr: out std_logic_vector(15 downto 0);
        Zero: out std_logic;
        ALURes: out std_logic_vector(15 downto 0)
  );
end EX;

architecture Behavioral of EX is

signal mux : std_logic_vector(15 downto 0):= x"0000";
signal ALURes2 : std_logic_vector(15 downto 0):=x"0000";
signal Zero2 : std_logic:='0'; 

begin
    mux <= extImm when ALUSrc = '1' else RD2;
	
    process(func, ALUOp)
    begin
		ALURes2 <= x"0000";
		
        case ALUOp is
            when "000" => ALURes2 <= RD1 + mux;
            
            when "001" => 
                if conv_integer(RD1 - mux) = 0 then 
                    Zero2 <= '1';
                else Zero2 <= '0';
                end if;
                
            when "010" => 
                    case func is
                        when "000" => ALURes2 <= RD1 + mux;
                        when "001" => ALURes2 <= RD1 - mux;
                        when "010" => 
                            if sa = '1' then
                                ALURes2 <= mux(14 downto 0) & '0';
                            else ALURes2 <= mux;
                            end if;
                        when "011" => 
                            if sa = '1' then
                                ALURes2 <= '0' & mux(15 downto 1);
                            else ALURes2 <= mux;
                            end if;
                        when "100" => ALURes2 <= RD1 and mux;
                        when "101" => ALURes2 <= RD1 or mux;
                        when "110" => ALURes2 <= RD1 xor mux;
                        when others => ALURes2 <= mux(15) & mux(15 downto 1);
                    end case;
            
            when "011" => ALURes2 <= RD1 + mux;
            when "100" => ALURes2 <= RD1 - mux;
            when "101" => ALURes2 <= RD1 and mux;
			when others => ALURes2 <= x"0000";
        end case;
    end process;
    
    BranchAdr <= extImm + pcNext;
	ALURes <= ALURes2;
	Zero <= Zero2;
end Behavioral;
