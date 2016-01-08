using UnityEngine;

///// <summary>
///// 触ったマンホールの名前と、ワープ先のマリちゃんのポジション
///// </summary>
//{ "ManholeKey_B", new Vector3(23f, 0f, 63f) },
//{ "ManholeKey_D", new Vector3(51.5f, 0f, 34.5f) },


public class GimmickManhole : MonoBehaviour {

    PlayerStatus state { get {  return PlayerStatus.instance; } }
    PopUpCanvas pop { get { return PopUpCanvas.instance; } }
    ManholeScript manhole { get { return ManholeScript.instance; } }

    public ItemState _key;

    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    public Vector3 _position;
    RaycastHit hit;
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
                Hit();
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

    void Hit()
    {
        if (_key.hasItem)
        {
            manhole._playerChangePosition = _position;
            pop.CreatePopUpWindowVerGimmick("移動しますか？", manhole.IsWarpMari);
        }
        else
        {
            pop.CreatePopUpWindow("開かない…");
        }
    }

}
