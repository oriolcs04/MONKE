using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator animator;
    private bool InventoryVisible = false;
    GameObject inventario_com;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        inventario_com = GameObject.FindGameObjectWithTag("inventario_com");
        inventario_com.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("PosX", moveX);
        animator.SetFloat("PosY", moveY);

        //Nuevo
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (!InventoryVisible)
            {
                InventoryVisible = true;
                inventario_com.SetActive(!InventoryVisible);
                GameObject.FindGameObjectWithTag("general-events").GetComponent<InventoryController>().showInventory();
            }
            else
            {
                InventoryVisible = false;
                inventario_com.SetActive(InventoryVisible);
            }
        }
 
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}