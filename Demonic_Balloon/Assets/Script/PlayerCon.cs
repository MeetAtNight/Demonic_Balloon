using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCon : MonoBehaviour
{
    public float speed = 10.0f;
    public float lookSensitivity = 3.0f;

    private float yRotation = 0.0f;
    
    // Add a reference to the crosshair image
    
    public Texture2D crosshairTexture;
    public int crosshairSize = 16;

    void Start()
    {
        // Lock the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        

        // Set the player's forward direction to the world's Z-axis
        transform.forward = Vector3.forward;
        
    }
    // void OnCollisionEnter(Collision col)
    // {
    //     if (col.gameObject.CompareTag("Projectile"))
    //     {
    //         
    //         Destroy(col.gameObject); 
    //         
    //     }
    //     
    // }

    void OnGUI()
    {
        // Draw a red dot as the crosshair
        GUI.DrawTexture(new Rect((Screen.width - crosshairSize) / 2, (Screen.height - crosshairSize) / 2, crosshairSize, crosshairSize), crosshairTexture);
    }

    void Update()
    {
        // Move player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime, Space.Self);

        // Rotate camera with mouse
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        yRotation += mouseY;
        yRotation = Mathf.Clamp(yRotation, -90.0f, 90.0f);
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(-yRotation, 0.0f, 0.0f);

        // Unlock the mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
