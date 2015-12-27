
using UnityEngine;
using System.Collections.Generic;


public class EnemyManager : SingletonBehaviour<EnemyManager> {

  GameManager gameManager { get { return GameManager.instance; } }

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
  // public method

  /// <summary> 敵キャラを指定した座標に生成 </summary>
  public EnemyDetectArea CreateEnemy(Vector3 position, Transform[] spots, string name = "") {
    var enemy = Instantiate(enemyObject);
    if (name != string.Empty) { enemy.name = name; }
    enemy.transform.position = position;
    enemy.transform.SetParent(transform);

    var actor = enemy.GetComponent<EnemyActor>();
    actor.Initialize(spots);
    actor.State(EnemyState.Move);
    _actors.Add(actor);

    return actor.detect;
  }

  /// <summary> 敵キャラを全て削除 </summary>
  public void DestroyEnemies() {
    foreach (var actor in _actors) { Destroy(actor.gameObject); }
  }

  /// <summary> 敵キャラを全て停止 </summary>
  public void PauseEnemies() {
    foreach (var actor in _actors) { actor.SetTarget(actor.transform); }
  }

  /// <summary> 敵キャラを全て行動できるようにする </summary>
  public void StartEnemies() {
    foreach (var actor in _actors) { actor.SetTarget(PlayerStatus.instance.transform); }
  }


  //------------------------------------------------------------
  // MonoBehaviour

  protected override void Awake() {
    base.Awake();
    _actors = new List<EnemyActor>();
  }

  void Update() {
    if (gameManager.isPause) { return; }
    foreach (var actor in _actors) { actor.Execute(); }
  }
}
