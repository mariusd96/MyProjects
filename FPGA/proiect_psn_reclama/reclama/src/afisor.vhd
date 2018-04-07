library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity afisor is
	port(CLK, temp : in std_logic;
	litere_cuv : std_logic_vector(0 to 27);
	anod : out std_logic_vector(3 downto 0);
	catod : out std_logic_vector(0 to 6));
end afisor;

architecture comportamental of afisor is

signal litera1, litera2, litera3, litera4 : std_logic_vector(0 to 6);

begin 
	litera1 <= litere_cuv(0 to 6);
	litera2 <= litere_cuv(7 to 13);
	litera3 <= litere_cuv(14 to 20);
	litera4 <= litere_cuv(21 to 27);
	
	process(CLK, litere_cuv)
	variable p : natural := 0;
	begin		
		if(CLK = '1' and CLK'EVENT) then
			if(temp = '1') then
				if(p = 0) then
					anod <= "0111";
					catod <= litera1;
					p := 1;
				elsif(p = 1) then
					anod <= "1011";
					catod <= litera2;
					p := 2;
				elsif(p = 2) then
					anod <= "1101";
					catod <= litera3;
					p := 3;
				elsif(p = 3) then
					anod <= "1110";
					catod <= litera4;
					p := 0;
				end if;
			end if;
		end if;
	end process;
end comportamental;