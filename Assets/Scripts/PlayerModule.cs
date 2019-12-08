using UnityEngine;
using GravitySurge.Audio;
using GravitySurge.Command;

namespace GravitySurge.Player
{
    public class PlayerModule : MonoBehaviour
    {
        private Vector2 Velocity = new Vector2(0f, 0f);

        [Header("Component")]
        public Rigidbody2D Rigidbody;

        [Header("Gravity")]
        public float Origin = 0;
        public bool  Motion = true;

        [Header("Trigger")]
        public float Charge = 0f;
        public int   Cutoff = 15;
        public int   Course = 0;
        
        private void OnEnable()
        {
            /*
            **  Inserts Event Connection.
            */
            PlayerLogic.OnBarrier += Barrier;
            PlayerLogic.OnTrigger += Trigger;
            PlayerLogic.OnGravity += Gravity;
        }

        private void OnDisable()
        {
            /*
            **  Removes Event Connection.
            */
            PlayerLogic.OnBarrier -= Barrier;
            PlayerLogic.OnTrigger -= Trigger;
            PlayerLogic.OnGravity -= Gravity;
        }

        private void Start()
        {
            /*
            **  Registers Player Specific Input Commands.
            */
            CommandHandler.Register(CommandType.LMouse, new CommandTrigger(20f, +1));
            CommandHandler.Register(CommandType.RMouse, new CommandTrigger(20f, -1));

            /*
            **  Resets Instruction Count On Start.
            */
            PlayerLogic.Reset();
        }

        private void Update()
        {
            if (Motion == false)
            {
                Velocity.x = Charge = 0f;
                Velocity.y = 0f;
            }
            else
            {
                Velocity.x = Charge += (Origin * Time.deltaTime);
                Velocity.y = 0f;
            }

            Rigidbody.velocity = Velocity;
        }

        /*
        **  Called When Player Collides With A Barrier.
        */
        private void Barrier(int value)
        {
            switch (value)
            {
                case 0:
                {
                    Course = 0;
                    Motion = true;

                    break;
                }

                case 1:
                {
                    Course = 1;
                    Motion = false;

                    AudioLocator.GetAudio().Play(0);

                    break;
                }

                case 2:
                {
                    Course = 2;
                    Motion = false;

                    AudioLocator.GetAudio().Play(0);

                    break;
                }
            }
        }

        /*
        **  Called When User Triggers Related Input.
        */
        private void Trigger(int value)
        {
            if (value > 0)
            {
                value = (value > +Cutoff) ? +Cutoff : value;
            }
            else
            {
                value = (value < -Cutoff) ? -Cutoff : value;
            }

            if (Motion == true)
            {
                Charge = (float) value;
            }
            else
            {
                switch (Course)
                {
                    case 1:
                    {
                        Charge = (value < 0) ? 0f    : (float) value;
                        Motion = (value < 0) ? false : true;
                        
                        break;
                    }

                    case 2:
                    {
                        Charge = (value > 0) ? 0f    : (float) value;
                        Motion = (value > 0) ? false : true;
                        
                        break;
                    }
                }
            }
        }
        
        /*
        **  Called When Player Enters In A Surge Module Or Gravity Changes.
        */
        private void Gravity(int value)
        {
            Origin = (float) value;
        }
    }
}