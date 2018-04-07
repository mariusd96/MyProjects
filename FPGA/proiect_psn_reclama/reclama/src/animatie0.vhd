-- afiseaza cuvantul COdE

library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity animatie0 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim0 : out std_logic_vector(27 downto 0));
end animatie0;

architecture anim0 of animatie0 is

signal enable_animatie, enable_animatie1, enable_animatie2 : std_logic := '0';

--enable pentru animatie
component is_enable is
	port(CLK : in std_logic;
	enable_in : in std_logic_vector(2 downto 0);
	cod : in std_logic_vector(2 downto 0);
	enable_anim : out std_logic);
end component;

begin
	is_enable1:	is_enable port map(CLK, enable_in, "000", enable_animatie1);
	is_enable2:	is_enable port map(CLK, enable_in, "111", enable_animatie2);
	enable_animatie <= enable_animatie1 xor enable_animatie2;
	
	cuvant_anim0 <= cuv(0 to 27) when enable_animatie = '1' else
						 (others => '1') when enable_animatie = '0';
end anim0;