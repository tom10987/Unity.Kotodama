using UnityEngine;
using System.Collections;

public class PublicPhoneEvent : MonoBehaviour
{

    [SerializeField]
    public Transform[] RootBase { get; private set; }

    [SerializeField]
    private Vector3[] CreatePos;

    [SerializeField]
    private int CreateCount = 2;

    [SerializeField]
    private bool EventStart = false;

    void Awake()
    {
        EventStart = false;
    }

    void Start ()
    {
        
	}
	
	void Update ()
    {
       if(DialButton_Ver2.ClearFlug_PublicPhone == true && EventStart == false)
        {
            AwakeEnemy();
            EventStart = true;
        }
	}

    void AwakeEnemy()
    {
        for(int c = 0; c < CreateCount; c++)
        {
            //Debug.Log("" + c);
            var Success_ = GameObject.Find("RootBase_" + c);
            if(Success_)
            {
                //Debug.Log("" + Success_.name);
                EnemyManager.instance.CreateEnemy(Success_.GetComponent<RootManager>().spots);
            }
        }
    }
}
