﻿using UnityEngine;

namespace Assets.Sources.menu
{
    public class Banner_intro : MonoBehaviour
    {

        public float starttime;
        public float elapsetime;
        public float showBannerTime = 20;

        // Use this for initialization
        public void Start()
        {
            starttime = Time.time;
            gameObject.AddComponent<GUIText>();
            Invoke("initBanner", showBannerTime);
        }

        public void Update()
        {
        
        }

        public void initBanner()
        {
            var atlas = GameObject.Find("ui_menu").GetComponent<UIToolkit>();

            var sprite = UIButton.create(atlas, "banner.png", "banner.png", 0, 0);
            sprite.positionFromTop(0.04f, 0);
            sprite.scale = new Vector3(0.7f, 0.7f, 1);

            sprite.colorFromTo(10f, new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 1f), Easing.Quartic.easeOut);
            sprite.scaleTo(30f, new Vector3(0.9f, 0.9f, 1f), Easing.Linear.easeOut);
        }

        public void OnGUI()
        {
            elapsetime = (Time.time - starttime);
            guiText.text = "" + elapsetime;
        }
	
    }
}
