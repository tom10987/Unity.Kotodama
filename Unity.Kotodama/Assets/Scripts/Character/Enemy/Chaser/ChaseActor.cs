
using UnityEngine;
using System.Collections;

public class ChaseActor : MonoBehaviour {

  static EnemyManager manager { get { return EnemyManager.instance; } }

  [SerializeField]
  [Tooltip("初期状態の移動速度")]
  [Range(2f, 5f)]
  float _defaultSpeed = 3f;
  public float defaultSpeed { get { return _defaultSpeed; } }

  [SerializeField]
  [Tooltip("警戒(Alert)状態の待機時間")]
  [Range(1f, 5f)]
  float _interval = 3f;

  [SerializeField]
  [Tooltip("警戒(Alert)状態の待機回数")]
  int _loopCount = 3;

  [SerializeField]
  [Tooltip("追跡(Chase)状態の継続判定を行う領域の広さ")]
  [Range(1f, 5f)]
  float _chaseDetectRange = 3f;

  [SerializeField]
  NavMeshAgent _agent = null;
  public NavMeshAgent agent { get { return _agent; } }

  void StopAgent() { _agent.SetDestination(transform.position); }
  bool IsArrival() { return _agent.remainingDistance <= _agent.stoppingDistance; }

  [SerializeField]
  ChaserDetectArea _area = null;
  public ChaserDetectArea area { get { return _area; } }

  [SerializeField]
  ChaserAnimator _animator = null;

  [SerializeField]
  RootRegister _register = null;

  ChaserState _currentState = ChaserState.Move;
  public void SetState(ChaserState newState) { _currentState = newState; }
  public bool isDetectPlayer { get { return _currentState != ChaserState.Move; } }
  bool isAlert { get { return _currentState == ChaserState.Alert; } }

  /// <summary> 行動開始 </summary>
  public void Activate() {
    _animator.StartAnimation();
    StartCoroutine(UpdateActor());
  }

  /// <summary> 動作を停止して、自身を消滅させる </summary>
  public void Delete() {
    StopAgent();
    _animator.Destroy(this);
  }

  /// <summary> <see cref="EnemyManager"/> に自身を登録して、休眠状態に入る </summary>
  void Start() {
    manager.actors.Add(this);
    _agent.speed = _defaultSpeed;
    _register.Initialize();
    gameObject.SetActive(false);
  }

  // TIPS: オブジェクトのメインループ
  IEnumerator UpdateActor() {
    while (manager.isActive) {
      var state = !isDetectPlayer ? Move() : Chase();
      yield return StartCoroutine(state);
    }

    // TIPS: ループ終了＝ポーズ状態になったら移動を停止する
    StopAgent();
  }

  // TIPS: プレイヤー未発見状態
  IEnumerator Move() {
    var spot = _register.GetRootSpots().GetEnumerator();
    _agent.SetDestination(spot.Current);

    System.Action Next = () => {
      if (!spot.MoveNext()) { spot = null; return; }
      _agent.SetDestination(spot.Current);
    };

    while (!isDetectPlayer && spot != null) {
      if (!manager.isActive) { break; }
      var distance = _agent.remainingDistance;
      if (distance < 0.1f) { Next(); }
      yield return null;
    }
  }

  // TIPS: プレイヤー追跡モード
  IEnumerator Chase() {
    var player = PlayerState.instance.transform;
    var currentCount = 0;

    while (currentCount < _loopCount) {
      if (!manager.isActive) { break; }
      _agent.SetDestination(player.position);
      if (isAlert) { yield return new WaitForSeconds(_interval); }
      yield return null;
      ++currentCount;
    }

    var result = (isAlert ? IsAlertRange() : IsChaseRange());
    if (!result) { _currentState = ChaserState.Move; }
  }

  bool IsAlertRange() {
    var distance = GetDistanceToPlayer();
    Debug.Log("alert = " + distance);
    Debug.Log(distance < area.alert.range);
    return (distance < area.alert.range);
  }

  // TIPS: 追跡状態の継続判定
  bool IsChaseRange() {
    var distance = GetDistanceToPlayer();
    Debug.Log("chase = " + distance);
    Debug.Log(distance < area.chase.range * _chaseDetectRange);
    return (distance < area.chase.range * _chaseDetectRange);
  }

  float GetDistanceToPlayer() {
    var player = PlayerState.instance.transform;
    return (player.position - transform.position).magnitude;
  }
}
