using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBillboard : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;

    void Update()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        Vector3 targetPosition = targetCamera.transform.position;
        Vector3 lookAtPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        transform.LookAt(lookAtPosition);

        
        transform.Rotate(0, 180f, 0);
    }
}
