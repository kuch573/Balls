using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balls
{
    public class BlueBall : MonoBehaviour
    {

        private BallManager BallManager;
        public BallMove BallMove;
        private Rigidbody2D _rigidbody2D;
        private CircleCollider2D _collider;
        private SpriteRenderer _sprite;
        private BlueBall _blueBall;

        private void Awake()
        {
            _blueBall = GetComponent<BlueBall>();
            BallManager = GameObject.FindWithTag("BallManager").GetComponent<BallManager>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void OnTouch()
        {
            StartCoroutine(Action());
        }
        private IEnumerator Action()
        {
            BallMove.speed = 0f;
            _collider.enabled = false;
            BallManager.CreateYellowBall(transform.position, _blueBall );
            yield return new WaitForSeconds(3.1f);
            BallManager.YellowBalls.Clear();
            _collider.enabled = true;
            BallMove.speed = 0.33f;

        }

        public void destroy()
        {
            Destroy(gameObject);
        }
    }
}