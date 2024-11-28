using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextUpdate : MonoBehaviour
{
    public List<Text> displayTexts; // List to hold dynamic number of Text elements
    public List<Image> displayImages; // List to hold dynamic number of Image elements

    private void Start()
    {
        if ((displayTexts?.Count == 0) && (displayImages?.Count == 0))
        {
            Debug.LogWarning("No displayText or displayImage elements are assigned in the Inspector.");
        }
    }

    public void UpdateCanvasContent(string[] descriptions, Sprite[] images)
    {
        // Update texts
        for (int i = 0; i < displayTexts.Count; i++)
        {
            displayTexts[i].text = i < descriptions.Length ? descriptions[i] : "";
        }

        // Update images
        for (int i = 0; i < displayImages.Count; i++)
        {
            displayImages[i].sprite = i < images.Length ? images[i] : null;
        }
    }
}
