using System.Collections;
using UnityEngine;

namespace Balls
{
    public class RedBallClick : MonoBehaviour
    {
        private Vector3 _scale;

        private void Awake()
        {
            _scale = new Vector3(0,0,0);
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _scale, Time.deltaTime);
            StartCoroutine(Remove());
        }

        private IEnumerator Remove()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}