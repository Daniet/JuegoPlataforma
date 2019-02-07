using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour {

	public Rigidbody2D playerRb;
	public float speed = 4f;
	public float jumpSpeed = 500f;
	bool isGrounded = true;
	// Use this for initialization
	public Animator playerAnim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);

		if(Input.GetAxis("Horizontal") == 0){
			playerAnim.SetBool("isWalking", false);
		}else if(Input.GetAxis("Horizontal") < 0){
			playerAnim.SetBool("isWalking", true);
			GetComponent<SpriteRenderer>().flipX = true;
		}else if(Input.GetAxis("Horizontal") > 0){
			playerAnim.SetBool("isWalking", true);
			GetComponent<SpriteRenderer>().flipX = false;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			playerRb.AddForce(Vector2.up * speed);
		}

		if(isGrounded){
			if (Input.GetKeyDown (KeyCode.Space)) {
				playerRb.AddForce (Vector2.up * jumpSpeed);
				isGrounded = false;
				playerAnim.SetTrigger("Jump");
			}
		}
	}


	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Ground")){
			isGrounded = true;
		}
	}
}
