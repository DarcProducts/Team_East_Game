using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool IsRotating;
    [SerializeField] Vector3 rotationVector;

    void FixedUpdate()
    {
        if (!IsRotating) return;
        transform.Rotate(Time.fixedDeltaTime * rotationVector, Space.Self);
    }
}
