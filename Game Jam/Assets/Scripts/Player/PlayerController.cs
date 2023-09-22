using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; 
    public float movespeed;
    private Rigidbody rb;
    private Vector3 moveImput;
    private Vector2 houseImput;
    private  Vector2 mouseImput;
    public float mouseSensitivty = 1.0f;


    public Camera viewCam; // this refeers to the main camera
    public GameObject bulletImpact;
    public int currentAmmo;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        moveImput = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical")); // getting keybord Inputs
        Vector3 moveH = transform.right * moveImput.x;
        Vector3 moveV = transform.forward * moveImput.z;
        rb.velocity = (moveH + moveV) * movespeed;

        mouseImput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivty;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - mouseImput.x, transform.rotation.eulerAngles.z);


     if(Input.GetMouseButtonDown(0))
     {
        if(currentAmmo > 0)
        {
             Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
             RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(" I'm looking at " + hit.transform.name);
                Instantiate(bulletImpact, hit.point, transform.rotation);
            }
            else
            {
                Debug.Log(" Not looking at anyting ");
            }
        }
     }
    }
}
