using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class touchsample : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform sprite;
    public TMP_Text texto;
    private Vector2 refOnScreen = Vector2.zero;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        refOnScreen = cam.ScreenToViewportPoint(Input.mousePosition);
#endif
#if UNITY_ANDROID
        if (Input.touchCount >= 1)
        {
            refOnScreen = cam.ScreenToViewportPoint(Input.GetTouch(0).position); //da porcentajes
        }
#endif
        Update_Common();
    }
      
    void Update_Common() {
        sprite.position = cam.ViewportToWorldPoint(refOnScreen) * Vector2.one;  //el vector2.one es un "truco" para poner a 0 su eje Z.
        texto.text = sprite.position.ToString();
    }
}
