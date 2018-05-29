using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CustomRigidBody : MonoBehaviour
{
    public bool UseGravity;
    public LayerMask CustomMask;
    Collider[] results;
    Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();

        results = new Collider[1];
    }

    void Update()
    {
        if (UseGravity)
            ApplyGravity();
    }

    void ApplyGravity()
    {
        Move(Physics.gravity, Time.deltaTime);
    }

    public void Move(Vector3 direction, float time)
    {
        Vector3 position = transform.position + direction * time;

        if (TryMove(position, GetRightExtent(direction)))
            transform.position = position;
    }

    bool TryMove(Vector3 position, float radius)
    {
        if (Physics.OverlapSphereNonAlloc(position, radius, results, CustomMask.value) >= 1)
            return false;
        return true;
    }

    float GetRightExtent(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
            return collider.bounds.extents.x;
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) && Mathf.Abs(direction.y) > Mathf.Abs(direction.z))
            return collider.bounds.extents.y;
        else
            return collider.bounds.extents.z;
    }
}
