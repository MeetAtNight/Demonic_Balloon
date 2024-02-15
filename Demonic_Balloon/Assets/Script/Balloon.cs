using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    public int points = 1;  // The number of points to award the player when the balloon is destroyed
    public gameController gc;
   
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            gc.AddScore(points);
            // Destroy(gameObject); 
            
        }
        
        
    }
    

}
