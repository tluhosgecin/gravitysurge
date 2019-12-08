using UnityEngine;
using GravitySurge.Player;

namespace GravitySurge.Scanner
{
    public class ScannerModule : MonoBehaviour
    {
        public delegate void  Scan();
        public static   event Scan OnScan;

        [Header("Scanner")]
        public bool Active = true;
        
        /*
        **  Triggered When Player Enters In A Scanner Module.
        */
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform.tag == "Player")
            {
                if (Active == true && OnScan != null)
                {
                    OnScan();
                }
            }
        }
    }
}