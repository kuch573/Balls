using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Balls
{
    public class DarkRedBall : MonoBehaviour
    {
        private BallManager BallManager;
        public int Counter;

        private bool Equals = false;

        public Text counterText;

        private void Awake()
        {
            BallManager = GameObject.FindWithTag("BallManager").GetComponent<BallManager>();
            Counter = Random.Range(1, 5);
            CheckBall();
            if (Equals == true)
            {
                Counter++;
            }
            counterText.text = Counter.ToString();
            
        }

        private void Update()
        {
            CheckBall();
            if (Equals == true)
            {
                foreach (var ball in BallManager.DarkRedBalls)
                {
                    Destroy(ball);
                }

                BallManager.DarkRedBalls.Clear();
            }
        }

        private void CheckBall()
        {
            foreach (var ball in BallManager.DarkRedBalls)
            {
                if (Counter == ball.GetComponent<DarkRedBall>().Counter)
                {
                    Equals = true;
                }
                else
                {
                    Equals = false;
                    return;
                }
            }
        }

        public void OnTouch()
        {
            if (Counter > 0 && Counter < 5)
            {
                Counter += 1;
                counterText.text = Counter.ToString();
            }
            else
            {
                Counter = 1;
                counterText.text = Counter.ToString();
            }

            
        }
    }
}