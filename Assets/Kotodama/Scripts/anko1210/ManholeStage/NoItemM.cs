
using UnityEngine;


public class NoItemM : MonoBehaviour {

  PlayerState state { get { return PlayerState.instance; } }
  PopUpCanvas pop { get { return PopUpCanvas.instance; } }
  ManholeStageManager manhole { get { return ManholeStageManager.instance; } }

  [SerializeField]
  LayerMask _mask;

  [SerializeField]
  Vector3 _position;

  const int _distance = 100;
  bool _isHit = false;

  void Update() {
    // TIPS: タッチされてない または オブジェクトに触れてなければ何もしない
    if (!TouchController.IsTouchBegan() || !_isHit) { return; }

    // TIPS: タッチ座標から画面奥にレイを飛ばす
    var ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
    var hit = new RaycastHit();

    // TIPS: レイがぶつからなければ何もしない
    if (!Physics.Raycast(ray, out hit, _distance, _mask)) { return; }

    // TIPS: スイッチだったらプレイヤーを止めて選択肢を表示する
    if (hit.collider.gameObject.name == gameObject.name) {
      state.Stop();
      manhole.playerDestination = _position;
      pop.CreatePopUpWindowVerGimmick("移動しますか？", manhole.IsWarpMari);
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
