using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum item
{
    chalk,
    frog,
    broom,
    candleBox,
    blackPaint,
    glitter,
    hat,
    key,
    trophy,
    plants,
    stone,
    stick,
    tube,
}

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    public bool chalk;
    public bool frog;
    public bool broom;
    public bool candleBox;
    public bool blackPaint;
    public bool glitter;
    public bool hat;
    public bool key;
    public bool trophy;
    public bool plants;
    public bool stone;
    public bool stick;

    public void LoadInventory()
    {

    }

    public void Collect(item itemType)
    {
        switch (itemType)
        {
            case item.chalk:
                chalk = true;
                break;
            case item.frog:
                frog = true;
                break;
            case item.broom:
                broom = true;
                break;
            case item.candleBox:
                candleBox= true;
                break;
            case item.blackPaint:
                blackPaint = true;
                break;
            case item.glitter:
                glitter = true;
                break;
            case item.hat:
                hat = true;
                break;
            case item.key:
                key = true;
                break;
            case item.trophy:
                trophy = true;
                break;
            case item.plants:
                hat = true;
                break;
            case item.stone:
                stone = true;
                break;
            case item.stick:
                stick = true;
                break;
        }
    }
}
