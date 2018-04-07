-- palpaire ritm alert

library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity animatie4 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim4 : out std_logic_vector(27 downto 0));
end animatie4;

architecture anim4 of animatie4 is

signal enable_animatie, CLK_new : std_logic := '0';

--enable pentru animatie
component is_enable is
	port(CLK : in std_logic;
	enable_in : in std_logic_vector(2 downto 0);
	cod : in std_logic_vector(2 downto 0);
	enable_anim : out std_logic);
end component;

--ritm alert
component ritm_alert is
    port(CLK : in std_logic;
	 enable : in std_logic;
	 tc : out std_logic);
end component;

--luminozitate procent
component luminozitate_procent is
	port(CLK : in std_logic;
	enable : in std_logic;
	semnal : in std_logic;
	cuv_in : in std_logic_vector(0 to 34);
	cuv_out : out std_logic_vector(0 to 27));
end component;

signal tc : std_logic := '0';

begin
	is_enable1:	is_enable port map(CLK, enable_in, "100", enable_animatie);	
	RA: ritm_alert port map(CLK, enable_animatie, tc);
	LP: luminozitate_procent port map(CLK, enable_animatie, tc, cuv, cuvant_anim4);
end anim4;