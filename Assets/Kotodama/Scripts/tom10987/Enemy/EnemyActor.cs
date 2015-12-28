
using UnityEngine;
using System;
using System.Collections.Generic;


public enum EnemyState {
  None,
  Move,
  Alert,
  Chase,

  Max,
}


//------------------------------------------------------------
// TIPS:
// オブジェクトのインスタンス化は
// EnemyManager クラスの CreateEnemy() を使う

public class EnemyActor : MonoBehaviour {

  EnemyState _state = EnemyState.None;
  Dictionary<EnemyState, Action> _action = null;

  List<Transform> _spot = null;
  int _spotID = 0;
  NavMeshAgent _agent = null;

  Transform _target = null;
  EnemyDetectArea _detect = null;
  public EnemyDetectArea detect { get { return _detect; } }

  [SerializeField]
  [Range(1f, 3f)]
  [Tooltip("追跡モードのスピード倍率（単位：1.00 倍）")]
  float _chaseSpeedRatio = 1.25f;
  float _originSpeed = 0f;

  [SerializeField]
  [Range(1f, 10f)]
  [Tooltip("警戒モード中の追跡インターバル（単位：秒）")]
  float _chaseInterval = 2f;
  public float chaseInterval {
    get { return _chaseInterval; }
    set {
      if (value <= 0f) { return; }
      _chaseInterval = value;
    }
  }

  float _chaseTime = 0;

  [SerializeField]
  [Range(1, 10)]
  [Tooltip("警戒、追跡モードが終了するまでの時間（単位：秒）")]
  uint _timeLimit = 5;
  public uint timeLimit {
    get { return _timeLimit; }
    set { if (value != 0) { _timeLimit = value; } }
  }

  int _chaseCount = 0;


  //------------------------------------------------------------
  // NavMesh Parameter

  public float agentSpeed {
    get { return _agent.speed; }
    private set { _agent.speed = value; }
  }

  public float agentAccel {
    get { return _agent.acceleration; }
    private set { _agent.acceleration = value; }
  }

  public float agentStoppingDistance {
    get { return _agent.stoppingDistance; }
    private set { _agent.stoppingDistance = value; }
  }


  //------------------------------------------------------------
  // public method

  public void Execute() {
    if (_action.ContainsKey(_state)) { _action[_state](); }
  }

  public void State(EnemyState state) {
    _state = state;
    CountReset();

    agentSpeed = (state == EnemyState.Chase) ?
      _originSpeed * _chaseSpeedRatio : _originSpeed;
  }

  public void SetTarget(Transform target) {
    _target = target;
  }

  public void Initialize(Transform[] spots) {
    _action = new Dictionary<EnemyState, Action>();
    _action.Add(EnemyState.Move, Move);
    _action.Add(EnemyState.Alert, Alert);
    _action.Add(EnemyState.Chase, Chase);

    _spot = new List<Transform>();
    foreach (var spot in spots) { _spot.Add(spot); }

    _agent = GetComponent<NavMeshAgent>();
    _agent.SetDestination(_spot[_spotID].position);
    _originSpeed = _agent.speed;

    _detect = GetComponent<EnemyDetectArea>();
  }


  //------------------------------------------------------------
  // Enemy Action

  void Move() {
    var distance_ = _spot[_spotID].position - transform.position;
    if (distance_.magnitude > agentStoppingDistance) { return; }

    ++_spotID;
    if (_spotID >= _spot.Count) { _spotID = 0; }
    _agent.velocity *= 0.5f;
    _agent.SetDestination(_spot[_spotID].position);
  }

  void Alert() {
    if (IsIntervalTime()) { return; }

    _chaseTime = 0f;
    _agent.SetDestination(_target.position);

    if (!IsCountOver()) { return; }

    if (IsDetectPlayer(_detect.alert.range)) { CountReset(); }
    else { PlayerLost(); }
  }

  void Chase() {
    _agent.SetDestination(_target.position);
    if (IsIntervalTime()) { return; }
    if (!IsCountOver()) { return; }

    if (IsDetectPlayer(_detect.chase.range)) { CountReset(); }
    else { PlayerLost(); }
  }


  //------------------------------------------------------------
  // System

  void PlayerLost() {
    State(EnemyState.Move);
    _agent.velocity = Vector3.zero;
    _agent.SetDestination(_spot[_spotID].position);
  }

  void CountReset() {
    _chaseTime = 0f;
    _chaseCount = 0;
  }

  bool IsIntervalTime() {
    _chaseTime += Time.deltaTime;
    return _chaseTime < chaseInterval;
  }

  bool IsCountOver() {
    ++_chaseCount;
    return _chaseCount >= timeLimit;
  }

  bool IsDetectPlayer(float range) {
    var distance_ = _target.position - transform.position;
    return distance_.magnitude < range;
  }
}
