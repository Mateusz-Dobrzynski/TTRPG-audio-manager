using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace TTRPG_Audio_Manager
{
    /// <summary>
    /// Creating an instance of this class performs registration and
    /// initialization of the Bass library. Performing registration
    /// is necessary to use the Bass library
    /// </summary>
    public class Registration
    {   
        public Registration()
        {
            //Registration. E-mail address and registration key must be provided to register successfully
            Un4seen.Bass.BassNet.Registration("mateusz.dobrzynski64@gmail.com", "2X2233330152222");
            //Initializing BASS library
            bool initializationResult = Bass.BASS_Init(-1, 48000, BASSInit.BASS_DEVICE_FREQ, IntPtr.Zero);
            if (initializationResult != true) throw new Exception("Bass initialization error");
        }
    }
}
