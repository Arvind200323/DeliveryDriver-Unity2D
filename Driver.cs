using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.001f;
    [SerializeField] float bumpSpeed = 0.0005f;
    [SerializeField] float boostSpeed = 0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // Input of movement and steer
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount =  Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
        

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        boostSpeed=moveSpeed;
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Bump") moveSpeed=bumpSpeed;
        if(other.tag =="Boost") moveSpeed=boostSpeed;
    }
}
