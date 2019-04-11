using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class touchfacil : MonoBehaviour
{
    public TMP_Text textToques;
    public int toques;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        toques++;
        textToques.text = "Toques: " + toques.ToString();
    }
}
