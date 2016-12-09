﻿using UnityEngine;
using System.Collections;

public class EnemyGhostController : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES 
    private BoxCollider2D _ghostCollider;
    private Transform _transform;
	private Rigidbody2D _rigidbody;
    private Animator _animator;
	private bool _isGrounded;
	private bool _isGroundAhead;
	private bool _isPlayerDetected;
    private bool _stoped = false;


	// PUBLIC INSTANCE VARIABLES (FOR TESTING)
	public float Speed = -1f;
	public float MaximumSpeed = -2f;
	public Transform SightStart;
	public Transform SightEnd;
	public Transform LineOfSight;

    //private AudioSources
    private AudioSource EnemySound;


	// Use this for initialization
	void Start () {
        
        _initialize();
	}
	
	// Update is called once per frame (Physics)
	void FixedUpdate () {
        //Debug.Log("is Grounded: " +_isGrounded +"Stoped:" +_stoped);
		// check if the object is grounded 
		if (this._isGrounded && !this._stoped) {
            // move the object in the direction of his local scale
            this._rigidbody.velocity = new Vector2(this._transform.localScale.x, 0) * this.Speed;

            this._isGroundAhead = Physics2D.Linecast(
                this.SightStart.position,
                this.SightEnd.position,
                1 << LayerMask.NameToLayer("Solid"));

            this._isPlayerDetected = Physics2D.Linecast(
                this.SightStart.position,
                this.LineOfSight.position,
                1 << LayerMask.NameToLayer("Player"));

            // for debugging purposes only
            //Debug.DrawLine(this.SightStart.position, this.SightEnd.position);
            //Debug.DrawLine(this.SightStart.position, this.LineOfSight.position);

            // check if there is ground ahead for the object to walk
            if (this._isGroundAhead == false) {
				// flip the direction
				this._flip();
			}

            //check if player is detected and then increase speed

            if (this._isPlayerDetected)
            {
                if (this._transform.localScale.x == 1)
                {
                    this._transform.localScale = new Vector2(2f, 1f);
                }
                else if(this._transform.localScale.x == -1)
                {
                    this._transform.localScale = new Vector2(-2f, 1f);
                }
             
            }
        }

	}

    private void _initialize()
    {
        // make a reference to this object's Transform and Rigidbody2D components
        this._transform = GetComponent<Transform>();
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._animator = GetComponent<Animator>();
        this.EnemySound = GetComponent<AudioSource>();
        this._isGrounded = false;
        this._isGroundAhead = true;
        this._isPlayerDetected = false;
        
    }

	// object is colliding with another one of its kind - flip directions
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			this._flip ();
		}
	}
		
	// object is grounded if it stays on the platform
	private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.CompareTag ("PlatformIce")) {
			this._isGrounded = true;
		}
	}

	// object is not grounded if it leaves the platform
	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.CompareTag ("PlatformIce")) {
			this._isGrounded = false;
		}
	}

	/**
	 * This method flips the character's bitmap across the x-axis
	 */
	private void _flip () {
        if (this._transform.localScale.x == 1 || this._transform.localScale.x == -1)
        {
            if (this._transform.localScale.x == 1)
            {
                this._transform.localScale = new Vector2(-1f, 1f);
            }
            else
            {
                this._transform.localScale = new Vector2(1f, 1f);
            }
        }
        else
        {
            if (this._transform.localScale.x == 2)
            {
                this._transform.localScale = new Vector2(-2f, 1f);
            }
            else
            {
                this._transform.localScale = new Vector2(2f, 1f);
            }
        }
	}

    //To kill the enemy step into its head have collider (is trigger)
    //Change the animation stop the player and desactivate the big collider 
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {      
            this._ghostCollider = gameObject.GetComponent<BoxCollider2D>();
            this._ghostCollider.enabled = false;
            this._rigidbody.freezeRotation = false;
            this._transform.localScale = new Vector2(2f, 2f);
            this.EnemySound.Play();
            this._animator.SetInteger("ghostState", 1);
            this._stoped = true;      
        }
    }
}