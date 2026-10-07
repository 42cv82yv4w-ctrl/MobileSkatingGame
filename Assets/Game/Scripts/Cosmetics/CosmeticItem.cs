using UnityEngine;

public class CosmeticItem : MonoBehaviour
{
    public string itemId;
    public string itemName;
    public Sprite icon;
    public int cost;
    public bool unlocked;

    public void Equip()
    {
        Debug.Log("Equipped: " + itemName);
    }
}
