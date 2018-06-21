using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Diagnostics;

namespace NeverBoardSoftwareApplicatie.SchaakSpelKlassen
{
    class SoundFuncties
    {
        private static bool valid;
        static public void PlayLoopSound(SoundPlayer player, SchaakSpel.Type type)
        {
            GetLoopSound(type);
            if (valid)
            {
                player.SoundLocation = GetLoopSound(type);
                player.Play();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.ElapsedMilliseconds < 4000) { };
                player.Stop();
                stopWatch.Stop();
            }
        }

        static private string GetLoopSound(SchaakSpel.Type type)
        {
            valid = true;
            switch (type)
            {
                case SchaakSpel.Type.Toren:
                    return RetrieveSoundLocation("TorenLoop");
                case SchaakSpel.Type.Paard:
                    return RetrieveSoundLocation("PaardLoop");
                case SchaakSpel.Type.Konigin:
                    return RetrieveSoundLocation("KoninginLoop");
                case SchaakSpel.Type.Pion:
                    return RetrieveSoundLocation("Pionloop");
                case SchaakSpel.Type.Koning:
                    return RetrieveSoundLocation("KoningLoop");
                default:
                    valid = false;
                    return null;
            }
        }

        static public void PlayAanvalSound(SoundPlayer player, SchaakSpel.Type type)
        {
            GetAanvalSound(type);
            if (valid)
            {
                player.SoundLocation = GetAanvalSound(type);
                player.Play();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.ElapsedMilliseconds < 4000) { };
                player.Stop();
                stopWatch.Stop();
            }
        }

        static private string GetAanvalSound(SchaakSpel.Type type)
        {
            valid = true;
            switch (type)
            {
                case SchaakSpel.Type.Konigin:
                    return RetrieveSoundLocation("KoninginAanval");
                case SchaakSpel.Type.Pion:
                    return RetrieveSoundLocation("PionAanval");
                case SchaakSpel.Type.Koning:
                    return RetrieveSoundLocation("KoningAanval");
                case SchaakSpel.Type.Loper:
                    return RetrieveSoundLocation("LoperAanval");
                case SchaakSpel.Type.Toren:
                    return RetrieveSoundLocation("TorenAanval");
                default:
                    valid = false;
                    return null;
            }
        }

        private static string RetrieveSoundLocation(string BestandNaam)
        {
            return System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Geluiden\" + BestandNaam + ".wav";
        }
    }
}
