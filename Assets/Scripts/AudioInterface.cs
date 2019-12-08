using UnityEngine;

namespace GravitySurge.Audio
{
    /*
    **  Audio Service Interface.
    */
    public class AudioInterface
    {
        protected AudioSource Source;
        
        public virtual void Play(int index) {}
        public virtual void Stop(int index) {}
    }
}