library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity mux is
	port(sel : in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	c0, c1, c2, c3, c4, c5, c6 : in std_logic_vector(27 downto 0);
	cuvant : out std_logic_vector(27 downto 0));
end mux;

architecture comportamental of mux is	
begin	
	process(sel, CLK, c0, c1, c2, c3, c4, c5, c6)
	begin 
		if(CLK = '1' and CLK'EVENT) then
			case sel is
				when "001" => cuvant <= c1;
				when "010" => cuvant <= c2;
				when "011" => cuvant <= c3;
				when "100" => cuvant <= c4;
				when "101" => cuvant <= c5;
				when "110" => cuvant <= c6;
				when others	=> cuvant <= c0;
			end case;
		end if;
	end process;
end comportamental;