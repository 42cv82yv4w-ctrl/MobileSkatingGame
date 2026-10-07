using UnityEngine;
using UnityEngine.UI;

public class CosmeticMenu : MonoBehaviour
{
    public OutfitManager outfitManager;
    public Button shirtBlueButton;
    public Button shirtRedButton;
    public Button shirtGreenButton;

    private void Start()
    {
        if (shirtBlueButton != null) shirtBlueButton.onClick.AddListener(() => SetShirt(Color.blue));
        if (shirtRedButton != null) shirtRedButton.onClick.AddListener(() => SetShirt(Color.red));
        if (shirtGreenButton != null) shirtGreenButton.onClick.AddListener(() => SetShirt(Color.green));
    }

    public void SetShirt(Color color)
    {
        if (outfitManager == null) return;

        outfitManager.shirtColor = color;
        outfitManager.ApplyOutfit();
        outfitManager.SaveOutfit();
    }
}
