
using UnityEngine;


public class GimmickManhole : MonoBehaviour {

  PlayerState state { get { return PlayerState.instance; } }
  PopUpCanvas pop { get { return PopUpCanvas.instance; } }
  ManholeScript manhole { get { return ManholeScript.instance; } }

  public ItemState _key;

  [SerializeField]
  private LayerMask mask;

  [SerializeField]
  public Vector3 _position;

  RaycastHit hit;
  private bool _isHit;

  void Update() {
    Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());

    if (Physics.Raycast(ray, out hit, 100, mask)) {
      GameObject obj = hit.collider.gameObject;
      if (_isHit && obj.name == this.gameObject.name && TouchController.IsTouchBegan()) {
        state.Stop();
        Hit();
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

  void Hit() {
    if (_key.hasItem) {
      manhole._playerChangePosition = _position;
      pop.CreatePopUpWindowVerGimmick("移動しますか？", manhole.IsWarpMari);
    }
    else {
      pop.CreatePopUpWindow("開かない…");
    }
  }
}
