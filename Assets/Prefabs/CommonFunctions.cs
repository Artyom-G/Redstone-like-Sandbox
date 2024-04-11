using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonFunctions
{
    static public Color[,] ChargeColors = {
        {//Orange-Grey Set
            new Color(255/255.0f, 161/255.0f, 37/255.0f), //Normal On
            new Color(217/255.0f, 217/255.0f, 217/255.0f), //Normal Off
            new Color(225/255.0f, 111/255.0f, 35/255.0f), //Secondary On
            new Color(195/255.0f, 195/255.0f, 195/255.0f), //Secondary Off
            new Color(255/255.0f, 161/255.0f, 37/255.0f), //Timer On
            new Color(106/255.0f, 106/255.0f, 106/255.0f), //Timer Off 
            new Color(225/255.0f, 111/255.0f, 35/255.0f), //Timer Secondary On
            new Color(81/255.0f, 81/255.0f, 81/255.0f), //Timer Secondary Off 
        },
        {//Red-Blue Set
            new Color(204/255.0f, 31/255.0f, 31/255.0f),
            new Color(62/255.0f, 115/255.0f, 238/255.0f),
            new Color(204/255.0f, 31/255.0f, 31/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(62/255.0f, 115/255.0f, 238/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(204/255.0f, 31/255.0f, 31/255.0f),
            new Color(62/255.0f, 115/255.0f, 238/255.0f),
            new Color(204/255.0f, 31/255.0f, 31/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(62/255.0f, 115/255.0f, 238/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Purple-Green Set
            new Color(195/255.0f, 45/255.0f, 163/255.0f),
            new Color(126/255.0f, 244/255.0f, 132/255.0f),
            new Color(195/255.0f, 45/255.0f, 163/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(126/255.0f, 244/255.0f, 132/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(195/255.0f, 45/255.0f, 163/255.0f),
            new Color(126/255.0f, 244/255.0f, 132/255.0f),
            new Color(195/255.0f, 45/255.0f, 163/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(126/255.0f, 244/255.0f, 132/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Shrek Set
            new Color(75/255.0f, 172/255.0f, 37/255.0f),
            new Color(214/255.0f, 249/255.0f, 153/255.0f),
            new Color(75/255.0f, 172/255.0f, 37/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(214/255.0f, 249/255.0f, 153/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(75/255.0f, 172/255.0f, 37/255.0f),
            new Color(214/255.0f, 249/255.0f, 153/255.0f),
            new Color(75/255.0f, 172/255.0f, 37/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(214/255.0f, 249/255.0f, 153/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Black-White Set
            new Color(242/255.0f, 242/255.0f, 242/255.0f),
            new Color(23/255.0f, 23/255.0f, 23/255.0f),
            new Color(242/255.0f, 242/255.0f, 242/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(23/255.0f, 23/255.0f, 23/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(242/255.0f, 242/255.0f, 242/255.0f),
            new Color(23/255.0f, 23/255.0f, 23/255.0f),
            new Color(242/255.0f, 242/255.0f, 242/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(23/255.0f, 23/255.0f, 23/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Halloween Set
            new Color(255/255.0f, 121/255.0f, 0/255.0f),
            new Color(36/255.0f, 0/255.0f, 70/255.0f),
            new Color(255/255.0f, 121/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(36/255.0f, 0/255.0f, 70/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 121/255.0f, 0/255.0f),
            new Color(36/255.0f, 0/255.0f, 70/255.0f),
            new Color(255/255.0f, 121/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(36/255.0f, 0/255.0f, 70/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Redstone Set
            new Color(249/255.0f, 35/255.0f, 35/255.0f),
            new Color(77/255.0f, 24/255.0f, 24/255.0f),
            new Color(249/255.0f, 35/255.0f, 35/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(77/255.0f, 24/255.0f, 24/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(249/255.0f, 35/255.0f, 35/255.0f),
            new Color(77/255.0f, 24/255.0f, 24/255.0f),
            new Color(249/255.0f, 35/255.0f, 35/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(77/255.0f, 24/255.0f, 24/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Gold-Silver Set
            new Color(255/255.0f, 195/255.0f, 0/255.0f),
            new Color(183/255.0f, 183/255.0f, 183/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(183/255.0f, 183/255.0f, 183/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f),
            new Color(183/255.0f, 183/255.0f, 183/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(183/255.0f, 183/255.0f, 183/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Cotton Candy Set
            new Color(255/255.0f, 153/255.0f, 200/255.0f),
            new Color(169/255.0f, 222/255.0f, 249/255.0f),
            new Color(255/255.0f, 153/255.0f, 200/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(169/255.0f, 222/255.0f, 249/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 153/255.0f, 200/255.0f),
            new Color(169/255.0f, 222/255.0f, 249/255.0f),
            new Color(255/255.0f, 153/255.0f, 200/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(169/255.0f, 222/255.0f, 249/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Brown Set
            new Color(165/255.0f, 99/255.0f, 54/255.0f),
            new Color(74/255.0f, 71/255.0f, 62/255.0f),
            new Color(165/255.0f, 99/255.0f, 54/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(74/255.0f, 71/255.0f, 62/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(165/255.0f, 99/255.0f, 54/255.0f),
            new Color(74/255.0f, 71/255.0f, 62/255.0f),
            new Color(165/255.0f, 99/255.0f, 54/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(74/255.0f, 71/255.0f, 62/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//My Fav Colors Set
            new Color(255/255.0f, 138/255.0f, 21/255.0f),
            new Color(25/255.0f, 58/255.0f, 208/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(25/255.0f, 58/255.0f, 208/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f),
            new Color(25/255.0f, 58/255.0f, 208/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(25/255.0f, 58/255.0f, 208/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Yellow-Blue Set
            new Color(255/255.0f, 195/255.0f, 0/255.0f),
            new Color(0/255.0f, 29/255.0f, 61/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(0/255.0f, 29/255.0f, 61/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f),
            new Color(0/255.0f, 29/255.0f, 61/255.0f),
            new Color(255/255.0f, 195/255.0f, 0/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(0/255.0f, 29/255.0f, 61/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Fall Set
            new Color(242/255.0f, 92/255.0f, 84/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f),
            new Color(242/255.0f, 92/255.0f, 84/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(242/255.0f, 92/255.0f, 84/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f),
            new Color(242/255.0f, 92/255.0f, 84/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Lavender Set
            new Color(145/255.0f, 99/255.0f, 203/255.0f),
            new Color(222/255.0f, 201/255.0f, 233/255.0f),
            new Color(145/255.0f, 99/255.0f, 203/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(222/255.0f, 201/255.0f, 233/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(145/255.0f, 99/255.0f, 203/255.0f),
            new Color(222/255.0f, 201/255.0f, 233/255.0f),
            new Color(145/255.0f, 99/255.0f, 203/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(222/255.0f, 201/255.0f, 233/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Badur's Set
            new Color(247/255.0f, 178/255.0f, 103/255.0f),
            new Color(245/255.0f, 249/255.0f, 228/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(245/255.0f, 249/255.0f, 228/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f),
            new Color(245/255.0f, 249/255.0f, 228/255.0f),
            new Color(247/255.0f, 178/255.0f, 103/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(245/255.0f, 249/255.0f, 228/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Melon Set
            new Color(255/255.0f, 138/255.0f, 21/255.0f),
            new Color(45/255.0f, 45/255.0f, 45/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(45/255.0f, 45/255.0f, 45/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f),
            new Color(45/255.0f, 45/255.0f, 45/255.0f),
            new Color(255/255.0f, 138/255.0f, 21/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
            new Color(45/255.0f, 45/255.0f, 45/255.0f) * new Color(160/255.0f, 160/255.0f, 160/255.0f),
        },
        {//Troll Set
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
            new Color(55/255.0f, 55/255.0f, 55/255.0f, 0f),
        },
    };
    public static int ColorIndex = 0;
    static public float updateTimer = 0.01f;
    static public Color BoolToColor(bool input){
        if(input) return ChargeColors[ColorIndex, 0];
        else return ChargeColors[ColorIndex, 1];
    }
    static public Color BoolToColor(bool input, int colorType){
        if(input) return ChargeColors[ColorIndex, 0+(colorType*2)];
        else return ChargeColors[ColorIndex, 1+(colorType*2)];
    }
    static public Sprite BoolToSprite(bool input, Sprite on, Sprite off){
        if(input) return on;
        else return off;
    }
    static public int FindIndexOfCon(SpriteRenderer outputCon){
        Data d = outputCon.transform.parent.parent.gameObject.GetComponent<Data>();
        for (int i = 0; i < d.outputCon.Length; i++)
        {
            if(outputCon == d.outputCon[i]) return i;
        }
        return 0;
    }
}
