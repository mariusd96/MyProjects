----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 02/27/2017 06:15:42 PM
-- Design Name: 
-- Module Name: test_env - Behavioral
-- Project Name: 
-- Target Devices: 
-- Tool Versions: 
-- Description: 
-- 
-- Dependencies: 
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
-- 
----------------------------------------------------------------------------------


library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity test_env is
    Port ( clk : in STD_LOGIC;
           btn : in STD_LOGIC_VECTOR (4 downto 0);
           sw : in STD_LOGIC_VECTOR (15 downto 0);
           led : out STD_LOGIC_VECTOR (15 downto 0);
           an : out STD_LOGIC_VECTOR (3 downto 0);
           cat : out STD_LOGIC_VECTOR (6 downto 0));
end test_env;

architecture Behavioral of test_env is
signal counter: std_logic_vector(3 downto 0):= (others => '0');
signal counter2: std_logic_vector(7 downto 0):= (others => '0');

signal enable: std_logic:='0';
signal we: std_logic:='0';

type reg_array is array(0 to 255) of std_logic_vector(15 downto 0);
signal matrice : reg_array := (x"0000", x"0001", x"0002", x"000F", x"0012", x"0034", x"0076", x"0FF7", others=> x"0000");

type reg_array2 is array(0 to 15) of std_logic_vector(15 downto 0);
signal instr : reg_array2 := 
    (
        B"000_000_101_010_0_000", 
        B"000_010_001_011_0_001", 
        B"000_000_000_010_1_010", 
        B"000_001_000_010_1_011",
        B"000_000_101_010_0_100",
        B"000_000_101_100_0_101",
        B"000_010_011_001_0_110",
        B"000_010_000_001_1_111",
        B"000_010_000_001_1_111",
        B"001_101_011_0001010",
        B"010_100_010_0001010",
        B"011_110_101_0000100",
        B"100_001_010_0000101",
        B"101_010_011_0000100",
        B"110_000_100_0001010",
        B"111_000_000_000_1001",
        others=>x"0000"
        );

signal program : reg_array2:=
(
    B"001_000_001_0001010", --addi $1, $0, 10
    B"001_000_010_1111111", --addi $2, $0, -1
    B"001_000_011_0000000", --addi $3, $0, 0
    B"001_000_100_0000001", --addi $4, $0, 1
    B"100_000_001_0000111", --beq $1, $0, 7
    B"000_011_100_101_0_000", --add $5, $3, $4
    B"000_010_101_110_0_000", --add $6, $2, $5
    B"000_000_011_010_0_000", --add $2, $0, $3
    B"000_000_100_011_0_000", --add $3, $0, $4
    B"000_000_110_100_0_000", --add $4, $0, $6
    B"110_001_001_0000001", --subi $1, $1, 1
    B"111_000_000_000_0100", --j 4
    B"011_010_110_0010100", --sw $6, 20($20)
    others => x"0000"
);

--signal rd1: std_logic_vector(15 downto 0):= x"0000";
--signal rd2: std_logic_vector(15 downto 0):= x"0000";
--signal wd: std_logic_vector(15 downto 0):= x"0000";

component MonoPulseGenerator is
  Port ( 
    btn: in std_logic;
    clk: in std_logic;
    enable: out std_logic  
  );
end component;

component SSD is
    Port ( Digit0 : in STD_LOGIC_VECTOR (3 downto 0);
           Digit1 : in STD_LOGIC_VECTOR (3 downto 0);
           Digit2 : in STD_LOGIC_VECTOR (3 downto 0);
           Digit3 : in STD_LOGIC_VECTOR (3 downto 0);
           clk : in STD_LOGIC;
           cat : out STD_LOGIC_VECTOR (6 downto 0);
           an : out STD_LOGIC_VECTOR (3 downto 0));
end component;

component reg_file is
  Port ( 
          clk: in std_logic;
          RA: in std_logic_vector(3 downto 0);
          RB: in std_logic_vector(3 downto 0);
          WA: in std_logic_vector(3 downto 0);
          WD: in std_logic_vector(15 downto 0);
          WE: in STD_LOGIC;
          RD1: out std_logic_vector(15 downto 0);
          RD2: out std_logic_vector(15 downto 0));
end component;

component RAM is
  Port ( 
          clk: in std_logic;
          RA: in std_logic_vector(3 downto 0);
          WD: in std_logic_vector(15 downto 0);
          WE: in STD_LOGIC;
          RD: out std_logic_vector(15 downto 0));
end component;

component InstrFetch is
  Port (
        reset : in std_logic;
        WE : in std_logic;
        clk: in std_logic;
        branchAdr: in std_logic_vector(15 downto 0);
        jumpAdr: in std_logic_vector(15 downto 0);
        PCsrc: in std_logic;
        jump: in std_logic;
        next_instr: out std_logic_vector(15 downto 0); 
        instructiune: out std_logic_vector(15 downto 0) 
        );
end component;

signal reset: std_logic;
signal nxtRezultat: std_logic_vector(15 downto 0):= x"0000";
signal rezultat: std_logic_vector(15 downto 0) := x"0000";
signal rezultat2: std_logic_vector(15 downto 0):= x"0000";

component Control is
  Port ( 
        instr : in std_logic_vector(2 downto 0);
        RegDst : out std_logic;
        ExtOp : out std_logic;
        ALUSrc : out std_logic;
        Branch : out std_logic;
        Jump : out std_logic;
        ALUOp : out std_logic_vector(2 downto 0);
        MemWrite: out std_logic;
        MemtoReg : out std_logic;
        RegWrite : out std_logic  
  );
end component;

