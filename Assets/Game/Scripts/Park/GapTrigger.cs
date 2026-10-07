using UnityEngine;

public class GapTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerSkater skater = other.GetComponentInParent<PlayerSkater>();
        if (skater == null) return;

        Debug.Log("Gap detected");
    }
}
