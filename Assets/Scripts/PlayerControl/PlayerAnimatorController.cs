using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    public string speedZ, speedX;
    int speedZHash, speedXHash;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        speedZHash = Animator.StringToHash(speedZ);
        speedXHash = Animator.StringToHash(speedX);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = -Input.GetAxis("Vertical");

       

        Vector3 dir = Vector3.zero;

        if (x != 0 || z != 0)
        {
            Vector3 cameraDir = Camera.main.transform.forward * x + Camera.main.transform.right * z;
            cameraDir.y = 0;
            cameraDir = cameraDir.normalized;

            float ang = Mathf.Deg2Rad * Vector3.SignedAngle(cameraDir, transform.forward, Vector3.up);
            dir = new Vector3(Mathf.Cos(ang), 0, Mathf.Sin(ang));
        }

        //Vector3 dir = new Vector3((cameraDir.x + transform.forward.x) / 2f, 0, (cameraDir.z + transform.forward.z) / 2f);
        //dir = new Vector3(x * dir.x, 0, z * dir.z);

        //dir = transform.forward * cameraDir.x * 1 + transform.right * cameraDir.z * 1;
        if (Input.GetButton("Sprint"))
            dir *= 2;

        animator.SetFloat(speedXHash, dir.x);
        animator.SetFloat(speedZHash, dir.z);
    }
}
