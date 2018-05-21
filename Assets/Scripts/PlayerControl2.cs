using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour {

	public float speed = 50f;
	public float maxZ = 21.0f, minZ = -1.0f;
	public float maxY = 5.5f, minY = -6.5f;

	public static Vector3 startpos2;

	// Use this for initialization
	void Start () {

		startpos2 = transform.position;
		Debug.Log (startpos2);
	}

	void FixedUpdate() {

		Vector3 pos = transform.position;

        MoveP2(pos);
	}

    void MoveP2(Vector3 pos)
    {
        Vector3 moveUp = new Vector3(0.0f, 0.0f, 0.5f);
        Vector3 moveHorizontal = new Vector3(0.5f, 0.0f, 0.0f);

        //stops user from moving after ball has hit wall
        if (HitBall.add)
        {

            if (Input.GetKey(KeyCode.W) && pos.y < maxY)
                transform.Translate(-moveUp * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.S) && pos.y > minY)
                transform.Translate(moveUp * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A) && pos.z < maxZ)
                transform.Translate(-moveHorizontal * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D) && pos.z > minZ)
                transform.Translate(moveHorizontal * speed * Time.deltaTime);

        }
    }

}
