using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class InvisibleTilemap : MonoBehaviour
{

    public TilemapRenderer tmr;

    // Start is called before the first frame update
    void Start()
    {
        tmr.enabled = false;
    }

    // ATTATCH THIS SCRIPT TO ANY TILEMAP THAT NEEDS TO BE INVISIBLE. NO NEED TO MESS WITH TRANSPARENT PNGS!
}
