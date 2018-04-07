library	ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity memorie_ROM is
	port(in_ROM: in integer range 0 to 23;--adrese
	CS_ROM: in std_logic; --chip select
	CLK : in std_logic;
	out_ROM: out std_logic_vector(0 to 6)--iesiri de date
	);
end memorie_ROM;

architecture comportamental of memorie_ROM is

type alfabet is array(0 to 23) of std_logic_vector(0 to 6);
constant litere : alfabet := ("1111111", -- spatiu
							"0001000", -- A
							"1100000", -- b
					     	"0110001", -- C
							"1000010", -- d
							"0110000", -- E
							"0111000", -- F
							"0000100", -- g
							"1001000", -- H
							"1111001", -- I
							"1000011", -- J
							"1110001", -- L
							"0001001", -- M
							"1101010", -- N
							"0000001", -- O
							"0011000", -- P
							"0001100", -- q
							"1111010", -- r
							"0100100", -- S
							"1110000", -- t
							"1000001", -- U
							"1100011", -- v
							"1000100", -- y
							"0010010" -- Z
						  );

begin
	process(CLK, in_ROM, CS_ROM)	
	begin
		if(CS_ROM = '1') then
			if(CLK = '1' and CLK'EVENT) then
				out_ROM <= litere(in_ROM);
			end if;
		end if;
	end process;
end comportamental;