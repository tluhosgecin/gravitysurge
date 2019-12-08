using UnityEngine;
using GravitySurge.Player;

namespace GravitySurge.Barrier
{
    public class BarrierModule : MonoBehaviour
    {
        [Header("Barrier")]
        public int Index = 0;

        /*
        **  Detects Collision Enter Of Player.
        */
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                /*
                **  Sends Bytecode To Player Logic To Be Interpreted.
                */
                PlayerLogic.Interpret(new int[] { 0x00, Index, 0x01});
            }
        }
        
        /*
        **  Detects Collision Exit Of Player.
        */
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                /*
                **  Sends Bytecode To Player Logic To Be Interpreted.
                */
                PlayerLogic.Interpret(new int[] { 0x00, 0, 0x01});
            }
        }
    }
}