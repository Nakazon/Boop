using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    float speed = 5f;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Vector2 moveDir = new Vector2(transform.position.x +  x, transform.position.y + y);
        //rb.MovePosition(moveDir * speed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + ((transform.up * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"))) * speed * Time.deltaTime);
        //rb.AddForce(new Vector2(x, y), ForceMode2D.Force);
    }
}
