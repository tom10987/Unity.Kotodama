
using UnityEngine;

using Root = System.Collections.Generic.
  List<UnityEngine.Transform>;


/*
全ての設定項目を管理するクラス

項目ごとにクラス化するかは要検討

各項目は基本的に SerializeField にする
ただし、要素が null であれば、初期値を設定するようにする
*/

public enum EnemyType {
  Chaser,
  Porter,
  None,
}


public class EnemyModel : MonoBehaviour {

  public EnemyType type { get; set; }

  [SerializeField]
  float _stateChangeTime = 3f;
  float _elapsedTime = 0f;
  public bool isTimeUp { get { return _elapsedTime <= 0f; } }

  public void CountUpdate() { if (_elapsedTime > 0f) _elapsedTime -= Time.deltaTime; }
  public void CountReset() { _elapsedTime = _stateChangeTime; }


  [SerializeField]
  Transform _player = null;
  public Transform targetTransform { get { return _player; } }

  NavMeshAgent _agent = null;

  [SerializeField]
  Transform[] _rootList = null;
  Root _root = new Root();
  int _rootId = 0;
  public Transform currentRoot { get { return _root[_rootId]; } }

  public void RootUpdate() { _agent.SetDestination(currentRoot.position); }

  public void RootIdUpdate() {
    ++_rootId;
    if (_rootId == _root.Count) { _rootId = 0; }
  }


  //void Awake() { state = ChaserState.Move; }

  void Start() {
    foreach (var root in _rootList) { _root.Add(root); }
    _agent = GetComponent<NavMeshAgent>();
  }
}
