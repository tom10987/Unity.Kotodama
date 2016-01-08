using UnityEngine;

public class MSwitch : MonoBehaviour {

    PlayerStatus state { get { return PlayerStatus.instance; } }
    PopUpCanvas pop {  get { return PopUpCanvas.instance; } }
    ManholeScript manhole { get { return ManholeScript.instance; } }

    [SerializeField]
    public LayerMask mask;
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
                pop.CreatePopUpWindowVerGimmick("スイッチを押しますか？", manhole.IsFloorMove);
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
