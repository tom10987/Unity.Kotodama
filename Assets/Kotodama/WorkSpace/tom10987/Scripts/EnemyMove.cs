
using UnityEngine;


[System.Serializable]
public class RangeParameter {

  [SerializeField]
  float _detection = 1f;
  public float detection { get { return _detection; } }

  [SerializeField]
  float _alert = 1f;
  public float alert { get { return _alert; } }

  [SerializeField]
  float _offset = 1f;
  public float offset { get { return _offset; } }

  [SerializeField]
  [Range(1f, 5f)]
  float _velocity = 1f;
  public float velocity { get { return _velocity; } }

  [SerializeField]
  [Range(1f, 3f)]
  float _velocityRatio = 1.25f;
  public float ratio { get { return _velocityRatio; } }
}


public class EnemyMove : MonoBehaviour {

  [SerializeField]
  RangeParameter _param = null;


  void Start() {
  }
}
