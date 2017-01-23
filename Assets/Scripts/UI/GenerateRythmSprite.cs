using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateRythmSprite : MonoBehaviour{

    public void GenerateNewSpriteOneSide(Image sliderImage, int width, int height, int percentageMediocre, int percentageMedium, int percentagePerfect, bool invert)
    {
        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        int widthMediocre = width * percentageMediocre / 100;
        int widthMedium = width * percentageMedium / 100;
        int widthPerfect = width * percentagePerfect / 100;

        if(invert)//monster
        {
            for (int i = width; i > 0; i--)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i > width - widthMediocre)
                    {
                        texture.SetPixel(i, j, Color.red);
                    }
                    else if (i < width - widthMediocre && i >= widthMedium)
                    {
                        texture.SetPixel(i, j, Color.yellow);
                    }
                    else if (i < widthPerfect)
                    {
                        texture.SetPixel(i, j, Color.green);
                    }
                }
            }
        }else // player
        {
            for (int i = width; i > 0; i--)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i < widthMediocre)
                    {
                        texture.SetPixel(i, j, Color.red);
                    }
                    else if (i >= widthMediocre && i < widthMediocre + widthMedium)
                    {
                        texture.SetPixel(i, j, Color.yellow);
                    }
                    else if (i >= widthMediocre + widthMedium)
                    {
                        texture.SetPixel(i, j, Color.green);
                    }
                }
            }
        }
        
        
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        sliderImage.sprite = sprite;
    }

    public void GenerateNewSpriteTwoSide(Image sliderImage, int width, int height, int percentageFirstMediocre, int percentageFirstMedium, int percentagePerfect, int percentageSecondMedium, int percentageSecondMediocre)
    {
        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        int widthFirstMediocre = width * percentageFirstMediocre / 100;
        int widthFirstMedium = width * percentageFirstMedium / 100;
        int widthPerfect = width * percentagePerfect / 100;
        int widthSecondMedium = width * percentageSecondMedium / 100;
        int widthSecondMediocre = width * percentageSecondMediocre / 100;


        //player
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i < widthFirstMediocre)
                {
                    texture.SetPixel(i, j, Color.red);
                }
                else if (i >= widthFirstMediocre && i < widthFirstMediocre + widthFirstMedium)
                {
                    texture.SetPixel(i, j, Color.yellow);
                }
                else if (i >= widthFirstMediocre + widthFirstMedium && i < widthFirstMediocre + widthFirstMedium + widthPerfect)
                {
                    texture.SetPixel(i, j, Color.green);
                }
                else if (i >= widthFirstMediocre + widthFirstMedium + widthPerfect && i < widthFirstMediocre + widthFirstMedium + widthPerfect + widthSecondMedium)
                {
                    texture.SetPixel(i, j, Color.yellow);
                }
                else if (i >= widthFirstMediocre + widthFirstMedium + widthPerfect + widthSecondMedium && i <= width)
                {
                    texture.SetPixel(i, j, Color.red);
                }
            }
        }

        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        sliderImage.sprite = sprite;
    }

}
