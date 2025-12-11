using UnityEngine;

public class InfoPanelFolowCamera : MonoBehaviour
{
    public float distance = 2.0f; 
    public float heightOffset = 0.5f; 

    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform; 
    }

    void OnEnable()
    {
        PositionPanel();
    }

    void Update()
    {
        transform.LookAt(cam);
        transform.Rotate(0, 180, 0); 
    }

    public void PositionPanel()
    {
        if (cam == null) return;

        Vector3 forwardPos = cam.position + cam.forward * distance;
        forwardPos.y += heightOffset;
        transform.position = forwardPos;

        transform.LookAt(cam);
        transform.Rotate(0, 180, 0);
    }
}
