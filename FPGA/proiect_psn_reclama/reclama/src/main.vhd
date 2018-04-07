library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity reclama is 
	port( CLK : in std_logic;
	sel_animatie :	in std_logic_vector(2 downto 0);
	anod : out std_logic_vector(3 downto 0);
	catod : out std_logic_vector(0 to 6));
end reclama; 

architecture arh_reclama of reclama is

signal temp : std_logic := '0';

type litere is array(0 to 4) of std_logic_vector(0 to 6);
signal lit : litere;

signal cuv_mem : std_logic_vector(0 to 34);
signal litere_cuv : std_logic_vector(0 to 27);

--memoria ROM
component memorie_ROM is
	port(in_ROM: in integer range 0 to 23;--adrese
	CS_ROM: in std_logic; --chip select
	CLK : in std_logic;
	out_ROM: out std_logic_vector(0 to 6)--iesiri de date
	);
end component;

--mux
component mux is
	port(sel : in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	c0, c1, c2, c3, c4, c5, c6 : in std_logic_vector(27 downto 0);
	cuvant : out std_logic_vector(27 downto 0));
end component;

--divizor reclama
component divizor_reclama is
    port(CLK : in std_logic;
	enable : in std_logic;
    temp: out std_logic);
end component;

--animatie0
component animatie0 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim0 : out std_logic_vector(27 downto 0));
end component;

--animatie1
component animatie1 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim1 : out std_logic_vector(27 downto 0));
end component;

--animatie2
component animatie2 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim2 : out std_logic_vector(27 downto 0));
end component;

--animatie3
component animatie3 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim3 : out std_logic_vector(27 downto 0));
end component;

--animatie4
component animatie4 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim4 : out std_logic_vector(27 downto 0));
end component;

--animatie5
component animatie5 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim5 : out std_logic_vector(27 downto 0));
end component;

--animatie6
component animatie6 is
	port(cuv : in std_logic_vector(0 to 34);
	enable_in: in std_logic_vector(2 downto 0);
	CLK : in std_logic;
	cuvant_anim6 : out std_logic_vector(27 downto 0));
end component;

--afisor
component afisor is
	port(CLK, temp : in std_logic;
	litere_cuv : std_logic_vector(0 to 27);
	anod : out std_logic_vector(3 downto 0);
	catod : out std_logic_vector(0 to 6));
end component;

type matrice is array(0 to 6) of std_logic_vector(27 downto 0);
signal cuv : matrice;

begin													
	R1: memorie_ROM port map(3, '1', CLK, lit(0));
	R2: memorie_ROM port map(14, '1', CLK, lit(1));
	R3: memorie_ROM port map(4, '1', CLK, lit(2));	 
	R4: memorie_ROM port map(5, '1', CLK, lit(3));
	R5: memorie_ROM port map(0, '1', CLK, lit(4));

	cuv_mem <= lit(0) & lit(1) & lit(2) & lit(3) & lit(4);
	
	A0 : animatie0 port map(cuv_mem, sel_animatie, CLK, cuv(0));
	A1 : animatie1 port map(cuv_mem, sel_animatie, CLK, cuv(1));
	A2 : animatie2 port map(cuv_mem, sel_animatie, CLK, cuv(2));
	A3 : animatie3 port map(cuv_mem, sel_animatie, CLK, cuv(3));
	A4 : animatie4 port map(cuv_mem, sel_animatie, CLK, cuv(4));
	A5 : animatie5 port map(cuv_mem, sel_animatie, CLK, cuv(5));
	A6 : animatie6 port map(cuv_mem, sel_animatie, CLK, cuv(6));
	
	M1: mux port map(sel_animatie, CLK, cuv(0), cuv(1), cuv(2), cuv(3), cuv(4), cuv(5), cuv(6), litere_cuv);
	DR1: divizor_reclama port map(CLK, '1', temp);
	AFIS: afisor port map(CLK, temp, litere_cuv, anod, catod);
end arh_reclama;