using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interiorActive : MonoBehaviour
{
    public GameObject InteriorCol;
    public GameObject ExteriorCol;
    public SpriteRenderer ExteriorSprite;
    public Animator CameraZoom;
    public SpriteRenderer Extrerior2Sprite;
    public SpriteRenderer Extrerior3Sprite;
    private GameObject player;
    public GameObject Light;

    public void Start()
    {
        ExteriorSprite = GetComponent<SpriteRenderer>();
     
    }  


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            CameraZoom.SetBool("Zoom", true);
            ExteriorSprite.color = new Color32(166, 166, 166, 50);
            Extrerior2Sprite.color = new Color32(255, 255, 255, 50);
            Extrerior3Sprite.color = new Color32(255, 255, 255, 50);
            HouseColor(false, true);
            Light.SetActive(true);

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraZoom.SetBool("Zoom", false);
            ExteriorSprite.color = new Color32(166, 166, 166, 255);
            Extrerior2Sprite.color = new Color32(255, 255, 255, 255);
            Extrerior3Sprite.color = new Color32(255, 255, 255, 255);
            HouseColor(true,false);
            Light.SetActive(false);
            //   ExteriorSprite.color = new Color(164, 164, 164, 255);
        }
    }
    public void HouseColor(bool col1, bool col2)
    {
        ExteriorCol.SetActive(col1);
        InteriorCol.SetActive(col2);
    }


}
