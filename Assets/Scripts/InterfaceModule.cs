using UnityEngine;
using GravitySurge.Audio;
using GravitySurge.Scanner;

namespace GravitySurge.Interface
{
    public class InterfaceModule : MonoBehaviour
    {
        [Header("Component")]
        public GameObject Conclusion;

        private void OnEnable()
        {
            /*
            **  Inserts Event Connection.
            */
            ScannerModule.OnScan += Conclude;
        }

        private void OnDisable()
        {
            /*
            **  Removes Event Connection.
            */
            ScannerModule.OnScan -= Conclude;
        }

        private void Start()
        {
            Conclusion.SetActive(false);
        }

        /*
        **  Concludes The Game On Event Call.
        */
        private void Conclude()
        {
            Time.timeScale = 0f;

            AudioLocator.GetAudio().Play(0);
            AudioLocator.GetAudio().Play(1);
            
            Conclusion.SetActive(true);
        }
    }
}