using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class MainMenu : MonoBehaviour
{
    public AssetReference MainGame;
    public Button StartGame;
    public Button QuitGame;
    public Image FrontImage;
    public Image BackImage;
    public float temp = 1f;
    public float temp2 = 0f;
    public float duration;
    public float shiftDuration;
    public List<Sprite> Sprites;
    public int spriteID = 0;
    public bool startFade;
    public bool isEntering = false;
    public void LoadNewGame()
    {
        isEntering = true;
        SceneLoader.LoadAddressableScene(MainGame);
    }
    public void QuitButton() => Application.Quit();

    private void FixedUpdate()
    {
        if (!isEntering)
        {
            if (temp2 <= 1 && !startFade)
            {
                temp2 += shiftDuration;
            }
            else if (temp >= 1)
            {
                startFade = true;
                temp = 1f;
                if (spriteID == 2)
                {
                    spriteID = 0;
                }
                else
                {
                    spriteID++;
                }
            }

            if (startFade)
            {
                temp -= duration;

                BackImage.sprite = Sprites[spriteID];
                FrontImage.color = new Color(1, 1, 1, temp);
            }
            if (temp <= 0 && startFade)
            {
                startFade = false;
                FrontImage.sprite = Sprites[spriteID];
                FrontImage.color = new Color(1, 1, 1, 1);
                temp = 1;
                temp2 = 0;
            }
        }    }
}
