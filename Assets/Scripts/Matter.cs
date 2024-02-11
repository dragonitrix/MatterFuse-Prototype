using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Matter : MonoBehaviour
{
    public MatterType type;
    public MatterPhase phase;

    [Header("Referrence")]
    public SpriteRenderer sr;
    public TextMeshPro label;

    public bool isCollide = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMatterInfo(MatterSettings settings)
    {
        this.type = settings.type;
        this.phase = settings.phase;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        label.text = type.ToString();

        switch (phase)
        {
            case MatterPhase.Circle:
                sr.sprite = GameManager.instance.sprites[0];
                break;
            case MatterPhase.Square:
                sr.sprite = GameManager.instance.sprites[1];
                break;
            case MatterPhase.Triangle:
                sr.sprite = GameManager.instance.sprites[2];
                break;
        }

    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void OnMatterTrigger(Matter other)
    {
        if (this.isCollide) return;
        this.isCollide = true;
        other.isCollide = true;

        GameManager.instance.OnMatterCollide(this, other);

    }

    public void Kill()
    {
        GameManager.instance.matters.Remove(this);
        Destroy(this.gameObject);
    }

    public void IncreasePhase()
    {
        // Get the values of the enum
        MatterPhase[] enumValues = (MatterPhase[])System.Enum.GetValues(typeof(MatterPhase));

        if ((int)phase >= enumValues.Length) return;

        phase = (MatterPhase)((int)phase + 1);

        UpdateDisplay();

    }

}
