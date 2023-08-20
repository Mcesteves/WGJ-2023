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
    ritual,
    toilet,
}

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    private bool chalk;
    private bool frog;
    private bool broom;
    private bool candleBox;
    private bool blackPaint;
    private bool glitter;
    private bool hat;
    private bool key;
    private bool trophy;
    private bool plants;
    private bool stone;
    private bool stick;
    private bool tube;
    private bool ritual;
    private bool toilet;
    private int toiletCount = 0;

    public void ResetInventory()
    {
        chalk = false;
        frog = false;
        broom = false;
        candleBox = false;
        blackPaint = false;
        glitter = false;
        hat = false;
        key = false;
        trophy = false;
        plants = false;
        stone = false;
        stick = false;
        ritual = false;
        toilet = false;
        tube = false;
        toiletCount = 0;
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
                plants = true;
                break;
            case item.stone:
                stone = true;
                break;
            case item.stick:
                stick = true;
                break;
            case item.ritual:
                ritual = true;
                break;
            case item.toilet:
                toilet = true;
                break;
            case item.tube:
                tube = true;
                break;
        }
    }
    public bool GetType(item itemType)
    {
        switch (itemType)
        {
            case item.chalk:
                return chalk;
            case item.frog:
                return frog;
            case item.broom:
                return broom;
            case item.candleBox:
                return candleBox;
            case item.blackPaint:
                return blackPaint;
            case item.glitter:
                return glitter;
            case item.hat:
                return hat;
            case item.key:
                return key;
            case item.trophy:
                return trophy;
            case item.plants:
                return plants;
            case item.stone:
                return stone;
            case item.stick:
                return stick;
            case item.ritual:
                return ritual;
            case item.toilet:
                return toilet;
            case item.tube:
                return tube;
        }
        return false;
    }

    public bool IsAllCollected()
    {
        return chalk && frog && broom && candleBox && blackPaint && glitter && tube
            && hat && key && trophy && plants && stone && stick && toilet;
    }

    public int IncreaseToiletCount()
    {
        toiletCount++;
        return toiletCount;
    }
}
