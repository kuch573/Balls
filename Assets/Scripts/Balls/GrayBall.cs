using System;
using System.Collections;
using UnityEngine;

namespace Balls
{
    public class GrayBall : MonoBehaviour
    {
        public BallMove BallMove;
        private Rigidbody2D _rigidbody2D;
        private CircleCollider2D _collider2D;
        private bool _ignore = false;
        private Vector2 force = new Vector2(0,50);

        private void Awake()
        {
            _collider2D = GetComponent<CircleCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void OnTouch()
        {
            StartCoroutine(Jump());
        }

        private IEnumerator Jump()
        {
            BallMove.enabled = false;
            _ignore = true;
            _rigidbody2D.velocity = force.normalized * BallMove.speed * 1.2f;
            //_rigidbody2D.AddForce(force);
            yield return new WaitForSeconds(3);
            _ignore = false;
            BallMove.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.CompareTag("BottomWall") && _ignore == true)
            {
                BallMove.enabled = false;
                _rigidbody2D.velocity = force.normalized * BallMove.speed * 1.2f;
                Physics2D.IgnoreCollision(collision2D.collider,_collider2D);
                StartCoroutine(DestroyTimer());
            } 
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}