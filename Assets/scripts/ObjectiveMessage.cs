using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ObjectiveMessage : MonoBehaviour
{
    private TextMeshProUGUI objectiveText;

    void Start()
    {
        objectiveText = GetComponent<TextMeshProUGUI>();
        objectiveText.text = "Level objective:\nGather all collectables";
        objectiveText.alignment = TextAlignmentOptions.Center;
        objectiveText.rectTransform.anchorMin = new Vector2(0.5f, 1f);
        objectiveText.rectTransform.anchorMax = new Vector2(0.5f, 1f);
        objectiveText.rectTransform.pivot = new Vector2(0.5f, 1f);
        objectiveText.rectTransform.anchoredPosition = new Vector2(0f, -20f);
        objectiveText.alpha = 1f;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSecondsRealtime(5f);

        while (objectiveText.alpha > 0f)
        {
            objectiveText.alpha -= Time.unscaledDeltaTime;
            if (objectiveText.alpha < 0f)
            {
                objectiveText.alpha = 0f;
            }

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
