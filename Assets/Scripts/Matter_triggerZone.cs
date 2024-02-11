using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matter_triggerZone : MonoBehaviour
{
    public Matter parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Matter_Trigger"))
        {
            parent.OnMatterTrigger(collision.transform.parent.GetComponent<Matter>());
        }
    }
}
