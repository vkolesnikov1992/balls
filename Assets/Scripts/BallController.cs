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
    public float Energy = 250;

    bool shot;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _trajectoryRenderer = GetComponent<TrajectoryRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ImpulseDirection();
        

    }

    private void Update()
    {
        Debug.DrawRay(transform.position, _rigidbody2D.velocity, Color.red);
        transform.right = _rigidbody2D.velocity;
        
       
    }

    private void ImpulseDirection()    
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        if (Input.GetMouseButton(0) && Energy > 0)
        {
            _direction = transform.position - mousePos;            
            _trajectoryRenderer.ShowTrajectory(transform.position, _direction.normalized * 30 );
            Energy -= Time.deltaTime * 5;
            TimeDilationON();
            
            shot = true;

        }

         else if (shot && Energy > 0)
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.AddForce(_direction.normalized * force, ForceMode2D.Impulse);
            _trajectoryRenderer.ClearPoints();
            Energy -= 50;
            TimeDilationOff();            
            shot = false;
            
            
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

            Energy += 50;
            

            Destroy(collision.collider.transform.gameObject);
        }

        if(collision.collider.tag == "Finish")
        {
            Debug.Log("Finish");
        }
       
    }   

    private void TimeDilationON()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    private void TimeDilationOff()
    {
        Time.timeScale = 1.0f;
    }

}
