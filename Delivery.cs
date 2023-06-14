using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage;
    SpriteRenderer spriteRenderer;
   
    // 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    [SerializeField] float destroyDelay = 0.5f ;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Occured");
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {   
       
        if (other.tag == "Package" && !hasPackage) 
        {
            Debug.Log("Package Picked");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject , destroyDelay);
        }
        if (other.tag == "Delivery" && hasPackage) 
        {   
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
    }
    
    
}
}