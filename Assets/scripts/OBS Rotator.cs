using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 25 * Time.deltaTime, 0);
    }
}