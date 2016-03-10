
using UnityEngine;
using System.Collections;

public abstract class AbstractPlayer : MonoBehaviour {
  public void Activate() { StartCoroutine(UpdateComponent()); }
  public abstract IEnumerator UpdateComponent();
}
