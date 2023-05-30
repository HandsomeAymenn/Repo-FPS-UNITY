using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform body;

    public float sensitivity = 500f;
    float xClamp = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXaxis = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float mouseYaxis = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;
        xClamp -= mouseYaxis;
        xClamp = Mathf.Clamp(xClamp, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xClamp, 0f, 0f);
        body.Rotate(Vector3.up*mouseXaxis);
    }
}
