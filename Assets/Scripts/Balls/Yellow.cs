using System;
using System.Collections;
using UnityEngine;

namespace Balls
{
    public class Yellow : MonoBehaviour
    {
        private LineRenderer _line;
        private BallManager BallManager;
        private BlueBall _blueBall;

        public void Constract(BlueBall blueBall)
        {
            _blueBall = blueBall;
        }
        
        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
            _line.useWorldSpace = true;
            _line.SetColors (Color.green, Color.green);
            BallManager = GameObject.FindWithTag("BallManager").GetComponent<BallManager>();
        }

        private void Update()
        {
            StartCoroutine(Search());
        }

        private IEnumerator Search()
        {
            yield return new WaitForSeconds(3);
            foreach (var yellowBall in BallManager.YellowBalls)
            {
                if (BallManager.YellowBalls.Count <= 1)
                {
                    Destroy(gameObject);
                }
                else
                {
                    yellowBall.GetComponent<Yellow>()._blueBall.destroy();
                    Destroy(yellowBall);
                    //_line.SetVertexCount(BallManager.YellowBallsPosition.Count);
                    //_line.SetPosition(BallManager.YellowBallsPosition.Count - 1, (Vector3)BallManager.YellowBallsPosition [BallManager.YellowBallsPosition.Count - 1]);

                }
            }
            BallManager.YellowBalls.Clear();
            BallManager.YellowBallsPosition.Clear();
        }
    }
}