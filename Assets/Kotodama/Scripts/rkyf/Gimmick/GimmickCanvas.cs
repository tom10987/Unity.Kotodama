using UnityEngine;
using System.Collections;

public class GimmickCanvas : MonoBehaviour
{
    PlayerState state { get { return PlayerState.instance; } }

    [SerializeField]
    string GimmickName;
    /// <summary>
    /// 
    /// 重いm(__)m
    /// 
    /// </summary>
    /// 

    void OnTriggerEnter(Collider col)
    {
        gameObject.transform.root.FindChild(GimmickName).gameObject.SetActive(true);
        //gameObject.transform.root.FindChild(GimmickName).gameObject.transform.parent = null;

        state.Stop();
    }

    
    public void CanvasReturn()
    {
        gameObject.transform.root.FindChild(GimmickName).gameObject.SetActive(false);
        
        
    }
}
