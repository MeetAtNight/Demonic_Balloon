using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTarget : MonoBehaviour
{
    public int points = 1;
    public gameController gc;
   
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            gc.AddScore(points);
            Destroy(gameObject); 
            
        }
        
        
    }
}
