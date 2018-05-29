using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomRigidBody))]
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Camera Camera;
    CustomRigidBody body;
    RaycastHit hitInfo;

    void Start()
    {
        if (Camera == null)
            Camera = Camera.main;
        body = GetComponent<CustomRigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBody();
        SetDirection();
    }

    void MoveBody()
    {
        float x = Input.GetAxis("Horizontal") * Speed;
        float z = Input.GetAxis("Vertical") * Speed;

        Vector3 dir = new Vector3(x, 0, z);

        if (dir.sqrMagnitude != 0)
            body.Move(dir, Time.deltaTime);
    }

    void SetDirection()
    {
        if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out hitInfo, 100))
            transform.LookAt(new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z));
    }
}
