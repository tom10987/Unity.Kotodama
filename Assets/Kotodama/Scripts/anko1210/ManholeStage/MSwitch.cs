
using UnityEngine;


public class MSwitch : MonoBehaviour {

  PlayerState state { get { return PlayerState.instance; } }
  PopUpCanvas pop { get { return PopUpCanvas.instance; } }
  ManholeStageManager manhole { get { return ManholeStageManager.instance; } }

  [SerializeField]
  public LayerMask mask;

  private RaycastHit hit;
  private bool _isHit;

  void Update() {
    Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());

    if (Physics.Raycast(ray, out hit, 100, mask)) {
      GameObject obj = hit.collider.gameObject;
      if (_isHit && obj.name == this.gameObject.name && TouchController.IsTouchBegan()) {
        state.Stop();
        pop.CreatePopUpWindowVerGimmick("スイッチを押しますか？", manhole.MoveFloor);
      }
    }
  }

  void OnTriggerEnter() {
    state.Stop();
    _isHit = true;
  }

  void OnTriggerExit() {
    pop.IsCancel();
    _isHit = false;
  }
}
