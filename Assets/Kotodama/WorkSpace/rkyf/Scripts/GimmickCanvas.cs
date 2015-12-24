using UnityEngine;
using System.Collections;

public class GimmickCanvas : MonoBehaviour
{
    PlayerStatus state { get { return PlayerStatus.instance; } }

    void Awake()
    {
    }

    void Start()
    {
    }

    void Update()
    {
    }


    void OnTriggerEnter(Collider col)
    {
        gameObject.transform.FindChild("Offset").gameObject.SetActive(true);
    }

    void Check()
    {

    }

    public void CanvasReturn()
    {
        gameObject.transform.FindChild("Offset").gameObject.SetActive(false);
    }
}
