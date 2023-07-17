using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAPI
{
    public class AudioController
    {
        public static void PlayStartupSound()
        {
            new System.Media.SoundPlayer("Extras/Audio/Startup.wav").Play();
        }
    }
}
