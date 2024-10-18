using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float minOrthoSize = 1;
    [SerializeField] private float maxOrthoSize = 15;
    [SerializeField] private float minPerspFov = 10;
    [SerializeField] private float maxPerspFov = 120;

    [SerializeField] private float cameraZoomMultiplier = -1 / 1200;

    
    private Actions actions;
    private InputAction mouseZoomAction;

    void Awake()
    {
        actions = new Actions();
        mouseZoomAction = actions.camera.zoom;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float zoomInput = mouseZoomAction.ReadValue<float>();
        Debug.Log(zoomInput);

        Camera.main.orthographicSize *= 1 + (zoomInput * cameraZoomMultiplier);
        Camera.main.fieldOfView *= 1 + (zoomInput * cameraZoomMultiplier);


        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minOrthoSize, maxOrthoSize);
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minPerspFov, maxPerspFov);
    }
}
