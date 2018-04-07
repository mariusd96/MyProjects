library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity luminozitate_procent is
	port(CLK : in std_logic;
	enable : in std_logic;
	semnal : in std_logic;
	cuv_in : in std_logic_vector(0 to 34);
	cuv_out : out std_logic_vector(0 to 27));
end luminozitate_procent;

architecture arh of luminozitate_procent is

signal divider : std_logic_vector (8 downto 0) := (others => '0');
signal percent : std_logic_vector (6 downto 0) := (others => '0');
signal pwm_level : std_logic_vector (6 downto 0) := (others => '0');
signal pwm : std_logic;

begin	
	process(CLK, enable, semnal, pwm)
	variable numar : integer := 0;
	begin
		if(enable = '1') then
			if(CLK = '1' and CLK'EVENT) then
				if(semnal = '1') then
					numar := numar + 1;
				end if;
			
				if(percent < pwm_level) then
					pwm <= '1';
					cuv_out <= cuv_in(0 to 27);
				else
					pwm <= '0';
					cuv_out <= (others => '1');
				end if;
			
				case numar is
					when 1 => pwm_level <= "0000001";
					when 2 => pwm_level <= "0000001";
					when 3 => pwm_level <= "0000010";
					when 4 => pwm_level <= "0000010";
					when 5 => pwm_level <= "0000100";
					when 6 => pwm_level <= "0000100";
					when 7 => pwm_level <= "1100100";
					when 8 => pwm_level <= "1100100";
					when others => pwm_level <= "1100100";
				end case;
			
				if(numar = 9) then numar := 0;
				end if;
			
				if divider = 499 then
					divider <= (others => '0');
					if percent = 99 then
						percent  <= (others => '0');
					else
						percent <= percent +1;
					end if;
				else
            divider <= divider + 1;
				end if;
			end if;
		else
			divider <= (others => '0');
			percent <= (others => '0');
			pwm_level <= (others => '0');
			pwm <= '0';
			numar := 0;
		end if;
	end process;
end arh;
	