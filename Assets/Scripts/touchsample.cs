using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class touchsample : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform sprite;
    public TMP_Text texto;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR_WIN
            Vector2 refOnScreen = cam.ScreenToViewportPoint(Input.mousePosition);
#endif
#if UNITY_ANDROID
        if (Input.touchCount >= 1)
        {
            Vector2 refOnSceen = cam.ScreenToViewportPoint(Input.GetTouch(0).position); //da porcentajes
#endif
        }

        sprite.position = refOnScreen;
        texto.text = sprite.position.ToString();
    }



}
