library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;

entity divizor_frecventa_1 is
    port(CLK : in std_logic;
	enable : in std_logic;
    LED: out std_logic);
end divizor_frecventa_1;

architecture comportamental of divizor_frecventa_1 is

signal counter : std_logic_vector(0 to 24):=(others =>'0');
signal temp : std_logic := '1';

begin
	process (CLK, enable)
	begin
		if(enable = '1') then
			if (CLK = '1' and CLK'EVENT) then
				if(counter(0) = '1') then
					counter <= (others => '0');
					temp <= not(temp);
				else counter <= counter + 1;
				end if;
			end if;
		else
			counter <= (others => '0');
			temp <= '1';
		end if;	         
	end process;
	LED <= temp;
end comportamental;