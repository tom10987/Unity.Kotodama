
using UnityEngine;

using State = EnemyData.EnemyState;
using StateAction = System.Collections.Generic.
  Dictionary<EnemyData.EnemyState, System.Action>;


public class EnemyActor : MonoBehaviour {

  StateAction _action = new StateAction();

  void Start() {
    _action.Add(State.Move, OnMove);
    _action.Add(State.Alert, OnAlert);
    _action.Add(State.Chase, OnChase);
  }


  void OnMove() {
  }

  void OnAlert() {
  }

  void OnChase() {
  }
}
