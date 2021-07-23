using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField]
  private float speed;
  void Start()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    // speed = 500f;
    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f) * speed);
  }
  void Update()
  {
    if (transform.position.y > 7f)
    {
      Destroy(gameObject);
    }
  }
}
