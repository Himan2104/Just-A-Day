using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSway : MonoBehaviour
{
    private Vector3 defaultRotation = Vector3.zero;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDelta = Mouse.current.position.ReadValue();

        mouseDelta.x -= Screen.width / 2;
        mouseDelta.y -= Screen.height / 2;

        mouseDelta.x /= Screen.width / 2;
        mouseDelta.y /= Screen.height / 2;

        float rotation_x = Mathf.Lerp(defaultRotation.x, defaultRotation.x - (10.0f * mouseDelta.y), 0.1f);
        float rotation_y = Mathf.Lerp(defaultRotation.y, defaultRotation.y + (10.0f * mouseDelta.x), 0.1f);
        Vector3 rotation = new Vector3(rotation_x, rotation_y);
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
