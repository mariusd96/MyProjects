-- curgere de sus in jos

library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity animatie6 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim6 : out std_logic_vector(27 downto 0));
end animatie6;

architecture anim6 of animatie6 is

signal enable_animatie, CLK_new : std_logic := '0';

type litere is array(0 to 3) of std_logic_vector(0 to 6);
signal lit_in, lit_out : litere;

--enable pentru animatie
component is_enable is
	port(CLK : in std_logic;
	enable_in : in std_logic_vector(2 downto 0);
	cod : in std_logic_vector(2 downto 0);
	enable_anim : out std_logic);
end component;

--divizor de frecventa
component divizor_frecventa_1 is
    port(CLK : in std_logic;
	 enable : in std_logic;
    LED: out std_logic);
end component; 

--componenta pentru curgere text
component curgere is
	port(CLK, enable : in std_logic;
	copie_lit1, copie_lit2, copie_lit3, copie_lit4 : in std_logic_vector(0 to 6);
	lit1, lit2, lit3, lit4 : out std_logic_vector(0 to 6)
	);
end component;

begin
	is_enable1:	is_enable port map(CLK, enable_in, "110", enable_animatie);
	DV: divizor_frecventa_1 port map(CLK, enable_animatie, CLK_new);
	
	lit_in(0) <= cuv(0 to 6);
	lit_in(1) <= cuv(7 to 13);
	lit_in(2) <= cuv(14 to 20);
	lit_in(3) <= cuv(21 to 27);
	
	C: curgere port map(CLK_new, enable_animatie, lit_in(0), lit_in(1), lit_in(2), lit_in(3), lit_out(0), lit_out(1), lit_out(2), lit_out(3));
	
	cuvant_anim6 <= lit_out(0) & lit_out(1) & lit_out(2) & lit_out(3);
end anim6;