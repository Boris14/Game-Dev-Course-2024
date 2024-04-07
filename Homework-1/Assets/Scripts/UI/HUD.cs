using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Sprite emptyHeartSprite;
    [SerializeField]
    Sprite fullHeartSprite;
    [SerializeField]
    Sprite emptyKeySprite;
    [SerializeField]
    Sprite fullKeySprite;

    [SerializeField]
    GameObject healthContainer;
    [SerializeField]
    GameObject keyContainer;


    Image[] hearts;
    Image[] keys;

    // Start is called before the first frame update
    void Start()
    {
       if(healthContainer)
       {
        hearts = healthContainer.GetComponentsInChildren<Image>();
       }
       if(keyContainer)
       {
        keys = keyContainer.GetComponentsInChildren<Image>();
       }
    }

    public void onHealthChangedHandler(int newHealth)
    {
        if(newHealth < 0 || newHealth > 3)
        {
            return;
        }

        for(int i = 0; i < hearts.Length; ++i)
        {
            hearts[i].sprite = i < newHealth ? fullHeartSprite : emptyHeartSprite;
        }
    }

    public void onKeysChangedHandler(int keyCount)
    {
        if(keyCount < 0 || keyCount > 3)
        {
            return;
        }

        for(int i = 0; i < keys.Length; ++i)
        {
            keys[i].sprite = i < keyCount ? fullKeySprite : emptyKeySprite;
        }
    }
}
