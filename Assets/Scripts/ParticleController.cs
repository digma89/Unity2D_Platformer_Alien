using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {
    private Transform _transform;

    // Use this for initialization
    void Start () {
        this._transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        this._transform.position += (new Vector3(1,0,0) * Time.deltaTime * 5f);
    }
}
