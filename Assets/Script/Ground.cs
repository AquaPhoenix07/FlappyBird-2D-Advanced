using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
   private float landMoveSpeed = 5f;
   private Vector3 startPos;
   private float widthToReset;
   private SpriteRenderer groundSkin;

   private void Awake()
   {
      groundSkin = GetComponentInChildren<SpriteRenderer>();
      startPos = transform.position;
      widthToReset = 10f;
   }

   private void Update()
   {
      GroundMovement();
   }
   private void GroundMovement()
   {
      transform.position += Vector3.left * (landMoveSpeed * Time.deltaTime);
      float distanceTravel = startPos.x - transform.position.x;
      if (distanceTravel >= widthToReset)
      {
         transform.position = startPos;
      }
   }

   
}
