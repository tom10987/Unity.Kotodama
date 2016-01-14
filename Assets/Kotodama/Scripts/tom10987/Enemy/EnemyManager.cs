
using UnityEngine;
using System.Collections.Generic;


public class EnemyManager : SingletonBehaviour<EnemyManager> {

  GameObject _enemy = null;
  GameObject enemyObject {
    get {
      if (_enemy == null) { _enemy = Resources.Load<GameObject>("Enemy/Chaser"); }
      return _enemy;
    }
  }

  List<EnemyActor> _actors = null;
  public List<EnemyActor> actors { get { return _actors; } }


  /// <summary> 敵キャラを指定した座標に生成 </summary>
  public EnemyDetectArea CreateEnemy(Transform[] spots, string name = "") {
    var enemy = Instantiate(enemyObject);
    if (name != string.Empty) { enemy.name = name; }
    enemy.transform.SetParent(transform);
    enemy.transform.position = spots[0].position;

    var actor = enemy.GetComponent<EnemyActor>();
    actor.Initialize(spots);
    actor.State(EnemyState.Move);
    _actors.Add(actor);

    return actor.detect;
  }

  /// <summary> 敵キャラを全て削除 </summary>
  public void DestroyEnemies(float time = 0.0f) {
    foreach (var actor in _actors) { Destroy(actor.gameObject, time); }
  }

  public void SwitchEnemiesState() {
    var game = GameManager.instance;
    foreach (var actor in _actors) {
      var target = game.isPause ? actor.transform : PlayerState.instance.transform;
      actor.SetTarget(target);
    }
  }

  protected override void Awake() {
    base.Awake();
    _actors = new List<EnemyActor>();
  }

  void Update() {
    if (GameManager.instance.isPause) { return; }
    foreach (var actor in _actors) { actor.Execute(); }
  }
}
