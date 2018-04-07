-- palpaire cuvant

library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity animatie2 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim2: out std_logic_vector(27 downto 0));
end animatie2;

architecture anim2 of animatie2 is

signal enable_animatie, CLK_new : std_logic := '0';

type litere is array(0 to 4) of std_logic_vector(0 to 6);
signal lit_in : litere; 

type litere2 is array(0 to 3) of std_logic_vector(0 to 6);
signal lit_out : litere2; 

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

--momentul cand apare cuvantul si cand nu
component stins_aprins is
	port( CLK : in std_logic;
	enable : in std_logic;
	lit_in1, lit_in2, lit_in3, lit_in4, lit_in5 : in std_logic_vector(0 to 6);
	lit_out1, lit_out2, lit_out3, lit_out4 : out std_logic_vector(0 to 6));
end component;

begin
	is_enable1:	is_enable port map(CLK, enable_in, "010", enable_animatie);	
	DV: divizor_frecventa_1 port map(CLK, enable_animatie, CLK_new);
	
	lit_in(0) <= cuv(0 to 6);
	lit_in(1) <= cuv(7 to 13);
	lit_in(2) <= cuv(14 to 20);
	lit_in(3) <= cuv(21 to 27);
	lit_in(4) <= cuv(28 to 34);
	
	S_A: stins_aprins port map(CLK_new, enable_animatie, lit_in(0), lit_in(1), lit_in(2), lit_in(3), lit_in(4), lit_out(0), lit_out(1), lit_out(2), lit_out(3)); 
	cuvant_anim2 <= lit_out(0) & lit_out(1) & lit_out(2) & lit_out(3);
end anim2;