@echo off
set xv_path=E:\\Xilinx\\Vivado_2016.4\\Vivado\\2016.4\\bin
call %xv_path%/xsim test_env_func_synth -key {Post-Synthesis:sim_1:Functional:test_env} -tclbatch test_env.tcl -log simulate.log
if "%errorlevel%"=="0" goto SUCCESS
if "%errorlevel%"=="1" goto END
:END
exit 1
:SUCCESS
exit 0
