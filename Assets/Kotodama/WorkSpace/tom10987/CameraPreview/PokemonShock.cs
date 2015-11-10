
using UnityEngine;


public class PokemonShock : MonoBehaviour {

  Light _light = null;
  float _time = 0f;


  void Start() {
    _light = GetComponent<Light>();
  }

  void Update() {
    _time += Time.deltaTime * 2f;
    _light.color = new Color(Mathf.Sin(_time) * 0.25f + 0.5f, 0f, 1f);
  }
}
