using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public string playerTag = "Player";

    private Transform player;

    void Start()
    {
        var playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector2 delta = player.position - transform.position;

        // Snap to nearest 45-degree direction (8-way movement).
        float angle = Mathf.Atan2(delta.y, delta.x);
        float step = Mathf.PI / 4f;
        float snappedAngle = Mathf.Round(angle / step) * step;
        Vector2 direction = new Vector2(Mathf.Cos(snappedAngle), Mathf.Sin(snappedAngle));
        Vector3 movement = new Vector3(direction.x, direction.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
