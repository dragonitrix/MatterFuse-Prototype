using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Settings")]
    public int ruleIndex = 0;


    [Header("Prefabs")]
    public GameObject matter_prefab;

    [Header("List")]
    public List<Matter> matters = new List<Matter>();
    public List<Sprite> sprites = new List<Sprite>();

    [Header("Referrence")]
    public Transform matterGroup;
    public RuleSet rule;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rule = new RuleSet(ruleIndex);

        foreach(Matter matter in matterGroup.GetComponentsInChildren<Matter>())
        {
            matters.Add(matter);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnMatter(Vector3 pos, MatterSettings settings)
    {
        var clone = Instantiate(matter_prefab, matterGroup);
        var matterScript = clone.GetComponent<Matter>();
        matterScript.SetPosition(pos);
        matterScript.SetMatterInfo(settings);
        matters.Add(matterScript);
    }

    public void OnMatterCollide(Matter a, Matter b)
    {
        var newPos =(a.transform.position + b.transform.position) / 2;

        // todo define rule of new matter status

        var settings = rule.MergeRuleCal(a, b);

        if (settings is null) // no possible combination given
        {
            a.isCollide = false;
            b.isCollide = false;
        }
        else
        {
            SpawnMatter(newPos, settings);
            a.Kill();
            b.Kill();
        }



    }

    public void Cook()
    {
        foreach(var matter in matters)
        {
            matter.IncreasePhase();
        }
    }

}
