using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnummerKollen
{
    internal class Toolbox
    {
        // Slå samman födelsedag och de tre första av de fyra sista
        public static string Concat(string fodelseDag, string treAvFyra)
        {
            string s1 = fodelseDag;
            string s2 = treAvFyra;
            string s = s1 + s2;
            string fodelseDagOchTreAvFyra = s;
            return fodelseDagOchTreAvFyra;
        }

        // Beräkna närmsta 10-tal uppåt
        public static int RoundUp(int horizSum)
        {
            // === Knyckt från stackoverflow ====
            double horizSumRoundUp = (double)horizSum / 10;     // Casta till double och dela med 10 för att få ett decimaltal
            horizSumRoundUp = Math.Ceiling(horizSumRoundUp);    // Runda av uppåt till närmsta heltal om talet inte är jämt
            horizSumRoundUp = horizSumRoundUp * 10;             // Multiplicera med 10 igen för att få närmsta 10-tal uppåt
            return (int)horizSumRoundUp;
        }
    }
}
