using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody2D _rigidbody2D;
    private TrajectoryRenderer _trajectoryRenderer;

    public float force;
    public float inpulseForce;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _trajectoryRenderer = GetComponent<TrajectoryRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ImpulseDirection();
        

    }
    
    private void ImpulseDirection()    
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        if (Input.GetMouseButton(0))
        {
            _direction = transform.position - mousePos;
            Debug.DrawRay(transform.position, _direction, Color.red);
            _trajectoryRenderer.ShowTrajectory(transform.position, _direction);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.AddForce(_direction * force, ForceMode2D.Impulse);
            _trajectoryRenderer.ClearPoints();
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.collider.tag == "Enemy")
        {
           
            if(_rigidbody2D.velocity.x < 0)
            {
                _rigidbody2D.AddForce(new Vector2(Random.Range(-4, 0), 5) * inpulseForce, ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(Random.Range(0, 4), 5) * inpulseForce, ForceMode2D.Impulse);
            }

            Debug.DrawRay(collision.collider.transform.position, -collision.contacts[0].normal, Color.red, 2);
            

            Destroy(collision.collider.transform.gameObject);
        }
        
       
    }   
   
}
