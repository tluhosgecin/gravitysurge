using UnityEngine;

namespace GravitySurge.Timer
{
    public class TimerModule : MonoBehaviour
    {
        [Header("Component")]
        public UnityEngine.UI.Text Target;

        [Header("Timer")]
        public int   Seconds  = 0;
        public int   Minutes  = 0;
        public float Duration = 0f;
        public float Interval = 60f;

        private void Start()
        {
            Target.text = (Minutes.ToString("D2") + ":" + Seconds.ToString("D2"));
        }

        private void Update()
        {
            /*
            **  Counts Time For The Timer Display On The Interface.
            */
            Duration += Time.deltaTime;

            Minutes = (int) (Duration / Interval);
            Seconds = (int) (Duration % Interval);

            Target.text = (Minutes.ToString("D2") + ":" + Seconds.ToString("D2"));
        }
    }
}