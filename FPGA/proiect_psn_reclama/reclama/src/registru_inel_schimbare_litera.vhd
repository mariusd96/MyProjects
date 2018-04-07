library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity registru_inel_schimbare_litera is
	port( CLK : in std_logic;
	enable : in std_logic;
	lit_in1, lit_in2, lit_in3, lit_in4, lit_in5 : in std_logic_vector(0 to 6);
	lit_out1, lit_out2, lit_out3, lit_out4 : out std_logic_vector(0 to 6));
end registru_inel_schimbare_litera;

architecture comportamental of registru_inel_schimbare_litera is

type litere is array(0 to 3) of std_logic_vector(0 to 6);
signal lit : litere;

begin
	process(CLK, enable, lit_in1, lit_in2, lit_in3, lit_in4, lit_in5, lit)
	variable index : natural := 0;
	begin
		if(enable = '0') then
			index := 0;
			lit(0) <= lit_in5;
			lit(1) <= lit_in5;
			lit(2) <= lit_in5;
			lit(3) <= lit_in5;
		else
			if(CLK = '1' and CLK'EVENT) then 	
				lit(0) <= lit(3);
				lit(1) <= lit(0);
				lit(2) <= lit(1);
				lit(3) <= lit(2);
				
				case index is
					when 0 => lit(0) <= lit_in1;
					when 1 => lit(1) <= lit_in2;
					when 2 => lit(2) <= lit_in3;
					when 3 => lit(3) <= lit_in4; 
					when others => 
						lit(0) <= lit_in5;
						lit(1) <= lit_in5;
						lit(2) <= lit_in5;
						lit(3) <= lit_in5;
				end case;
				
				index := index + 1;
				if(index = 4) then index := 0;
				end if;
			end if;
		end if;
		
		lit_out1 <= lit(0);
		lit_out2 <= lit(1);
		lit_out3 <= lit(2);
		lit_out4 <= lit(3);
		
	end process;
end comportamental;