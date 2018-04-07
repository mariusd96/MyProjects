library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;

entity ritm_alert is
    port(CLK : in std_logic;
	 enable : in std_logic;
	 tc : out std_logic);
end ritm_alert;

architecture comportamental of ritm_alert is

signal counter : std_logic_vector(0 to 24):=(others =>'0');
signal temp : std_logic := '0';

begin
	process (CLK, enable, temp)
	begin
		if(enable = '1') then
			if (CLK = '1' and CLK'EVENT) then
				if(counter(0) = '1') then
					counter <= (others => '0');
					temp <= '1';
				else 
					counter <= counter + 1;
					temp <= '0';
				end if;
			end if;
		else
			counter <= (others => '0');
			temp <= '0';
		end if;	
		
		tc <= temp;
	end process;
end comportamental;