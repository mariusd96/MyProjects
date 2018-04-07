library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity pwm is
	port(CLK : in std_logic;
	enable : in std_logic;
	pwm_out : out std_logic);
end pwm; 

architecture arh of pwm is
begin
	process (CLK, enable)						   
	
	variable count : integer range 0 to 50000;			
	variable duty_cycle : integer range 0 to 50000;					   
	variable flag : integer range 0 to 1;
	
	begin					
		if(enable = '1') then
			if(CLK = '1' and CLK'EVENT) then
				count := count + 1;										 
				
				if (count = duty_cycle) then
					pwm_out <= '1';
				end if;

				if (count = 50000) then
					pwm_out <= '0';
					count := 0;
				
					if(flag = 0) then
						duty_cycle := duty_cycle + 50;
					else
						duty_cycle := duty_cycle - 50;
					end if;
				
					if(duty_cycle = 50000) then
						flag := 1;
					elsif(duty_cycle = 0) then
						flag := 0;
					end if;
				end if;
			end if;
			else
				pwm_out <= '0';
				count := 0;
				duty_cycle := 0;
				flag := 0;
		end if;
	end process;
end arh;																											