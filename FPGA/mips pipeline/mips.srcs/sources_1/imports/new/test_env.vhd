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
        WA : in std_logic_vector(2 downto 0);
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

--pt pipeline
signal muxREG : std_logic_vector(2 downto 0) := (others => '0');

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

component IF_ID is
  Port ( 
        enable : in std_logic;
        next_instr: in std_logic_vector(15 downto 0); 
        instructiune: in std_logic_vector(15 downto 0);
        clk: in std_logic;
        next_instr2: out std_logic_vector(15 downto 0);
        instructiune2: out std_logic_vector(15 downto 0) 
  );
end component;
signal nxtRezultat2: std_logic_vector(15 downto 0):= x"0000";
signal instructiune2: std_logic_vector(15 downto 0) := x"0000";


component ID_EX is
  Port ( 
          enable : in std_logic;
          
          MemToReg : in std_logic; --WB
          RegWrite : in std_logic; --WB
          MemWrite : in std_logic; --M
          Branch : in std_logic; --M
          ALUOp : in std_logic_vector(2 downto 0); --EX
          ALUSrc : in std_logic; --EX
          RegDst : in std_logic; --EX
          nxtInstructiune : in std_logic_vector(15 downto 0);
          RD1 : in std_logic_vector(15 downto 0);
          RD2 : in std_logic_vector(15 downto 0);
          Ext_Imm : in std_logic_vector(15 downto 0);
          func : in std_logic_vector(2 downto 0);
          sa : in std_logic;
          RA : in std_logic_vector(2 downto 0);
          RB : in std_logic_vector(2 downto 0);
          
          clk : in std_logic;
          
          MemToRegOUT : out std_logic; --WB
          RegWriteOUT : out std_logic; --WB
          MemWriteOUT : out std_logic; --M
          BranchOUT : out std_logic; --M
          ALUOpOUT : out std_logic_vector(2 downto 0); --EX
          ALUSrcOUT : out std_logic; --EX
          RegDstOUT : out std_logic; --EX
          nxtInstructiuneOUT : out std_logic_vector(15 downto 0);
          RD1OUT : out std_logic_vector(15 downto 0);
          RD2OUT : out std_logic_vector(15 downto 0);
          Ext_ImmOUT : out std_logic_vector(15 downto 0);
          funcOUT : out std_logic_vector(2 downto 0);
          saOUT : out std_logic;
          RAOUT : out std_logic_vector(2 downto 0);
          RBOUT : out std_logic_vector(2 downto 0)
  );
end component;
signal memToReg2 : std_logic := '0';
signal regWrite2 : std_logic := '0';
signal memWrite2 : std_logic := '0';
signal branch2 : std_logic := '0';
signal aluOp2 : std_logic_vector(2 downto 0) := "000";
signal aluSrc2 : std_logic := '0';
signal regDst2 : std_logic := '0';
signal nxtRezultat3 : std_logic_vector(15 downto 0) := x"0000";
signal newRD1 : std_logic_vector(15 downto 0) := x"0000";
signal newRD2 : std_logic_vector(15 downto 0) := x"0000";
signal extImm2 : std_logic_vector(15 downto 0) := x"0000";
signal func2 : std_logic_vector(2 downto 0) := "000";
signal sa2 : std_logic := '0';
signal ra1 : std_logic_vector(2 downto 0) := "000";
signal ra2 : std_logic_vector(2 downto 0) := "000";

component EX_MEM is
  Port ( 
        enable : in std_logic;
        
        MemtoReg : in std_logic; --WB
        RegWrite : in std_logic; --WB
        MemWrite : in std_logic; --M
        Branch : in std_logic; --M
        BranchAdr : in std_logic_vector(15 downto 0);
        ZeroFlag : in std_logic;
        ALURes : in std_logic_vector(15 downto 0);
        RD2 : in std_logic_vector(15 downto 0);
        instrMUX : in std_logic_vector(2 downto 0);
        
        clk : in std_logic;
        
        MemtoRegOUT : out std_logic;
        RegWriteOUT : out std_logic;
        MemWriteOUT : out std_logic;
        BranchOUT : out std_logic;
        BranchAdrOUT : out std_logic_vector(15 downto 0);
        ZeroFlagOUT : out std_logic;
        ALUResOUT : out std_logic_vector(15 downto 0);
        RD2OUT : out std_logic_vector(15 downto 0);
        instrMUXOUT : out std_logic_vector(2 downto 0)
  );
