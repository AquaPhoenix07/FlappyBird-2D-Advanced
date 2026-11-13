using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
     private const float MOVEMENT_SPEED = 5f;
     private const float DESPAWN_ZONE = -15f;
    public event Action<GameObject> ObjectDespawned;

    // Update is called once per frame
    void Update()
    {
        ObjectMoveLeft();
    }

    private void ObjectMoveLeft()
    {
        transform.position += Vector3.left * (MOVEMENT_SPEED * Time.deltaTime);
        if (transform.position.x < DESPAWN_ZONE)
        {
            ObjectDespawned?.Invoke(gameObject);
        }
    }
}
