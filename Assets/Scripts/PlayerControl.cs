using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 50.0f;
	public float maxZ = 21.0f, minZ = -1.0f;
	public float maxY = 5.5f, minY = -6.5f;

	public bool isCollide = false;
	public static bool hitP = false;

    public GameObject ball;

	public BoxCollider p1, p2;
	public static int count = 0;
	public static Vector3 startpos1;

	// Use this for initialization
	void Start () {
		startpos1 = transform.position;
		Debug.Log (startpos1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {

		Vector3 pos = transform.position;

        MoveP1(pos);

        LaunchBall();
    }

    void LaunchBall()
    {
        if (count == 0)
        {
            Vector3 v = new Vector3(0, Random.value, -Random.value);
            Vector3 v2 = new Vector3(1, 0, 0);
            float angleY = Random.Range(10, 45);

            Debug.Log(angleY);
            float force = 3500.0f;

            if (HitBall.p2StartBall)
                force = -force;

            Vector3 dir = Quaternion.AngleAxis(angleY, v) * v2;
            ball.GetComponent<Rigidbody>().AddForce(dir * force);
            count++;
        }
    }

    void MoveP1(Vector3 pos)
    {
        Vector3 moveUp = new Vector3(0.0f, 0.0f, 0.5f);
        Vector3 moveHorizontal = new Vector3(0.5f, 0.0f, 0.0f);

        //stops user from moving after ball has hit wall
        if (HitBall.add)
        {
            if (Input.GetKey(KeyCode.UpArrow) && pos.y < maxY)
            {
                transform.Translate(-moveUp * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow) && pos.y > minY)
                transform.Translate(moveUp * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow) && pos.z < maxZ)
            {
                transform.Translate(-moveHorizontal * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && pos.z > minZ)
                transform.Translate(moveHorizontal * speed * Time.deltaTime);

        }
    }
}
