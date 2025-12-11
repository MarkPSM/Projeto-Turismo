using UnityEngine;
using UnityEngine.InputSystem;

public class PinInteractionManager : MonoBehaviour
{
    [Header("Referências")]
    public Camera mainCamera;
    public GameObject globe;
    private GameObject currentInfoCanvas;
    private bool isInfoOpen = false;

    [Header("Input Action")]
    public InputActionProperty backAction;

    private void OnEnable()
    {
        if (backAction != null)
            backAction.action.performed += OnBackPressed;
    }

    private void OnDisable()
    {
        if (backAction != null)
            backAction.action.performed -= OnBackPressed;
    }

    private void Update()
    {
        if (isInfoOpen) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                PinInteraction pin = hit.collider.GetComponent<PinInteraction>();
                if (pin != null)
                {
                    currentInfoCanvas = pin.infoCanvas;
                    AbrirInfo(pin);
                }
            }
        }
    }

    private void AbrirInfo(PinInteraction pin)
    {
        if (pin.infoCanvas != null)
        {
            pin.infoCanvas.SetActive(true);
            globe.SetActive(true);
            isInfoOpen = true;
        }
    }

    private void OnBackPressed(InputAction.CallbackContext ctx)
    {
        if (isInfoOpen && currentInfoCanvas != null)
        {
            currentInfoCanvas.SetActive(false);
            globe.SetActive(true);
            isInfoOpen = false;
        }
    }
}
