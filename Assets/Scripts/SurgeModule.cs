using UnityEngine;
using GravitySurge.Player;

namespace GravitySurge.Surge
{
    public class SurgeModule : MonoBehaviour
    {
        private static SurgeModule Active = null;
        private        Vector2     Offset = new Vector2(0f, 0f);

        [Header("Component")]
        public Renderer            Renderer;
        public UnityEngine.UI.Text Target;

        [Header("Surge")]
        public float          Duration  = 0f;
        public float          Interval  = 5f;
        public SurgeDirection Direction = SurgeDirection.Positive;

        [Header("Gravity")]
        public float Origin = 10f;
        public float Mutate = 20f;

        /*
        **  Triggered When Player Enters In A Surge Module.
        */
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform.tag == "Player")
            {
                if (Active != this)
                {
                    Active = this;
                }
                
                /*
                **  Sends Bytecode To Player Logic To Be Interpreted.
                */
                PlayerLogic.Interpret(new int[]{ 0x00, (int) (Origin * (int) Direction), 0x03 });
            }
        }

        void Start()
        {
            Target.text = Origin.ToString();
        }
        
        void Update()
        {
            if (Duration < Interval)
            {
                Duration += Time.deltaTime;
            }
            else
            {
                Target.text = (Origin = (float) Random.Range(5, 15)).ToString();
                
                if (Active == this)
                {
                    /*
                    **  Sends Bytecode To Player Logic To Be Interpreted.
                    */
                    PlayerLogic.Interpret(new int[]{ 0x00, (int) (Origin * (int) Direction), 0x03 });
                }

                Duration = 0f;
            }

            /*
            **  Calculetes Texture Offset Value For Surge Visual.
            */
            if (Offset.x >= 1f)
            {
                Offset.x = 0f;
                Offset.y = 0f;
            }
            else
            {
                Offset.x += (Origin / Mutate) * Time.deltaTime;
                Offset.y += 0f;
            }

            Renderer.material.SetTextureOffset("_MainTex", Offset);
        }
    }
}