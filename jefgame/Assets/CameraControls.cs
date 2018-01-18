using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    // Editor editable variables
    public float orbitSpeed = 3f;
    public float moveSpeed = 10f;
    public float distance = 10.0f;
    public float viewAngle = 30.0f; // Currently unused
    // Private variables
    private bool needCamUpdate = false;
    private Vector3 target, offset;
    private float camTheta = Mathf.PI*0.25f; // Please explain
	private float heightCoef = 1.0f / Mathf.Sqrt(3.0f); // Make use of the public viewAngle variable for this

    void Start() {
        target = new Vector3(0.0f, 0.0f, 0.0f);
        offset = new Vector3(0.0f, 0.0f, 0.0f);
        CamUpdate();
	}

	void Update() {
        // Camera rotation
        if (Input.GetKey(KeyCode.Q)) {
            camTheta -= orbitSpeed * Time.deltaTime;
            needCamUpdate = true;
        } else if (Input.GetKey(KeyCode.E)) {
            camTheta += orbitSpeed * Time.deltaTime;
            needCamUpdate = true;
        }
        // Camera "vertical" movement
		if (Input.GetKey(KeyCode.W)) {
			target.x += (moveSpeed * Mathf.Cos(camTheta - Mathf.PI)) * Time.deltaTime;
			target.z += (moveSpeed * Mathf.Sin(camTheta - Mathf.PI)) * Time.deltaTime;
			needCamUpdate = true;
		} else if (Input.GetKey(KeyCode.S)) {
            target.x += (moveSpeed * Mathf.Cos(camTheta)) * Time.deltaTime;
            target.z += (moveSpeed * Mathf.Sin(camTheta)) * Time.deltaTime;
            needCamUpdate = true;
        }
        // Camera "lateral" movement
        if (Input.GetKey(KeyCode.A)) {
			target.x += (moveSpeed * Mathf.Cos(camTheta - Mathf.PI * 0.5f)) * Time.deltaTime;
			target.z += (moveSpeed * Mathf.Sin(camTheta - Mathf.PI * 0.5f)) * Time.deltaTime; 
			needCamUpdate = true;
		} else if (Input.GetKey(KeyCode.D)) {
			target.x += (moveSpeed * Mathf.Cos(camTheta + Mathf.PI * 0.5f)) * Time.deltaTime;
			target.z += (moveSpeed * Mathf.Sin(camTheta + Mathf.PI * 0.5f)) * Time.deltaTime;
			needCamUpdate = true;
		}

        if (needCamUpdate) CamUpdate();
    }

    void CamUpdate() {
        updateOffset();
        transform.position = offset;
        transform.LookAt(target);
    }

    void updateOffset() {
        offset.x = target.x + distance * Mathf.Cos(camTheta);
        offset.y = target.y + distance * heightCoef;
        offset.z = target.z + distance * Mathf.Sin(camTheta);
    }
}
