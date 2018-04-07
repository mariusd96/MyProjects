library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity curgere is
	port(CLK, enable : in std_logic;
	copie_lit1, copie_lit2, copie_lit3, copie_lit4 : in std_logic_vector(0 to 6);
	lit1, lit2, lit3, lit4 : out std_logic_vector(0 to 6)
	);
end curgere;

architecture comportamental of curgere is
begin	   
	process(CLK, enable, copie_lit1, copie_lit2, copie_lit3, copie_lit4)
	variable nivel : natural := 0;
	begin
		if(enable = '0') then
			lit1 <= "1111111";
			lit2 <= "1111111";
			lit3 <= "1111111";
			lit4 <= "1111111";
			nivel := 0;
		else
			if(CLK = '1' and CLK'EVENT) then
				if(nivel = 0) then
					lit1 <= "1111111";
					lit2 <= "1111111";
					lit3 <= "1111111";
					lit4 <= "1111111";
					nivel := 1;
				elsif(nivel = 1) then
					lit1 <= copie_lit1(3) & "111111";
					lit2 <= copie_lit2(3) & "111111";
					lit3 <= copie_lit3(3) & "111111";
					lit4 <= copie_lit4(3) & "111111";
					nivel := 2;
				elsif(nivel = 2) then
					lit1 <= copie_lit1(6) & copie_lit1(2) & "111" & copie_lit1(4) & copie_lit1(3);
					lit2 <= copie_lit2(6) & copie_lit2(2) & "111" & copie_lit2(4) & copie_lit2(3);
					lit3 <= copie_lit3(6) & copie_lit3(2) & "111" & copie_lit3(4) & copie_lit3(3);
					lit4 <= copie_lit4(6) & copie_lit4(2) & "111" & copie_lit4(4) & copie_lit4(3);
					nivel := 3;
				elsif(nivel = 3) then
					lit1 <= copie_lit1;
					lit2 <= copie_lit2;
					lit3 <= copie_lit3;
					lit4 <= copie_lit4;
					nivel := 4;	
				elsif(nivel = 4) then
					lit1 <= "11" & copie_lit1(1) & copie_lit1(6) & copie_lit1(5) & "1" & copie_lit1(0);
					lit2 <= "11" & copie_lit2(1) & copie_lit2(6) & copie_lit2(5) & "1" & copie_lit2(0);
					lit3 <= "11" & copie_lit3(1) & copie_lit3(6) & copie_lit3(5) & "1" & copie_lit3(0);
					lit4 <= "11" & copie_lit4(1) & copie_lit4(6) & copie_lit4(5) & "1" & copie_lit4(0);
					nivel :=5;
				elsif(nivel = 5) then
					lit1 <= "111" & copie_lit1(0) & "111";
					lit2 <= "111" & copie_lit2(0) & "111";
					lit3 <= "111" & copie_lit3(0) & "111";
					lit4 <= "111" & copie_lit4(0) & "111";
					nivel :=0;
				end if;
			end if;
		end if;
	end process;
end comportamental;