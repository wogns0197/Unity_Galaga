using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
  void Start()
  {
    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1f) * GameManager.ObstaclcSpeed);
  }

  void Update()
  {

  }
}
