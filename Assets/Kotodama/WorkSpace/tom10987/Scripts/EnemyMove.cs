
using UnityEngine;

using Root = System.Collections.Generic.
  List<UnityEngine.Transform>;


public class EnemyMove : MonoBehaviour {

  [SerializeField]
  Transform _player = null;
  NavMeshAgent _agent = null;
  SpriteRenderer _renderer = null;

  [SerializeField]
  [Range(1f, 3f)]
  float _chaseSpeedRatio = 1.25f;
  float _originSpeed = 0f;

  [SerializeField]
  Transform[] _rootList = null;
  Root _root = null;
  int _rootId = 0;

  public enum EnemyState {
    Move,
    Alert,
    Detect,
  }
  static public EnemyState state { get; private set; }


  public void PlayerAlert() {
    state = EnemyState.Alert;
    PlayerChase();
    _agent.speed = _originSpeed * 0.9f;
    _renderer.color = Color.yellow;
  }

  public void PlayerDetection() {
    state = EnemyState.Detect;
    _agent.speed = _originSpeed * _chaseSpeedRatio;
    _renderer.color = Color.red;
  }

  public void PlayerLost() {
    state = EnemyState.Move;
    _agent.SetDestination(_root[_rootId].position);
    _agent.speed = _originSpeed;
    _renderer.color = Color.white;
  }

  public void PlayerChase() {
    _agent.SetDestination(_player.position);
  }

  public Transform GetPlayerTransform() { return _player; }

  public bool IsArrived() {
    var magnitude = _agent.velocity.magnitude;
    return magnitude < _agent.stoppingDistance;
  }


  void Awake() { state = EnemyState.Move; }

  void Start() {
    _root = new Root();
    foreach (var root in _rootList) { _root.Add(root); }

    _agent = GetComponent<NavMeshAgent>();
    _agent.SetDestination(_root[_rootId].position);
    _originSpeed = _agent.speed;

    _renderer = GetComponentInChildren<SpriteRenderer>();
  }

  void Update() {
    if (state != EnemyState.Move) { _rootId = 0; return; }

    var here = transform.position;
    var root = _root[_rootId].position;
    var distance = root - here;
    if (distance.magnitude > 1f) { return; }

    ++_rootId;
    if (_rootId >= _root.Count) { _rootId = 0; }

    _agent.SetDestination(_root[_rootId].position);
  }
}
