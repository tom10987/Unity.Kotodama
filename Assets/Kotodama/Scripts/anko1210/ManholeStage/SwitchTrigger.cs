
using UnityEngine;


public class SwitchTrigger : MonoBehaviour, ITrigger {

  WindowManager window { get { return WindowManager.instance; } }
  ManholeStageManager manhole { get { return ManholeStageManager.instance; } }

  [SerializeField]
  LayerMask _layerMask;

  const int _distance = 100;

  public bool isEnter { get; private set; }

  public void TriggerUpdate(Vector3 touchPosition) {
    // TIPS: タッチ座標から画面奥にレイを飛ばす
    var ray = Camera.main.ScreenPointToRay(touchPosition);
    var hit = new RaycastHit();

    // TIPS: レイがぶつからなければ何もしない
    if (!Physics.Raycast(ray, out hit, _distance, _layerMask)) { return; }

    // TIPS: ギミックだったらプレイヤーを止める
    if (hit.collider.gameObject.name != gameObject.name) { return; }
    PlayerState.instance.Stop();
    window.CreateCommandWindow("スイッチを押しますか？", manhole.MoveBridge);
  }

  void OnTriggerEnter(Collider other) {
    isEnter = (other.tag == ObjectTag.Player.ToString());
    if (isEnter) { PlayerState.instance.Stop(); }
  }

  void OnTriggerExit(Collider other) {
    isEnter = !(other.tag == ObjectTag.Player.ToString());
  }

  void Start() {
    isEnter = false;
    manhole.triggers.Add(this);
  }
}
