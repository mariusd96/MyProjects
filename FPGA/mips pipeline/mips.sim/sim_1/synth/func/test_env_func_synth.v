// Copyright 1986-2016 Xilinx, Inc. All Rights Reserved.
// --------------------------------------------------------------------------------
// Tool Version: Vivado v.2016.4 (win64) Build 1756540 Mon Jan 23 19:11:23 MST 2017
// Date        : Thu May 11 22:38:14 2017
// Host        : DESKTOP-NBTEJI2 running 64-bit major release  (build 9200)
// Command     : write_verilog -mode funcsim -nolib -force -file {E:/Download/Sem II/AC - Arhitectura
//               calculatoarelor/laboratoare/lab9/mips/mips.sim/sim_1/synth/func/test_env_func_synth.v}
// Design      : test_env
// Purpose     : This verilog netlist is a functional simulation representation of the design and should not be modified
//               or synthesized. This netlist cannot be used for SDF annotated simulation.
// Device      : xc7a35tcpg236-1
// --------------------------------------------------------------------------------
`timescale 1 ps / 1 ps

module EX
   (Zero,
    BranchAdr,
    sel0,
    Zero2,
    \ALUOpOUT_reg[0] ,
    Ext_ImmOUT,
    S,
    \Ext_ImmOUT_reg[11] ,
    \Ext_ImmOUT_reg[11]_0 ,
    \Ext_ImmOUT_reg[11]_1 ,
    Q,
    \Ext_ImmOUT_reg[3] ,
    \Ext_ImmOUT_reg[11]_2 ,
    \Ext_ImmOUT_reg[11]_3 ,
    \Ext_ImmOUT_reg[11]_4 );
  output Zero;
  output [15:0]BranchAdr;
  output [15:0]sel0;
  input Zero2;
  input \ALUOpOUT_reg[0] ;
  input [7:0]Ext_ImmOUT;
  input [3:0]S;
  input [3:0]\Ext_ImmOUT_reg[11] ;
  input [3:0]\Ext_ImmOUT_reg[11]_0 ;
  input [3:0]\Ext_ImmOUT_reg[11]_1 ;
  input [14:0]Q;
  input [3:0]\Ext_ImmOUT_reg[3] ;
  input [3:0]\Ext_ImmOUT_reg[11]_2 ;
  input [3:0]\Ext_ImmOUT_reg[11]_3 ;
  input [3:0]\Ext_ImmOUT_reg[11]_4 ;

  wire \ALUOpOUT_reg[0] ;
  wire [15:0]BranchAdr;
  wire [7:0]Ext_ImmOUT;
  wire [3:0]\Ext_ImmOUT_reg[11] ;
  wire [3:0]\Ext_ImmOUT_reg[11]_0 ;
  wire [3:0]\Ext_ImmOUT_reg[11]_1 ;
  wire [3:0]\Ext_ImmOUT_reg[11]_2 ;
  wire [3:0]\Ext_ImmOUT_reg[11]_3 ;
  wire [3:0]\Ext_ImmOUT_reg[11]_4 ;
  wire [3:0]\Ext_ImmOUT_reg[3] ;
  wire [14:0]Q;
  wire [3:0]S;
  wire Zero;
  wire Zero2;
  wire minusOp_carry__0_n_0;
  wire minusOp_carry__0_n_1;
  wire minusOp_carry__0_n_2;
  wire minusOp_carry__0_n_3;
  wire minusOp_carry__1_n_0;
  wire minusOp_carry__1_n_1;
  wire minusOp_carry__1_n_2;
  wire minusOp_carry__1_n_3;
  wire minusOp_carry__2_n_1;
  wire minusOp_carry__2_n_2;
  wire minusOp_carry__2_n_3;
  wire minusOp_carry_n_0;
  wire minusOp_carry_n_1;
  wire minusOp_carry_n_2;
  wire minusOp_carry_n_3;
  wire plusOp_carry__0_n_0;
  wire plusOp_carry__0_n_1;
  wire plusOp_carry__0_n_2;
  wire plusOp_carry__0_n_3;
  wire plusOp_carry__1_n_0;
  wire plusOp_carry__1_n_1;
  wire plusOp_carry__1_n_2;
  wire plusOp_carry__1_n_3;
  wire plusOp_carry__2_n_1;
  wire plusOp_carry__2_n_2;
  wire plusOp_carry__2_n_3;
  wire plusOp_carry_n_0;
  wire plusOp_carry_n_1;
  wire plusOp_carry_n_2;
  wire plusOp_carry_n_3;
  wire [15:0]sel0;
  wire [3:3]NLW_minusOp_carry__2_CO_UNCONNECTED;
  wire [3:3]NLW_plusOp_carry__2_CO_UNCONNECTED;

  (* XILINX_LEGACY_PRIM = "LD" *) 
  LDCE #(
    .INIT(1'b0)) 
    Zero2_reg
       (.CLR(1'b0),
        .D(Zero2),
        .G(\ALUOpOUT_reg[0] ),
        .GE(1'b1),
        .Q(Zero));
  CARRY4 minusOp_carry
       (.CI(1'b0),
        .CO({minusOp_carry_n_0,minusOp_carry_n_1,minusOp_carry_n_2,minusOp_carry_n_3}),
        .CYINIT(1'b1),
        .DI(Q[3:0]),
        .O(sel0[3:0]),
        .S(\Ext_ImmOUT_reg[3] ));
  CARRY4 minusOp_carry__0
       (.CI(minusOp_carry_n_0),
        .CO({minusOp_carry__0_n_0,minusOp_carry__0_n_1,minusOp_carry__0_n_2,minusOp_carry__0_n_3}),
        .CYINIT(1'b0),
        .DI(Q[7:4]),
        .O(sel0[7:4]),
        .S(\Ext_ImmOUT_reg[11]_2 ));
  CARRY4 minusOp_carry__1
       (.CI(minusOp_carry__0_n_0),
        .CO({minusOp_carry__1_n_0,minusOp_carry__1_n_1,minusOp_carry__1_n_2,minusOp_carry__1_n_3}),
        .CYINIT(1'b0),
        .DI(Q[11:8]),
        .O(sel0[11:8]),
        .S(\Ext_ImmOUT_reg[11]_3 ));
  CARRY4 minusOp_carry__2
       (.CI(minusOp_carry__1_n_0),
        .CO({NLW_minusOp_carry__2_CO_UNCONNECTED[3],minusOp_carry__2_n_1,minusOp_carry__2_n_2,minusOp_carry__2_n_3}),
        .CYINIT(1'b0),
        .DI({1'b0,Q[14:12]}),
        .O(sel0[15:12]),
        .S(\Ext_ImmOUT_reg[11]_4 ));
  CARRY4 plusOp_carry
       (.CI(1'b0),
        .CO({plusOp_carry_n_0,plusOp_carry_n_1,plusOp_carry_n_2,plusOp_carry_n_3}),
        .CYINIT(1'b0),
        .DI(Ext_ImmOUT[3:0]),
        .O(BranchAdr[3:0]),
        .S(S));
  CARRY4 plusOp_carry__0
       (.CI(plusOp_carry_n_0),
        .CO({plusOp_carry__0_n_0,plusOp_carry__0_n_1,plusOp_carry__0_n_2,plusOp_carry__0_n_3}),
        .CYINIT(1'b0),
        .DI(Ext_ImmOUT[7:4]),
        .O(BranchAdr[7:4]),
        .S(\Ext_ImmOUT_reg[11] ));
  CARRY4 plusOp_carry__1
       (.CI(plusOp_carry__0_n_0),
        .CO({plusOp_carry__1_n_0,plusOp_carry__1_n_1,plusOp_carry__1_n_2,plusOp_carry__1_n_3}),
        .CYINIT(1'b0),
        .DI({Ext_ImmOUT[7],Ext_ImmOUT[7],Ext_ImmOUT[7],Ext_ImmOUT[7]}),
        .O(BranchAdr[11:8]),
        .S(\Ext_ImmOUT_reg[11]_0 ));
  CARRY4 plusOp_carry__2
       (.CI(plusOp_carry__1_n_0),
        .CO({NLW_plusOp_carry__2_CO_UNCONNECTED[3],plusOp_carry__2_n_1,plusOp_carry__2_n_2,plusOp_carry__2_n_3}),
        .CYINIT(1'b0),
        .DI({1'b0,Ext_ImmOUT[7],Ext_ImmOUT[7],Ext_ImmOUT[7]}),
        .O(BranchAdr[15:12]),
        .S(\Ext_ImmOUT_reg[11]_1 ));
endmodule

module EX_MEM
   (branch3,
    MemToRegOUT_reg,
    RegWriteOUT_reg,
    D,
    Q,
    \RD1OUT_reg[13] ,
    \instrMUXOUT_reg[2]_0 ,
    Branch,
    clk_IBUF_BUFG,
    led_OBUF,
    Zero,
    \pc_reg[15] ,
    BranchAdr,
    \ALUOpOUT_reg[0] ,
    \RD2OUT_reg[15]_0 ,
    \Ext_ImmOUT_reg[6] );
  output branch3;
  output MemToRegOUT_reg;
  output RegWriteOUT_reg;
  output [3:0]D;
  output [15:0]Q;
  output [15:0]\RD1OUT_reg[13] ;
  output [2:0]\instrMUXOUT_reg[2]_0 ;
  input Branch;
  input clk_IBUF_BUFG;
  input [2:0]led_OBUF;
  input Zero;
  input [3:0]\pc_reg[15] ;
  input [3:0]BranchAdr;
  input [15:0]\ALUOpOUT_reg[0] ;
  input [15:0]\RD2OUT_reg[15]_0 ;
  input [2:0]\Ext_ImmOUT_reg[6] ;

  wire [15:0]\ALUOpOUT_reg[0] ;
  wire Branch;
  wire [3:0]BranchAdr;
  wire [3:0]D;
  wire [2:0]\Ext_ImmOUT_reg[6] ;
  wire MemToRegOUT_reg;
  wire [15:0]Q;
  wire [15:0]\RD1OUT_reg[13] ;
  wire [15:0]\RD2OUT_reg[15]_0 ;
  wire RegWriteOUT_reg;
  wire Zero;
  wire branch3;
  wire clk_IBUF_BUFG;
  wire [2:0]\instrMUXOUT_reg[2]_0 ;
  wire [2:0]led_OBUF;
  wire [3:0]\pc_reg[15] ;

  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [0]),
        .Q(Q[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [10]),
        .Q(Q[10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [11]),
        .Q(Q[11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [12]),
        .Q(Q[12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [13]),
        .Q(Q[13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [14]),
        .Q(Q[14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [15]),
        .Q(Q[15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [1]),
        .Q(Q[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [2]),
        .Q(Q[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [3]),
        .Q(Q[3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [4]),
        .Q(Q[4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [5]),
        .Q(Q[5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [6]),
        .Q(Q[6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [7]),
        .Q(Q[7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [8]),
        .Q(Q[8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\ALUOpOUT_reg[0] [9]),
        .Q(Q[9]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    BranchOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Branch),
        .Q(branch3),
        .R(1'b0));
  (* srl_name = "\ex_mem1/MemtoRegOUT_reg_srl2 " *) 
  SRL16E #(
    .INIT(16'h0000)) 
    MemtoRegOUT_reg_srl2
       (.A0(1'b1),
        .A1(1'b0),
        .A2(1'b0),
        .A3(1'b0),
        .CE(1'b1),
        .CLK(clk_IBUF_BUFG),
        .D(led_OBUF[1]),
        .Q(MemToRegOUT_reg));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [0]),
        .Q(\RD1OUT_reg[13] [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [10]),
        .Q(\RD1OUT_reg[13] [10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [11]),
        .Q(\RD1OUT_reg[13] [11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [12]),
        .Q(\RD1OUT_reg[13] [12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [13]),
        .Q(\RD1OUT_reg[13] [13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [14]),
        .Q(\RD1OUT_reg[13] [14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [15]),
        .Q(\RD1OUT_reg[13] [15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [1]),
        .Q(\RD1OUT_reg[13] [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [2]),
        .Q(\RD1OUT_reg[13] [2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [3]),
        .Q(\RD1OUT_reg[13] [3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [4]),
        .Q(\RD1OUT_reg[13] [4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [5]),
        .Q(\RD1OUT_reg[13] [5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [6]),
        .Q(\RD1OUT_reg[13] [6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [7]),
        .Q(\RD1OUT_reg[13] [7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [8]),
        .Q(\RD1OUT_reg[13] [8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\RD2OUT_reg[15]_0 [9]),
        .Q(\RD1OUT_reg[13] [9]),
        .R(1'b0));
  (* srl_name = "\ex_mem1/RegWriteOUT_reg_srl2 " *) 
  SRL16E #(
    .INIT(16'h0000)) 
    RegWriteOUT_reg_srl2
       (.A0(1'b1),
        .A1(1'b0),
        .A2(1'b0),
        .A3(1'b0),
        .CE(1'b1),
        .CLK(clk_IBUF_BUFG),
        .D(led_OBUF[0]),
        .Q(RegWriteOUT_reg));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\Ext_ImmOUT_reg[6] [0]),
        .Q(\instrMUXOUT_reg[2]_0 [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\Ext_ImmOUT_reg[6] [1]),
        .Q(\instrMUXOUT_reg[2]_0 [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\Ext_ImmOUT_reg[6] [2]),
        .Q(\instrMUXOUT_reg[2]_0 [2]),
        .R(1'b0));
  LUT5 #(
    .INIT(32'h0000F870)) 
    \pc[12]_i_1 
       (.I0(branch3),
        .I1(Zero),
        .I2(\pc_reg[15] [0]),
        .I3(BranchAdr[0]),
        .I4(led_OBUF[2]),
        .O(D[0]));
  LUT5 #(
    .INIT(32'h0000F870)) 
    \pc[13]_i_1 
       (.I0(branch3),
        .I1(Zero),
        .I2(\pc_reg[15] [1]),
        .I3(BranchAdr[1]),
        .I4(led_OBUF[2]),
        .O(D[1]));
  LUT5 #(
    .INIT(32'h0000F870)) 
    \pc[14]_i_1 
       (.I0(branch3),
        .I1(Zero),
        .I2(\pc_reg[15] [2]),
        .I3(BranchAdr[2]),
        .I4(led_OBUF[2]),
        .O(D[2]));
  LUT5 #(
    .INIT(32'h0000F870)) 
    \pc[15]_i_1 
       (.I0(branch3),
        .I1(Zero),
        .I2(\pc_reg[15] [3]),
        .I3(BranchAdr[3]),
        .I4(led_OBUF[2]),
        .O(D[3]));
endmodule

module ID
   (D,
    \RD2OUT_reg[15] ,
    cat_OBUF,
    clk_IBUF_BUFG,
    RegWriteOUT,
    WD,
    Q,
    \instrMUXOUT_reg[2] ,
    p_0_in,
    sw_IBUF,
    \instructiune2_reg[1] ,
    \pc_reg[15] ,
    \pc_reg_rep[1] ,
    \instructiune2_reg[3] ,
    \instructiune2_reg[5] ,
    \instructiune2_reg[6] ,
    \ALUResOUT_reg[9] ,
    \ALUResOUT_reg[13] ,
    \instructiune2_reg[0] ,
    \pc_reg[0] ,
    \instructiune2_reg[2] ,
    \instructiune2_reg[4] ,
    \ALUResOUT_reg[14] ,
    \ALUResOUT_reg[15] ,
    \ALUResOUT_reg[10] ,
    \ALUResOUT_reg[11] ,
    \ALUResOUT_reg[8] ,
    \ALUResOUT_reg[7] ,
    \ALUResOUT_reg[12] );
  output [15:0]D;
  output [15:0]\RD2OUT_reg[15] ;
  output [6:0]cat_OBUF;
  input clk_IBUF_BUFG;
  input RegWriteOUT;
  input [15:0]WD;
  input [4:0]Q;
  input [2:0]\instrMUXOUT_reg[2] ;
  input [1:0]p_0_in;
  input [2:0]sw_IBUF;
  input \instructiune2_reg[1] ;
  input [14:0]\pc_reg[15] ;
  input [14:0]\pc_reg_rep[1] ;
  input \instructiune2_reg[3] ;
  input \instructiune2_reg[5] ;
  input \instructiune2_reg[6] ;
  input \ALUResOUT_reg[9] ;
  input \ALUResOUT_reg[13] ;
  input \instructiune2_reg[0] ;
  input [0:0]\pc_reg[0] ;
  input \instructiune2_reg[2] ;
  input \instructiune2_reg[4] ;
  input \ALUResOUT_reg[14] ;
  input \ALUResOUT_reg[15] ;
  input \ALUResOUT_reg[10] ;
  input \ALUResOUT_reg[11] ;
  input \ALUResOUT_reg[8] ;
  input \ALUResOUT_reg[7] ;
  input \ALUResOUT_reg[12] ;

  wire \ALUResOUT_reg[10] ;
  wire \ALUResOUT_reg[11] ;
  wire \ALUResOUT_reg[12] ;
  wire \ALUResOUT_reg[13] ;
  wire \ALUResOUT_reg[14] ;
  wire \ALUResOUT_reg[15] ;
  wire \ALUResOUT_reg[7] ;
  wire \ALUResOUT_reg[8] ;
  wire \ALUResOUT_reg[9] ;
  wire [15:0]D;
  wire [4:0]Q;
  wire [15:0]\RD2OUT_reg[15] ;
  wire RegWriteOUT;
  wire [15:0]WD;
  wire [6:0]cat_OBUF;
  wire clk_IBUF_BUFG;
  wire [2:0]\instrMUXOUT_reg[2] ;
  wire \instructiune2_reg[0] ;
  wire \instructiune2_reg[1] ;
  wire \instructiune2_reg[2] ;
  wire \instructiune2_reg[3] ;
  wire \instructiune2_reg[4] ;
  wire \instructiune2_reg[5] ;
  wire \instructiune2_reg[6] ;
  wire [1:0]p_0_in;
  wire [0:0]\pc_reg[0] ;
  wire [14:0]\pc_reg[15] ;
  wire [14:0]\pc_reg_rep[1] ;
  wire [2:0]sw_IBUF;

  reg_file rg1
       (.\ALUResOUT_reg[10] (\ALUResOUT_reg[10] ),
        .\ALUResOUT_reg[11] (\ALUResOUT_reg[11] ),
        .\ALUResOUT_reg[12] (\ALUResOUT_reg[12] ),
        .\ALUResOUT_reg[13] (\ALUResOUT_reg[13] ),
        .\ALUResOUT_reg[14] (\ALUResOUT_reg[14] ),
        .\ALUResOUT_reg[15] (\ALUResOUT_reg[15] ),
        .\ALUResOUT_reg[7] (\ALUResOUT_reg[7] ),
        .\ALUResOUT_reg[8] (\ALUResOUT_reg[8] ),
        .\ALUResOUT_reg[9] (\ALUResOUT_reg[9] ),
        .D(D),
        .Q(Q),
        .\RD2OUT_reg[15] (\RD2OUT_reg[15] ),
        .RegWriteOUT(RegWriteOUT),
        .WD(WD),
        .cat_OBUF(cat_OBUF),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instrMUXOUT_reg[2] (\instrMUXOUT_reg[2] ),
        .\instructiune2_reg[0] (\instructiune2_reg[0] ),
        .\instructiune2_reg[1] (\instructiune2_reg[1] ),
        .\instructiune2_reg[2] (\instructiune2_reg[2] ),
        .\instructiune2_reg[3] (\instructiune2_reg[3] ),
        .\instructiune2_reg[4] (\instructiune2_reg[4] ),
        .\instructiune2_reg[5] (\instructiune2_reg[5] ),
        .\instructiune2_reg[6] (\instructiune2_reg[6] ),
        .p_0_in(p_0_in),
        .\pc_reg[0] (\pc_reg[0] ),
        .\pc_reg[15] (\pc_reg[15] ),
        .\pc_reg_rep[1] (\pc_reg_rep[1] ),
        .sw_IBUF(sw_IBUF));
endmodule

module ID_EX
   (Ext_ImmOUT,
    Branch,
    \ALUResOUT_reg[15] ,
    \ALUResOUT_reg[15]_0 ,
    \RD2OUT_reg[15]_0 ,
    \pc_reg[15] ,
    \pc_reg[1] ,
    \instrMUXOUT_reg[2] ,
    Zero2,
    S,
    \pc_reg[7] ,
    \pc_reg[11] ,
    \ALUResOUT_reg[3] ,
    \ALUResOUT_reg[11] ,
    \ALUResOUT_reg[7] ,
    \ALUResOUT_reg[15]_1 ,
    \instructiune2_reg[14] ,
    clk_IBUF_BUFG,
    led_OBUF,
    Q,
    sel0,
    \next_instr2_reg[15] ,
    D,
    RegWriteOUT_reg);
  output [7:0]Ext_ImmOUT;
  output Branch;
  output [15:0]\ALUResOUT_reg[15] ;
  output [14:0]\ALUResOUT_reg[15]_0 ;
  output [15:0]\RD2OUT_reg[15]_0 ;
  output [3:0]\pc_reg[15] ;
  output \pc_reg[1] ;
  output [2:0]\instrMUXOUT_reg[2] ;
  output Zero2;
  output [3:0]S;
  output [3:0]\pc_reg[7] ;
  output [3:0]\pc_reg[11] ;
  output [3:0]\ALUResOUT_reg[3] ;
  output [3:0]\ALUResOUT_reg[11] ;
  output [3:0]\ALUResOUT_reg[7] ;
  output [3:0]\ALUResOUT_reg[15]_1 ;
  input \instructiune2_reg[14] ;
  input clk_IBUF_BUFG;
  input [5:0]led_OBUF;
  input [9:0]Q;
  input [15:0]sel0;
  input [15:0]\next_instr2_reg[15] ;
  input [15:0]D;
  input [15:0]RegWriteOUT_reg;

  wire [2:0]ALUOpOUT;
  wire \ALUResOUT[0]_i_3_n_0 ;
  wire \ALUResOUT[0]_i_4_n_0 ;
  wire \ALUResOUT[0]_i_5_n_0 ;
  wire \ALUResOUT[0]_i_6_n_0 ;
  wire \ALUResOUT[10]_i_3_n_0 ;
  wire \ALUResOUT[10]_i_4_n_0 ;
  wire \ALUResOUT[10]_i_5_n_0 ;
  wire \ALUResOUT[10]_i_6_n_0 ;
  wire \ALUResOUT[11]_i_10_n_0 ;
  wire \ALUResOUT[11]_i_11_n_0 ;
  wire \ALUResOUT[11]_i_4_n_0 ;
  wire \ALUResOUT[11]_i_5_n_0 ;
  wire \ALUResOUT[11]_i_6_n_0 ;
  wire \ALUResOUT[11]_i_7_n_0 ;
  wire \ALUResOUT[11]_i_8_n_0 ;
  wire \ALUResOUT[11]_i_9_n_0 ;
  wire \ALUResOUT[12]_i_3_n_0 ;
  wire \ALUResOUT[12]_i_4_n_0 ;
  wire \ALUResOUT[12]_i_5_n_0 ;
  wire \ALUResOUT[12]_i_6_n_0 ;
  wire \ALUResOUT[13]_i_3_n_0 ;
  wire \ALUResOUT[13]_i_4_n_0 ;
  wire \ALUResOUT[13]_i_5_n_0 ;
  wire \ALUResOUT[13]_i_6_n_0 ;
  wire \ALUResOUT[14]_i_3_n_0 ;
  wire \ALUResOUT[14]_i_4_n_0 ;
  wire \ALUResOUT[14]_i_5_n_0 ;
  wire \ALUResOUT[14]_i_6_n_0 ;
  wire \ALUResOUT[15]_i_10_n_0 ;
  wire \ALUResOUT[15]_i_11_n_0 ;
  wire \ALUResOUT[15]_i_12_n_0 ;
  wire \ALUResOUT[15]_i_4_n_0 ;
  wire \ALUResOUT[15]_i_5_n_0 ;
  wire \ALUResOUT[15]_i_6_n_0 ;
  wire \ALUResOUT[15]_i_7_n_0 ;
  wire \ALUResOUT[15]_i_8_n_0 ;
  wire \ALUResOUT[15]_i_9_n_0 ;
  wire \ALUResOUT[1]_i_3_n_0 ;
  wire \ALUResOUT[1]_i_4_n_0 ;
  wire \ALUResOUT[1]_i_5_n_0 ;
  wire \ALUResOUT[1]_i_6_n_0 ;
  wire \ALUResOUT[2]_i_3_n_0 ;
  wire \ALUResOUT[2]_i_4_n_0 ;
  wire \ALUResOUT[2]_i_5_n_0 ;
  wire \ALUResOUT[2]_i_6_n_0 ;
  wire \ALUResOUT[3]_i_10_n_0 ;
  wire \ALUResOUT[3]_i_11_n_0 ;
  wire \ALUResOUT[3]_i_4_n_0 ;
  wire \ALUResOUT[3]_i_5_n_0 ;
  wire \ALUResOUT[3]_i_6_n_0 ;
  wire \ALUResOUT[3]_i_7_n_0 ;
  wire \ALUResOUT[3]_i_8_n_0 ;
  wire \ALUResOUT[3]_i_9_n_0 ;
  wire \ALUResOUT[4]_i_3_n_0 ;
  wire \ALUResOUT[4]_i_4_n_0 ;
  wire \ALUResOUT[4]_i_5_n_0 ;
  wire \ALUResOUT[4]_i_6_n_0 ;
  wire \ALUResOUT[5]_i_3_n_0 ;
  wire \ALUResOUT[5]_i_4_n_0 ;
  wire \ALUResOUT[5]_i_5_n_0 ;
  wire \ALUResOUT[5]_i_6_n_0 ;
  wire \ALUResOUT[6]_i_3_n_0 ;
  wire \ALUResOUT[6]_i_4_n_0 ;
  wire \ALUResOUT[6]_i_5_n_0 ;
  wire \ALUResOUT[6]_i_6_n_0 ;
  wire \ALUResOUT[7]_i_10_n_0 ;
  wire \ALUResOUT[7]_i_11_n_0 ;
  wire \ALUResOUT[7]_i_4_n_0 ;
  wire \ALUResOUT[7]_i_5_n_0 ;
  wire \ALUResOUT[7]_i_6_n_0 ;
  wire \ALUResOUT[7]_i_7_n_0 ;
  wire \ALUResOUT[7]_i_8_n_0 ;
  wire \ALUResOUT[7]_i_9_n_0 ;
  wire \ALUResOUT[8]_i_3_n_0 ;
  wire \ALUResOUT[8]_i_4_n_0 ;
  wire \ALUResOUT[8]_i_5_n_0 ;
  wire \ALUResOUT[8]_i_6_n_0 ;
  wire \ALUResOUT[9]_i_3_n_0 ;
  wire \ALUResOUT[9]_i_4_n_0 ;
  wire \ALUResOUT[9]_i_5_n_0 ;
  wire \ALUResOUT[9]_i_6_n_0 ;
  wire [3:0]\ALUResOUT_reg[11] ;
  wire \ALUResOUT_reg[11]_i_2_n_0 ;
  wire \ALUResOUT_reg[11]_i_2_n_1 ;
  wire \ALUResOUT_reg[11]_i_2_n_2 ;
  wire \ALUResOUT_reg[11]_i_2_n_3 ;
  wire [15:0]\ALUResOUT_reg[15] ;
  wire [14:0]\ALUResOUT_reg[15]_0 ;
  wire [3:0]\ALUResOUT_reg[15]_1 ;
  wire \ALUResOUT_reg[15]_i_2_n_1 ;
  wire \ALUResOUT_reg[15]_i_2_n_2 ;
  wire \ALUResOUT_reg[15]_i_2_n_3 ;
  wire [3:0]\ALUResOUT_reg[3] ;
  wire \ALUResOUT_reg[3]_i_2_n_0 ;
  wire \ALUResOUT_reg[3]_i_2_n_1 ;
  wire \ALUResOUT_reg[3]_i_2_n_2 ;
  wire \ALUResOUT_reg[3]_i_2_n_3 ;
  wire [3:0]\ALUResOUT_reg[7] ;
  wire \ALUResOUT_reg[7]_i_2_n_0 ;
  wire \ALUResOUT_reg[7]_i_2_n_1 ;
  wire \ALUResOUT_reg[7]_i_2_n_2 ;
  wire \ALUResOUT_reg[7]_i_2_n_3 ;
  wire ALUSrc;
  wire Branch;
  wire [15:0]D;
  wire [7:0]Ext_ImmOUT;
  wire [9:0]Q;
  wire [2:0]RAOUT;
  wire [15:15]RD1OUT;
  wire [15:0]\RD2OUT_reg[15]_0 ;
  wire RegDstOUT;
  wire [15:0]RegWriteOUT_reg;
  wire [3:0]S;
  wire Zero2;
  wire Zero2_reg_i_3_n_0;
  wire Zero2_reg_i_4_n_0;
  wire Zero2_reg_i_5_n_0;
  wire clk_IBUF_BUFG;
  wire [15:0]data0;
  wire [15:0]\ex1/ALURes2__17 ;
  wire [14:1]\ex1/mux ;
  wire [15:15]\ex1/mux__39 ;
  wire [2:0]\instrMUXOUT_reg[2] ;
  wire \instructiune2_reg[14] ;
  wire [5:0]led_OBUF;
  wire [15:0]\next_instr2_reg[15] ;
  wire [15:0]nxtInstructiuneOUT;
  wire [3:0]\pc_reg[11] ;
  wire [3:0]\pc_reg[15] ;
  wire \pc_reg[1] ;
  wire [3:0]\pc_reg[7] ;
  wire [15:0]sel0;
  wire [3:3]\NLW_ALUResOUT_reg[15]_i_2_CO_UNCONNECTED ;

  FDRE #(
    .INIT(1'b0)) 
    \ALUOpOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[0]),
        .Q(ALUOpOUT[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUOpOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[1]),
        .Q(ALUOpOUT[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUOpOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[2]),
        .Q(ALUOpOUT[2]),
        .R(1'b0));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[0]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[0]),
        .I2(\ex1/ALURes2__17 [0]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[0]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [0]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[0]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [0]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [0]),
        .I3(Ext_ImmOUT[0]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[0]),
        .O(\ALUResOUT[0]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[0]_i_4 
       (.I0(\ALUResOUT[0]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[0]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[0]),
        .O(\ALUResOUT[0]_i_4_n_0 ));
  LUT6 #(
    .INIT(64'hFCF0B3BCFCF0BC80)) 
    \ALUResOUT[0]_i_5 
       (.I0(\RD2OUT_reg[15]_0 [1]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [0]),
        .I4(ALUSrc),
        .I5(\RD2OUT_reg[15]_0 [0]),
        .O(\ALUResOUT[0]_i_5_n_0 ));
  LUT6 #(
    .INIT(64'hA0C0A0C0F0FFF000)) 
    \ALUResOUT[0]_i_6 
       (.I0(Ext_ImmOUT[1]),
        .I1(\RD2OUT_reg[15]_0 [1]),
        .I2(Ext_ImmOUT[0]),
        .I3(ALUSrc),
        .I4(\RD2OUT_reg[15]_0 [0]),
        .I5(Ext_ImmOUT[3]),
        .O(\ALUResOUT[0]_i_6_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[10]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[10]),
        .I2(\ex1/ALURes2__17 [10]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[10]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [10]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[10]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [10]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [10]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[10]),
        .O(\ALUResOUT[10]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[10]_i_4 
       (.I0(\ALUResOUT[10]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[10]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[10]),
        .O(\ALUResOUT[10]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[10]_i_5 
       (.I0(\ex1/mux [11]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [10]),
        .I4(\ex1/mux [10]),
        .O(\ALUResOUT[10]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[10]_i_6 
       (.I0(\ex1/mux [11]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [9]),
        .I3(\ex1/mux [10]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[10]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair9" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[10]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [10]),
        .I2(ALUSrc),
        .O(\ex1/mux [10]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[11]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[11]),
        .I2(\ex1/ALURes2__17 [11]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[11]_i_4_n_0 ),
        .O(\ALUResOUT_reg[15] [11]));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[11]_i_10 
       (.I0(\ex1/mux [12]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [11]),
        .I4(\ex1/mux [11]),
        .O(\ALUResOUT[11]_i_10_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[11]_i_11 
       (.I0(\ex1/mux [12]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [10]),
        .I3(\ex1/mux [11]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[11]_i_11_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair10" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[11]_i_12 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [11]),
        .I2(ALUSrc),
        .O(\ex1/mux [11]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[11]_i_4 
       (.I0(\ALUResOUT_reg[15]_0 [11]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [11]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[11]),
        .O(\ALUResOUT[11]_i_4_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[11]_i_5 
       (.I0(\ALUResOUT_reg[15]_0 [11]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [11]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[11]_i_5_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[11]_i_6 
       (.I0(\ALUResOUT_reg[15]_0 [10]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [10]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[11]_i_6_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[11]_i_7 
       (.I0(\ALUResOUT_reg[15]_0 [9]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [9]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[11]_i_7_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[11]_i_8 
       (.I0(\ALUResOUT_reg[15]_0 [8]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [8]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[11]_i_8_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[11]_i_9 
       (.I0(\ALUResOUT[11]_i_11_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[11]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[11]),
        .O(\ALUResOUT[11]_i_9_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[12]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[12]),
        .I2(\ex1/ALURes2__17 [12]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[12]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [12]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[12]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [12]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [12]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[12]),
        .O(\ALUResOUT[12]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[12]_i_4 
       (.I0(\ALUResOUT[12]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[12]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[12]),
        .O(\ALUResOUT[12]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[12]_i_5 
       (.I0(\ex1/mux [13]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [12]),
        .I4(\ex1/mux [12]),
        .O(\ALUResOUT[12]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[12]_i_6 
       (.I0(\ex1/mux [13]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [11]),
        .I3(\ex1/mux [12]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[12]_i_6_n_0 ));
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[12]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [12]),
        .I2(ALUSrc),
        .O(\ex1/mux [12]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[13]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[13]),
        .I2(\ex1/ALURes2__17 [13]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[13]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [13]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[13]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [13]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [13]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[13]),
        .O(\ALUResOUT[13]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[13]_i_4 
       (.I0(\ALUResOUT[13]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[13]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[13]),
        .O(\ALUResOUT[13]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[13]_i_5 
       (.I0(\ex1/mux [14]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [13]),
        .I4(\ex1/mux [13]),
        .O(\ALUResOUT[13]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[13]_i_6 
       (.I0(\ex1/mux [14]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [12]),
        .I3(\ex1/mux [13]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[13]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair10" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[13]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [13]),
        .I2(ALUSrc),
        .O(\ex1/mux [13]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[14]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[14]),
        .I2(\ex1/ALURes2__17 [14]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[14]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [14]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[14]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [14]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [14]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[14]),
        .O(\ALUResOUT[14]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[14]_i_4 
       (.I0(\ALUResOUT[14]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[14]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[14]),
        .O(\ALUResOUT[14]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[14]_i_5 
       (.I0(\ex1/mux__39 ),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [14]),
        .I4(\ex1/mux [14]),
        .O(\ALUResOUT[14]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[14]_i_6 
       (.I0(\ex1/mux__39 ),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [13]),
        .I3(\ex1/mux [14]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[14]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair11" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[14]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [15]),
        .I2(ALUSrc),
        .O(\ex1/mux__39 ));
  (* SOFT_HLUTNM = "soft_lutpair11" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[14]_i_8 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [14]),
        .I2(ALUSrc),
        .O(\ex1/mux [14]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[15]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[15]),
        .I2(\ex1/ALURes2__17 [15]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[15]_i_4_n_0 ),
        .O(\ALUResOUT_reg[15] [15]));
  LUT6 #(
    .INIT(64'hDEDEDE6060DE6060)) 
    \ALUResOUT[15]_i_10 
       (.I0(Ext_ImmOUT[1]),
        .I1(Ext_ImmOUT[0]),
        .I2(RD1OUT),
        .I3(ALUSrc),
        .I4(\RD2OUT_reg[15]_0 [15]),
        .I5(Ext_ImmOUT[7]),
        .O(\ALUResOUT[15]_i_10_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair3" *) 
  LUT3 #(
    .INIT(8'h5D)) 
    \ALUResOUT[15]_i_11 
       (.I0(ALUOpOUT[2]),
        .I1(ALUOpOUT[0]),
        .I2(ALUOpOUT[1]),
        .O(\ALUResOUT[15]_i_11_n_0 ));
  LUT6 #(
    .INIT(64'h50504444F0F0FF00)) 
    \ALUResOUT[15]_i_12 
       (.I0(Ext_ImmOUT[0]),
        .I1(\RD2OUT_reg[15]_0 [14]),
        .I2(Ext_ImmOUT[7]),
        .I3(\RD2OUT_reg[15]_0 [15]),
        .I4(ALUSrc),
        .I5(Ext_ImmOUT[3]),
        .O(\ALUResOUT[15]_i_12_n_0 ));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[15]_i_4 
       (.I0(RD1OUT),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [15]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[15]),
        .O(\ALUResOUT[15]_i_4_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[15]_i_5 
       (.I0(RD1OUT),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [15]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[15]_i_5_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[15]_i_6 
       (.I0(\ALUResOUT_reg[15]_0 [14]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [14]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[15]_i_6_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[15]_i_7 
       (.I0(\ALUResOUT_reg[15]_0 [13]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [13]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[15]_i_7_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[15]_i_8 
       (.I0(\ALUResOUT_reg[15]_0 [12]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [12]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[15]_i_8_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[15]_i_9 
       (.I0(\ALUResOUT[15]_i_12_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[15]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[15]),
        .O(\ALUResOUT[15]_i_9_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[1]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[1]),
        .I2(\ex1/ALURes2__17 [1]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[1]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [1]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[1]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [1]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [1]),
        .I3(Ext_ImmOUT[1]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[1]),
        .O(\ALUResOUT[1]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[1]_i_4 
       (.I0(\ALUResOUT[1]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[1]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[1]),
        .O(\ALUResOUT[1]_i_4_n_0 ));
  LUT6 #(
    .INIT(64'hB08CB3BCB08CBC80)) 
    \ALUResOUT[1]_i_5 
       (.I0(\ex1/mux [2]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [1]),
        .I4(ALUSrc),
        .I5(\RD2OUT_reg[15]_0 [1]),
        .O(\ALUResOUT[1]_i_5_n_0 ));
  LUT6 #(
    .INIT(64'h88B888B8FFFF0000)) 
    \ALUResOUT[1]_i_6 
       (.I0(\ex1/mux [2]),
        .I1(Ext_ImmOUT[0]),
        .I2(\RD2OUT_reg[15]_0 [0]),
        .I3(ALUSrc),
        .I4(\ex1/mux [1]),
        .I5(Ext_ImmOUT[3]),
        .O(\ALUResOUT[1]_i_6_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[2]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[2]),
        .I2(\ex1/ALURes2__17 [2]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[2]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [2]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[2]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [2]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [2]),
        .I3(Ext_ImmOUT[2]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[2]),
        .O(\ALUResOUT[2]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[2]_i_4 
       (.I0(\ALUResOUT[2]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[2]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[2]),
        .O(\ALUResOUT[2]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[2]_i_5 
       (.I0(\ex1/mux [3]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [2]),
        .I4(\ex1/mux [2]),
        .O(\ALUResOUT[2]_i_5_n_0 ));
  LUT6 #(
    .INIT(64'hEFE0EFE0FFFF0000)) 
    \ALUResOUT[2]_i_6 
       (.I0(\RD2OUT_reg[15]_0 [3]),
        .I1(ALUSrc),
        .I2(Ext_ImmOUT[0]),
        .I3(\ex1/mux [1]),
        .I4(\ex1/mux [2]),
        .I5(Ext_ImmOUT[3]),
        .O(\ALUResOUT[2]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair5" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[2]_i_7 
       (.I0(Ext_ImmOUT[2]),
        .I1(\RD2OUT_reg[15]_0 [2]),
        .I2(ALUSrc),
        .O(\ex1/mux [2]));
  (* SOFT_HLUTNM = "soft_lutpair5" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[2]_i_8 
       (.I0(Ext_ImmOUT[1]),
        .I1(\RD2OUT_reg[15]_0 [1]),
        .I2(ALUSrc),
        .O(\ex1/mux [1]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[3]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[3]),
        .I2(\ex1/ALURes2__17 [3]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[3]_i_4_n_0 ),
        .O(\ALUResOUT_reg[15] [3]));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[3]_i_10 
       (.I0(\ex1/mux [4]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [3]),
        .I4(\ex1/mux [3]),
        .O(\ALUResOUT[3]_i_10_n_0 ));
  LUT6 #(
    .INIT(64'hB800B800B8FFB800)) 
    \ALUResOUT[3]_i_11 
       (.I0(\ex1/mux [4]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [2]),
        .I3(Ext_ImmOUT[3]),
        .I4(\RD2OUT_reg[15]_0 [3]),
        .I5(ALUSrc),
        .O(\ALUResOUT[3]_i_11_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair6" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[3]_i_12 
       (.I0(Ext_ImmOUT[3]),
        .I1(\RD2OUT_reg[15]_0 [3]),
        .I2(ALUSrc),
        .O(\ex1/mux [3]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[3]_i_4 
       (.I0(\ALUResOUT_reg[15]_0 [3]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [3]),
        .I3(Ext_ImmOUT[3]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[3]),
        .O(\ALUResOUT[3]_i_4_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[3]_i_5 
       (.I0(\ALUResOUT_reg[15]_0 [3]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [3]),
        .I3(Ext_ImmOUT[3]),
        .O(\ALUResOUT[3]_i_5_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[3]_i_6 
       (.I0(\ALUResOUT_reg[15]_0 [2]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [2]),
        .I3(Ext_ImmOUT[2]),
        .O(\ALUResOUT[3]_i_6_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[3]_i_7 
       (.I0(\ALUResOUT_reg[15]_0 [1]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [1]),
        .I3(Ext_ImmOUT[1]),
        .O(\ALUResOUT[3]_i_7_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[3]_i_8 
       (.I0(\ALUResOUT_reg[15]_0 [0]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [0]),
        .I3(Ext_ImmOUT[0]),
        .O(\ALUResOUT[3]_i_8_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[3]_i_9 
       (.I0(\ALUResOUT[3]_i_11_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[3]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[3]),
        .O(\ALUResOUT[3]_i_9_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[4]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[4]),
        .I2(\ex1/ALURes2__17 [4]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[4]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [4]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[4]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [4]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [4]),
        .I3(Ext_ImmOUT[4]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[4]),
        .O(\ALUResOUT[4]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[4]_i_4 
       (.I0(\ALUResOUT[4]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[4]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[4]),
        .O(\ALUResOUT[4]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[4]_i_5 
       (.I0(\ex1/mux [5]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [4]),
        .I4(\ex1/mux [4]),
        .O(\ALUResOUT[4]_i_5_n_0 ));
  LUT6 #(
    .INIT(64'hBBB8BBB8FFFF0000)) 
    \ALUResOUT[4]_i_6 
       (.I0(\ex1/mux [5]),
        .I1(Ext_ImmOUT[0]),
        .I2(\RD2OUT_reg[15]_0 [3]),
        .I3(ALUSrc),
        .I4(\ex1/mux [4]),
        .I5(Ext_ImmOUT[3]),
        .O(\ALUResOUT[4]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair4" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[4]_i_7 
       (.I0(Ext_ImmOUT[4]),
        .I1(\RD2OUT_reg[15]_0 [4]),
        .I2(ALUSrc),
        .O(\ex1/mux [4]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[5]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[5]),
        .I2(\ex1/ALURes2__17 [5]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[5]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [5]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[5]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [5]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [5]),
        .I3(Ext_ImmOUT[5]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[5]),
        .O(\ALUResOUT[5]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[5]_i_4 
       (.I0(\ALUResOUT[5]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[5]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[5]),
        .O(\ALUResOUT[5]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[5]_i_5 
       (.I0(\ex1/mux [6]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [5]),
        .I4(\ex1/mux [5]),
        .O(\ALUResOUT[5]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[5]_i_6 
       (.I0(\ex1/mux [6]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [4]),
        .I3(\ex1/mux [5]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[5]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair6" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[5]_i_7 
       (.I0(Ext_ImmOUT[5]),
        .I1(\RD2OUT_reg[15]_0 [5]),
        .I2(ALUSrc),
        .O(\ex1/mux [5]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[6]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[6]),
        .I2(\ex1/ALURes2__17 [6]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[6]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [6]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[6]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [6]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [6]),
        .I3(Ext_ImmOUT[6]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[6]),
        .O(\ALUResOUT[6]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[6]_i_4 
       (.I0(\ALUResOUT[6]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[6]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[6]),
        .O(\ALUResOUT[6]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[6]_i_5 
       (.I0(\ex1/mux [7]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [6]),
        .I4(\ex1/mux [6]),
        .O(\ALUResOUT[6]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[6]_i_6 
       (.I0(\ex1/mux [7]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [5]),
        .I3(\ex1/mux [6]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[6]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair7" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[6]_i_7 
       (.I0(Ext_ImmOUT[6]),
        .I1(\RD2OUT_reg[15]_0 [6]),
        .I2(ALUSrc),
        .O(\ex1/mux [6]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[7]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[7]),
        .I2(\ex1/ALURes2__17 [7]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[7]_i_4_n_0 ),
        .O(\ALUResOUT_reg[15] [7]));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[7]_i_10 
       (.I0(\ex1/mux [8]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [7]),
        .I4(\ex1/mux [7]),
        .O(\ALUResOUT[7]_i_10_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[7]_i_11 
       (.I0(\ex1/mux [8]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [6]),
        .I3(\ex1/mux [7]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[7]_i_11_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair8" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[7]_i_12 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [7]),
        .I2(ALUSrc),
        .O(\ex1/mux [7]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[7]_i_4 
       (.I0(\ALUResOUT_reg[15]_0 [7]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [7]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[7]),
        .O(\ALUResOUT[7]_i_4_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[7]_i_5 
       (.I0(\ALUResOUT_reg[15]_0 [7]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [7]),
        .I3(Ext_ImmOUT[7]),
        .O(\ALUResOUT[7]_i_5_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[7]_i_6 
       (.I0(\ALUResOUT_reg[15]_0 [6]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [6]),
        .I3(Ext_ImmOUT[6]),
        .O(\ALUResOUT[7]_i_6_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[7]_i_7 
       (.I0(\ALUResOUT_reg[15]_0 [5]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [5]),
        .I3(Ext_ImmOUT[5]),
        .O(\ALUResOUT[7]_i_7_n_0 ));
  LUT4 #(
    .INIT(16'h569A)) 
    \ALUResOUT[7]_i_8 
       (.I0(\ALUResOUT_reg[15]_0 [4]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [4]),
        .I3(Ext_ImmOUT[4]),
        .O(\ALUResOUT[7]_i_8_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[7]_i_9 
       (.I0(\ALUResOUT[7]_i_11_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[7]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[7]),
        .O(\ALUResOUT[7]_i_9_n_0 ));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[8]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[8]),
        .I2(\ex1/ALURes2__17 [8]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[8]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [8]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[8]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [8]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [8]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[8]),
        .O(\ALUResOUT[8]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[8]_i_4 
       (.I0(\ALUResOUT[8]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[8]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[8]),
        .O(\ALUResOUT[8]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[8]_i_5 
       (.I0(\ex1/mux [9]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [8]),
        .I4(\ex1/mux [8]),
        .O(\ALUResOUT[8]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[8]_i_6 
       (.I0(\ex1/mux [9]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [7]),
        .I3(\ex1/mux [8]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[8]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair8" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[8]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [8]),
        .I2(ALUSrc),
        .O(\ex1/mux [8]));
  LUT6 #(
    .INIT(64'h00FFD8440000D844)) 
    \ALUResOUT[9]_i_1 
       (.I0(ALUOpOUT[0]),
        .I1(data0[9]),
        .I2(\ex1/ALURes2__17 [9]),
        .I3(ALUOpOUT[1]),
        .I4(ALUOpOUT[2]),
        .I5(\ALUResOUT[9]_i_3_n_0 ),
        .O(\ALUResOUT_reg[15] [9]));
  LUT6 #(
    .INIT(64'hA820FFFFA8200000)) 
    \ALUResOUT[9]_i_3 
       (.I0(\ALUResOUT_reg[15]_0 [9]),
        .I1(ALUSrc),
        .I2(\RD2OUT_reg[15]_0 [9]),
        .I3(Ext_ImmOUT[7]),
        .I4(\ALUResOUT[15]_i_11_n_0 ),
        .I5(sel0[9]),
        .O(\ALUResOUT[9]_i_3_n_0 ));
  LUT5 #(
    .INIT(32'hB8BBB888)) 
    \ALUResOUT[9]_i_4 
       (.I0(\ALUResOUT[9]_i_6_n_0 ),
        .I1(Ext_ImmOUT[1]),
        .I2(sel0[9]),
        .I3(Ext_ImmOUT[0]),
        .I4(data0[9]),
        .O(\ALUResOUT[9]_i_4_n_0 ));
  LUT5 #(
    .INIT(32'hB3BCBC80)) 
    \ALUResOUT[9]_i_5 
       (.I0(\ex1/mux [10]),
        .I1(Ext_ImmOUT[1]),
        .I2(Ext_ImmOUT[0]),
        .I3(\ALUResOUT_reg[15]_0 [9]),
        .I4(\ex1/mux [9]),
        .O(\ALUResOUT[9]_i_5_n_0 ));
  LUT5 #(
    .INIT(32'hB8B8FF00)) 
    \ALUResOUT[9]_i_6 
       (.I0(\ex1/mux [10]),
        .I1(Ext_ImmOUT[0]),
        .I2(\ex1/mux [8]),
        .I3(\ex1/mux [9]),
        .I4(Ext_ImmOUT[3]),
        .O(\ALUResOUT[9]_i_6_n_0 ));
  (* SOFT_HLUTNM = "soft_lutpair9" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \ALUResOUT[9]_i_7 
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [9]),
        .I2(ALUSrc),
        .O(\ex1/mux [9]));
  MUXF7 \ALUResOUT_reg[0]_i_2 
       (.I0(\ALUResOUT[0]_i_4_n_0 ),
        .I1(\ALUResOUT[0]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [0]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[10]_i_2 
       (.I0(\ALUResOUT[10]_i_4_n_0 ),
        .I1(\ALUResOUT[10]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [10]),
        .S(Ext_ImmOUT[2]));
  CARRY4 \ALUResOUT_reg[11]_i_2 
       (.CI(\ALUResOUT_reg[7]_i_2_n_0 ),
        .CO({\ALUResOUT_reg[11]_i_2_n_0 ,\ALUResOUT_reg[11]_i_2_n_1 ,\ALUResOUT_reg[11]_i_2_n_2 ,\ALUResOUT_reg[11]_i_2_n_3 }),
        .CYINIT(1'b0),
        .DI(\ALUResOUT_reg[15]_0 [11:8]),
        .O(data0[11:8]),
        .S({\ALUResOUT[11]_i_5_n_0 ,\ALUResOUT[11]_i_6_n_0 ,\ALUResOUT[11]_i_7_n_0 ,\ALUResOUT[11]_i_8_n_0 }));
  MUXF7 \ALUResOUT_reg[11]_i_3 
       (.I0(\ALUResOUT[11]_i_9_n_0 ),
        .I1(\ALUResOUT[11]_i_10_n_0 ),
        .O(\ex1/ALURes2__17 [11]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[12]_i_2 
       (.I0(\ALUResOUT[12]_i_4_n_0 ),
        .I1(\ALUResOUT[12]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [12]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[13]_i_2 
       (.I0(\ALUResOUT[13]_i_4_n_0 ),
        .I1(\ALUResOUT[13]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [13]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[14]_i_2 
       (.I0(\ALUResOUT[14]_i_4_n_0 ),
        .I1(\ALUResOUT[14]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [14]),
        .S(Ext_ImmOUT[2]));
  CARRY4 \ALUResOUT_reg[15]_i_2 
       (.CI(\ALUResOUT_reg[11]_i_2_n_0 ),
        .CO({\NLW_ALUResOUT_reg[15]_i_2_CO_UNCONNECTED [3],\ALUResOUT_reg[15]_i_2_n_1 ,\ALUResOUT_reg[15]_i_2_n_2 ,\ALUResOUT_reg[15]_i_2_n_3 }),
        .CYINIT(1'b0),
        .DI({1'b0,\ALUResOUT_reg[15]_0 [14:12]}),
        .O(data0[15:12]),
        .S({\ALUResOUT[15]_i_5_n_0 ,\ALUResOUT[15]_i_6_n_0 ,\ALUResOUT[15]_i_7_n_0 ,\ALUResOUT[15]_i_8_n_0 }));
  MUXF7 \ALUResOUT_reg[15]_i_3 
       (.I0(\ALUResOUT[15]_i_9_n_0 ),
        .I1(\ALUResOUT[15]_i_10_n_0 ),
        .O(\ex1/ALURes2__17 [15]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[1]_i_2 
       (.I0(\ALUResOUT[1]_i_4_n_0 ),
        .I1(\ALUResOUT[1]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [1]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[2]_i_2 
       (.I0(\ALUResOUT[2]_i_4_n_0 ),
        .I1(\ALUResOUT[2]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [2]),
        .S(Ext_ImmOUT[2]));
  CARRY4 \ALUResOUT_reg[3]_i_2 
       (.CI(1'b0),
        .CO({\ALUResOUT_reg[3]_i_2_n_0 ,\ALUResOUT_reg[3]_i_2_n_1 ,\ALUResOUT_reg[3]_i_2_n_2 ,\ALUResOUT_reg[3]_i_2_n_3 }),
        .CYINIT(1'b0),
        .DI(\ALUResOUT_reg[15]_0 [3:0]),
        .O(data0[3:0]),
        .S({\ALUResOUT[3]_i_5_n_0 ,\ALUResOUT[3]_i_6_n_0 ,\ALUResOUT[3]_i_7_n_0 ,\ALUResOUT[3]_i_8_n_0 }));
  MUXF7 \ALUResOUT_reg[3]_i_3 
       (.I0(\ALUResOUT[3]_i_9_n_0 ),
        .I1(\ALUResOUT[3]_i_10_n_0 ),
        .O(\ex1/ALURes2__17 [3]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[4]_i_2 
       (.I0(\ALUResOUT[4]_i_4_n_0 ),
        .I1(\ALUResOUT[4]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [4]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[5]_i_2 
       (.I0(\ALUResOUT[5]_i_4_n_0 ),
        .I1(\ALUResOUT[5]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [5]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[6]_i_2 
       (.I0(\ALUResOUT[6]_i_4_n_0 ),
        .I1(\ALUResOUT[6]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [6]),
        .S(Ext_ImmOUT[2]));
  CARRY4 \ALUResOUT_reg[7]_i_2 
       (.CI(\ALUResOUT_reg[3]_i_2_n_0 ),
        .CO({\ALUResOUT_reg[7]_i_2_n_0 ,\ALUResOUT_reg[7]_i_2_n_1 ,\ALUResOUT_reg[7]_i_2_n_2 ,\ALUResOUT_reg[7]_i_2_n_3 }),
        .CYINIT(1'b0),
        .DI(\ALUResOUT_reg[15]_0 [7:4]),
        .O(data0[7:4]),
        .S({\ALUResOUT[7]_i_5_n_0 ,\ALUResOUT[7]_i_6_n_0 ,\ALUResOUT[7]_i_7_n_0 ,\ALUResOUT[7]_i_8_n_0 }));
  MUXF7 \ALUResOUT_reg[7]_i_3 
       (.I0(\ALUResOUT[7]_i_9_n_0 ),
        .I1(\ALUResOUT[7]_i_10_n_0 ),
        .O(\ex1/ALURes2__17 [7]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[8]_i_2 
       (.I0(\ALUResOUT[8]_i_4_n_0 ),
        .I1(\ALUResOUT[8]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [8]),
        .S(Ext_ImmOUT[2]));
  MUXF7 \ALUResOUT_reg[9]_i_2 
       (.I0(\ALUResOUT[9]_i_4_n_0 ),
        .I1(\ALUResOUT[9]_i_5_n_0 ),
        .O(\ex1/ALURes2__17 [9]),
        .S(Ext_ImmOUT[2]));
  FDRE #(
    .INIT(1'b0)) 
    ALUSrcOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[4]),
        .Q(ALUSrc),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    BranchOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[3]),
        .Q(Branch),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[0]),
        .Q(Ext_ImmOUT[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instructiune2_reg[14] ),
        .Q(Ext_ImmOUT[7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[1]),
        .Q(Ext_ImmOUT[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[2]),
        .Q(Ext_ImmOUT[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[3]),
        .Q(Ext_ImmOUT[3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[4]),
        .Q(Ext_ImmOUT[4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[5]),
        .Q(Ext_ImmOUT[5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \Ext_ImmOUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[6]),
        .Q(Ext_ImmOUT[6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RAOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[7]),
        .Q(RAOUT[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RAOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[8]),
        .Q(RAOUT[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RAOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(Q[9]),
        .Q(RAOUT[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[0]),
        .Q(\ALUResOUT_reg[15]_0 [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[10]),
        .Q(\ALUResOUT_reg[15]_0 [10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[11]),
        .Q(\ALUResOUT_reg[15]_0 [11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[12]),
        .Q(\ALUResOUT_reg[15]_0 [12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[13]),
        .Q(\ALUResOUT_reg[15]_0 [13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[14]),
        .Q(\ALUResOUT_reg[15]_0 [14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[15]),
        .Q(RD1OUT),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[1]),
        .Q(\ALUResOUT_reg[15]_0 [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[2]),
        .Q(\ALUResOUT_reg[15]_0 [2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[3]),
        .Q(\ALUResOUT_reg[15]_0 [3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[4]),
        .Q(\ALUResOUT_reg[15]_0 [4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[5]),
        .Q(\ALUResOUT_reg[15]_0 [5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[6]),
        .Q(\ALUResOUT_reg[15]_0 [6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[7]),
        .Q(\ALUResOUT_reg[15]_0 [7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[8]),
        .Q(\ALUResOUT_reg[15]_0 [8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD1OUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(RegWriteOUT_reg[9]),
        .Q(\ALUResOUT_reg[15]_0 [9]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[0]),
        .Q(\RD2OUT_reg[15]_0 [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[10]),
        .Q(\RD2OUT_reg[15]_0 [10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[11]),
        .Q(\RD2OUT_reg[15]_0 [11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[12]),
        .Q(\RD2OUT_reg[15]_0 [12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[13]),
        .Q(\RD2OUT_reg[15]_0 [13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[14]),
        .Q(\RD2OUT_reg[15]_0 [14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[15]),
        .Q(\RD2OUT_reg[15]_0 [15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[1]),
        .Q(\RD2OUT_reg[15]_0 [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[2]),
        .Q(\RD2OUT_reg[15]_0 [2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[3]),
        .Q(\RD2OUT_reg[15]_0 [3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[4]),
        .Q(\RD2OUT_reg[15]_0 [4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[5]),
        .Q(\RD2OUT_reg[15]_0 [5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[6]),
        .Q(\RD2OUT_reg[15]_0 [6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[7]),
        .Q(\RD2OUT_reg[15]_0 [7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[8]),
        .Q(\RD2OUT_reg[15]_0 [8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \RD2OUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[9]),
        .Q(\RD2OUT_reg[15]_0 [9]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    RegDstOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(led_OBUF[5]),
        .Q(RegDstOUT),
        .R(1'b0));
  LUT6 #(
    .INIT(64'h0000000000000001)) 
    Zero2_reg_i_1
       (.I0(Zero2_reg_i_3_n_0),
        .I1(sel0[15]),
        .I2(sel0[14]),
        .I3(sel0[12]),
        .I4(sel0[13]),
        .I5(Zero2_reg_i_4_n_0),
        .O(Zero2));
  (* SOFT_HLUTNM = "soft_lutpair3" *) 
  LUT3 #(
    .INIT(8'h02)) 
    Zero2_reg_i_2
       (.I0(ALUOpOUT[0]),
        .I1(ALUOpOUT[2]),
        .I2(ALUOpOUT[1]),
        .O(\pc_reg[1] ));
  LUT4 #(
    .INIT(16'hFFFE)) 
    Zero2_reg_i_3
       (.I0(sel0[10]),
        .I1(sel0[11]),
        .I2(sel0[8]),
        .I3(sel0[9]),
        .O(Zero2_reg_i_3_n_0));
  LUT5 #(
    .INIT(32'hFFFFFFFE)) 
    Zero2_reg_i_4
       (.I0(sel0[5]),
        .I1(sel0[4]),
        .I2(sel0[7]),
        .I3(sel0[6]),
        .I4(Zero2_reg_i_5_n_0),
        .O(Zero2_reg_i_4_n_0));
  LUT4 #(
    .INIT(16'hFFFE)) 
    Zero2_reg_i_5
       (.I0(sel0[2]),
        .I1(sel0[3]),
        .I2(sel0[0]),
        .I3(sel0[1]),
        .O(Zero2_reg_i_5_n_0));
  (* SOFT_HLUTNM = "soft_lutpair4" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \instrMUXOUT[0]_i_1 
       (.I0(Ext_ImmOUT[4]),
        .I1(RAOUT[0]),
        .I2(RegDstOUT),
        .O(\instrMUXOUT_reg[2] [0]));
  LUT3 #(
    .INIT(8'hAC)) 
    \instrMUXOUT[1]_i_1 
       (.I0(Ext_ImmOUT[5]),
        .I1(RAOUT[1]),
        .I2(RegDstOUT),
        .O(\instrMUXOUT_reg[2] [1]));
  (* SOFT_HLUTNM = "soft_lutpair7" *) 
  LUT3 #(
    .INIT(8'hAC)) 
    \instrMUXOUT[2]_i_1 
       (.I0(Ext_ImmOUT[6]),
        .I1(RAOUT[2]),
        .I2(RegDstOUT),
        .O(\instrMUXOUT_reg[2] [2]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__0_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [7]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [7]),
        .O(\ALUResOUT_reg[7] [3]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__0_i_2
       (.I0(Ext_ImmOUT[6]),
        .I1(\RD2OUT_reg[15]_0 [6]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [6]),
        .O(\ALUResOUT_reg[7] [2]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__0_i_3
       (.I0(Ext_ImmOUT[5]),
        .I1(\RD2OUT_reg[15]_0 [5]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [5]),
        .O(\ALUResOUT_reg[7] [1]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__0_i_4
       (.I0(Ext_ImmOUT[4]),
        .I1(\RD2OUT_reg[15]_0 [4]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [4]),
        .O(\ALUResOUT_reg[7] [0]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__1_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [11]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [11]),
        .O(\ALUResOUT_reg[11] [3]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__1_i_2
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [10]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [10]),
        .O(\ALUResOUT_reg[11] [2]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__1_i_3
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [9]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [9]),
        .O(\ALUResOUT_reg[11] [1]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__1_i_4
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [8]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [8]),
        .O(\ALUResOUT_reg[11] [0]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__2_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [15]),
        .I2(ALUSrc),
        .I3(RD1OUT),
        .O(\ALUResOUT_reg[15]_1 [3]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__2_i_2
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [14]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [14]),
        .O(\ALUResOUT_reg[15]_1 [2]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__2_i_3
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [13]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [13]),
        .O(\ALUResOUT_reg[15]_1 [1]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry__2_i_4
       (.I0(Ext_ImmOUT[7]),
        .I1(\RD2OUT_reg[15]_0 [12]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [12]),
        .O(\ALUResOUT_reg[15]_1 [0]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry_i_1
       (.I0(Ext_ImmOUT[3]),
        .I1(\RD2OUT_reg[15]_0 [3]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [3]),
        .O(\ALUResOUT_reg[3] [3]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry_i_2
       (.I0(Ext_ImmOUT[2]),
        .I1(\RD2OUT_reg[15]_0 [2]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [2]),
        .O(\ALUResOUT_reg[3] [2]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry_i_3
       (.I0(Ext_ImmOUT[1]),
        .I1(\RD2OUT_reg[15]_0 [1]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [1]),
        .O(\ALUResOUT_reg[3] [1]));
  LUT4 #(
    .INIT(16'hAC53)) 
    minusOp_carry_i_4
       (.I0(Ext_ImmOUT[0]),
        .I1(\RD2OUT_reg[15]_0 [0]),
        .I2(ALUSrc),
        .I3(\ALUResOUT_reg[15]_0 [0]),
        .O(\ALUResOUT_reg[3] [0]));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [0]),
        .Q(nxtInstructiuneOUT[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [10]),
        .Q(nxtInstructiuneOUT[10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [11]),
        .Q(nxtInstructiuneOUT[11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [12]),
        .Q(nxtInstructiuneOUT[12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [13]),
        .Q(nxtInstructiuneOUT[13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [14]),
        .Q(nxtInstructiuneOUT[14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [15]),
        .Q(nxtInstructiuneOUT[15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [1]),
        .Q(nxtInstructiuneOUT[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [2]),
        .Q(nxtInstructiuneOUT[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [3]),
        .Q(nxtInstructiuneOUT[3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [4]),
        .Q(nxtInstructiuneOUT[4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [5]),
        .Q(nxtInstructiuneOUT[5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [6]),
        .Q(nxtInstructiuneOUT[6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [7]),
        .Q(nxtInstructiuneOUT[7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [8]),
        .Q(nxtInstructiuneOUT[8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \nxtInstructiuneOUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\next_instr2_reg[15] [9]),
        .Q(nxtInstructiuneOUT[9]),
        .R(1'b0));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__0_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[7]),
        .O(\pc_reg[7] [3]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__0_i_2
       (.I0(Ext_ImmOUT[6]),
        .I1(nxtInstructiuneOUT[6]),
        .O(\pc_reg[7] [2]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__0_i_3
       (.I0(Ext_ImmOUT[5]),
        .I1(nxtInstructiuneOUT[5]),
        .O(\pc_reg[7] [1]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__0_i_4
       (.I0(Ext_ImmOUT[4]),
        .I1(nxtInstructiuneOUT[4]),
        .O(\pc_reg[7] [0]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__1_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[11]),
        .O(\pc_reg[11] [3]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__1_i_2
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[10]),
        .O(\pc_reg[11] [2]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__1_i_3
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[9]),
        .O(\pc_reg[11] [1]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__1_i_4
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[8]),
        .O(\pc_reg[11] [0]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__2_i_1
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[15]),
        .O(\pc_reg[15] [3]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__2_i_2
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[14]),
        .O(\pc_reg[15] [2]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__2_i_3
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[13]),
        .O(\pc_reg[15] [1]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry__2_i_4
       (.I0(Ext_ImmOUT[7]),
        .I1(nxtInstructiuneOUT[12]),
        .O(\pc_reg[15] [0]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry_i_1
       (.I0(Ext_ImmOUT[3]),
        .I1(nxtInstructiuneOUT[3]),
        .O(S[3]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry_i_2
       (.I0(Ext_ImmOUT[2]),
        .I1(nxtInstructiuneOUT[2]),
        .O(S[2]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry_i_3
       (.I0(Ext_ImmOUT[1]),
        .I1(nxtInstructiuneOUT[1]),
        .O(S[1]));
  LUT2 #(
    .INIT(4'h6)) 
    plusOp_carry_i_4
       (.I0(Ext_ImmOUT[0]),
        .I1(nxtInstructiuneOUT[0]),
        .O(S[0]));
endmodule

module IF_ID
   (led_OBUF,
    \Ext_ImmOUT_reg[11] ,
    Q,
    \nxtInstructiuneOUT_reg[15] ,
    D,
    clk_IBUF_BUFG,
    \pc_reg_rep[1] );
  output [10:0]led_OBUF;
  output \Ext_ImmOUT_reg[11] ;
  output [11:0]Q;
  output [15:0]\nxtInstructiuneOUT_reg[15] ;
  input [15:0]D;
  input clk_IBUF_BUFG;
  input [14:0]\pc_reg_rep[1] ;

  wire [15:0]D;
  wire \Ext_ImmOUT_reg[11] ;
  wire [11:0]Q;
  wire clk_IBUF_BUFG;
  wire [15:13]instructiune2;
  wire [10:0]led_OBUF;
  wire [15:0]\nxtInstructiuneOUT_reg[15] ;
  wire [14:0]\pc_reg_rep[1] ;

  (* SOFT_HLUTNM = "soft_lutpair12" *) 
  LUT4 #(
    .INIT(16'h7E00)) 
    \Ext_ImmOUT[11]_i_1 
       (.I0(instructiune2[14]),
        .I1(instructiune2[15]),
        .I2(instructiune2[13]),
        .I3(Q[6]),
        .O(\Ext_ImmOUT_reg[11] ));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [0]),
        .Q(Q[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [10]),
        .Q(Q[10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [11]),
        .Q(Q[11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [12]),
        .Q(instructiune2[13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [13]),
        .Q(instructiune2[14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [14]),
        .Q(instructiune2[15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [1]),
        .Q(Q[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [2]),
        .Q(Q[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [3]),
        .Q(Q[3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [4]),
        .Q(Q[4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [5]),
        .Q(Q[5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [6]),
        .Q(Q[6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [7]),
        .Q(Q[7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [8]),
        .Q(Q[8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instructiune2_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\pc_reg_rep[1] [9]),
        .Q(Q[9]),
        .R(1'b0));
  (* SOFT_HLUTNM = "soft_lutpair15" *) 
  LUT3 #(
    .INIT(8'h3D)) 
    \led_OBUF[0]_inst_i_1 
       (.I0(instructiune2[15]),
        .I1(instructiune2[14]),
        .I2(instructiune2[13]),
        .O(led_OBUF[0]));
  (* SOFT_HLUTNM = "soft_lutpair12" *) 
  LUT3 #(
    .INIT(8'h01)) 
    \led_OBUF[10]_inst_i_1 
       (.I0(instructiune2[14]),
        .I1(instructiune2[13]),
        .I2(instructiune2[15]),
        .O(led_OBUF[10]));
  (* SOFT_HLUTNM = "soft_lutpair16" *) 
  LUT3 #(
    .INIT(8'h02)) 
    \led_OBUF[1]_inst_i_1 
       (.I0(instructiune2[14]),
        .I1(instructiune2[13]),
        .I2(instructiune2[15]),
        .O(led_OBUF[1]));
  LUT3 #(
    .INIT(8'h40)) 
    \led_OBUF[2]_inst_i_1 
       (.I0(instructiune2[15]),
        .I1(instructiune2[13]),
        .I2(instructiune2[14]),
        .O(led_OBUF[2]));
  (* SOFT_HLUTNM = "soft_lutpair16" *) 
  LUT3 #(
    .INIT(8'h0E)) 
    \led_OBUF[3]_inst_i_1 
       (.I0(instructiune2[13]),
        .I1(instructiune2[15]),
        .I2(instructiune2[14]),
        .O(led_OBUF[3]));
  (* SOFT_HLUTNM = "soft_lutpair15" *) 
  LUT3 #(
    .INIT(8'h83)) 
    \led_OBUF[4]_inst_i_1 
       (.I0(instructiune2[13]),
        .I1(instructiune2[14]),
        .I2(instructiune2[15]),
        .O(led_OBUF[4]));
  LUT3 #(
    .INIT(8'hA8)) 
    \led_OBUF[5]_inst_i_1 
       (.I0(instructiune2[15]),
        .I1(instructiune2[13]),
        .I2(instructiune2[14]),
        .O(led_OBUF[5]));
  (* SOFT_HLUTNM = "soft_lutpair14" *) 
  LUT3 #(
    .INIT(8'h80)) 
    \led_OBUF[6]_inst_i_1 
       (.I0(instructiune2[14]),
        .I1(instructiune2[13]),
        .I2(instructiune2[15]),
        .O(led_OBUF[6]));
  (* SOFT_HLUTNM = "soft_lutpair14" *) 
  LUT3 #(
    .INIT(8'h02)) 
    \led_OBUF[7]_inst_i_1 
       (.I0(instructiune2[15]),
        .I1(instructiune2[13]),
        .I2(instructiune2[14]),
        .O(led_OBUF[7]));
  (* SOFT_HLUTNM = "soft_lutpair13" *) 
  LUT3 #(
    .INIT(8'h7C)) 
    \led_OBUF[8]_inst_i_1 
       (.I0(instructiune2[15]),
        .I1(instructiune2[14]),
        .I2(instructiune2[13]),
        .O(led_OBUF[8]));
  (* SOFT_HLUTNM = "soft_lutpair13" *) 
  LUT3 #(
    .INIT(8'h7E)) 
    \led_OBUF[9]_inst_i_1 
       (.I0(instructiune2[13]),
        .I1(instructiune2[15]),
        .I2(instructiune2[14]),
        .O(led_OBUF[9]));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[0]),
        .Q(\nxtInstructiuneOUT_reg[15] [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[10]),
        .Q(\nxtInstructiuneOUT_reg[15] [10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[11]),
        .Q(\nxtInstructiuneOUT_reg[15] [11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[12]),
        .Q(\nxtInstructiuneOUT_reg[15] [12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[13]),
        .Q(\nxtInstructiuneOUT_reg[15] [13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[14]),
        .Q(\nxtInstructiuneOUT_reg[15] [14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[15]),
        .Q(\nxtInstructiuneOUT_reg[15] [15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[1]),
        .Q(\nxtInstructiuneOUT_reg[15] [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[2]),
        .Q(\nxtInstructiuneOUT_reg[15] [2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[3]),
        .Q(\nxtInstructiuneOUT_reg[15] [3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[4]),
        .Q(\nxtInstructiuneOUT_reg[15] [4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[5]),
        .Q(\nxtInstructiuneOUT_reg[15] [5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[6]),
        .Q(\nxtInstructiuneOUT_reg[15] [6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[7]),
        .Q(\nxtInstructiuneOUT_reg[15] [7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[8]),
        .Q(\nxtInstructiuneOUT_reg[15] [8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \next_instr2_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[9]),
        .Q(\nxtInstructiuneOUT_reg[15] [9]),
        .R(1'b0));
endmodule

module InstrFetch
   (D,
    Q,
    \instructiune2_reg[15] ,
    BranchAdr,
    Zero,
    branch3,
    led_OBUF,
    BranchOUT_reg,
    E,
    clk_IBUF_BUFG,
    AR);
  output [15:0]D;
  output [0:0]Q;
  output [14:0]\instructiune2_reg[15] ;
  input [11:0]BranchAdr;
  input Zero;
  input branch3;
  input [0:0]led_OBUF;
  input [3:0]BranchOUT_reg;
  input [0:0]E;
  input clk_IBUF_BUFG;
  input [0:0]AR;

  wire [0:0]AR;
  wire [11:0]BranchAdr;
  wire [3:0]BranchOUT_reg;
  wire [15:0]D;
  wire [0:0]E;
  wire [0:0]Q;
  wire Zero;
  wire branch3;
  wire clk_IBUF_BUFG;
  wire \instructiune2[15]_i_2_n_0 ;
  wire [14:0]\instructiune2_reg[15] ;
  wire [0:0]led_OBUF;
  wire [11:8]mux2;
  wire [7:0]mux2_0;
  wire [15:1]pc;
  wire [7:0]pc_reg_rep;
  wire plusOp_carry__0_i_1__0_n_0;
  wire plusOp_carry__0_i_2__0_n_0;
  wire plusOp_carry__0_i_3__0_n_0;
  wire plusOp_carry__0_i_4__0_n_0;
  wire plusOp_carry__0_n_0;
  wire plusOp_carry__0_n_1;
  wire plusOp_carry__0_n_2;
  wire plusOp_carry__0_n_3;
  wire plusOp_carry__1_i_1__0_n_0;
  wire plusOp_carry__1_i_2__0_n_0;
  wire plusOp_carry__1_i_3__0_n_0;
  wire plusOp_carry__1_i_4__0_n_0;
  wire plusOp_carry__1_n_0;
  wire plusOp_carry__1_n_1;
  wire plusOp_carry__1_n_2;
  wire plusOp_carry__1_n_3;
  wire plusOp_carry__2_i_1__0_n_0;
  wire plusOp_carry__2_i_2__0_n_0;
  wire plusOp_carry__2_i_3__0_n_0;
  wire plusOp_carry__2_n_2;
  wire plusOp_carry__2_n_3;
  wire plusOp_carry_i_1__0_n_0;
  wire plusOp_carry_i_2__0_n_0;
  wire plusOp_carry_i_3__0_n_0;
  wire plusOp_carry_i_4__0_n_0;
  wire plusOp_carry_n_0;
  wire plusOp_carry_n_1;
  wire plusOp_carry_n_2;
  wire plusOp_carry_n_3;
  wire [3:2]NLW_plusOp_carry__2_CO_UNCONNECTED;
  wire [3:3]NLW_plusOp_carry__2_O_UNCONNECTED;

  LUT6 #(
    .INIT(64'h0000120000004000)) 
    \instructiune2[0]_i_1 
       (.I0(pc_reg_rep[4]),
        .I1(pc_reg_rep[3]),
        .I2(pc_reg_rep[1]),
        .I3(\instructiune2[15]_i_2_n_0 ),
        .I4(pc_reg_rep[0]),
        .I5(pc_reg_rep[2]),
        .O(\instructiune2_reg[15] [0]));
  LUT6 #(
    .INIT(64'h0000080000200000)) 
    \instructiune2[10]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[1]),
        .I2(pc_reg_rep[4]),
        .I3(pc_reg_rep[3]),
        .I4(pc_reg_rep[2]),
        .I5(pc_reg_rep[0]),
        .O(\instructiune2_reg[15] [10]));
  LUT6 #(
    .INIT(64'h0008080000000400)) 
    \instructiune2[11]_i_1 
       (.I0(pc_reg_rep[3]),
        .I1(\instructiune2[15]_i_2_n_0 ),
        .I2(pc_reg_rep[2]),
        .I3(pc_reg_rep[4]),
        .I4(pc_reg_rep[0]),
        .I5(pc_reg_rep[1]),
        .O(\instructiune2_reg[15] [11]));
  LUT6 #(
    .INIT(64'h0220000000002802)) 
    \instructiune2[13]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[2]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[1]),
        .I4(pc_reg_rep[4]),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [12]));
  LUT6 #(
    .INIT(64'h0028000002000008)) 
    \instructiune2[14]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[1]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[2]),
        .I4(pc_reg_rep[4]),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [13]));
  LUT6 #(
    .INIT(64'h0020000802000000)) 
    \instructiune2[15]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[1]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[2]),
        .I4(pc_reg_rep[4]),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [14]));
  LUT3 #(
    .INIT(8'h01)) 
    \instructiune2[15]_i_2 
       (.I0(pc_reg_rep[7]),
        .I1(pc_reg_rep[6]),
        .I2(pc_reg_rep[5]),
        .O(\instructiune2[15]_i_2_n_0 ));
  LUT6 #(
    .INIT(64'h0CCC0C8404044C04)) 
    \instructiune2[1]_i_1 
       (.I0(pc_reg_rep[1]),
        .I1(\instructiune2[15]_i_2_n_0 ),
        .I2(pc_reg_rep[4]),
        .I3(pc_reg_rep[3]),
        .I4(pc_reg_rep[0]),
        .I5(pc_reg_rep[2]),
        .O(\instructiune2_reg[15] [1]));
  LUT6 #(
    .INIT(64'h000A008000000000)) 
    \instructiune2[2]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[4]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[2]),
        .I4(pc_reg_rep[1]),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [2]));
  LUT6 #(
    .INIT(64'h0002000000000002)) 
    \instructiune2[3]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[2]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[4]),
        .I4(pc_reg_rep[3]),
        .I5(pc_reg_rep[1]),
        .O(\instructiune2_reg[15] [3]));
  LUT6 #(
    .INIT(64'h0008000800800000)) 
    \instructiune2[4]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[1]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[2]),
        .I4(pc_reg_rep[3]),
        .I5(pc_reg_rep[4]),
        .O(\instructiune2_reg[15] [4]));
  LUT6 #(
    .INIT(64'h0000004000004040)) 
    \instructiune2[5]_i_1 
       (.I0(pc_reg_rep[3]),
        .I1(pc_reg_rep[4]),
        .I2(\instructiune2[15]_i_2_n_0 ),
        .I3(pc_reg_rep[0]),
        .I4(pc_reg_rep[2]),
        .I5(pc_reg_rep[1]),
        .O(\instructiune2_reg[15] [5]));
  LUT6 #(
    .INIT(64'h0200000008000008)) 
    \instructiune2[6]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[4]),
        .I2(pc_reg_rep[2]),
        .I3(pc_reg_rep[0]),
        .I4(pc_reg_rep[1]),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [6]));
  LUT6 #(
    .INIT(64'h0000002010204030)) 
    \instructiune2[7]_i_1 
       (.I0(pc_reg_rep[4]),
        .I1(pc_reg_rep[3]),
        .I2(\instructiune2[15]_i_2_n_0 ),
        .I3(pc_reg_rep[1]),
        .I4(pc_reg_rep[0]),
        .I5(pc_reg_rep[2]),
        .O(\instructiune2_reg[15] [7]));
  LUT6 #(
    .INIT(64'h0200202000002200)) 
    \instructiune2[8]_i_1 
       (.I0(\instructiune2[15]_i_2_n_0 ),
        .I1(pc_reg_rep[2]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[1]),
        .I4(pc_reg_rep[3]),
        .I5(pc_reg_rep[4]),
        .O(\instructiune2_reg[15] [8]));
  LUT6 #(
    .INIT(64'h1200000026020000)) 
    \instructiune2[9]_i_1 
       (.I0(pc_reg_rep[4]),
        .I1(pc_reg_rep[2]),
        .I2(pc_reg_rep[0]),
        .I3(pc_reg_rep[1]),
        .I4(\instructiune2[15]_i_2_n_0 ),
        .I5(pc_reg_rep[3]),
        .O(\instructiune2_reg[15] [9]));
  LUT1 #(
    .INIT(2'h1)) 
    \next_instr2[0]_i_1 
       (.I0(Q),
        .O(D[0]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc[10]_i_1 
       (.I0(\instructiune2_reg[15] [10]),
        .I1(BranchAdr[10]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[10]),
        .I5(led_OBUF),
        .O(mux2[10]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc[11]_i_1 
       (.I0(\instructiune2_reg[15] [11]),
        .I1(BranchAdr[11]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[11]),
        .I5(led_OBUF),
        .O(mux2[11]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc[8]_i_1 
       (.I0(\instructiune2_reg[15] [8]),
        .I1(BranchAdr[8]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[8]),
        .I5(led_OBUF),
        .O(mux2[8]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc[9]_i_1 
       (.I0(\instructiune2_reg[15] [9]),
        .I1(BranchAdr[9]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[9]),
        .I5(led_OBUF),
        .O(mux2[9]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[0]),
        .Q(Q));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2[10]),
        .Q(pc[10]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2[11]),
        .Q(pc[11]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(BranchOUT_reg[0]),
        .Q(pc[12]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(BranchOUT_reg[1]),
        .Q(pc[13]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(BranchOUT_reg[2]),
        .Q(pc[14]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(BranchOUT_reg[3]),
        .Q(pc[15]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[1]),
        .Q(pc[1]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[2]),
        .Q(pc[2]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[3]),
        .Q(pc[3]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[4]),
        .Q(pc[4]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[5]),
        .Q(pc[5]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[6]),
        .Q(pc[6]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[7]),
        .Q(pc[7]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2[8]),
        .Q(pc[8]));
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2[9]),
        .Q(pc[9]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[0] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[0]),
        .Q(pc_reg_rep[0]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[1] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[1]),
        .Q(pc_reg_rep[1]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[2] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[2]),
        .Q(pc_reg_rep[2]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[3] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[3]),
        .Q(pc_reg_rep[3]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[4] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[4]),
        .Q(pc_reg_rep[4]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[5] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[5]),
        .Q(pc_reg_rep[5]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[6] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[6]),
        .Q(pc_reg_rep[6]));
  (* equivalent_register_removal = "no" *) 
  FDCE #(
    .INIT(1'b0)) 
    \pc_reg_rep[7] 
       (.C(clk_IBUF_BUFG),
        .CE(E),
        .CLR(AR),
        .D(mux2_0[7]),
        .Q(pc_reg_rep[7]));
  LUT6 #(
    .INIT(64'hAAAAAAAAC000CFFF)) 
    \pc_rep[0]_i_1 
       (.I0(\instructiune2_reg[15] [0]),
        .I1(BranchAdr[0]),
        .I2(Zero),
        .I3(branch3),
        .I4(Q),
        .I5(led_OBUF),
        .O(mux2_0[0]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[1]_i_1 
       (.I0(\instructiune2_reg[15] [1]),
        .I1(BranchAdr[1]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[1]),
        .I5(led_OBUF),
        .O(mux2_0[1]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[2]_i_1 
       (.I0(\instructiune2_reg[15] [2]),
        .I1(BranchAdr[2]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[2]),
        .I5(led_OBUF),
        .O(mux2_0[2]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[3]_i_1 
       (.I0(\instructiune2_reg[15] [3]),
        .I1(BranchAdr[3]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[3]),
        .I5(led_OBUF),
        .O(mux2_0[3]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[4]_i_1 
       (.I0(\instructiune2_reg[15] [4]),
        .I1(BranchAdr[4]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[4]),
        .I5(led_OBUF),
        .O(mux2_0[4]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[5]_i_1 
       (.I0(\instructiune2_reg[15] [5]),
        .I1(BranchAdr[5]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[5]),
        .I5(led_OBUF),
        .O(mux2_0[5]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[6]_i_1 
       (.I0(\instructiune2_reg[15] [6]),
        .I1(BranchAdr[6]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[6]),
        .I5(led_OBUF),
        .O(mux2_0[6]));
  LUT6 #(
    .INIT(64'hAAAAAAAACFFFC000)) 
    \pc_rep[7]_i_2 
       (.I0(\instructiune2_reg[15] [7]),
        .I1(BranchAdr[7]),
        .I2(Zero),
        .I3(branch3),
        .I4(D[7]),
        .I5(led_OBUF),
        .O(mux2_0[7]));
  CARRY4 plusOp_carry
       (.CI(1'b0),
        .CO({plusOp_carry_n_0,plusOp_carry_n_1,plusOp_carry_n_2,plusOp_carry_n_3}),
        .CYINIT(Q),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O(D[4:1]),
        .S({plusOp_carry_i_1__0_n_0,plusOp_carry_i_2__0_n_0,plusOp_carry_i_3__0_n_0,plusOp_carry_i_4__0_n_0}));
  CARRY4 plusOp_carry__0
       (.CI(plusOp_carry_n_0),
        .CO({plusOp_carry__0_n_0,plusOp_carry__0_n_1,plusOp_carry__0_n_2,plusOp_carry__0_n_3}),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O(D[8:5]),
        .S({plusOp_carry__0_i_1__0_n_0,plusOp_carry__0_i_2__0_n_0,plusOp_carry__0_i_3__0_n_0,plusOp_carry__0_i_4__0_n_0}));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__0_i_1__0
       (.I0(pc[8]),
        .O(plusOp_carry__0_i_1__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__0_i_2__0
       (.I0(pc[7]),
        .O(plusOp_carry__0_i_2__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__0_i_3__0
       (.I0(pc[6]),
        .O(plusOp_carry__0_i_3__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__0_i_4__0
       (.I0(pc[5]),
        .O(plusOp_carry__0_i_4__0_n_0));
  CARRY4 plusOp_carry__1
       (.CI(plusOp_carry__0_n_0),
        .CO({plusOp_carry__1_n_0,plusOp_carry__1_n_1,plusOp_carry__1_n_2,plusOp_carry__1_n_3}),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O(D[12:9]),
        .S({plusOp_carry__1_i_1__0_n_0,plusOp_carry__1_i_2__0_n_0,plusOp_carry__1_i_3__0_n_0,plusOp_carry__1_i_4__0_n_0}));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__1_i_1__0
       (.I0(pc[12]),
        .O(plusOp_carry__1_i_1__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__1_i_2__0
       (.I0(pc[11]),
        .O(plusOp_carry__1_i_2__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__1_i_3__0
       (.I0(pc[10]),
        .O(plusOp_carry__1_i_3__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__1_i_4__0
       (.I0(pc[9]),
        .O(plusOp_carry__1_i_4__0_n_0));
  CARRY4 plusOp_carry__2
       (.CI(plusOp_carry__1_n_0),
        .CO({NLW_plusOp_carry__2_CO_UNCONNECTED[3:2],plusOp_carry__2_n_2,plusOp_carry__2_n_3}),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O({NLW_plusOp_carry__2_O_UNCONNECTED[3],D[15:13]}),
        .S({1'b0,plusOp_carry__2_i_1__0_n_0,plusOp_carry__2_i_2__0_n_0,plusOp_carry__2_i_3__0_n_0}));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__2_i_1__0
       (.I0(pc[15]),
        .O(plusOp_carry__2_i_1__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__2_i_2__0
       (.I0(pc[14]),
        .O(plusOp_carry__2_i_2__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry__2_i_3__0
       (.I0(pc[13]),
        .O(plusOp_carry__2_i_3__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry_i_1__0
       (.I0(pc[4]),
        .O(plusOp_carry_i_1__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry_i_2__0
       (.I0(pc[3]),
        .O(plusOp_carry_i_2__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry_i_3__0
       (.I0(pc[2]),
        .O(plusOp_carry_i_3__0_n_0));
  LUT1 #(
    .INIT(2'h2)) 
    plusOp_carry_i_4__0
       (.I0(pc[1]),
        .O(plusOp_carry_i_4__0_n_0));
endmodule

module MEM
   (MemData,
    clk_IBUF_BUFG,
    RD2,
    led_OBUF,
    \ALUOpOUT_reg[0] );
  output [15:0]MemData;
  input clk_IBUF_BUFG;
  input [15:0]RD2;
  input [0:0]led_OBUF;
  input [7:0]\ALUOpOUT_reg[0] ;

  wire [7:0]\ALUOpOUT_reg[0] ;
  wire [15:0]MemData;
  wire [15:0]RD2;
  wire clk_IBUF_BUFG;
  wire [0:0]led_OBUF;

  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_0_0
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[0]),
        .O(MemData[0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_10_10
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[10]),
        .O(MemData[10]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_11_11
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[11]),
        .O(MemData[11]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_12_12
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[12]),
        .O(MemData[12]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_13_13
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[13]),
        .O(MemData[13]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_14_14
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[14]),
        .O(MemData[14]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_15_15
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[15]),
        .O(MemData[15]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_1_1
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[1]),
        .O(MemData[1]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_2_2
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[2]),
        .O(MemData[2]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_3_3
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[3]),
        .O(MemData[3]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_4_4
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[4]),
        .O(MemData[4]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_5_5
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[5]),
        .O(MemData[5]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_6_6
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[6]),
        .O(MemData[6]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_7_7
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[7]),
        .O(MemData[7]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_8_8
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[8]),
        .O(MemData[8]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
  RAM256X1S #(
    .INIT(256'h0000000000000000000000000000000000000000000000000000000000000001)) 
    matrice_reg_0_255_9_9
       (.A(\ALUOpOUT_reg[0] ),
        .D(RD2[9]),
        .O(MemData[9]),
        .WCLK(clk_IBUF_BUFG),
        .WE(led_OBUF));
endmodule

module MEM_WB
   (RegWriteOUT,
    \cat[1] ,
    WD,
    \cat[1]_0 ,
    \cat[1]_1 ,
    \cat[1]_2 ,
    \cat[1]_3 ,
    \cat[1]_4 ,
    \cat[1]_5 ,
    \cat[1]_6 ,
    \cat[1]_7 ,
    \cat[1]_8 ,
    \cat[1]_9 ,
    \cat[1]_10 ,
    \cat[1]_11 ,
    \cat[1]_12 ,
    \cat[1]_13 ,
    \cat[1]_14 ,
    \RD1OUT_reg[1] ,
    \instructiune2_reg[14] ,
    clk_IBUF_BUFG,
    \instructiune2_reg[15] ,
    MemData,
    sw_IBUF,
    \ALUOpOUT_reg[0] ,
    Q,
    \instructiune2_reg[14]_0 ,
    D,
    \instrMUXOUT_reg[2]_0 );
  output RegWriteOUT;
  output \cat[1] ;
  output [15:0]WD;
  output \cat[1]_0 ;
  output \cat[1]_1 ;
  output \cat[1]_2 ;
  output \cat[1]_3 ;
  output \cat[1]_4 ;
  output \cat[1]_5 ;
  output \cat[1]_6 ;
  output \cat[1]_7 ;
  output \cat[1]_8 ;
  output \cat[1]_9 ;
  output \cat[1]_10 ;
  output \cat[1]_11 ;
  output \cat[1]_12 ;
  output \cat[1]_13 ;
  output \cat[1]_14 ;
  output [2:0]\RD1OUT_reg[1] ;
  input \instructiune2_reg[14] ;
  input clk_IBUF_BUFG;
  input \instructiune2_reg[15] ;
  input [15:0]MemData;
  input [1:0]sw_IBUF;
  input [15:0]\ALUOpOUT_reg[0] ;
  input [6:0]Q;
  input \instructiune2_reg[14]_0 ;
  input [15:0]D;
  input [2:0]\instrMUXOUT_reg[2]_0 ;

  wire [15:0]\ALUOpOUT_reg[0] ;
  wire [15:0]ALUResOUT;
  wire [15:0]D;
  wire [15:0]MemData;
  wire MemToRegOUT_reg_n_0;
  wire [6:0]Q;
  wire [2:0]\RD1OUT_reg[1] ;
  wire RegWriteOUT;
  wire [15:0]WD;
  wire \cat[1] ;
  wire \cat[1]_0 ;
  wire \cat[1]_1 ;
  wire \cat[1]_10 ;
  wire \cat[1]_11 ;
  wire \cat[1]_12 ;
  wire \cat[1]_13 ;
  wire \cat[1]_14 ;
  wire \cat[1]_2 ;
  wire \cat[1]_3 ;
  wire \cat[1]_4 ;
  wire \cat[1]_5 ;
  wire \cat[1]_6 ;
  wire \cat[1]_7 ;
  wire \cat[1]_8 ;
  wire \cat[1]_9 ;
  wire clk_IBUF_BUFG;
  wire [2:0]\instrMUXOUT_reg[2]_0 ;
  wire \instructiune2_reg[14] ;
  wire \instructiune2_reg[14]_0 ;
  wire \instructiune2_reg[15] ;
  wire [1:0]sw_IBUF;

  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[0]),
        .Q(ALUResOUT[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[10]),
        .Q(ALUResOUT[10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[11]),
        .Q(ALUResOUT[11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[12]),
        .Q(ALUResOUT[12]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[13]),
        .Q(ALUResOUT[13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[14]),
        .Q(ALUResOUT[14]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[15]),
        .Q(ALUResOUT[15]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[1]),
        .Q(ALUResOUT[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[2]),
        .Q(ALUResOUT[2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[3]),
        .Q(ALUResOUT[3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[4]),
        .Q(ALUResOUT[4]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[5]),
        .Q(ALUResOUT[5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[6]),
        .Q(ALUResOUT[6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[7]),
        .Q(ALUResOUT[7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[8]),
        .Q(ALUResOUT[8]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \ALUResOUT_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(D[9]),
        .Q(ALUResOUT[9]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    MemToRegOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instructiune2_reg[14] ),
        .Q(MemToRegOUT_reg_n_0),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    RegWriteOUT_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instructiune2_reg[15] ),
        .Q(RegWriteOUT),
        .R(1'b0));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_23 
       (.I0(WD[15]),
        .I1(MemData[15]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [15]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_14 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_25 
       (.I0(WD[7]),
        .I1(MemData[7]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [7]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_7 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_27 
       (.I0(WD[11]),
        .I1(MemData[11]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [11]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_3 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_29 
       (.I0(WD[3]),
        .I1(MemData[3]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [3]),
        .I4(sw_IBUF[0]),
        .I5(Q[3]),
        .O(\cat[1] ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_31 
       (.I0(WD[12]),
        .I1(MemData[12]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [12]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_13 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_33 
       (.I0(WD[4]),
        .I1(MemData[4]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [4]),
        .I4(sw_IBUF[0]),
        .I5(Q[4]),
        .O(\cat[1]_10 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_35 
       (.I0(WD[8]),
        .I1(MemData[8]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [8]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_6 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_37 
       (.I0(WD[0]),
        .I1(MemData[0]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [0]),
        .I4(sw_IBUF[0]),
        .I5(Q[0]),
        .O(\cat[1]_2 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_39 
       (.I0(WD[14]),
        .I1(MemData[14]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [14]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_11 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_41 
       (.I0(WD[6]),
        .I1(MemData[6]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [6]),
        .I4(sw_IBUF[0]),
        .I5(Q[6]),
        .O(\cat[1]_8 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_43 
       (.I0(WD[10]),
        .I1(MemData[10]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [10]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_4 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_45 
       (.I0(WD[2]),
        .I1(MemData[2]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [2]),
        .I4(sw_IBUF[0]),
        .I5(Q[2]),
        .O(\cat[1]_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_47 
       (.I0(WD[13]),
        .I1(MemData[13]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [13]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_12 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_49 
       (.I0(WD[5]),
        .I1(MemData[5]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [5]),
        .I4(sw_IBUF[0]),
        .I5(Q[5]),
        .O(\cat[1]_9 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_51 
       (.I0(WD[9]),
        .I1(MemData[9]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [9]),
        .I4(sw_IBUF[0]),
        .I5(\instructiune2_reg[14]_0 ),
        .O(\cat[1]_5 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_53 
       (.I0(WD[1]),
        .I1(MemData[1]),
        .I2(sw_IBUF[1]),
        .I3(\ALUOpOUT_reg[0] [1]),
        .I4(sw_IBUF[0]),
        .I5(Q[1]),
        .O(\cat[1]_1 ));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instrMUXOUT_reg[2]_0 [0]),
        .Q(\RD1OUT_reg[1] [0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instrMUXOUT_reg[2]_0 [1]),
        .Q(\RD1OUT_reg[1] [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \instrMUXOUT_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\instrMUXOUT_reg[2]_0 [2]),
        .Q(\RD1OUT_reg[1] [2]),
        .R(1'b0));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_1
       (.I0(MemData[1]),
        .I1(ALUResOUT[1]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[1]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_2
       (.I0(MemData[0]),
        .I1(ALUResOUT[0]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[0]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_3
       (.I0(MemData[3]),
        .I1(ALUResOUT[3]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[3]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_4
       (.I0(MemData[2]),
        .I1(ALUResOUT[2]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[2]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_5
       (.I0(MemData[5]),
        .I1(ALUResOUT[5]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[5]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_0_5_i_6
       (.I0(MemData[4]),
        .I1(ALUResOUT[4]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[4]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_12_15_i_1
       (.I0(MemData[13]),
        .I1(ALUResOUT[13]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[13]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_12_15_i_2
       (.I0(MemData[12]),
        .I1(ALUResOUT[12]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[12]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_12_15_i_3
       (.I0(MemData[15]),
        .I1(ALUResOUT[15]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[15]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_12_15_i_4
       (.I0(MemData[14]),
        .I1(ALUResOUT[14]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[14]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_1
       (.I0(MemData[7]),
        .I1(ALUResOUT[7]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[7]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_2
       (.I0(MemData[6]),
        .I1(ALUResOUT[6]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[6]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_3
       (.I0(MemData[9]),
        .I1(ALUResOUT[9]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[9]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_4
       (.I0(MemData[8]),
        .I1(ALUResOUT[8]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[8]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_5
       (.I0(MemData[11]),
        .I1(ALUResOUT[11]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[11]));
  LUT3 #(
    .INIT(8'hAC)) 
    matrice_reg_r1_0_7_6_11_i_6
       (.I0(MemData[10]),
        .I1(ALUResOUT[10]),
        .I2(MemToRegOUT_reg_n_0),
        .O(WD[10]));
endmodule

module MonoPulseGenerator
   (en1,
    p_0_in,
    an_OBUF,
    E,
    btn_IBUF,
    clk_IBUF_BUFG);
  output en1;
  output [1:0]p_0_in;
  output [3:0]an_OBUF;
  output [0:0]E;
  input [0:0]btn_IBUF;
  input clk_IBUF_BUFG;

  wire [0:0]E;
  wire [3:0]an_OBUF;
  wire [0:0]btn_IBUF;
  wire clk_IBUF_BUFG;
  wire \counter2[0]_i_2_n_0 ;
  wire \counter2[0]_i_3_n_0 ;
  wire \counter2[0]_i_4_n_0 ;
  wire \counter2[0]_i_5_n_0 ;
  wire \counter2[12]_i_2_n_0 ;
  wire \counter2[12]_i_3_n_0 ;
  wire \counter2[12]_i_4_n_0 ;
  wire \counter2[12]_i_5_n_0 ;
  wire \counter2[4]_i_2_n_0 ;
  wire \counter2[4]_i_3_n_0 ;
  wire \counter2[4]_i_4_n_0 ;
  wire \counter2[4]_i_5_n_0 ;
  wire \counter2[8]_i_2_n_0 ;
  wire \counter2[8]_i_3_n_0 ;
  wire \counter2[8]_i_4_n_0 ;
  wire \counter2[8]_i_5_n_0 ;
  wire \counter2_reg[0]_i_1_n_0 ;
  wire \counter2_reg[0]_i_1_n_1 ;
  wire \counter2_reg[0]_i_1_n_2 ;
  wire \counter2_reg[0]_i_1_n_3 ;
  wire \counter2_reg[0]_i_1_n_4 ;
  wire \counter2_reg[0]_i_1_n_5 ;
  wire \counter2_reg[0]_i_1_n_6 ;
  wire \counter2_reg[0]_i_1_n_7 ;
  wire \counter2_reg[12]_i_1_n_1 ;
  wire \counter2_reg[12]_i_1_n_2 ;
  wire \counter2_reg[12]_i_1_n_3 ;
  wire \counter2_reg[12]_i_1_n_4 ;
  wire \counter2_reg[12]_i_1_n_5 ;
  wire \counter2_reg[12]_i_1_n_6 ;
  wire \counter2_reg[12]_i_1_n_7 ;
  wire \counter2_reg[4]_i_1_n_0 ;
  wire \counter2_reg[4]_i_1_n_1 ;
  wire \counter2_reg[4]_i_1_n_2 ;
  wire \counter2_reg[4]_i_1_n_3 ;
  wire \counter2_reg[4]_i_1_n_4 ;
  wire \counter2_reg[4]_i_1_n_5 ;
  wire \counter2_reg[4]_i_1_n_6 ;
  wire \counter2_reg[4]_i_1_n_7 ;
  wire \counter2_reg[8]_i_1_n_0 ;
  wire \counter2_reg[8]_i_1_n_1 ;
  wire \counter2_reg[8]_i_1_n_2 ;
  wire \counter2_reg[8]_i_1_n_3 ;
  wire \counter2_reg[8]_i_1_n_4 ;
  wire \counter2_reg[8]_i_1_n_5 ;
  wire \counter2_reg[8]_i_1_n_6 ;
  wire \counter2_reg[8]_i_1_n_7 ;
  wire en1;
  wire [1:0]p_0_in;
  wire reg1;
  wire reg1_i_2_n_0;
  wire reg1_i_3_n_0;
  wire reg1_i_4_n_0;
  wire reg2;
  wire reg3;
  wire [13:0]\ssd1/counter16_reg ;
  wire [3:3]\NLW_counter2_reg[12]_i_1_CO_UNCONNECTED ;

  (* SOFT_HLUTNM = "soft_lutpair17" *) 
  LUT2 #(
    .INIT(4'hE)) 
    \an_OBUF[0]_inst_i_1 
       (.I0(p_0_in[0]),
        .I1(p_0_in[1]),
        .O(an_OBUF[0]));
  (* SOFT_HLUTNM = "soft_lutpair18" *) 
  LUT2 #(
    .INIT(4'hB)) 
    \an_OBUF[1]_inst_i_1 
       (.I0(p_0_in[1]),
        .I1(p_0_in[0]),
        .O(an_OBUF[1]));
  (* SOFT_HLUTNM = "soft_lutpair18" *) 
  LUT2 #(
    .INIT(4'hB)) 
    \an_OBUF[2]_inst_i_1 
       (.I0(p_0_in[0]),
        .I1(p_0_in[1]),
        .O(an_OBUF[2]));
  (* SOFT_HLUTNM = "soft_lutpair17" *) 
  LUT2 #(
    .INIT(4'h7)) 
    \an_OBUF[3]_inst_i_1 
       (.I0(p_0_in[0]),
        .I1(p_0_in[1]),
        .O(an_OBUF[3]));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[0]_i_2 
       (.I0(\ssd1/counter16_reg [3]),
        .O(\counter2[0]_i_2_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[0]_i_3 
       (.I0(\ssd1/counter16_reg [2]),
        .O(\counter2[0]_i_3_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[0]_i_4 
       (.I0(\ssd1/counter16_reg [1]),
        .O(\counter2[0]_i_4_n_0 ));
  LUT1 #(
    .INIT(2'h1)) 
    \counter2[0]_i_5 
       (.I0(\ssd1/counter16_reg [0]),
        .O(\counter2[0]_i_5_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[12]_i_2 
       (.I0(p_0_in[1]),
        .O(\counter2[12]_i_2_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[12]_i_3 
       (.I0(p_0_in[0]),
        .O(\counter2[12]_i_3_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[12]_i_4 
       (.I0(\ssd1/counter16_reg [13]),
        .O(\counter2[12]_i_4_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[12]_i_5 
       (.I0(\ssd1/counter16_reg [12]),
        .O(\counter2[12]_i_5_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[4]_i_2 
       (.I0(\ssd1/counter16_reg [7]),
        .O(\counter2[4]_i_2_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[4]_i_3 
       (.I0(\ssd1/counter16_reg [6]),
        .O(\counter2[4]_i_3_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[4]_i_4 
       (.I0(\ssd1/counter16_reg [5]),
        .O(\counter2[4]_i_4_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[4]_i_5 
       (.I0(\ssd1/counter16_reg [4]),
        .O(\counter2[4]_i_5_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[8]_i_2 
       (.I0(\ssd1/counter16_reg [11]),
        .O(\counter2[8]_i_2_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[8]_i_3 
       (.I0(\ssd1/counter16_reg [10]),
        .O(\counter2[8]_i_3_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[8]_i_4 
       (.I0(\ssd1/counter16_reg [9]),
        .O(\counter2[8]_i_4_n_0 ));
  LUT1 #(
    .INIT(2'h2)) 
    \counter2[8]_i_5 
       (.I0(\ssd1/counter16_reg [8]),
        .O(\counter2[8]_i_5_n_0 ));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[0] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[0]_i_1_n_7 ),
        .Q(\ssd1/counter16_reg [0]),
        .R(1'b0));
  CARRY4 \counter2_reg[0]_i_1 
       (.CI(1'b0),
        .CO({\counter2_reg[0]_i_1_n_0 ,\counter2_reg[0]_i_1_n_1 ,\counter2_reg[0]_i_1_n_2 ,\counter2_reg[0]_i_1_n_3 }),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b1}),
        .O({\counter2_reg[0]_i_1_n_4 ,\counter2_reg[0]_i_1_n_5 ,\counter2_reg[0]_i_1_n_6 ,\counter2_reg[0]_i_1_n_7 }),
        .S({\counter2[0]_i_2_n_0 ,\counter2[0]_i_3_n_0 ,\counter2[0]_i_4_n_0 ,\counter2[0]_i_5_n_0 }));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[10] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[8]_i_1_n_5 ),
        .Q(\ssd1/counter16_reg [10]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[11] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[8]_i_1_n_4 ),
        .Q(\ssd1/counter16_reg [11]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[12] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[12]_i_1_n_7 ),
        .Q(\ssd1/counter16_reg [12]),
        .R(1'b0));
  CARRY4 \counter2_reg[12]_i_1 
       (.CI(\counter2_reg[8]_i_1_n_0 ),
        .CO({\NLW_counter2_reg[12]_i_1_CO_UNCONNECTED [3],\counter2_reg[12]_i_1_n_1 ,\counter2_reg[12]_i_1_n_2 ,\counter2_reg[12]_i_1_n_3 }),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O({\counter2_reg[12]_i_1_n_4 ,\counter2_reg[12]_i_1_n_5 ,\counter2_reg[12]_i_1_n_6 ,\counter2_reg[12]_i_1_n_7 }),
        .S({\counter2[12]_i_2_n_0 ,\counter2[12]_i_3_n_0 ,\counter2[12]_i_4_n_0 ,\counter2[12]_i_5_n_0 }));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[13] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[12]_i_1_n_6 ),
        .Q(\ssd1/counter16_reg [13]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[14] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[12]_i_1_n_5 ),
        .Q(p_0_in[0]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[15] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[12]_i_1_n_4 ),
        .Q(p_0_in[1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[1] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[0]_i_1_n_6 ),
        .Q(\ssd1/counter16_reg [1]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[2] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[0]_i_1_n_5 ),
        .Q(\ssd1/counter16_reg [2]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[3] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[0]_i_1_n_4 ),
        .Q(\ssd1/counter16_reg [3]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[4] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[4]_i_1_n_7 ),
        .Q(\ssd1/counter16_reg [4]),
        .R(1'b0));
  CARRY4 \counter2_reg[4]_i_1 
       (.CI(\counter2_reg[0]_i_1_n_0 ),
        .CO({\counter2_reg[4]_i_1_n_0 ,\counter2_reg[4]_i_1_n_1 ,\counter2_reg[4]_i_1_n_2 ,\counter2_reg[4]_i_1_n_3 }),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O({\counter2_reg[4]_i_1_n_4 ,\counter2_reg[4]_i_1_n_5 ,\counter2_reg[4]_i_1_n_6 ,\counter2_reg[4]_i_1_n_7 }),
        .S({\counter2[4]_i_2_n_0 ,\counter2[4]_i_3_n_0 ,\counter2[4]_i_4_n_0 ,\counter2[4]_i_5_n_0 }));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[5] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[4]_i_1_n_6 ),
        .Q(\ssd1/counter16_reg [5]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[6] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[4]_i_1_n_5 ),
        .Q(\ssd1/counter16_reg [6]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[7] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[4]_i_1_n_4 ),
        .Q(\ssd1/counter16_reg [7]),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[8] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[8]_i_1_n_7 ),
        .Q(\ssd1/counter16_reg [8]),
        .R(1'b0));
  CARRY4 \counter2_reg[8]_i_1 
       (.CI(\counter2_reg[4]_i_1_n_0 ),
        .CO({\counter2_reg[8]_i_1_n_0 ,\counter2_reg[8]_i_1_n_1 ,\counter2_reg[8]_i_1_n_2 ,\counter2_reg[8]_i_1_n_3 }),
        .CYINIT(1'b0),
        .DI({1'b0,1'b0,1'b0,1'b0}),
        .O({\counter2_reg[8]_i_1_n_4 ,\counter2_reg[8]_i_1_n_5 ,\counter2_reg[8]_i_1_n_6 ,\counter2_reg[8]_i_1_n_7 }),
        .S({\counter2[8]_i_2_n_0 ,\counter2[8]_i_3_n_0 ,\counter2[8]_i_4_n_0 ,\counter2[8]_i_5_n_0 }));
  FDRE #(
    .INIT(1'b0)) 
    \counter2_reg[9] 
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(\counter2_reg[8]_i_1_n_6 ),
        .Q(\ssd1/counter16_reg [9]),
        .R(1'b0));
  LUT2 #(
    .INIT(4'h2)) 
    \pc_rep[7]_i_1 
       (.I0(reg2),
        .I1(reg3),
        .O(E));
  LUT6 #(
    .INIT(64'h0000000040000000)) 
    reg1_i_1
       (.I0(reg1_i_2_n_0),
        .I1(\ssd1/counter16_reg [13]),
        .I2(\ssd1/counter16_reg [12]),
        .I3(p_0_in[0]),
        .I4(p_0_in[1]),
        .I5(reg1_i_3_n_0),
        .O(en1));
  LUT4 #(
    .INIT(16'h7FFF)) 
    reg1_i_2
       (.I0(\ssd1/counter16_reg [9]),
        .I1(\ssd1/counter16_reg [8]),
        .I2(\ssd1/counter16_reg [11]),
        .I3(\ssd1/counter16_reg [10]),
        .O(reg1_i_2_n_0));
  LUT5 #(
    .INIT(32'h7FFFFFFF)) 
    reg1_i_3
       (.I0(\ssd1/counter16_reg [2]),
        .I1(\ssd1/counter16_reg [3]),
        .I2(\ssd1/counter16_reg [0]),
        .I3(\ssd1/counter16_reg [1]),
        .I4(reg1_i_4_n_0),
        .O(reg1_i_3_n_0));
  LUT4 #(
    .INIT(16'h8000)) 
    reg1_i_4
       (.I0(\ssd1/counter16_reg [5]),
        .I1(\ssd1/counter16_reg [4]),
        .I2(\ssd1/counter16_reg [7]),
        .I3(\ssd1/counter16_reg [6]),
        .O(reg1_i_4_n_0));
  FDRE #(
    .INIT(1'b0)) 
    reg1_reg
       (.C(clk_IBUF_BUFG),
        .CE(en1),
        .D(btn_IBUF),
        .Q(reg1),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    reg2_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(reg1),
        .Q(reg2),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    reg3_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(reg2),
        .Q(reg3),
        .R(1'b0));
endmodule

(* ORIG_REF_NAME = "MonoPulseGenerator" *) 
module MonoPulseGenerator_0
   (AR,
    en1,
    btn_IBUF,
    clk_IBUF_BUFG);
  output [0:0]AR;
  input en1;
  input [0:0]btn_IBUF;
  input clk_IBUF_BUFG;

  wire [0:0]AR;
  wire [0:0]btn_IBUF;
  wire clk_IBUF_BUFG;
  wire en1;
  wire reg1_reg_n_0;
  wire reg2;
  wire reg3;

  LUT2 #(
    .INIT(4'h2)) 
    \pc_rep[7]_i_3 
       (.I0(reg2),
        .I1(reg3),
        .O(AR));
  FDRE #(
    .INIT(1'b0)) 
    reg1_reg
       (.C(clk_IBUF_BUFG),
        .CE(en1),
        .D(btn_IBUF),
        .Q(reg1_reg_n_0),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    reg2_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(reg1_reg_n_0),
        .Q(reg2),
        .R(1'b0));
  FDRE #(
    .INIT(1'b0)) 
    reg3_reg
       (.C(clk_IBUF_BUFG),
        .CE(1'b1),
        .D(reg2),
        .Q(reg3),
        .R(1'b0));
endmodule

module reg_file
   (D,
    \RD2OUT_reg[15] ,
    cat_OBUF,
    clk_IBUF_BUFG,
    RegWriteOUT,
    WD,
    Q,
    \instrMUXOUT_reg[2] ,
    p_0_in,
    sw_IBUF,
    \instructiune2_reg[1] ,
    \pc_reg[15] ,
    \pc_reg_rep[1] ,
    \instructiune2_reg[3] ,
    \instructiune2_reg[5] ,
    \instructiune2_reg[6] ,
    \ALUResOUT_reg[9] ,
    \ALUResOUT_reg[13] ,
    \instructiune2_reg[0] ,
    \pc_reg[0] ,
    \instructiune2_reg[2] ,
    \instructiune2_reg[4] ,
    \ALUResOUT_reg[14] ,
    \ALUResOUT_reg[15] ,
    \ALUResOUT_reg[10] ,
    \ALUResOUT_reg[11] ,
    \ALUResOUT_reg[8] ,
    \ALUResOUT_reg[7] ,
    \ALUResOUT_reg[12] );
  output [15:0]D;
  output [15:0]\RD2OUT_reg[15] ;
  output [6:0]cat_OBUF;
  input clk_IBUF_BUFG;
  input RegWriteOUT;
  input [15:0]WD;
  input [4:0]Q;
  input [2:0]\instrMUXOUT_reg[2] ;
  input [1:0]p_0_in;
  input [2:0]sw_IBUF;
  input \instructiune2_reg[1] ;
  input [14:0]\pc_reg[15] ;
  input [14:0]\pc_reg_rep[1] ;
  input \instructiune2_reg[3] ;
  input \instructiune2_reg[5] ;
  input \instructiune2_reg[6] ;
  input \ALUResOUT_reg[9] ;
  input \ALUResOUT_reg[13] ;
  input \instructiune2_reg[0] ;
  input [0:0]\pc_reg[0] ;
  input \instructiune2_reg[2] ;
  input \instructiune2_reg[4] ;
  input \ALUResOUT_reg[14] ;
  input \ALUResOUT_reg[15] ;
  input \ALUResOUT_reg[10] ;
  input \ALUResOUT_reg[11] ;
  input \ALUResOUT_reg[8] ;
  input \ALUResOUT_reg[7] ;
  input \ALUResOUT_reg[12] ;

  wire \ALUResOUT_reg[10] ;
  wire \ALUResOUT_reg[11] ;
  wire \ALUResOUT_reg[12] ;
  wire \ALUResOUT_reg[13] ;
  wire \ALUResOUT_reg[14] ;
  wire \ALUResOUT_reg[15] ;
  wire \ALUResOUT_reg[7] ;
  wire \ALUResOUT_reg[8] ;
  wire \ALUResOUT_reg[9] ;
  wire [15:0]D;
  wire [4:0]Q;
  wire [15:0]\RD2OUT_reg[15] ;
  wire RegWriteOUT;
  wire [15:0]WD;
  wire [6:0]cat_OBUF;
  wire \cat_OBUF[6]_inst_i_22_n_0 ;
  wire \cat_OBUF[6]_inst_i_24_n_0 ;
  wire \cat_OBUF[6]_inst_i_26_n_0 ;
  wire \cat_OBUF[6]_inst_i_28_n_0 ;
  wire \cat_OBUF[6]_inst_i_30_n_0 ;
  wire \cat_OBUF[6]_inst_i_32_n_0 ;
  wire \cat_OBUF[6]_inst_i_34_n_0 ;
  wire \cat_OBUF[6]_inst_i_36_n_0 ;
  wire \cat_OBUF[6]_inst_i_38_n_0 ;
  wire \cat_OBUF[6]_inst_i_40_n_0 ;
  wire \cat_OBUF[6]_inst_i_42_n_0 ;
  wire \cat_OBUF[6]_inst_i_44_n_0 ;
  wire \cat_OBUF[6]_inst_i_46_n_0 ;
  wire \cat_OBUF[6]_inst_i_48_n_0 ;
  wire \cat_OBUF[6]_inst_i_50_n_0 ;
  wire \cat_OBUF[6]_inst_i_52_n_0 ;
  wire clk_IBUF_BUFG;
  wire [2:0]\instrMUXOUT_reg[2] ;
  wire \instructiune2_reg[0] ;
  wire \instructiune2_reg[1] ;
  wire \instructiune2_reg[2] ;
  wire \instructiune2_reg[3] ;
  wire \instructiune2_reg[4] ;
  wire \instructiune2_reg[5] ;
  wire \instructiune2_reg[6] ;
  wire [1:0]p_0_in;
  wire [0:0]\pc_reg[0] ;
  wire [14:0]\pc_reg[15] ;
  wire [14:0]\pc_reg_rep[1] ;
  wire [15:0]rezultat;
  wire [3:0]\ssd1/cifra__11 ;
  wire [2:0]sw_IBUF;
  wire [1:0]NLW_matrice_reg_r1_0_7_0_5_DOD_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r1_0_7_12_15_DOC_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r1_0_7_12_15_DOD_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r1_0_7_6_11_DOD_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r2_0_7_0_5_DOD_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r2_0_7_12_15_DOC_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r2_0_7_12_15_DOD_UNCONNECTED;
  wire [1:0]NLW_matrice_reg_r2_0_7_6_11_DOD_UNCONNECTED;

  (* SOFT_HLUTNM = "soft_lutpair1" *) 
  LUT4 #(
    .INIT(16'h2094)) 
    \cat_OBUF[0]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [2]),
        .I2(\ssd1/cifra__11 [0]),
        .I3(\ssd1/cifra__11 [1]),
        .O(cat_OBUF[0]));
  (* SOFT_HLUTNM = "soft_lutpair0" *) 
  LUT4 #(
    .INIT(16'hA4C8)) 
    \cat_OBUF[1]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [2]),
        .I2(\ssd1/cifra__11 [1]),
        .I3(\ssd1/cifra__11 [0]),
        .O(cat_OBUF[1]));
  LUT4 #(
    .INIT(16'hA210)) 
    \cat_OBUF[2]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [0]),
        .I2(\ssd1/cifra__11 [1]),
        .I3(\ssd1/cifra__11 [2]),
        .O(cat_OBUF[2]));
  (* SOFT_HLUTNM = "soft_lutpair1" *) 
  LUT4 #(
    .INIT(16'hC214)) 
    \cat_OBUF[3]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [2]),
        .I2(\ssd1/cifra__11 [0]),
        .I3(\ssd1/cifra__11 [1]),
        .O(cat_OBUF[3]));
  (* SOFT_HLUTNM = "soft_lutpair2" *) 
  LUT4 #(
    .INIT(16'h5710)) 
    \cat_OBUF[4]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [1]),
        .I2(\ssd1/cifra__11 [2]),
        .I3(\ssd1/cifra__11 [0]),
        .O(cat_OBUF[4]));
  (* SOFT_HLUTNM = "soft_lutpair2" *) 
  LUT4 #(
    .INIT(16'h5190)) 
    \cat_OBUF[5]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [2]),
        .I2(\ssd1/cifra__11 [0]),
        .I3(\ssd1/cifra__11 [1]),
        .O(cat_OBUF[5]));
  (* SOFT_HLUTNM = "soft_lutpair0" *) 
  LUT4 #(
    .INIT(16'h4025)) 
    \cat_OBUF[6]_inst_i_1 
       (.I0(\ssd1/cifra__11 [3]),
        .I1(\ssd1/cifra__11 [0]),
        .I2(\ssd1/cifra__11 [2]),
        .I3(\ssd1/cifra__11 [1]),
        .O(cat_OBUF[6]));
  MUXF7 \cat_OBUF[6]_inst_i_10 
       (.I0(\cat_OBUF[6]_inst_i_30_n_0 ),
        .I1(\ALUResOUT_reg[12] ),
        .O(rezultat[12]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_11 
       (.I0(\cat_OBUF[6]_inst_i_32_n_0 ),
        .I1(\instructiune2_reg[4] ),
        .O(rezultat[4]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_12 
       (.I0(\cat_OBUF[6]_inst_i_34_n_0 ),
        .I1(\ALUResOUT_reg[8] ),
        .O(rezultat[8]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_13 
       (.I0(\cat_OBUF[6]_inst_i_36_n_0 ),
        .I1(\instructiune2_reg[0] ),
        .O(rezultat[0]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_14 
       (.I0(\cat_OBUF[6]_inst_i_38_n_0 ),
        .I1(\ALUResOUT_reg[14] ),
        .O(rezultat[14]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_15 
       (.I0(\cat_OBUF[6]_inst_i_40_n_0 ),
        .I1(\instructiune2_reg[6] ),
        .O(rezultat[6]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_16 
       (.I0(\cat_OBUF[6]_inst_i_42_n_0 ),
        .I1(\ALUResOUT_reg[10] ),
        .O(rezultat[10]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_17 
       (.I0(\cat_OBUF[6]_inst_i_44_n_0 ),
        .I1(\instructiune2_reg[2] ),
        .O(rezultat[2]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_18 
       (.I0(\cat_OBUF[6]_inst_i_46_n_0 ),
        .I1(\ALUResOUT_reg[13] ),
        .O(rezultat[13]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_19 
       (.I0(\cat_OBUF[6]_inst_i_48_n_0 ),
        .I1(\instructiune2_reg[5] ),
        .O(rezultat[5]),
        .S(sw_IBUF[2]));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_2 
       (.I0(rezultat[15]),
        .I1(rezultat[7]),
        .I2(p_0_in[0]),
        .I3(rezultat[11]),
        .I4(p_0_in[1]),
        .I5(rezultat[3]),
        .O(\ssd1/cifra__11 [3]));
  MUXF7 \cat_OBUF[6]_inst_i_20 
       (.I0(\cat_OBUF[6]_inst_i_50_n_0 ),
        .I1(\ALUResOUT_reg[9] ),
        .O(rezultat[9]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_21 
       (.I0(\cat_OBUF[6]_inst_i_52_n_0 ),
        .I1(\instructiune2_reg[1] ),
        .O(rezultat[1]),
        .S(sw_IBUF[2]));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_22 
       (.I0(\RD2OUT_reg[15] [15]),
        .I1(D[15]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [14]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [14]),
        .O(\cat_OBUF[6]_inst_i_22_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_24 
       (.I0(\RD2OUT_reg[15] [7]),
        .I1(D[7]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [6]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [7]),
        .O(\cat_OBUF[6]_inst_i_24_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_26 
       (.I0(\RD2OUT_reg[15] [11]),
        .I1(D[11]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [10]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [11]),
        .O(\cat_OBUF[6]_inst_i_26_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_28 
       (.I0(\RD2OUT_reg[15] [3]),
        .I1(D[3]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [2]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [3]),
        .O(\cat_OBUF[6]_inst_i_28_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_3 
       (.I0(rezultat[12]),
        .I1(rezultat[4]),
        .I2(p_0_in[0]),
        .I3(rezultat[8]),
        .I4(p_0_in[1]),
        .I5(rezultat[0]),
        .O(\ssd1/cifra__11 [0]));
  LUT5 #(
    .INIT(32'hAFC0A0C0)) 
    \cat_OBUF[6]_inst_i_30 
       (.I0(\RD2OUT_reg[15] [12]),
        .I1(D[12]),
        .I2(sw_IBUF[1]),
        .I3(sw_IBUF[0]),
        .I4(\pc_reg[15] [11]),
        .O(\cat_OBUF[6]_inst_i_30_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_32 
       (.I0(\RD2OUT_reg[15] [4]),
        .I1(D[4]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [3]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [4]),
        .O(\cat_OBUF[6]_inst_i_32_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_34 
       (.I0(\RD2OUT_reg[15] [8]),
        .I1(D[8]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [7]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [8]),
        .O(\cat_OBUF[6]_inst_i_34_n_0 ));
  LUT6 #(
    .INIT(64'hA0AFCFCFA0AFC0C0)) 
    \cat_OBUF[6]_inst_i_36 
       (.I0(\RD2OUT_reg[15] [0]),
        .I1(D[0]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[0] ),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [0]),
        .O(\cat_OBUF[6]_inst_i_36_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_38 
       (.I0(\RD2OUT_reg[15] [14]),
        .I1(D[14]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [13]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [13]),
        .O(\cat_OBUF[6]_inst_i_38_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_4 
       (.I0(rezultat[14]),
        .I1(rezultat[6]),
        .I2(p_0_in[0]),
        .I3(rezultat[10]),
        .I4(p_0_in[1]),
        .I5(rezultat[2]),
        .O(\ssd1/cifra__11 [2]));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_40 
       (.I0(\RD2OUT_reg[15] [6]),
        .I1(D[6]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [5]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [6]),
        .O(\cat_OBUF[6]_inst_i_40_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_42 
       (.I0(\RD2OUT_reg[15] [10]),
        .I1(D[10]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [9]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [10]),
        .O(\cat_OBUF[6]_inst_i_42_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_44 
       (.I0(\RD2OUT_reg[15] [2]),
        .I1(D[2]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [1]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [2]),
        .O(\cat_OBUF[6]_inst_i_44_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_46 
       (.I0(\RD2OUT_reg[15] [13]),
        .I1(D[13]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [12]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [12]),
        .O(\cat_OBUF[6]_inst_i_46_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_48 
       (.I0(\RD2OUT_reg[15] [5]),
        .I1(D[5]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [4]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [5]),
        .O(\cat_OBUF[6]_inst_i_48_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_5 
       (.I0(rezultat[13]),
        .I1(rezultat[5]),
        .I2(p_0_in[0]),
        .I3(rezultat[9]),
        .I4(p_0_in[1]),
        .I5(rezultat[1]),
        .O(\ssd1/cifra__11 [1]));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_50 
       (.I0(\RD2OUT_reg[15] [9]),
        .I1(D[9]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [8]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [9]),
        .O(\cat_OBUF[6]_inst_i_50_n_0 ));
  LUT6 #(
    .INIT(64'hAFA0CFCFAFA0C0C0)) 
    \cat_OBUF[6]_inst_i_52 
       (.I0(\RD2OUT_reg[15] [1]),
        .I1(D[1]),
        .I2(sw_IBUF[1]),
        .I3(\pc_reg[15] [0]),
        .I4(sw_IBUF[0]),
        .I5(\pc_reg_rep[1] [1]),
        .O(\cat_OBUF[6]_inst_i_52_n_0 ));
  MUXF7 \cat_OBUF[6]_inst_i_6 
       (.I0(\cat_OBUF[6]_inst_i_22_n_0 ),
        .I1(\ALUResOUT_reg[15] ),
        .O(rezultat[15]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_7 
       (.I0(\cat_OBUF[6]_inst_i_24_n_0 ),
        .I1(\ALUResOUT_reg[7] ),
        .O(rezultat[7]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_8 
       (.I0(\cat_OBUF[6]_inst_i_26_n_0 ),
        .I1(\ALUResOUT_reg[11] ),
        .O(rezultat[11]),
        .S(sw_IBUF[2]));
  MUXF7 \cat_OBUF[6]_inst_i_9 
       (.I0(\cat_OBUF[6]_inst_i_28_n_0 ),
        .I1(\instructiune2_reg[3] ),
        .O(rezultat[3]),
        .S(sw_IBUF[2]));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r1_0_7_0_5
       (.ADDRA({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRB({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRC({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[1:0]),
        .DIB(WD[3:2]),
        .DIC(WD[5:4]),
        .DID({1'b0,1'b0}),
        .DOA(D[1:0]),
        .DOB(D[3:2]),
        .DOC(D[5:4]),
        .DOD(NLW_matrice_reg_r1_0_7_0_5_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r1_0_7_12_15
       (.ADDRA({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRB({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRC({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[13:12]),
        .DIB(WD[15:14]),
        .DIC({1'b0,1'b0}),
        .DID({1'b0,1'b0}),
        .DOA(D[13:12]),
        .DOB(D[15:14]),
        .DOC(NLW_matrice_reg_r1_0_7_12_15_DOC_UNCONNECTED[1:0]),
        .DOD(NLW_matrice_reg_r1_0_7_12_15_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r1_0_7_6_11
       (.ADDRA({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRB({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRC({1'b0,1'b0,1'b0,Q[4:3]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[7:6]),
        .DIB(WD[9:8]),
        .DIC(WD[11:10]),
        .DID({1'b0,1'b0}),
        .DOA(D[7:6]),
        .DOB(D[9:8]),
        .DOC(D[11:10]),
        .DOD(NLW_matrice_reg_r1_0_7_6_11_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r2_0_7_0_5
       (.ADDRA({1'b0,1'b0,Q[2:0]}),
        .ADDRB({1'b0,1'b0,Q[2:0]}),
        .ADDRC({1'b0,1'b0,Q[2:0]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[1:0]),
        .DIB(WD[3:2]),
        .DIC(WD[5:4]),
        .DID({1'b0,1'b0}),
        .DOA(\RD2OUT_reg[15] [1:0]),
        .DOB(\RD2OUT_reg[15] [3:2]),
        .DOC(\RD2OUT_reg[15] [5:4]),
        .DOD(NLW_matrice_reg_r2_0_7_0_5_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r2_0_7_12_15
       (.ADDRA({1'b0,1'b0,Q[2:0]}),
        .ADDRB({1'b0,1'b0,Q[2:0]}),
        .ADDRC({1'b0,1'b0,Q[2:0]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[13:12]),
        .DIB(WD[15:14]),
        .DIC({1'b0,1'b0}),
        .DID({1'b0,1'b0}),
        .DOA(\RD2OUT_reg[15] [13:12]),
        .DOB(\RD2OUT_reg[15] [15:14]),
        .DOC(NLW_matrice_reg_r2_0_7_12_15_DOC_UNCONNECTED[1:0]),
        .DOD(NLW_matrice_reg_r2_0_7_12_15_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
  (* METHODOLOGY_DRC_VIOS = "" *) 
  RAM32M #(
    .INIT_A(64'h0000000000000000),
    .INIT_B(64'h0000000000000000),
    .INIT_C(64'h0000000000000000),
    .INIT_D(64'h0000000000000000)) 
    matrice_reg_r2_0_7_6_11
       (.ADDRA({1'b0,1'b0,Q[2:0]}),
        .ADDRB({1'b0,1'b0,Q[2:0]}),
        .ADDRC({1'b0,1'b0,Q[2:0]}),
        .ADDRD({1'b0,1'b0,\instrMUXOUT_reg[2] }),
        .DIA(WD[7:6]),
        .DIB(WD[9:8]),
        .DIC(WD[11:10]),
        .DID({1'b0,1'b0}),
        .DOA(\RD2OUT_reg[15] [7:6]),
        .DOB(\RD2OUT_reg[15] [9:8]),
        .DOC(\RD2OUT_reg[15] [11:10]),
        .DOD(NLW_matrice_reg_r2_0_7_6_11_DOD_UNCONNECTED[1:0]),
        .WCLK(clk_IBUF_BUFG),
        .WE(RegWriteOUT));
endmodule

(* NotValidForBitStream *)
module test_env
   (clk,
    btn,
    sw,
    led,
    an,
    cat);
  input clk;
  input [4:0]btn;
  input [15:0]sw;
  output [15:0]led;
  output [3:0]an;
  output [6:0]cat;

  wire [15:0]ALURes;
  wire Branch;
  wire [15:0]BranchAdr;
  wire [11:0]Ext_ImmOUT;
  wire [15:0]MemData;
  wire [1:0]RA;
  wire [2:0]RB;
  wire [15:0]RD1;
  wire [14:0]RD1OUT;
  wire [15:0]RD2;
  wire RegWriteOUT;
  wire [15:0]WD;
  wire Zero;
  wire Zero2;
  wire [3:0]an;
  wire [3:0]an_OBUF;
  wire branch3;
  wire [4:0]btn;
  wire [1:0]btn_IBUF;
  wire [6:0]cat;
  wire [6:0]cat_OBUF;
  wire clk;
  wire clk_IBUF;
  wire clk_IBUF_BUFG;
  wire [15:0]data1;
  wire en1;
  wire ex_mem1_n_1;
  wire ex_mem1_n_2;
  wire ex_mem1_n_23;
  wire ex_mem1_n_24;
  wire ex_mem1_n_25;
  wire ex_mem1_n_26;
  wire ex_mem1_n_27;
  wire ex_mem1_n_28;
  wire ex_mem1_n_29;
  wire ex_mem1_n_30;
  wire ex_mem1_n_31;
  wire ex_mem1_n_32;
  wire ex_mem1_n_33;
  wire ex_mem1_n_34;
  wire ex_mem1_n_35;
  wire ex_mem1_n_36;
  wire ex_mem1_n_37;
  wire ex_mem1_n_38;
  wire ex_mem1_n_39;
  wire ex_mem1_n_40;
  wire ex_mem1_n_41;
  wire id1_n_16;
  wire id1_n_17;
  wire id1_n_18;
  wire id1_n_19;
  wire id1_n_20;
  wire id1_n_21;
  wire id1_n_22;
  wire id1_n_23;
  wire id1_n_24;
  wire id1_n_25;
  wire id1_n_26;
  wire id1_n_27;
  wire id1_n_28;
  wire id1_n_29;
  wire id1_n_30;
  wire id1_n_31;
  wire id_ex1_n_10;
  wire id_ex1_n_11;
  wire id_ex1_n_12;
  wire id_ex1_n_13;
  wire id_ex1_n_14;
  wire id_ex1_n_15;
  wire id_ex1_n_16;
  wire id_ex1_n_17;
  wire id_ex1_n_18;
  wire id_ex1_n_19;
  wire id_ex1_n_20;
  wire id_ex1_n_21;
  wire id_ex1_n_22;
  wire id_ex1_n_23;
  wire id_ex1_n_24;
  wire id_ex1_n_56;
  wire id_ex1_n_57;
  wire id_ex1_n_58;
  wire id_ex1_n_59;
  wire id_ex1_n_60;
  wire id_ex1_n_65;
  wire id_ex1_n_66;
  wire id_ex1_n_67;
  wire id_ex1_n_68;
  wire id_ex1_n_69;
  wire id_ex1_n_70;
  wire id_ex1_n_71;
  wire id_ex1_n_72;
  wire id_ex1_n_73;
  wire id_ex1_n_74;
  wire id_ex1_n_75;
  wire id_ex1_n_76;
  wire id_ex1_n_77;
  wire id_ex1_n_78;
  wire id_ex1_n_79;
  wire id_ex1_n_80;
  wire id_ex1_n_81;
  wire id_ex1_n_82;
  wire id_ex1_n_83;
  wire id_ex1_n_84;
  wire id_ex1_n_85;
  wire id_ex1_n_86;
  wire id_ex1_n_87;
  wire id_ex1_n_88;
  wire id_ex1_n_89;
  wire id_ex1_n_9;
  wire id_ex1_n_90;
  wire id_ex1_n_91;
  wire id_ex1_n_92;
  wire if_id1_n_11;
  wire if_id1_n_18;
  wire if_id1_n_19;
  wire if_id1_n_21;
  wire if_id1_n_22;
  wire if_id1_n_23;
  wire [2:0]instrMUXOUT;
  wire [15:0]instructiune;
  wire [15:0]led;
  wire [10:0]led_OBUF;
  wire mem_wb1_n_1;
  wire mem_wb1_n_18;
  wire mem_wb1_n_19;
  wire mem_wb1_n_20;
  wire mem_wb1_n_21;
  wire mem_wb1_n_22;
  wire mem_wb1_n_23;
  wire mem_wb1_n_24;
  wire mem_wb1_n_25;
  wire mem_wb1_n_26;
  wire mem_wb1_n_27;
  wire mem_wb1_n_28;
  wire mem_wb1_n_29;
  wire mem_wb1_n_30;
  wire mem_wb1_n_31;
  wire mem_wb1_n_32;
  wire mpg1_n_7;
  wire mpg2_n_0;
  wire [15:12]mux2;
  wire [2:0]muxREG;
  wire [15:0]next_instr2;
  wire p_0_in0;
  wire [0:0]pc;
  wire sa;
  wire [15:0]sel0;
  wire [1:0]\ssd1/p_0_in ;
  wire [15:0]sw;
  wire [7:5]sw_IBUF;

  OBUF \an_OBUF[0]_inst 
       (.I(an_OBUF[0]),
        .O(an[0]));
  OBUF \an_OBUF[1]_inst 
       (.I(an_OBUF[1]),
        .O(an[1]));
  OBUF \an_OBUF[2]_inst 
       (.I(an_OBUF[2]),
        .O(an[2]));
  OBUF \an_OBUF[3]_inst 
       (.I(an_OBUF[3]),
        .O(an[3]));
  IBUF \btn_IBUF[0]_inst 
       (.I(btn[0]),
        .O(btn_IBUF[0]));
  IBUF \btn_IBUF[1]_inst 
       (.I(btn[1]),
        .O(btn_IBUF[1]));
  OBUF \cat_OBUF[0]_inst 
       (.I(cat_OBUF[0]),
        .O(cat[0]));
  OBUF \cat_OBUF[1]_inst 
       (.I(cat_OBUF[1]),
        .O(cat[1]));
  OBUF \cat_OBUF[2]_inst 
       (.I(cat_OBUF[2]),
        .O(cat[2]));
  OBUF \cat_OBUF[3]_inst 
       (.I(cat_OBUF[3]),
        .O(cat[3]));
  OBUF \cat_OBUF[4]_inst 
       (.I(cat_OBUF[4]),
        .O(cat[4]));
  OBUF \cat_OBUF[5]_inst 
       (.I(cat_OBUF[5]),
        .O(cat[5]));
  OBUF \cat_OBUF[6]_inst 
       (.I(cat_OBUF[6]),
        .O(cat[6]));
  BUFG clk_IBUF_BUFG_inst
       (.I(clk_IBUF),
        .O(clk_IBUF_BUFG));
  IBUF clk_IBUF_inst
       (.I(clk),
        .O(clk_IBUF));
  EX ex1
       (.\ALUOpOUT_reg[0] (id_ex1_n_60),
        .BranchAdr(BranchAdr),
        .Ext_ImmOUT({Ext_ImmOUT[11],Ext_ImmOUT[6:0]}),
        .\Ext_ImmOUT_reg[11] ({id_ex1_n_69,id_ex1_n_70,id_ex1_n_71,id_ex1_n_72}),
        .\Ext_ImmOUT_reg[11]_0 ({id_ex1_n_73,id_ex1_n_74,id_ex1_n_75,id_ex1_n_76}),
        .\Ext_ImmOUT_reg[11]_1 ({id_ex1_n_56,id_ex1_n_57,id_ex1_n_58,id_ex1_n_59}),
        .\Ext_ImmOUT_reg[11]_2 ({id_ex1_n_85,id_ex1_n_86,id_ex1_n_87,id_ex1_n_88}),
        .\Ext_ImmOUT_reg[11]_3 ({id_ex1_n_81,id_ex1_n_82,id_ex1_n_83,id_ex1_n_84}),
        .\Ext_ImmOUT_reg[11]_4 ({id_ex1_n_89,id_ex1_n_90,id_ex1_n_91,id_ex1_n_92}),
        .\Ext_ImmOUT_reg[3] ({id_ex1_n_77,id_ex1_n_78,id_ex1_n_79,id_ex1_n_80}),
        .Q(RD1OUT),
        .S({id_ex1_n_65,id_ex1_n_66,id_ex1_n_67,id_ex1_n_68}),
        .Zero(Zero),
        .Zero2(Zero2),
        .sel0(sel0));
  EX_MEM ex_mem1
       (.\ALUOpOUT_reg[0] ({id_ex1_n_9,id_ex1_n_10,id_ex1_n_11,id_ex1_n_12,id_ex1_n_13,id_ex1_n_14,id_ex1_n_15,id_ex1_n_16,id_ex1_n_17,id_ex1_n_18,id_ex1_n_19,id_ex1_n_20,id_ex1_n_21,id_ex1_n_22,id_ex1_n_23,id_ex1_n_24}),
        .Branch(Branch),
        .BranchAdr(BranchAdr[15:12]),
        .D(mux2),
        .\Ext_ImmOUT_reg[6] (muxREG),
        .MemToRegOUT_reg(ex_mem1_n_1),
        .Q(ALURes),
        .\RD1OUT_reg[13] ({ex_mem1_n_23,ex_mem1_n_24,ex_mem1_n_25,ex_mem1_n_26,ex_mem1_n_27,ex_mem1_n_28,ex_mem1_n_29,ex_mem1_n_30,ex_mem1_n_31,ex_mem1_n_32,ex_mem1_n_33,ex_mem1_n_34,ex_mem1_n_35,ex_mem1_n_36,ex_mem1_n_37,ex_mem1_n_38}),
        .\RD2OUT_reg[15]_0 (RD2),
        .RegWriteOUT_reg(ex_mem1_n_2),
        .Zero(Zero),
        .branch3(branch3),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instrMUXOUT_reg[2]_0 ({ex_mem1_n_39,ex_mem1_n_40,ex_mem1_n_41}),
        .led_OBUF({led_OBUF[6],led_OBUF[1:0]}),
        .\pc_reg[15] (data1[15:12]));
  ID id1
       (.\ALUResOUT_reg[10] (mem_wb1_n_22),
        .\ALUResOUT_reg[11] (mem_wb1_n_21),
        .\ALUResOUT_reg[12] (mem_wb1_n_31),
        .\ALUResOUT_reg[13] (mem_wb1_n_30),
        .\ALUResOUT_reg[14] (mem_wb1_n_29),
        .\ALUResOUT_reg[15] (mem_wb1_n_32),
        .\ALUResOUT_reg[7] (mem_wb1_n_25),
        .\ALUResOUT_reg[8] (mem_wb1_n_24),
        .\ALUResOUT_reg[9] (mem_wb1_n_23),
        .D(RD1),
        .Q({RA,RB}),
        .\RD2OUT_reg[15] ({id1_n_16,id1_n_17,id1_n_18,id1_n_19,id1_n_20,id1_n_21,id1_n_22,id1_n_23,id1_n_24,id1_n_25,id1_n_26,id1_n_27,id1_n_28,id1_n_29,id1_n_30,id1_n_31}),
        .RegWriteOUT(RegWriteOUT),
        .WD(WD),
        .cat_OBUF(cat_OBUF),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instrMUXOUT_reg[2] (instrMUXOUT),
        .\instructiune2_reg[0] (mem_wb1_n_20),
        .\instructiune2_reg[1] (mem_wb1_n_19),
        .\instructiune2_reg[2] (mem_wb1_n_18),
        .\instructiune2_reg[3] (mem_wb1_n_1),
        .\instructiune2_reg[4] (mem_wb1_n_28),
        .\instructiune2_reg[5] (mem_wb1_n_27),
        .\instructiune2_reg[6] (mem_wb1_n_26),
        .p_0_in(\ssd1/p_0_in ),
        .\pc_reg[0] (pc),
        .\pc_reg[15] (data1[15:1]),
        .\pc_reg_rep[1] ({instructiune[15:13],instructiune[11:0]}),
        .sw_IBUF(sw_IBUF));
  ID_EX id_ex1
       (.\ALUResOUT_reg[11] ({id_ex1_n_81,id_ex1_n_82,id_ex1_n_83,id_ex1_n_84}),
        .\ALUResOUT_reg[15] ({id_ex1_n_9,id_ex1_n_10,id_ex1_n_11,id_ex1_n_12,id_ex1_n_13,id_ex1_n_14,id_ex1_n_15,id_ex1_n_16,id_ex1_n_17,id_ex1_n_18,id_ex1_n_19,id_ex1_n_20,id_ex1_n_21,id_ex1_n_22,id_ex1_n_23,id_ex1_n_24}),
        .\ALUResOUT_reg[15]_0 (RD1OUT),
        .\ALUResOUT_reg[15]_1 ({id_ex1_n_89,id_ex1_n_90,id_ex1_n_91,id_ex1_n_92}),
        .\ALUResOUT_reg[3] ({id_ex1_n_77,id_ex1_n_78,id_ex1_n_79,id_ex1_n_80}),
        .\ALUResOUT_reg[7] ({id_ex1_n_85,id_ex1_n_86,id_ex1_n_87,id_ex1_n_88}),
        .Branch(Branch),
        .D({id1_n_16,id1_n_17,id1_n_18,id1_n_19,id1_n_20,id1_n_21,id1_n_22,id1_n_23,id1_n_24,id1_n_25,id1_n_26,id1_n_27,id1_n_28,id1_n_29,id1_n_30,id1_n_31}),
        .Ext_ImmOUT({Ext_ImmOUT[11],Ext_ImmOUT[6:0]}),
        .Q({RB,p_0_in0,if_id1_n_18,if_id1_n_19,sa,if_id1_n_21,if_id1_n_22,if_id1_n_23}),
        .\RD2OUT_reg[15]_0 (RD2),
        .RegWriteOUT_reg(RD1),
        .S({id_ex1_n_65,id_ex1_n_66,id_ex1_n_67,id_ex1_n_68}),
        .Zero2(Zero2),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instrMUXOUT_reg[2] (muxREG),
        .\instructiune2_reg[14] (if_id1_n_11),
        .led_OBUF({led_OBUF[10],led_OBUF[8:7],led_OBUF[5:3]}),
        .\next_instr2_reg[15] (next_instr2),
        .\pc_reg[11] ({id_ex1_n_73,id_ex1_n_74,id_ex1_n_75,id_ex1_n_76}),
        .\pc_reg[15] ({id_ex1_n_56,id_ex1_n_57,id_ex1_n_58,id_ex1_n_59}),
        .\pc_reg[1] (id_ex1_n_60),
        .\pc_reg[7] ({id_ex1_n_69,id_ex1_n_70,id_ex1_n_71,id_ex1_n_72}),
        .sel0(sel0));
  InstrFetch if1
       (.AR(mpg2_n_0),
        .BranchAdr(BranchAdr[11:0]),
        .BranchOUT_reg(mux2),
        .D(data1),
        .E(mpg1_n_7),
        .Q(pc),
        .Zero(Zero),
        .branch3(branch3),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instructiune2_reg[15] ({instructiune[15:13],instructiune[11:0]}),
        .led_OBUF(led_OBUF[6]));
  IF_ID if_id1
       (.D(data1),
        .\Ext_ImmOUT_reg[11] (if_id1_n_11),
        .Q({RA,RB,p_0_in0,if_id1_n_18,if_id1_n_19,sa,if_id1_n_21,if_id1_n_22,if_id1_n_23}),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .led_OBUF(led_OBUF),
        .\nxtInstructiuneOUT_reg[15] (next_instr2),
        .\pc_reg_rep[1] ({instructiune[15:13],instructiune[11:0]}));
  OBUF \led_OBUF[0]_inst 
       (.I(led_OBUF[0]),
        .O(led[0]));
  OBUF \led_OBUF[10]_inst 
       (.I(led_OBUF[10]),
        .O(led[10]));
  OBUF \led_OBUF[11]_inst 
       (.I(1'b0),
        .O(led[11]));
  OBUF \led_OBUF[12]_inst 
       (.I(1'b0),
        .O(led[12]));
  OBUF \led_OBUF[13]_inst 
       (.I(1'b0),
        .O(led[13]));
  OBUF \led_OBUF[14]_inst 
       (.I(1'b0),
        .O(led[14]));
  OBUF \led_OBUF[15]_inst 
       (.I(1'b0),
        .O(led[15]));
  OBUF \led_OBUF[1]_inst 
       (.I(led_OBUF[1]),
        .O(led[1]));
  OBUF \led_OBUF[2]_inst 
       (.I(led_OBUF[2]),
        .O(led[2]));
  OBUF \led_OBUF[3]_inst 
       (.I(led_OBUF[3]),
        .O(led[3]));
  OBUF \led_OBUF[4]_inst 
       (.I(led_OBUF[4]),
        .O(led[4]));
  OBUF \led_OBUF[5]_inst 
       (.I(led_OBUF[5]),
        .O(led[5]));
  OBUF \led_OBUF[6]_inst 
       (.I(led_OBUF[6]),
        .O(led[6]));
  OBUF \led_OBUF[7]_inst 
       (.I(led_OBUF[7]),
        .O(led[7]));
  OBUF \led_OBUF[8]_inst 
       (.I(led_OBUF[8]),
        .O(led[8]));
  OBUF \led_OBUF[9]_inst 
       (.I(led_OBUF[9]),
        .O(led[9]));
  MEM mem1
       (.\ALUOpOUT_reg[0] ({id_ex1_n_17,id_ex1_n_18,id_ex1_n_19,id_ex1_n_20,id_ex1_n_21,id_ex1_n_22,id_ex1_n_23,id_ex1_n_24}),
        .MemData(MemData),
        .RD2({ex_mem1_n_23,ex_mem1_n_24,ex_mem1_n_25,ex_mem1_n_26,ex_mem1_n_27,ex_mem1_n_28,ex_mem1_n_29,ex_mem1_n_30,ex_mem1_n_31,ex_mem1_n_32,ex_mem1_n_33,ex_mem1_n_34,ex_mem1_n_35,ex_mem1_n_36,ex_mem1_n_37,ex_mem1_n_38}),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .led_OBUF(led_OBUF[2]));
  MEM_WB mem_wb1
       (.\ALUOpOUT_reg[0] ({id_ex1_n_9,id_ex1_n_10,id_ex1_n_11,id_ex1_n_12,id_ex1_n_13,id_ex1_n_14,id_ex1_n_15,id_ex1_n_16,id_ex1_n_17,id_ex1_n_18,id_ex1_n_19,id_ex1_n_20,id_ex1_n_21,id_ex1_n_22,id_ex1_n_23,id_ex1_n_24}),
        .D(ALURes),
        .MemData(MemData),
        .Q({p_0_in0,if_id1_n_18,if_id1_n_19,sa,if_id1_n_21,if_id1_n_22,if_id1_n_23}),
        .\RD1OUT_reg[1] (instrMUXOUT),
        .RegWriteOUT(RegWriteOUT),
        .WD(WD),
        .\cat[1] (mem_wb1_n_1),
        .\cat[1]_0 (mem_wb1_n_18),
        .\cat[1]_1 (mem_wb1_n_19),
        .\cat[1]_10 (mem_wb1_n_28),
        .\cat[1]_11 (mem_wb1_n_29),
        .\cat[1]_12 (mem_wb1_n_30),
        .\cat[1]_13 (mem_wb1_n_31),
        .\cat[1]_14 (mem_wb1_n_32),
        .\cat[1]_2 (mem_wb1_n_20),
        .\cat[1]_3 (mem_wb1_n_21),
        .\cat[1]_4 (mem_wb1_n_22),
        .\cat[1]_5 (mem_wb1_n_23),
        .\cat[1]_6 (mem_wb1_n_24),
        .\cat[1]_7 (mem_wb1_n_25),
        .\cat[1]_8 (mem_wb1_n_26),
        .\cat[1]_9 (mem_wb1_n_27),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .\instrMUXOUT_reg[2]_0 ({ex_mem1_n_39,ex_mem1_n_40,ex_mem1_n_41}),
        .\instructiune2_reg[14] (ex_mem1_n_1),
        .\instructiune2_reg[14]_0 (if_id1_n_11),
        .\instructiune2_reg[15] (ex_mem1_n_2),
        .sw_IBUF(sw_IBUF[6:5]));
  MonoPulseGenerator mpg1
       (.E(mpg1_n_7),
        .an_OBUF(an_OBUF),
        .btn_IBUF(btn_IBUF[0]),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .en1(en1),
        .p_0_in(\ssd1/p_0_in ));
  MonoPulseGenerator_0 mpg2
       (.AR(mpg2_n_0),
        .btn_IBUF(btn_IBUF[1]),
        .clk_IBUF_BUFG(clk_IBUF_BUFG),
        .en1(en1));
  IBUF \sw_IBUF[5]_inst 
       (.I(sw[5]),
        .O(sw_IBUF[5]));
  IBUF \sw_IBUF[6]_inst 
       (.I(sw[6]),
        .O(sw_IBUF[6]));
  IBUF \sw_IBUF[7]_inst 
       (.I(sw[7]),
        .O(sw_IBUF[7]));
endmodule
`ifndef GLBL
`define GLBL
`timescale  1 ps / 1 ps

