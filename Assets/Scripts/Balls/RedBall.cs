using UnityEngine;

namespace Balls
{
    public class RedBall : MonoBehaviour
    {
        public void OnTouch()
        {
            Destroy(gameObject);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(Resources.Load("RedClick"), transform.position, Quaternion.identity);
            }
        }
    }
}