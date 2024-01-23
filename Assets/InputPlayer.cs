using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private PlayerInput _pI;
    public float movementSpeed = 15f; // Ajusta la velocidad de movimiento según tus necesidades
    private Vector2 currentMovement;
    private Animator animator;

    void Awake()
    {
        _pI = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _pI.actions["Movement"].performed += StartMove;
        _pI.actions["Movement"].canceled += StopMove;
    }

    private void OnDisable()
    {
        _pI.actions["Movement"].performed -= StartMove;
        _pI.actions["Movement"].canceled -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        currentMovement = ctx.ReadValue<Vector2>();
        Debug.Log("Start Moving: " + currentMovement);
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        currentMovement = Vector2.zero;
        Debug.Log("Stop Moving");
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(currentMovement.x, currentMovement.y);
        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        animator.SetFloat("PosX", currentMovement.x);
        animator.SetFloat("PosY", currentMovement.y);
    }
}