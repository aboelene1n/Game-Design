using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime = 5f;
    private float timer;

    public TMP_Text timerText;
    public TMP_Text timeUpText;

    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;

        timer = startTime;

        if (timer < 0f)
        {
            timer = 0f;
        }

        timerText.text = "Time: " + timer.ToString("F2");
        timeUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        timer = timer - Time.deltaTime;

        if (timer > 0f)
        {
            timerText.text = "Time: " + timer.ToString("F2");
            return;
        }

        timer = 0f;
        timerText.text = "Time: 0";
        timeUpText.text = "TIME'S UP!\nYou Lose!";
        timeUpText.color = Color.red;
        timeUpText.outlineColor = Color.black;
        timeUpText.outlineWidth = 0.2f;
        timeUpText.alignment = TextAlignmentOptions.Center;
        timeUpText.fontStyle = FontStyles.Bold;
        timeUpText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        timeUpText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        timeUpText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        timeUpText.rectTransform.anchoredPosition = Vector2.zero;
        timeUpText.gameObject.SetActive(true);

        gameEnded = true;
        Time.timeScale = 0f;
    }
}