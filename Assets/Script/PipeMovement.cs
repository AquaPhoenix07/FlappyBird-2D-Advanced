using System;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
     private const float MOVEMENT_SPEED = 5f;
     private const float DESPAWN_ZONE = -15f;
    public event Action<GameObject> OnPipeDespawned;

    // Update is called once per frame
    void Update()
    {
        PipeMove();
    }

    private void PipeMove()
    {
        transform.position += Vector3.left * (MOVEMENT_SPEED * Time.deltaTime);
        if (transform.position.x < DESPAWN_ZONE)
        {
            OnPipeDespawned?.Invoke(this.gameObject);
        }
    }
}
