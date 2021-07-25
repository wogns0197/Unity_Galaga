using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField]
  private float speed;
  private GunType bulletLevel;
  private Rigidbody2D rg;
  private Collider2D[] targetArr;

  private void Awake()
  {
    bulletLevel = PlaneController.PlaneInstance.GetCurrentAmmo();
  }
  private void Start()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    // speed = 500f;
    rg = GetComponent<Rigidbody2D>();
    rg.AddForce(new Vector2(0, 1f) * speed);
    if (PlaneController.PlaneInstance != null) { targetArr = PlaneController.PlaneInstance.GetDetectionColl(); }
  }
  private void Update()
  {


    if (transform.position.y > 7f)
    {
      Destroy(gameObject);
    }

    if (targetArr.Length != 0)
    {
      for (int i = 0; i < targetArr.Length; i++)
      {
        if (targetArr[i].tag == "Obstacle")
        {
          Chaser(targetArr[i].gameObject);
          break;
        }
      }

    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if ((int)bulletLevel < 2) // 총알 레벨에 따라 부딛히고 죽냐 아니면 밀고 들어가냐 차이
    {
      if (other.tag == "Obstacle")
      {
        Destroy(gameObject);
      }
    }
  }

  private void Chaser(GameObject target)
  {
    Vector3 dir = (target.transform.position - this.transform.position).normalized;

    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    rg.velocity = new Vector2(dir.x * 10f, dir.y * 10f);
  }
}
