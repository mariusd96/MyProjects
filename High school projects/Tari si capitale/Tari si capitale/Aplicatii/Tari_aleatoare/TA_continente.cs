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
    public partial class TA_continente : Form
    {
        string[] v = new string[200];//vector de tari
        int[] r = new int[200];//vector in care elementele sale se vor amesteca
        int n, index, temp;
        public TA_continente()
        {
            InitializeComponent();
            v[1] = "Africa de Sud";
            v[2] = "Algeria";
            v[3] = "Angola";
            v[4] = "Benin";
            v[5] = "Botswana";
            v[6] = "Burkina Faso";
            v[7] = "Burundi";
            v[8] = "Camerun";
            v[9] = "Ciad";
            v[10] = "Coasta de Fildeş";
            v[11] = "Comore";
            v[12] = "Djibouti";
            v[13] = "Egipt";
            v[14] = "Eritreea";
            v[15] = "Etiopia";
            v[16] = "Gabon";
            v[17] = "Gambia";
            v[18] = "Ghana";
            v[19] = "Guineea";
            v[20] = "Guineea-Bissau";
            v[21] = "Guineea-Ecuatorială";
            v[22] = "Insulele Capului Verde";
            v[23] = "Kenya";
            v[24] = "Lesotho";
            v[25] = "Liberia";
            v[26] = "Libia";
            v[27] = "Madagascar";
            v[28] = "Malawi";
            v[29] = "Mali";
            v[30] = "Maroc";
            v[31] = "Mauritania";
            v[32] = "Mauritius";
            v[33] = "Mozambic";
            v[34] = "Namibia";
            v[35] = "Niger";
            v[36] = "Nigeria";
            v[37] = "Republica Centrafricană";
            v[38] = "Republica Congo";
            v[39] = "Republica Democrată Congo";
            v[40] = "Rwanda";
            v[41] = "Sao Tome şi Principe";
            v[42] = "Senegal";
            v[43] = "Seychelles";
            v[44] = "Sierra Leone";
            v[45] = "Somalia";
            v[46] = "Sudan";
            v[47] = "Sudanul de Sud";
            v[48] = "Swaziland";
            v[49] = "Tanzania";
            v[50] = "Togo";
            v[51] = "Tunisia";
            v[52] = "Uganda";
            v[53] = "Zambia";
            v[54] = "Zimbabwe";

            v[55] = "Antigua şi Barbuda";
            v[56] = "Bahamas";
            v[57] = "Barbados";
            v[58] = "Belize";
            v[59] = "Canada";
            v[60] = "Costa Rica";
            v[61] = "Cuba";
            v[62] = "Dominica";
            v[63] = "El Salvador";
            v[64] = "Grenada";
            v[65] = "Guatemala";
            v[66] = "Haiti";
            v[67] = "Honduras";
            v[68] = "Jamaica";
            v[69] = "Mexic";
            v[70] = "Nicaragua";
            v[71] = "Panama";
            v[72] = "Republica Dominicană";
            v[73] = "Saint Kitts şi Nevis";
            v[74] = "Saint Lucia";
            v[75] = "Saint Vicent și Grenadine";
            v[76] = "Statele Unite ale Americii";
            v[77] = "Trinidad şi Tobago";

            v[78] = "Argentina";
            v[79] = "Bolivia";
            v[80] = "Brazilia";
            v[81] = "Chile";
            v[82] = "Columbia";
            v[83] = "Ecuador";
            v[84] = "Guyana";
            v[85] = "Guyana Franceză";
            v[86] = "Paraguay";
            v[87] = "Peru";
            v[88] = "Surinam";
            v[89] = "Uruguay";
            v[90] = "Venezuela";

            v[91] = "Afganistan";
            v[92] = "Arabia Saudită";
            v[93] = "Armenia";
            v[94] = "Azerbaidjan";
            v[95] = "Bahrain";
            v[96] = "Bangladesh";
            v[97] = "Bhutan";
            v[98] = "Birmania";
            v[99] = "Brunei";
            v[100] = "Cambodgia";
            v[101] = "China";
            v[102] = "Coreea de Nord";
            v[103] = "Coreea de Sud";
            v[104] = "Emiratele Arabe Unite";
            v[105] = "Filipine";
            v[106] = "Georgia";
            v[107] = "India";
            v[108] = "Indonezia";
            v[109] = "Iordania";
            v[110] = "Irak";
            v[111] = "Iran";
            v[112] = "Israel";
            v[113] = "Japonia";
            v[114] = "Kazahstan";
            v[115] = "Kârgâzstan";
            v[116] = "Kuweit";
            v[117] = "Laos";
            v[118] = "Liban";
            v[119] = "Malaezia";
            v[120] = "Mongolia";
            v[121] = "Nepal";
            v[122] = "Oman";
            v[123] = "Pakistan";
            v[124] = "Qatar";
            v[125] = "Rusia";
            v[126] = "Singapore";
            v[127] = "Siria";
            v[128] = "Sri Lanka";
            v[129] = "Tadjikistan";
            v[130] = "Taiwan";
            v[131] = "Thailanda";
            v[132] = "Timorul de Est";
            v[133] = "Turcia";
            v[134] = "Turkmenistan";
            v[135] = "Uzbekistan";
            v[136] = "Vietnam";
            v[137] = "Yemen";

            v[138] = "Albania";
            v[139] = "Andorra";
            v[140] = "Austria";
            v[141] = "Belarus";
            v[142] = "Belgia";
            v[143] = "Bosnia şi Herţegovina";
            v[144] = "Bulgaria";
            v[145] = "Cehia";
            v[146] = "Cipru";
            v[147] = "Croaţia";
            v[148] = "Danemarca";
            v[149] = "Elveţia";
            v[150] = "Estonia";
            v[151] = "Finlanda";
            v[152] = "Franţa";
            v[153] = "Germania";
            v[154] = "Grecia";
            v[155] = "Irlanda";
            v[156] = "Islanda";
            v[157] = "Italia";
            v[158] = "Kosovo";
            v[159] = "Letonia";
            v[160] = "Lichtenstein";
            v[161] = "Lituania";
            v[162] = "Luxemburg";
            v[163] = "Macedonia";
            v[164] = "Malta";
            v[165] = "Monaco";
            v[166] = "Muntenegru";
            v[167] = "Norvegia";
            v[168] = "Olanda";
            v[169] = "Polonia";
            v[170] = "Portugalia";
            v[171] = "Regatul Unit";
            v[172] = "Republica Moldova";
            v[173] = "România";
            v[174] = "San Marino";
            v[175] = "Serbia";
            v[176] = "Slovacia";
            v[177] = "Slovenia";
            v[178] = "Spania";
            v[179] = "Suedia";
            v[180] = "Ucraina";
            v[181] = "Ungaria";
            v[182] = "Vatican";

            v[183] = "Australia";
            v[184] = "Fiji";
            v[185] = "Insulele Solomon";
            v[186] = "Noua Zeelandă";
            v[187] = "Papua Noua Guinee";
            v[188] = "Samoa";
            v[189] = "Tonga";
            v[190] = "Vanuatu";
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
            }//in ciclul for amestecam elementele din vectorul r
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

            Biblioteca form = new Biblioteca(5);
            form.Show();
            this.Close();
        }
    }
}
