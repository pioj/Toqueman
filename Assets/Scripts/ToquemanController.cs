using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Toqueman
{
    public class ToquemanController : MonoBehaviour
    {
        [Header("TouchSample")]
        public Transform sprite;

        [Header("Colors")]
        [SerializeField] protected List<Color> TouchIDColors = new List<Color>();
        private Color _sampleColor = new Color(1f, 1f, 1f, 0.5f);

        [Header("Limit Touch Area")]
        [SerializeField] protected bool Limit = true;
        public Rect RectArea;

        protected Camera cam;
        protected int[] toques, swipes;
        protected int toqueLimit = 4;
        protected Vector2[] newtoquePOS, lasttoquePos;
        protected Touch[] toquelist;
        protected int toquecount;

        void Awake()   {
            //colors
            if (TouchIDColors.Count < 1) TouchIDColors.Add(_sampleColor);

            toquelist = new Touch[toqueLimit];
            toques = new int[toqueLimit];
            swipes = new int[toqueLimit];
            newtoquePOS = new Vector2[toqueLimit];
            lasttoquePos = new Vector2[toqueLimit];
            cam = Camera.main;
        }

        void Update()
        {
            TouchControls();
            //DebugProperties();
        }


        void TouchControls() {
            //limito a cuando toquen
            if (Input.touchCount > 0)
            {

                toquecount = Input.touchCount;

                for (int i = 0; i < toqueLimit; i++)
                {

                    toquelist[i] = Input.GetTouch(i); //el primero
                    toques[i] = toquelist[i].tapCount;

                    switch (toquelist[i].phase)
                    {
                        //
                        case TouchPhase.Began:
                            newtoquePOS[i] = cam.ScreenToWorldPoint(toquelist[i].position);
                            break;
                        case TouchPhase.Moved:
                            lasttoquePos[i] = newtoquePOS[i];
                            newtoquePOS[i] = cam.ScreenToWorldPoint(toquelist[i].position);
                            break;
                    }
                    //
                    sprite.position = newtoquePOS[0];
                }
            }
        }

        
        //Limits the touch detection to a closed Rect area
        private Vector2 ClampPosition(Vector2 rawPos) {
            Vector2 FilteredPos = new Vector2(
                Mathf.Clamp(rawPos.x, RectArea.xMin, RectArea.xMax),
                Mathf.Clamp(rawPos.y, RectArea.yMin, RectArea.yMax)
                );

            return FilteredPos;
        }


        //Debug variables and properties for testing purposes
        private void DebugProperties() {
            Debug.Log(sprite.position.ToString() );
        }


    }
}