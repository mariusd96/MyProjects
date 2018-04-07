using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tari_si_capitale
{
    public partial class CA_continente : Form
    {
        string[] v = new string[200];
        int[] r = new int[200];
        int n, index, temp;
        public CA_continente()
        {
            InitializeComponent();
            v[1] = "Pretoria";
            v[2] = "Alger";
            v[3] = "Luanda";
            v[4] = "Porto Novo";
            v[5] = "Gaborone";
            v[6] = "Ouagadougou";
            v[7] = "Bujumbura";
            v[8] = "Yaounde";
            v[9] = "N'Djamena";
            v[10] = "Yamoussoukro";
            v[11] = "Moroni";
            v[12] = "Djibouti";
            v[13] = "Cairo";
            v[14] = "Asmara";
            v[15] = "Addis Abeba";
            v[16] = "Libreville";
            v[17] = "Banjul";
            v[18] = "Accra";
            v[19] = "Conakry";
            v[20] = "Bissau";
            v[21] = "Malabo";
            v[22] = "Praia";
            v[23] = "Nairobi";
            v[24] = "Maseru";
            v[25] = "Monrovia";
            v[26] = "Tripoli";
            v[27] = "Antananarivo";
            v[28] = "Lilongwe";
            v[29] = "Bamako";
            v[30] = "Rabat";
            v[31] = "Nouakchott";
            v[32] = "Port Louis";
            v[33] = "Maputo";
            v[34] = "Windhoek";
            v[35] = "Niamey";
            v[36] = "Abuja";
            v[37] = "Bangui";
            v[38] = "Brazzaville";
            v[39] = "Kinshasa";
            v[40] = "Kigali";
            v[41] = "Sao Tome";
            v[42] = "Dakar";
            v[43] = "Victoria";
            v[44] = "Freetown";
            v[45] = "Mogadishu";
            v[46] = "Khartoum";
            v[47] = "Juba";
            v[48] = "Mbabane";
            v[49] = "Dodoma";
            v[50] = "Lome";
            v[51] = "Tunis";
            v[52] = "Kampala";
            v[53] = "Lusaka";
            v[54] = "Harare";
            
            v[55] = "Buenos Aires";
            v[56] = "La Paz";
            v[57] = "Brasilia";
            v[58] = "Santiago";
            v[59] = "Bogota";
            v[60] = "Quito";
            v[61] = "Georgetown";
            v[62] = "Cayenne";
            v[63] = "Asuncion";
            v[64] = "Lima";
            v[65] = "Paramaribo";
            v[66] = "Montevideo";
            v[67] = "Caracas";

            v[68] = "Saint John's";
            v[69] = "Nassau";
            v[70] = "Bridgetown";
            v[71] = "Belmopan";
            v[72] = "Ottawa";
            v[73] = "San Jose";
            v[74] = "Havana";
            v[75] = "Roseau";
            v[76] = "San Salvador";
            v[77] = "Saint George's";
            v[78] = "Ciudad de Guatemala";
            v[79] = "Port-au-Prince";
            v[80] = "Tegucigalpa";
            v[81] = "Kingston";
            v[82] = "Ciudad de Mexico";
            v[83] = "Managua";
            v[84] = "Ciudad de Panama";
            v[85] = "Santo Domingo";
            v[86] = "Basseterre";
            v[87] = "Castries";
            v[88] = "Kingstown";
            v[89] = "Washington DC";
            v[90] = "Port of Spain";

            v[91] = "Kabul";
            v[92] = "Riyadh";
            v[93] = "Erevan";
            v[94] = "Baku";
            v[95] = "Manama";
            v[96] = "Dhaka";
            v[97] = "Thimphu";
            v[98] = "Naypyidaw";
            v[99] = "Bandar Seri Begawan";
            v[100] = "Phnom Penh";
            v[101] = "Beijing";
            v[102] = "Phenian";
            v[103] = "Seul";
            v[104] = "Abu Dhabi";
            v[105] = "Manila";
            v[106] = "Tbilisi";
            v[107] = "New Delhi";
            v[108] = "Jakarta";
            v[109] = "Amman";
            v[110] = "Bagdad";
            v[111] = "Teheran";
            v[112] = "Ierusalim";
            v[113] = "Tokyo";
            v[114] = "Astana";
            v[115] = "Bișkek";
            v[116] = "Kuweit";
            v[117] = "Vientiane";
            v[118] = "Beirut";
            v[119] = "Kuala Lumpur";
            v[120] = "Ulan Bator";
            v[121] = "Kathmandu";
            v[122] = "Muscat";
            v[123] = "Islamabad";
            v[124] = "Doha";
            v[125] = "Moscova";
            v[126] = "Singapore";
            v[127] = "Damasc";
            v[128] = "Colombo";
            v[129] = "Dușanbe";
            v[130] = "Taipei";
            v[131] = "Bangkok";
            v[132] = "Dili";
            v[133] = "Ankara";
            v[134] = "Așgabat";
            v[135] = "Tașkent";
            v[136] = "Hanoi";
            v[137] = "Sana'a";

            v[138] = "Tirana";
            v[139] = "Andorra la Vella";
            v[140] = "Viena";
            v[141] = "Minsk";
            v[142] = "Bruxelles";
            v[143] = "Sarajevo";
            v[144] = "Sofia";
            v[145] = "Praga";
            v[146] = "Nicosia";
            v[147] = "Zagreb";
            v[148] = "Copenhaga";
            v[149] = "Berna";
            v[150] = "Tallinn";
            v[151] = "Helsinki";
            v[152] = "Paris";
            v[153] = "Berlin";
            v[154] = "Atena";
            v[155] = "Dublin";
            v[156] = "Reykjavik";
            v[157] = "Roma";
            v[158] = "Priștina";
            v[159] = "Riga";
            v[160] = "Vaduz";
            v[161] = "Vilnius";
            v[162] = "Luxemburg";
            v[163] = "Skopje";
            v[164] = "Valletta";
            v[165] = "Monaco";
            v[166] = "Podgorica";
            v[167] = "Oslo";
            v[168] = "Amsterdam";
            v[169] = "Varșovia";
            v[170] = "Lisabona";
            v[171] = "Londra";
            v[172] = "Chișinău";
            v[173] = "București";
            v[174] = "San Marino";
            v[175] = "Belgrad";
            v[176] = "Bratislava";
            v[177] = "Ljubljana";
            v[178] = "Madrid";
            v[179] = "Stockholm";
            v[180] = "Kiev";
            v[181] = "Budapesta";
            v[182] = "Vatican";

            v[183] = "Canberra";
            v[184] = "Suva";
            v[185] = "Honiara";
            v[186] = "Wellington";
            v[187] = "Port Moresby";
            v[188] = "Apia";
            v[189] = "Nuku'alofa";
            v[190] = "Port Vila";
            amestecare();
        }

        private void amestecare()
        {
            n = 0;
            label1.Text = "";
            for (int i = 1; i <= 190; i++) r[i] = i;
            Random rand = new Random();
            for (int i = 1; i <= 190; i++)
            {
                index = rand.Next(1, 190);
                temp = r[i];
                r[i] = r[index];
                r[index] = temp;
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (n == 190)
            {
                amestecare();
            }
            else
            {
                n++;
                label1.Text = v[r[n]];
                label1.Location = new Point(this.ClientSize.Width / 2 - label1.Width / 2, this.ClientSize.Height / 2 - label1.Height / 2);
                //pozitionam eticheta pe centrul ecranului la apasarea butonul "next" din cauza lungimii textului din v[r[n]]
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            amestecare();
        }

        private void iesire_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Biblioteca form = new Biblioteca(6);
            form.Show();
            this.Close();
        }
    }
}
