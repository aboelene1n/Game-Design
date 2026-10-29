using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;

    public float speed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            winTextObject.SetActive(true);
            TextMeshProUGUI resultText = winTextObject.GetComponent<TextMeshProUGUI>();
            resultText.text = "You Win!";
            resultText.color = Color.green;
            resultText.outlineColor = Color.black;
            resultText.outlineWidth = 0.2f;
            resultText.fontStyle = FontStyles.Bold;
            resultText.alignment = TextAlignmentOptions.Center;
            resultText.rectTransform.anchoredPosition = Vector2.zero;
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            TextMeshProUGUI loseText = winTextObject.GetComponent<TextMeshProUGUI>();
            loseText.text = "You Lose!";
            loseText.color = Color.red;
            loseText.outlineColor = Color.black;
            loseText.outlineWidth = 0.2f;
            loseText.fontStyle = FontStyles.Bold;
            loseText.alignment = TextAlignmentOptions.Center;
            loseText.rectTransform.anchoredPosition = Vector2.zero;
            Time.timeScale = 0f;
        }
    }
}