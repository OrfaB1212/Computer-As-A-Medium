using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
        }
    }

    void Update()
    {
        if (playerMovement == null) return;

        Vector2 dir = playerMovement.facingDirection;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Keep the current size, only flip the Y sign when facing left
        Vector3 currentScale = transform.localScale;
        float absY = Mathf.Abs(currentScale.y);
        currentScale.y = (dir == Vector2.left) ? -absY : absY;
        transform.localScale = currentScale;
    }
}
