using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] public float speed = 1f;
    private Vector2 _direction;
    public float x;
    public float y;
    public bool randomX;
    public bool randomY;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (randomX == true)
        {
            _direction = new Vector2(Random.Range(0.5f,1),y);
        }else
        if (randomY == true)
        {
            _direction = new Vector2(x,Random.Range(0.5f,1));
        }else
            _direction = new Vector2(x,y);
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = _direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BottomWall")) 
        {
            _direction.y = -_direction.y;
        }
        if (collision.gameObject.CompareTag("SideWall")) 
        {
            _direction.x = -_direction.x;
        }
    }
    
}
