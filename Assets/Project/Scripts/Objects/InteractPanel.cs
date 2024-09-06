using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractPanel : InteractiveSystem
{
    [SerializeField] GameObject panel;
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (!_other.CompareTag("Player")) return;
        HighlightObject();
    }

    private void Update()
    {
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                panel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (!_other.CompareTag("Player")) return;
        HighlightObject();
        panel.SetActive(false);

    }

    protected override void HighlightObject()
    {
        base.HighlightObject();
    }
}
