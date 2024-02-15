using UnityEngine;

public class Floor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}