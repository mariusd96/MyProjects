library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity is_enable is
	port(CLK : in std_logic;
	enable_in : in std_logic_vector(2 downto 0);
	cod : in std_logic_vector(2 downto 0);
	enable_anim : out std_logic);
end is_enable; 

architecture comportamental of is_enable is
begin			   
	process(CLK, enable_in, cod)
	begin
		if(enable_in = cod) then 
			enable_anim <= '1';
		else
			enable_anim <= '0';
		end if;
	end process;
end comportamental;