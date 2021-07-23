using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType : int
{
  Low,
  Normal,
  Magic,
  Ulti,
}

public class AmmoGage
{
  private float Low;
  private float Normal;
  private float Magic;
  private float Ulti;
  public AmmoGage(float N, float L, float M, float U)
  {
    Low = L;
    Normal = N;
    Magic = M;
    Ulti = U;
  }
  public void Set_Normal(float n)
  {
    Normal = n;
  }
  public void Set_Low(float n)
  {
    Low = n;
  }
  public void Set_Magic(float n)
  {
    Magic = n;
  }
  public void Set_Ulti(float n)
  {
    Ulti = n;
  }
  public float Get_Normal()
  {
    return Normal;
  }
  public float Get_Low()
  {
    return Low;
  }
  public float Get_Magic()
  {
    return Magic;
  }
  public float Get_Ulti()
  {
    return Ulti;
  }
  public void AddDeltaTime(float time)
  {
    Set_Normal(Get_Normal() + time);
    Set_Low(Get_Low() + time);
    Set_Magic(Get_Magic() + time);
    Set_Ulti(Get_Ulti() + time);
  }

}
public class GameManager : MonoBehaviour
{
  public static float ObstaclcSpeed = 200f;
  public static int PlayerLevel = 1;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
