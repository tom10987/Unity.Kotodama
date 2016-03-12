
using UnityEngine;
using System.Collections.Generic;


public interface ITrigger {
  bool isEnter { get; }
  void TriggerUpdate(Vector3 touchPosition);
}


public class ManholeStageManager : SingletonBehaviour<ManholeStageManager> {

  WindowManager window { get { return WindowManager.instance; } }

  [SerializeField]
  GameObject _player = null;

  /// <summary> 地下のオブジェクトを登録、管理する </summary>
  [System.Serializable]
  class UnderGroundStage {
    public Transform floor = null;
    public Collider wall = null;
  }

  [SerializeField]
  UnderGroundStage _left = null;

  [SerializeField]
  UnderGroundStage _right = null;

  public List<ITrigger> triggers { get; set; }

  /// <summary> マリちゃのすたーと位置 </summary>
  readonly Vector3 _playerStartPosition = new Vector3(40f, 0f, -38f);

  /// <summary> プレイヤーの移動先 </summary>
  public Vector3 playerDestination { get; set; }

  /// <summary> 移動に必要なキーアイテム </summary>
  public ItemType keyItem { get; set; }


  protected override void Awake() {
    base.Awake();

    triggers = new List<ITrigger>();

    System.Action<UnderGroundStage, bool, Vector3> StageSetup = null;
    StageSetup = (stage, isEnable, place) => {
      stage.wall.enabled = false;
      stage.floor.localPosition = place;
    };

    // TIPS: 地下のオブジェクトを初期化
    StageSetup(_left, false, Vector3.zero);
    StageSetup(_right, true, Vector3.down);

    // TIPS: インスペクターで設定されてなければ、ヒエラルキーから探す
    if (_player == null) { _player = FindObjectOfType<PlayerState>().gameObject; }

    // TIPS: プレイヤーの開始位置を初期化
    ChangePlayerPosition(_playerStartPosition);
    playerDestination = Vector3.zero;

    keyItem = ItemType.Empty;
  }

  void Update() {
    if (!TouchController.IsTouchBegan()) { return; }

    //var touchPosition = TouchController.GetTouchScreenPosition();
    var touchPosition = Vector3.zero;
    foreach (var trigger in triggers) {
      if (!trigger.isEnter) { continue; }
      trigger.TriggerUpdate(touchPosition);
    }
  }

  /// <summary> ボタンの処理 </summary>
  public void MoveBridge() {
    window.DestroyWindow();

    _left.wall.enabled = !_left.wall.enabled;
    _right.wall.enabled = !_right.wall.enabled;

    _left.floor.localPosition = _left.wall.enabled ? Vector3.down : Vector3.zero;
    _right.floor.localPosition = _left.wall.enabled ? Vector3.zero : Vector3.down;
  }

  /// <summary> エリア移動の処理 </summary>
  public void ChangeArea() {
    window.QuickDestroyWindow();

    /*
    var items = ItemManager.instance.items;
    var existsItem = items.ContainsKey(keyItem);
    if (existsItem ? items[keyItem].hasItem : (keyItem == ItemType.Empty)) {
      //EffectSequencer.instance.FadeStart(MovePlayer, 0.5f);
    }
    else {
      window.CreateMessageWindow("開かない...");
    }
    */

    keyItem = ItemType.Empty;
  }

  void MovePlayer() {
    ChangePlayerPosition(playerDestination);
  }

  void ChangePlayerPosition(Vector3 place) {
    _player.transform.position = place;
  }
}