signal regDst : std_logic:= '0';
signal extOp : std_logic:= '0';
signal aluSrc : std_logic:= '0';
signal branch : std_logic:= '0';
signal jump : std_logic := '0';
signal aluOp : std_logic_vector(2 downto 0):= "000";
signal memWrite : std_logic:= '0';
signal memToReg : std_logic:= '0';
signal regWrite : std_logic := '0';

component ID is
  Port (
        clk : in std_logic;
        instr : in std_logic_vector(15 downto 0);
        WD : in std_logic_vector(15 downto 0); 
        WE: in std_logic;
		RegWr : in std_logic;
        RegDst : in std_logic;
        ExtOp : in std_logic;
        RD1:  out std_logic_vector(15 downto 0);
        RD2:  out std_logic_vector(15 downto 0);
        Ext_imm: out std_logic_vector(15 downto 0);
        func: out std_logic_vector(2 downto 0);
        sa: out std_logic
   );
end component;

signal wd: std_logic_vector(15 downto 0):= x"0000";
signal rd1: std_logic_vector(15 downto 0):= x"0000";
signal rd2: std_logic_vector(15 downto 0):= x"0000";
signal extImm: std_logic_vector(15 downto 0):= x"0000";
signal func: std_logic_vector(2 downto 0):= "000";
signal sa1: std_logic := '0';

component EX is
  Port ( 
        pcNext : in std_logic_vector(15 downto 0);
        RD1: in std_logic_vector(15 downto 0);
        RD2: in std_logic_vector(15 downto 0);
        extImm: in std_logic_vector(15 downto 0);
        ALUSrc : in std_logic;
        sa: in std_logic;
        func: in std_logic_vector(2 downto 0);
        ALUOp: in std_logic_vector(2 downto 0);
        BranchAdr: out std_logic_vector(15 downto 0);
        Zero: out std_logic;
        ALURes: out std_logic_vector(15 downto 0)
  );
end component;

signal branchAdr: std_logic_vector(15 downto 0) := x"0000";
signal zeroFlag: std_logic := '0';
signal aluRes: std_logic_vector(15 downto 0) := x"0000";

component MEM is
  Port ( 
        clk : in std_logic;
        MemWrite : in std_logic;
        ALURes : in std_logic_vector(15 downto 0);
        RD2 : in std_logic_vector(15 downto 0);
        MemData: out std_logic_vector(15 downto 0)  
  );
end component;

signal memData: std_logic_vector(15 downto 0) := x"0000";


signal andSignal: std_logic := '0';
signal jumpAdr: std_logic_vector(15 downto 0) := x"0000";

begin    
    mpg1: MonoPulseGenerator port map(btn(0), clk, enable);
    mpg2: MonoPulseGenerator port map(btn(1), clk, reset);
    --enable <= btn(0);
	--reset <= btn(1);
    --process(clk)
    --begin
      --  if rising_edge(clk) then
        --    if enable = '1' then
          --        counter2 <= counter2 + 1;
           -- end if;
         --end if;
    --end process;
    
    --rezultat <= matrice(conv_integer(counter2));
    
    --process(clk)
      --  begin
        --    if(btn(2) = '1') then
          --          counter <= "0000";
            --else 
              --  if(rising_edge(clk)) then
                --    if(enable = '1') then
                  --      counter <= counter + 1;
                    --end if;
                --end if;
            --end if;
        --end process;
    
    --process(clk)
    --begin
      --  if rising_edge(clk) then
        --    if enable = '1' then
          --      counter <= counter + 1;
            --end if;
        --end if;
    --end process;
            
    --rezultat <= program(conv_integer(counter));
    
    if1: InstrFetch port map(reset, enable, clk, branchAdr, jumpAdr, andSignal, jump, nxtRezultat, rezultat2);
    uc1: Control port map(rezultat2(15 downto 13), regDst, extOp, aluSrc, branch, jump, aluOp, memWrite, memToReg, regWrite);
    id1: ID port map(clk, rezultat2, wd, enable, regWrite, regDst, extOp, rd1, rd2, extImm, func, sa1);
    ex1: EX port map(nxtRezultat, rd1, rd2, extImm, aluSrc, sa1, func, aluOp, branchAdr, zeroFlag, aluRes);
    mem1: MEM port map(clk, memWrite, aluRes, rd2, memData);
    
    jumpAdr <= "000" & rezultat2(12 downto 0);
    wd <= memData when memToReg = '1' else aluRes;
    
    andSignal <= branch and zeroFlag;
    
    --rezultat <= rezultat2 when sw(7) = '0' else nxtRezultat;
    
    with sw(7 downto 5) select rezultat <= rezultat2 when "000",
                                            nxtRezultat when "001",
                                            rd1 when "010",
                                            rd2 when "011",
                                            extImm when "100",
                                            aluRes when "101",
                                            memData when "110",
                                            wd when others;
    
    --rg1 : reg_file port map(clk, counter, counter, counter, wd, we, rd1, rd2);
    --rezultat <= rd1 + rd2;
    --ram1: RAM port map(clk, counter, wd, we, rd1);
    --rezultat <= rd1(13 downto 0) & "00";
    --wd <= rezultat;
    --ssd1: SSD port map(counter(3 downto 0), counter(7 downto 4), counter(11 downto 8), counter(15 downto 12), clk, cat, an);
    ssd1: SSD port map(rezultat(3 downto 0), rezultat(7 downto 4), rezultat(11 downto 8), rezultat(15 downto 12), clk, cat, an);
    
    led(15 downto 0) <= "00000" & regDst & extOp & aluSrc & branch & jump & aluOp & memWrite & memToReg & regWrite;
    --led <= rezultat;
    --an <= btn(3 downto 0);
    --cat <= (others => '0');
end Behavioral;
