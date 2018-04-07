library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity registru_inel is
	port( CLK : in std_logic;
	enable : in std_logic;
	lit_in1, lit_in2, lit_in3, lit_in4, lit_in5, lit_in6 : in std_logic_vector(0 to 6);
	lit_out1, lit_out2, lit_out3, lit_out4 : out std_logic_vector(0 to 6));
end registru_inel;

architecture comportamental of registru_inel is

type litere is array(0 to 5) of std_logic_vector(0 to 6);
signal lit : litere;

begin
	process(CLK, enable, lit_in1, lit_in2, lit_in3, lit_in4, lit_in5, lit_in6, lit)
	begin
		if(enable = '0') then
			lit(0) <= lit_in1;
			lit(1) <= lit_in2;
			lit(2) <= lit_in3;
			lit(3) <= lit_in4;
			lit(4) <= lit_in5;
			lit(5) <= lit_in6;
		else
			if(CLK = '1' and CLK'EVENT) then
				lit(0) <= lit(1);
				lit(1) <= lit(2);
				lit(2) <= lit(3);
				lit(3) <= lit(4);
				lit(4) <= lit(5);
				lit(5) <= lit(0);
			end if;
		end if;
		
		lit_out1 <= lit(0);
		lit_out2 <= lit(1);
		lit_out3 <= lit(2);
		lit_out4 <= lit(3);
		
	end process;
end comportamental;