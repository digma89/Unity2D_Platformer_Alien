using UnityEngine;
using System.Collections;

// This controller rotates the generic 'GameObject' which in turn moves the ship.
public class EnemyFly : MonoBehaviour {
    private Transform _transform;
    public Transform _Enemy;
    private float degreesPerSecond = 90.0f;
    private Vector3 v;

    // Use this for initialization
    void Start () {
        this._transform = GetComponent<Transform>();
        v = _Enemy.position - this._transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
        this._Enemy.position = this._transform.position + v;
    }
}
