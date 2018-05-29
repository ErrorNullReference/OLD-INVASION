using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Steamworks;

[RequireComponent(typeof(CustomRigidBody))]
public class SimpleController : MonoBehaviour
{
    public float Speed;
    WaitForSeconds waitForSeconds;
    CustomRigidBody body;

    void Start()
    {
        body = GetComponent<CustomRigidBody>();
        waitForSeconds = new WaitForSeconds(0.1f);
        StartCoroutine(SendTransform());
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Speed;
        float z = Input.GetAxis("Vertical") * Speed;

        Vector3 dir = new Vector3(x, 0, z);

        if (dir.sqrMagnitude != 0)
        {
            body.Move(dir, Time.deltaTime);
            transform.forward = dir;
        }
    }

    IEnumerator SendTransform()
    {
        while (true)
        {
            Client.SendTransformToHost(transform, EP2PSend.k_EP2PSendUnreliable);
            yield return waitForSeconds;
        }
    }
}
