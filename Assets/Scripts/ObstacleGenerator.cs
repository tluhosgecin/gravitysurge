using System.Collections.Generic;
using UnityEngine;

namespace GravitySurge.Obstacle
{
    public class ObstacleGenerator : MonoBehaviour
    {
        private Vector2[] Positions = new Vector2[]
        { 
            new Vector2(-4.5f, 11f),
            new Vector2(-3f,   11f),
            new Vector2(-1.5f, 11f),
            new Vector2(1.5f,  11f),
            new Vector2(3f,    11f),
            new Vector2(4.5f,  11f),
        };
        
        [Header("Component")]
        public ObstacleModule Reference;

        [Header("Timer")]
        public float Interval = 2f;
        public float Duration = 0f;

        private void Update()
        {
            if (Duration < Interval)
            {
                Duration += Time.deltaTime;
            }
            else
            {
                /*
                **  Creates Random Amount Of Obstacles Every Given Interval.
                */
                foreach (var position in Positions)
                {
                    if (Random.Range(1, 10) <= 2)
                    {
                        Instantiate(Reference).Assign(transform, position);
                    }
                }

                Duration = 0f;
            }
        }
    }
}