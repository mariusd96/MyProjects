library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;

entity divizor_reclama is
    port(CLK : in std_logic;
	enable : in std_logic;
    temp: out std_logic);
end divizor_reclama;

architecture comportamental of divizor_reclama is

signal counter : std_logic_vector(0 to 12):=(others =>'0');

begin
	process (CLK, enable)
	begin
		if(enable = '1') then
			if (CLK = '1' and CLK'EVENT) then
				if(counter = 0) then
					temp <= '1';
				else
					temp <= '0';
					if(counter(0) = '1') then counter <= (others => '0');
					end if;					
				end if;
				counter <= counter + 1;
			end if;
		else
			counter <= (others => '0');
			temp <= '0';
		end if;	         
	end process;
end comportamental;