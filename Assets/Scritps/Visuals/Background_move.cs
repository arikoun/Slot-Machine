using Unity.VisualScripting;
using UnityEngine;

public class Background_move : MonoBehaviour
{
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float speed;

    void Update()
    {
        float movement_Y = Mathf.Lerp(maxY, minY, Mathf.PingPong(Time.time * speed, 1f));

        transform.position = new Vector3(0, movement_Y, 0);
    }
}
