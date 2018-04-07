library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity stins_aprins is
	port( CLK : in std_logic;
	enable : in std_logic;
	lit_in1, lit_in2, lit_in3, lit_in4, lit_in5 : in std_logic_vector(0 to 6);
	lit_out1, lit_out2, lit_out3, lit_out4 : out std_logic_vector(0 to 6));
end stins_aprins;

architecture comportamental of stins_aprins is

type litere is array(0 to 3) of std_logic_vector(0 to 6);
signal lit : litere;
	  
signal counter1 : integer := 0;
signal counter2 : integer := 2;

begin
	process(CLK, enable, lit_in1, lit_in2, lit_in3, lit_in4, lit_in5, lit, counter1, counter2)
	begin
		if(enable = '0') then
			counter1 <= 0;
			counter2 <= 2;
			lit(0) <= lit_in5;
			lit(1) <= lit_in5;
			lit(2) <= lit_in5;
			lit(3) <= lit_in5;
		else
			if(CLK = '1' and CLK'EVENT) then 
				if(counter2 = 0) then
					counter1 <= counter1 + 1;
				end if;
			
				if(counter1 = 0) then
					counter2 <= counter2 + 1;
				end if;
				
				if(counter1 = 1) then 
					lit(0) <= lit_in1;
					lit(1) <= lit_in2;
					lit(2) <= lit_in3;
					lit(3) <= lit_in4;
					counter1 <= 0;
				elsif(counter2 = 2) then
					lit(0) <= lit_in5;
					lit(1) <= lit_in5;
					lit(2) <= lit_in5;
					lit(3) <= lit_in5;
					counter2 <= 0;
				end if;
			end if;
		end if;
		
		lit_out1 <= lit(0);
		lit_out2 <= lit(1);
		lit_out3 <= lit(2);
		lit_out4 <= lit(3);
		
	end process;
end comportamental;