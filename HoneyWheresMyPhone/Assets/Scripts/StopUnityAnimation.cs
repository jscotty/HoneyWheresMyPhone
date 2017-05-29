using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopUnityAnimation : MonoBehaviour {

    [SerializeField]
    private Animator _animator;

	void Start () {
        _animator.StopPlayback();
	}
#if UNITY_EDITOR
    private void Reset()
    {
        this.enabled = false;
        _animator = GetComponent<Animator>();
    }
#endif
}
