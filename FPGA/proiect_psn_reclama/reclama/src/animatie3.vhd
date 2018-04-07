-- fade in - fade out

library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity animatie3 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim3 : out std_logic_vector(27 downto 0));
end animatie3;

architecture anim3 of animatie3 is

signal enable_animatie, temp : std_logic := '0';

type litere is array(0 to 4) of std_logic_vector(0 to 6);
signal lit_in : litere; 

--enable pentru animatie
component is_enable is
	port(CLK : in std_logic;
	enable_in : in std_logic_vector(2 downto 0);
	cod : in std_logic_vector(2 downto 0);
	enable_anim : out std_logic);
end component;

--pwm
component pwm is
	port(CLK : in std_logic;
	enable : in std_logic;
	pwm_out : out std_logic);
end component; 

begin
	is_enable1:	is_enable port map(CLK, enable_in, "011", enable_animatie);
	PWM1: pwm port map(CLK, enable_animatie, temp);
	
	lit_in(0) <= cuv(0 to 6);
	lit_in(1) <= cuv(7 to 13);
	lit_in(2) <= cuv(14 to 20);
	lit_in(3) <= cuv(21 to 27);
	lit_in(4) <= cuv(28 to 34);
	
	cuvant_anim3 <= lit_in(0) & lit_in(1) & lit_in(2) & lit_in(3) when temp = '1' else
						 lit_in(4) & lit_in(4) & lit_in(4) & lit_in(4);
end anim3;