module glbl ();

    parameter ROC_WIDTH = 100000;
    parameter TOC_WIDTH = 0;

//--------   STARTUP Globals --------------
    wire GSR;
    wire GTS;
    wire GWE;
    wire PRLD;
    tri1 p_up_tmp;
    tri (weak1, strong0) PLL_LOCKG = p_up_tmp;

    wire PROGB_GLBL;
    wire CCLKO_GLBL;
    wire FCSBO_GLBL;
    wire [3:0] DO_GLBL;
    wire [3:0] DI_GLBL;
   
    reg GSR_int;
    reg GTS_int;
    reg PRLD_int;

//--------   JTAG Globals --------------
    wire JTAG_TDO_GLBL;
    wire JTAG_TCK_GLBL;
    wire JTAG_TDI_GLBL;
    wire JTAG_TMS_GLBL;
    wire JTAG_TRST_GLBL;

    reg JTAG_CAPTURE_GLBL;
    reg JTAG_RESET_GLBL;
    reg JTAG_SHIFT_GLBL;
    reg JTAG_UPDATE_GLBL;
    reg JTAG_RUNTEST_GLBL;

    reg JTAG_SEL1_GLBL = 0;
    reg JTAG_SEL2_GLBL = 0 ;
    reg JTAG_SEL3_GLBL = 0;
    reg JTAG_SEL4_GLBL = 0;

    reg JTAG_USER_TDO1_GLBL = 1'bz;
    reg JTAG_USER_TDO2_GLBL = 1'bz;
    reg JTAG_USER_TDO3_GLBL = 1'bz;
    reg JTAG_USER_TDO4_GLBL = 1'bz;

    assign (weak1, weak0) GSR = GSR_int;
    assign (weak1, weak0) GTS = GTS_int;
    assign (weak1, weak0) PRLD = PRLD_int;

    initial begin
	GSR_int = 1'b1;
	PRLD_int = 1'b1;
	#(ROC_WIDTH)
	GSR_int = 1'b0;
	PRLD_int = 1'b0;
    end

    initial begin
	GTS_int = 1'b1;
	#(TOC_WIDTH)
	GTS_int = 1'b0;
    end

endmodule
`endif
