using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throwing : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public GameObject objectToThrowCurveL;
    public GameObject objectToThrowCurveR;
    
    public int totalThrows;
    public float throwCooldown;
    public Text failText;
    
    
    
    public KeyCode throwKey = KeyCode.Mouse0;
    public KeyCode throwCurveKeyL = KeyCode.Q;
    public KeyCode throwCurveKeyR = KeyCode.E;
    public float throwForce;
    public float throwUpwardForce;
    

    bool readyToThrow;

    private void Start()
    {
        failText.gameObject.SetActive(false);
        readyToThrow = true;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw(objectToThrow);
        }
        else if (Input.GetKeyDown(throwCurveKeyL) && readyToThrow && totalThrows > 0)
        {
            Throw(objectToThrowCurveL);
        }
        else if (Input.GetKeyDown(throwCurveKeyR) && readyToThrow && totalThrows > 0)
        {
            Throw(objectToThrowCurveR);
        }

    }
    
    public void FailGame()
    {
        failText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    private void Throw(GameObject obj)
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(obj, attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        
        Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        
        totalThrows--;
        if (totalThrows == 0)
        {
            FailGame();
        }


        Invoke(nameof(ResetThrow), throwCooldown);
        
    }
    
    
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
