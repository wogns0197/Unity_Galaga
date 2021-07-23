using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
  private void Update()
  {
    if (transform.position.y < -10f) { transform.position = new Vector3(0, 10); }
    transform.Translate(new Vector3(0, -.1f));
  }
}
