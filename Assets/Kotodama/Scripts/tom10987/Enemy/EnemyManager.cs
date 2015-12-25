
using UnityEngine;
using System.Collections.Generic;


public class EnemyManager : SingletonBehaviour<EnemyManager> {

  GameManager gameManager { get { return GameManager.instance; } }

  [SerializeField]
  List<Transform> _spots = null;
  public List<Transform> spots { get { return _spots; } }

  GameObject _enemy = null;
  GameObject enemyObject {
    get {
      if (_enemy == null) { _enemy = Resources.Load<GameObject>("Enemy/Enemy"); }
      return _enemy;
    }
  }

  List<EnemyActor> _actors = null;
  public List<EnemyActor> actors { get { return _actors; } }


  //------------------------------------------------------------
  // Instanciate Enemy

  public void CreateEnemy(Vector3 position) {
    var enemy = Instantiate(enemyObject);
    enemy.transform.position = position;
    enemy.transform.SetParent(transform);

    var actor = enemy.GetComponent<EnemyActor>();
    actor.SetCourse(_spots.ToArray());
    _actors.Add(actor);
  }

  /// <summary> 敵キャラを全て削除 </summary>
  public void DestroyEnemy() {
    foreach (var actor in _actors) { Destroy(actor.gameObject); }
  }


  //------------------------------------------------------------
  // MonoBehaviour

  protected override void Awake() {
    base.Awake();
    if (_spots == null) { _spots = new List<Transform>(); }
    _actors = new List<EnemyActor>();
  }

  void Update() {
    foreach (var actor in _actors) {
      actor.Execute();
      if (gameManager.isPause) { }
    }
  }
}
