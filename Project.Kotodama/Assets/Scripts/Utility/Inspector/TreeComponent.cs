
using UnityEngine;

public class TreeComponent : MonoBehaviour {

  [SerializeField]
  Transform _polygon = null;
  public Transform polygon { get { return _polygon; } }
}
