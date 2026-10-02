using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	private Transform target;
    public float resetSpeed = 0.5f;
	public float cameraSpeed = 0.3f;

	public Bounds cameraBounds;


	private float offsetZ;
	private Vector3 currentVelocity;

	private bool followsPlayer;

	void Awake() {
		BoxCollider2D myCol = GetComponent<BoxCollider2D> ();
		myCol.size = new Vector2 (Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
		cameraBounds = myCol.bounds;
	}

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("CameraFollow: no active object tagged Player was found.");
            enabled = false;
            return;
        }

        target = player.transform;

        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (followsPlayer) {
			Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;

			if (aheadTargetPos.x >= transform.position.x) {
				Vector3 newCameraPosition = Vector3.SmoothDamp (transform.position, aheadTargetPos,
					ref currentVelocity, cameraSpeed);

				transform.position = new Vector3 (newCameraPosition.x, transform.position.y,
					newCameraPosition.z);

			}
		}
	}


} // class




































