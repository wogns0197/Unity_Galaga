using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Sprite[] spriteResources;
  [SerializeField]
  private GameObject Cur_Ammo_Image;
  private int curAmmo;
  private void Start()
  {
    curAmmo = 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      StartCoroutine("ChangeSprite");
    }
  }

  IEnumerator ChangeSprite()
  {
    for (float alpha = 1f; alpha >= 0; alpha -= .05f)
    {
      Color c = Cur_Ammo_Image.GetComponent<Image>().color;
      c.a = alpha;
      Cur_Ammo_Image.GetComponent<Image>().color = c;
      yield return null;
    }
    Cur_Ammo_Image.GetComponent<Image>().sprite = spriteResources[curAmmo > 2 ? curAmmo = 0 : ++curAmmo];
    Cur_Ammo_Image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    Debug.Log(curAmmo);
  }

}
