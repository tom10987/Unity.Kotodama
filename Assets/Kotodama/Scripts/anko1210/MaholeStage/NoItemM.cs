using UnityEngine;

///// <summary>
///// 触ったマンホールの名前と、ワープ先のマリちゃんのポジション
///// </summary>
//{ "ManholeDA", new Vector3(-48.5f, 0f, -26f) },
//{ "ManholeDB", new Vector3(-69f, 0f, -46.5f) },
//{ "ManholeDC", new Vector3(-27.5f, 0f, -47f) },
//{ "ManholeDD", new Vector3(-52f, 0f, -63.5f) },

//{ "ManholeUA",    new Vector3(41f, 0f, 80f) },
//{ "ManholeUC",    new Vector3(73.3f, 0f, 48f) },


public class NoItemM : MonoBehaviour {

    PlayerStatus state { get { return PlayerStatus.instance; } }
    PopUpCanvas pop { get { return PopUpCanvas.instance; } }
    ManholeScript manhole { get { return ManholeScript.instance; } }

    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private Vector3 _position;
    private RaycastHit hit;
    private bool _isHit;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            GameObject obj = hit.collider.gameObject;
            if (_isHit && obj.name == this.gameObject.name && TouchController.IsTouchBegan())
            {
                state.MoveStop();
                manhole._playerChangePosition = _position;
                pop.CreatePopUpWindowVerGimmick("移動しますか？", manhole.IsWarpMari);
            }
        }
    }


    void OnTriggerEnter()
    {
        state.MoveStop();
        _isHit = true;
    }

    void OnTriggerExit()
    {
        pop.IsCancel();
        _isHit = false;
    }
}
