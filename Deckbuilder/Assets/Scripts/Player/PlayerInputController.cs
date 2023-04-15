using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour,PlayerControllers.IPlayerControllerActions
{
    private PlayerControllers _playerControllers;
    private Camera mainCamera;

    [SerializeField] private float mouseDragSpeed = .1f;
    private Vector3 velocity = Vector3.zero;

    private WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        _playerControllers = new PlayerControllers();
        _playerControllers.PlayerController.SetCallbacks(this);
        _playerControllers.Enable();
    }

    void StartDrag()
    {
        print("StartDrag");
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") ||
                                     hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") ||
                                     hit.collider.gameObject.GetComponent<IDrag>() != null))
        {
            StartCoroutine(DragUpdate(hit.collider.gameObject));
        }

}

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        iDragComponent?.OnStartDrag();
        while (_playerControllers.PlayerController.Click.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position,
                ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
            yield return null;
        }
        iDragComponent?.OnEndDrag();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        StartDrag();
    }
}
