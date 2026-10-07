using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    [Header("Ramp Launch")]
    public float launchForce = 12f;
    public Vector3 launchDirection = Vector3.up;

    [Header("Angle")]
    public bool useTransformForward = true;

    private void OnTriggerEnter(Collider other)
    {
        PlayerSkater skater = other.GetComponentInParent<PlayerSkater>();
        if (skater == null) return;

        Vector3 dir = launchDirection;
        if (useTransformForward)
        {
            dir = transform.forward + Vector3.up * 0.5f;
        }

        skater.TriggerRampLaunch(launchForce, dir);
    }
}
