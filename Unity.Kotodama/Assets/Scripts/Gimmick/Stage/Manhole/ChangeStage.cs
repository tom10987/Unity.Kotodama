
using UnityEngine;


public class ChangeStage : MonoBehaviour, ITrigger {

  WindowManager window { get { return WindowManager.instance; } }
  ManholeStageManager manhole { get { return ManholeStageManager.instance; } }

  [SerializeField]
  ItemType _itemName = ItemType.Empty;

  [SerializeField]
  LayerMask _layerMask = new LayerMask();

  [SerializeField]
  [Tooltip("プレイヤーの行き先")]
  Vector3 _destination = Vector3.zero;

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

    // TIPS: 行き先を指定、選択肢を表示する
    manhole.playerDestination = _destination;
    if (_itemName != ItemType.Empty) { manhole.keyItem = _itemName; }
//    window.CreateCommandWindow("移動しますか？", manhole.ChangeArea);
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
