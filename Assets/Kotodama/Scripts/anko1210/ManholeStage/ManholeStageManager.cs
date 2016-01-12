
using UnityEngine;


public class ManholeStageManager : SingletonBehaviour<ManholeStageManager> {

  PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }

  [SerializeField]
  RootManager _rootMapUp;

  [SerializeField]
  RootManager _rootMapDown;

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

  /// <summary> マリちゃのすたーと位置 </summary>
  readonly Vector3 _playerStartPosition = new Vector3(-40f, 0.0f, -60f);

  /// <summary> プレイヤーの移動先 </summary>
  public Vector3 playerDestination { get; set; }


  protected override void Awake() {
    base.Awake();

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
  }

  /// <summary> ボタンの処理 </summary>
  public void MoveFloor() {
    popupCanvas._isChoice = true;

    _left.wall.enabled = !_left.wall.enabled;
    _right.wall.enabled = !_right.wall.enabled;

    _left.floor.localPosition = _left.wall.enabled ? Vector3.down : Vector3.zero;
    _right.floor.localPosition = _left.wall.enabled ? Vector3.zero : Vector3.down;
  }

  /// <summary> エリア移動の処理 </summary>
  public void IsWarpMari() {
    popupCanvas._isChoice = true;
    EffectSequencer.instance.FadeStart(MovePlayer, 0.5f);
  }

  void MovePlayer() {
    ChangePlayerPosition(playerDestination);
  }

  void ChangePlayerPosition(Vector3 place) {
    _player.transform.localPosition = place;
    playerDestination = Vector3.zero;
  }
}
