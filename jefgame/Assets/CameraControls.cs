using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    private float camSize = 5.0f;
    private Vector3 target, offset;
    private float camTheta = Mathf.PI*0.25f;

    private const float orbitSpeed = .05f;
	private const float moveSpeed = .05f;

    private const float distance = 10.0f;
    private const float viewAngle = 30.0f;

	private float heightCoef = 1.0f / Mathf.Sqrt(3.0f);

    private Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);

	void Start () {
        target = new Vector3(0.0f, 0.0f, 0.0f);
        float x = distance * Mathf.Cos(camTheta);
		float y = distance * heightCoef;
		float z = distance * Mathf.Sin(camTheta);
        offset = new Vector3(x, y, z);
        CamUpdate();
	}

	void Update () {
        bool needCamUpdate = false;
        if (Input.GetKey(KeyCode.Q))
        {
            camTheta += orbitSpeed;
            needCamUpdate = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            camTheta -= orbitSpeed;
            needCamUpdate = true;
        }

		if (Input.GetKey(KeyCode.W))
		{
			target.x += moveSpeed * Mathf.Cos (camTheta - Mathf.PI);
			target.z += moveSpeed * Mathf.Sin (camTheta - Mathf.PI);
			needCamUpdate = true;
		}

		if (Input.GetKey(KeyCode.A))
		{
			target.x += moveSpeed * Mathf.Cos (camTheta - Mathf.PI * 0.5f);
			target.z += moveSpeed * Mathf.Sin (camTheta - Mathf.PI * 0.5f);
			needCamUpdate = true;
		}

		if (Input.GetKey(KeyCode.S))
		{
			target.x += moveSpeed * Mathf.Cos (camTheta);
			target.z += moveSpeed * Mathf.Sin (camTheta);
			needCamUpdate = true;
		}

		if (Input.GetKey(KeyCode.D))
		{
			target.x += moveSpeed * Mathf.Cos (camTheta + Mathf.PI * 0.5f);
			target.z += moveSpeed * Mathf.Sin (camTheta + Mathf.PI * 0.5f);
			needCamUpdate = true;
		}


        if (needCamUpdate) CamUpdate();
    }

    void CamUpdate()
    { 
        offset.x = target.x + distance * Mathf.Cos(camTheta);
		offset.y = target.y + distance * heightCoef;
		offset.z = target.z + distance * Mathf.Sin(camTheta);
        transform.position = offset;
        transform.LookAt(target);
    }
}
