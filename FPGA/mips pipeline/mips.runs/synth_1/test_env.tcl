# 
# Synthesis run script generated by Vivado
# 

set_msg_config -id {HDL 9-1061} -limit 100000
set_msg_config -id {HDL 9-1654} -limit 100000
create_project -in_memory -part xc7a35tcpg236-1

set_param project.singleFileAddWarning.threshold 0
set_param project.compositeFile.enableAutoGeneration 0
set_param synth.vivado.isSynthRun true
set_property webtalk.parent_dir {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.cache/wt} [current_project]
set_property parent.project_path {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.xpr} [current_project]
set_property default_lib xil_defaultlib [current_project]
set_property target_language Verilog [current_project]
set_property ip_output_repo {e:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.cache/ip} [current_project]
set_property ip_cache_permissions {read write} [current_project]
read_vhdl -library xil_defaultlib {
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/reg_file.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/MEM_WB.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/EX_MEM.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/EX.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/ID_EX.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/SSD.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/imports/new/MonoPulseGenerator.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/MEM.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/InstrFetch.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/IF_ID.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/Control.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/new/ID.vhd}
  {E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/sources_1/imports/new/test_env.vhd}
}
foreach dcp [get_files -quiet -all *.dcp] {
  set_property used_in_implementation false $dcp
}
read_xdc {{E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/constrs_1/imports/Dulau Marius/Basys3_test_env.xdc}}
set_property used_in_implementation false [get_files {{E:/School/Proiecte M/Facultate/An II/Sem II/AC - Arhitectura calculatoarelor/laboratoare/lab9/mips/mips.srcs/constrs_1/imports/Dulau Marius/Basys3_test_env.xdc}}]


synth_design -top test_env -part xc7a35tcpg236-1


write_checkpoint -force -noxdef test_env.dcp

catch { report_utilization -file test_env_utilization_synth.rpt -pb test_env_utilization_synth.pb }