end component;
signal memToReg3 : std_logic := '0';
signal regWrite3 : std_logic := '0';
signal memWrite3 : std_logic := '0';
signal branch3 : std_logic := '0';
signal branchAdr3 : std_logic_vector := x"0000"; 
signal zeroFlag3 : std_logic := '0';
signal aluRes3 : std_logic_vector := x"0000";
signal newRD2_3 : std_logic_vector := x"0000";
signal muxREG_3: std_logic_vector(2 downto 0) := "000";

component MEM_WB is
  Port ( 
        enable : in std_logic;
        
        MemToReg : in std_logic;
        RegWrite : in std_logic;
        ReadData : in std_logic_vector(15 downto 0);
        ALURes : in std_logic_vector(15 downto 0);
        instrMUX : in std_logic_vector(2 downto 0);
        
        clk : in std_logic;
        
        MemToRegOUT : out std_logic;
        RegWriteOUT : out std_logic;
        ReadDataOUT : out std_logic_vector(15 downto 0);
        ALUResOUT : out std_logic_vector(15 downto 0);
        instrMUXOUT : out std_logic_vector(2 downto 0)
  );
end component;
signal memToReg4 : std_logic := '0';
signal regWrite4 : std_logic := '0';
signal memData4 : std_logic_vector(15 downto 0) := x"0000";
signal aluRes4 : std_logic_vector(15 downto 0) := x"0000";
signal wa4 : std_logic_vector(2 downto 0) := "000";


signal PcSrc : std_logic := '1';

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
    
    if1: InstrFetch port map(reset, enable, clk, branchAdr, jumpAdr, PcSrc, jump, nxtRezultat, rezultat2);
    -------------------------------------------------------------------------------------------------------------------------
    jumpAdr <= "000" & rezultat2(12 downto 0);
    if_id1: IF_ID port map(enable, nxtRezultat, rezultat2, clk, nxtRezultat2, instructiune2);
    -------------------------------------------------------------------------------------------------------------------------
    uc1: Control port map(instructiune2(15 downto 13), regDst, extOp, aluSrc, branch, jump, aluOp, memWrite, memToReg, regWrite);
    id1: ID port map(clk, instructiune2, wa4, wd, enable, regWrite4, regDst, extOp, rd1, rd2, extImm, func, sa1);
   -------------------------------------------------------------------------------------------------------------------------
    id_ex1: ID_EX port map(enable, memToReg, regWrite, memWrite, branch, aluOp, aluSrc, regDst, nxtRezultat2, rd1, rd2, extImm, func, sa1, instructiune2(9 downto 7), instructiune2(6 downto 4), clk, memToReg2, regWrite2, memWrite2, branch2, aluOp2, aluSrc2, regDst2, nxtRezultat3, newRD1, newRD2, extImm2, func2, sa2, ra1, ra2);
    -------------------------------------------------------------------------------------------------------------------------
    muxREG <= ra1 when regDst2 = '0' else ra2;
    ex1: EX port map(nxtRezultat3, newRD1, newRD2, extImm2, aluSrc2, sa2, func2, aluOp2, branchAdr, zeroFlag, aluRes);
    -------------------------------------------------------------------------------------------------------------------------
    ex_mem1: EX_MEM port map(enable, memToReg2, regWrite2, memWrite2, branch2, branchAdr, zeroFlag, aluRes, newRD2, muxREG, clk, memToReg3, regWrite3, memWrite3, branch3, branchAdr3, zeroFlag3, aluRes3, newRD2_3, muxREG_3);
    -------------------------------------------------------------------------------------------------------------------------
    PcSrc <= branch3 and zeroFlag;
    mem1: MEM port map(clk, memWrite3, aluRes3, newRD2_3, memData);
    -------------------------------------------------------------------------------------------------------------------------
    mem_wb1: MEM_WB port map(enable, memToReg3, regWrite3, memData, aluRes3, muxReg_3, clk, memToReg4, regWrite4, memData4, aluRes4, wa4);
    -------------------------------------------------------------------------------------------------------------------------
    
    --jumpAdr <= "000" & rezultat2(12 downto 0);
    wd <= memData4 when memToReg4 = '1' else aluRes4;
    
    --andSignal <= branch and zeroFlag;--PcSrc la mips ciclu unic
    
    --rezultat <= rezultat2 when sw(7) = '0' else nxtRezultat;
    
    with sw(7 downto 5) select rezultat <= rezultat2 when "000",
                                            nxtRezultat when "001",
                                            newRD1 when "010",
                                            newRD2 when "011",
                                            extImm2 when "100",
                                            aluRes4 when "101",
                                            memData4 when "110",
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
