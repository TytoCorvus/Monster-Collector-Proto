using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCreatureSprite : MonoBehaviour
{
    public SpriteRenderer creatureSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setSprite(Sprite sprite)
    {
        creatureSprite.sprite = sprite;
    }

    public void setSprite(string fileName)
    {
       // Resources.Load(fileName);
    }
}
