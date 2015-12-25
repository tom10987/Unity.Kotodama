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


    // 表示させるものはOffsetの子オブジェクトに。
    void OnTriggerEnter(Collider col)
    {
        gameObject.transform.FindChild("Offset").gameObject.SetActive(true);
        state.MoveStop();
    }

    void Check()
    {

    }

    // OffsetからActiveをfalseに。
    public void CanvasReturn()
    {
        gameObject.transform.FindChild("Offset").gameObject.SetActive(false);
    }
}
