using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractiveSystem : MonoBehaviour
{
    BoxCollider2D proximityRange;
    SpriteRenderer spriterender;
    GameObject highlight;
    [SerializeField] GameObject emptySkill;
    protected bool inside;
    private void Awake()
    {
        spriterender = GetComponent<SpriteRenderer>();
        proximityRange = GetComponent<BoxCollider2D>();
        proximityRange.isTrigger = true;
        //proximityRange.size = new Vector2(spriterender.bounds.max.x+0.5f, spriterender.bounds.max.y+0.5f);
        proximityRange.size = new Vector2(proximityRange.size.x * 1.50f, proximityRange.size.y * 1.25f); 
    }

    void Test()
    {

    }

    protected virtual void HighlightObject()
    {
        if (highlight)
        {
            Destroy(highlight);
            inside = false;
            return;
        }
        highlight = Instantiate(emptySkill,transform.position ,Quaternion.identity);
        SpriteRenderer sprite1 = highlight.AddComponent<SpriteRenderer>();
        sprite1.sprite = spriterender.sprite;
        highlight.transform.localScale = new Vector3(transform.localScale.x * 1.05f, transform.localScale.y * 1.05f, transform.localScale.z);
        sprite1.size = spriterender.size;
        sprite1.sortingOrder = -1;
        sprite1.color = Color.yellow;
        inside = true;

    }



}
