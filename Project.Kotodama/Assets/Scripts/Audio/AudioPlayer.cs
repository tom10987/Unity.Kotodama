
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

  [SerializeField]
  AudioSource _source = null;
  public AudioSource source { get { return _source; } }

  [SerializeField]
  AudioClip[] _clips = null;
  public AudioClip[] clips { get { return _clips; } }

  /// <summary> 再生するクリップを指定 </summary>
  public void Clip(uint index) {
    if (index < _clips.Length) { _source.clip = _clips[index]; }
  }

  /// <summary> クリップを再生する </summary>
  public void Play() {
    if (_source.clip == null) { return; }
    if (!_source.isPlaying) { _source.Play(); }
  }

  /// <summary> 指定した ID のクリップを再生する </summary>
  public void Play(uint index) { Clip(index); Play(); }

  /// <summary> クリップを停止する </summary>
  public void Stop() { _source.Stop(); }
}
