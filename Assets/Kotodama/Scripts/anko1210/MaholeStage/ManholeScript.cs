
using UnityEngine;


public class ManholeScript : SingletonBehaviour<ManholeScript> {

  PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }
  EffectSequencer effectSequencer { get { return EffectSequencer.instance; } }
  EnemyManager enemy { get { return EnemyManager.instance; } }

  [SerializeField]
  RootManager _rootMapUp;

  [SerializeField]
  RootManager _rootMapDown;

  [SerializeField]
  private string _playerObjName = "Player";

  /// <summary>
  /// マリちゃのすたーと位置
  /// </summary>
  private static Vector3 _playerStartPosition = new Vector3(-40f, 0.0f, -60f);
  private GameObject _player;
  public Vector3 _playerChangePosition;

  private GameObject _items;

  private Transform _rightFloor;
  private Collider _rightWall;
  private Transform _leftFloor;
  private Collider _leftWall;

  private float _min = -1f;
  private float _max = +0f;


  protected override void Awake() {
    base.Awake();
    RESET();
  }

  void Start() {
    _playerChangePosition = new Vector3(0f, 0f, 0f);
  }

  public void ChangePosition(Vector3 pos) {
    /// プレイヤーの座標を変更する関数
    _player.transform.localPosition = pos;
    _playerChangePosition = new Vector3(0f, 0f, 0f);
  }

  public void IsDestination() {
    ChangePosition(_playerChangePosition);
  }

  public void MoveFloor() {
    _rightWall.enabled = !_rightWall.enabled;
    _leftWall.enabled = !_leftWall.enabled;

    if (_leftWall.enabled) {
      _leftFloor.localPosition = new Vector3(0f, _min);
      _rightFloor.localPosition = new Vector3(0f, _max);
    }
    else {
      _leftFloor.localPosition = new Vector3(0f, _max);
      _rightFloor.localPosition = new Vector3(0f, _min);
    }

  }

  public void RESET() {
    ReadingPrefab();
    _rightFloor = GameObject.Find("RightRoads").GetComponentInChildren<Transform>();
    _rightWall = GameObject.Find("RightRoadWall").GetComponentInChildren<Collider>();
    _leftFloor = GameObject.Find("LeftRoads").GetComponentInChildren<Transform>();
    _leftWall = GameObject.Find("LeftRoadWall").GetComponentInChildren<Collider>();
    _leftWall.enabled = false;
    _rightWall.enabled = true;
    _leftFloor.localPosition = new Vector3(0f, _max);
    _rightFloor.localPosition = new Vector3(0f, _min);
    _player = GameObject.Find(_playerObjName);
    ChangePosition(_playerStartPosition);
  }

  /// <summary>
  /// もしプレハブのインスペクターが壊れた場合
  /// </summary>
  void ReadingPrefab() {
    //var upMap = Resources.Load<GameObject>("Map/Stage/Manhole/ManholeStage_Ver2");
    //var downMap = Resources.Load<GameObject>("Map/Stage/Manhole/ManholeDownStage_Ver2");
    var item = Resources.Load<GameObject>("Map/Stage/Manhole/ManholeObjects");
    //var rootUp = Resources.Load<GameObject>("Map/Stage/Manhole/EnemyUP");
    //var rootDown = Resources.Load<GameObject>("Map/Stage/Manhole/EnemyDOWN");
    //if (_upMap == null) { _upMap = Instantiate(upMap); }
    //_upMap.name = "Up";
    //if (_downMap == null) { _downMap = Instantiate(downMap); }
    //_downMap.name = "Down";
    if (_items == null) { _items = Instantiate(item); }
    _items.name = "objects";
    //_rootMapUp = Instantiate(rootUp).GetComponent<RootManager>();
    //_rootMapDown = Instantiate(rootDown).GetComponent<RootManager>();
    //_upMap.SetActive(true);
    //_downMap.SetActive(true);
    _items.SetActive(true);
  }

  /// <summary>
  /// ボタンの処理
  /// </summary>
  public void IsFloorMove() {
    popupCanvas._isChoice = true;
    MoveFloor();
  }

  public void IsWarpMari() {
    popupCanvas._isChoice = true;
    effectSequencer.FadeStart(IsDestination, 0.5f);
  }
}
