using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker_PlayerController : PlayerController {

    public int clicks;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        this.enabled = false;
    }
	
    protected override void OnEnable()
    {
        base.OnEnable();
    }

	protected override void Update () {
        if (Input.GetKeyDown(PlayerData.playerKeys[slot])) 
        {
            points++;
            ExtendSprite();
        }
	}

    void ExtendSprite()
    {
        sprite.size = new Vector2(1 + points/3.0f, sprite.size.y);
    }
}
