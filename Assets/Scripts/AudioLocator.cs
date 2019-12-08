using System.Collections.Generic;

namespace GravitySurge.Audio
{
    /*
    **  Singleton Service Locator.
    */
    public class AudioLocator
    {
        private static AudioInterface Service;

        /*
        **  Singleton Implementation.
        */
        public static AudioInterface GetAudio()
        {
            /*
            **  Null Service Implementation.
            */
            if (Service == null)
            {
                Service = new AudioInterface();
            }

            return Service;
        }

        /*
        **  Provide A Service To Be Used As A Valid Service.
        */
        public static void Provide(AudioInterface service)
        {
            Service = service;
        }
    }
}