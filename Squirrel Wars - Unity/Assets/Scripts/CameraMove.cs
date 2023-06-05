using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Rigidbody2D physicsBody = null;

    // Start is called before the first frame update
    public void CameraMoveRight()
    {
        Vector3 temp = transform.position;
        temp.x += 0.1f;
        GetComponent<Camera>().transform.position = temp;
    }

    public void CameraMoveLeft()
    {
        Vector3 temp = transform.position;
        temp.x -= 0.1f;
        GetComponent<Camera>().transform.position = temp;
    }

    private void Awake()
    {
        physicsBody = GetComponent<Rigidbody2D>();
    }
}
