using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inventory")]
    public float wood = 0;
    public float stone = 0;
    public float ore = 0;
    
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Tree Check")]
    public LayerMask Tree;
    bool isTree;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    RaycastHit hitData;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            FireRay();
            if (hitData.collider.gameObject.name == "PT_Pine_Tree_03_green")
            {
                wood += 1;
                hitData.transform.SendMessage("HitByRay");
            }
            if (hitData.collider.gameObject.name == "PT_Generic_Rock_01")
            {
                stone += 1;
                hitData.transform.SendMessage("HitByRay");
            }
            if (hitData.collider.gameObject.name == "PT_Ore_Rock_01")
            {
                ore += 1;
                hitData.transform.SendMessage("HitByRay");
            }
        }

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight + 0.2f, whatIsGround);

        MyInput();

        // handle drag
        if (grounded) 
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        RaycastHit hitInfo; 
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(orientation.position, Vector3.forward, out hitInfo, 1f))
            {
                Debug.DrawRay(orientation.position, Vector3.forward, Color.green);
                Debug.Log(hitInfo.collider.gameObject.name);
            }
        }
        

    }

    void FireRay()
    {
        Ray ray = new Ray(orientation.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        Physics.Raycast(ray, out hitData);
        Debug.Log(hitData.collider.gameObject.name);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
