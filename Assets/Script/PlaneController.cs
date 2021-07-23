﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneController : MonoBehaviour
{
  private float moveSpeed;
  public GunType ammo;
  private int gunLevel, gunNum;
  private const float DelayTime_Normal = .1f, DelayTime_Low = .05f, DelayTime_Magic = .5f, DelayTime_Ulti = 2f;

  [SerializeField]
  private GameObject[] bulletPrefab;
  private AmmoGage GageController;
  private void Start()
  {
    moveSpeed = .08f;
    gunLevel = 1;
    gunNum = 1;
    ammo = GunType.Low;
    GageController = new AmmoGage(0, 0, 0, 0);
  }
  private void Update()
  {

    Move();

    //test key
    if (Input.GetKeyDown(KeyCode.F))
    {
      if (ammo == GunType.Ulti) { ammo = GunType.Low; }
      else
      {
        ammo++;
      }
    }
    if (Input.GetKeyDown(KeyCode.G))
    {
      if (GameManager.PlayerLevel == 4) { GameManager.PlayerLevel = 0; }
      GameManager.PlayerLevel++;
    }

    if (Input.GetKey(KeyCode.Space))
    {
      Fire(ammo);
    }


  }
  private void Move()
  {
    float axisX = Input.GetAxis("Horizontal");
    float axisY = Input.GetAxis("Vertical");

    if (axisX != 0)
    {
      // transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
      transform.Translate(new Vector2(1f, 0) * (moveSpeed + .05f) * axisX);
      // transform.rotation = Quaternion.Euler(new Vector3(0, 30f * axisX, 0));
    }
    if (axisY != 0)
    {
      transform.Translate(new Vector2(0, 1f) * moveSpeed * axisY);
    }
  }

  private void Fire(GunType ammoSelect)
  {
    // GageController.Set_Magic(GageController.Get_Magic() + Time.deltaTime);
    // GageController.Set_Ulti(GageController.Get_Ulti() + Time.deltaTime);
    GageController.AddDeltaTime(Time.deltaTime);

    switch ((int)ammoSelect)
    {
      case 0:
        if (GageController.Get_Normal() > DelayTime_Normal)
        {
          // Instantiate(bulletPrefab[0], this.transform.position, Quaternion.Euler(0, 0, 90));
          InstantiateByLevel(bulletPrefab[0]);
          GageController.Set_Normal(0);
        }
        break;
      case 1:
        if (GageController.Get_Low() > DelayTime_Low)
        {
          // Instantiate(bulletPrefab[1], this.transform.position, Quaternion.Euler(0, 0, 90));
          InstantiateByLevel(bulletPrefab[1]);
          GageController.Set_Low(0);
        }
        break;
      case 2:
        if (GageController.Get_Magic() > DelayTime_Magic)
        {
          Instantiate(bulletPrefab[2], this.transform.position, Quaternion.Euler(0, 0, 90));
          GageController.Set_Magic(0);
        }
        break;
      case 3:
        if (GageController.Get_Ulti() > DelayTime_Ulti)
        {
          Instantiate(bulletPrefab[3], this.transform.position, Quaternion.Euler(0, 0, 90));
          GageController.Set_Ulti(0);
        }
        break;
      default:
        break;
    }
  }
  private void InstantiateByLevel(GameObject bullet)
  {
    Vector3 pos = transform.position;
    switch (GameManager.PlayerLevel)
    {
      case (1):
        Instantiate(bullet, pos, Quaternion.Euler(0, 0, 90));
        break;
      case (2):
        Instantiate(bullet, pos + new Vector3(-.3f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(.3f, 0), Quaternion.Euler(0, 0, 90));
        break;
      case (3):
        Instantiate(bullet, pos + new Vector3(-.4f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(0, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(.4f, 0), Quaternion.Euler(0, 0, 90));
        break;
      case (4):
        Instantiate(bullet, pos + new Vector3(-.5f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(-.2f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(.2f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, pos + new Vector3(.5f, 0), Quaternion.Euler(0, 0, 90));
        break;
      default:
        break;
    }

  }

}
