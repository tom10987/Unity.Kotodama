
using UnityEngine;
using System.Collections.Generic;


public class EnemyManager : SingletonBehaviour<EnemyManager> {

  [SerializeField]
  Transform[] _spots = null;

  GameObject _enemy = null;
  GameObject enemy {
    get {
      if (_enemy == null) { _enemy = Resources.Load<GameObject>("Enemy/Enemy"); }
      return _enemy;
    }
  }

  List<EnemyActor> _actors = null;


  //------------------------------------------------------------
  // Instanciate Enemy

  // TODO: actor の agent パラメータを変更してバリエーションを増やす
  // TODO: タイプごとに生成メソッドを作る
  public void CreateEnemy(Vector3 position) {
    var actor = GenerateActor(position);
    AppendActor(actor);
  }

  public void DestroyEnemy() {
    foreach (var actor in _actors) { Destroy(actor.gameObject); }
  }


  //------------------------------------------------------------
  // System

  EnemyActor GenerateActor(Vector3 position) {
    var actor = Instantiate(enemy);
    actor.transform.position = position;
    actor.transform.SetParent(transform);
    return actor.GetComponent<EnemyActor>();
  }

  void AppendActor(EnemyActor actor) {
    actor.SetCourse(_spots);
    _actors.Add(actor);
  }


  //------------------------------------------------------------
  // MonoBehaviour

  protected override void Awake() {
    base.Awake();
    _actors = new List<EnemyActor>();
  }

  void Update() {
    //TODO: ポーズ中は敵キャラの更新をしない
    //if (true) { return; }
    //foreach (var actor in _actors) { actor.Execute(); }
  }
}
