using System.Collections.Generic;
using UnityEngine;

namespace GravitySurge.Audio
{
    /*
    **  Audio Service Implementation.
    */
    public class AudioService : AudioInterface
    {
        private List<AudioClip> Bundle;

        public AudioService(AudioSource source)
        {
            /*
            **  Initializes Source And Available Audio.
            */
            Source = source;
            Bundle = new List<AudioClip>()
            {
                Resources.Load<AudioClip>("Sounds/Contact"),
                Resources.Load<AudioClip>("Sounds/Resolve"),
            };
        }
        
        /*
        **  Plays The Sound With Given Index.
        */
        public override void Play(int index)
        {
            if (index >= Bundle.Count)
            {
                return;
            }

            Source.PlayOneShot(Bundle[index]);
        }

        /*
        **  Stops The Sound With Given Index.
        */
        public override void Stop(int index)
        {
            if (index >= Bundle.Count)
            {
                return;
            }

            Source.Stop();
        }
    }
}