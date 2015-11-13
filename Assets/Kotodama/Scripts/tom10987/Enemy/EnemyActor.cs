
using UnityEngine;
using System;
using System.Collections.Generic;


public class EnemyAction {

  EnemyModel model { get; set; }
  public EnemyModel setModel { set { model = value; } }

  public void OnWait() {
  }

  public void OnMove() {
  }

  public void OnAlert() {
  }

  public void OnChase() {
  }

  public void OnPortal() {
  }
}


public class EnemyTypeBase {

  protected EnemyAction _action = null;

  public virtual void Setup() {
    _action = new EnemyAction();
  }
}


public class EnemyChaser : EnemyTypeBase {
}


public class EnemyActor : MonoBehaviour {

  [SerializeField]
  EnemyType _type = EnemyType.None;
  EnemyTypeBase _action = null;


  void Awake() {
  }

  void Start() {
    EnemyManager.actors.Add(this);
  }

  public void Execute() {
  }
}
