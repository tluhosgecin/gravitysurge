using UnityEngine;

namespace GravitySurge.Audio
{
    public class AudioModule : MonoBehaviour
    {
        [Header("Component")]
        public AudioSource Source;
        
        private void Start()
        {
            /*
            **  Initialize Audio Service Locator.
            */
            AudioLocator.Provide(new AudioService(Source));
        }
    }
}