using UnityEngine;

public class GrindRail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerSkater skater = other.GetComponentInParent<PlayerSkater>();
        if (skater == null) return;

        Debug.Log("Grinding rail");
    }
}
