using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [Header("Character Parts")]
    public Renderer shirtRenderer;
    public Renderer pantsRenderer;
    public Renderer shoeRenderer;

    [Header("Current Colors")]
    public Color shirtColor = Color.blue;
    public Color pantsColor = Color.black;
    public Color shoeColor = Color.white;

    private const string SAVE_KEY = "skater_outfit";

    private void Start()
    {
        LoadOutfit();
        ApplyOutfit();
    }

    public void ApplyOutfit()
    {
        if (shirtRenderer != null) shirtRenderer.material.color = shirtColor;
        if (pantsRenderer != null) pantsRenderer.material.color = pantsColor;
        if (shoeRenderer != null) shoeRenderer.material.color = shoeColor;
    }

    public void SaveOutfit()
    {
        OutfitData data = new OutfitData
        {
            outfitName = "Player Outfit",
            shirtColor = shirtColor,
            pantsColor = pantsColor,
            shoeColor = shoeColor,
            unlocked = true
        };

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    public void LoadOutfit()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY)) return;

        string json = PlayerPrefs.GetString(SAVE_KEY);
        OutfitData data = JsonUtility.FromJson<OutfitData>(json);

        if (data == null) return;

        shirtColor = data.shirtColor;
        pantsColor = data.pantsColor;
        shoeColor = data.shoeColor;
    }
}
