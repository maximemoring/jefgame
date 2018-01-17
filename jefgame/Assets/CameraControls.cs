using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    private float camSize = 5.0f;
    private Vector3 target, offset;
    private float camTheta = Mathf.PI*0.25f;

    private const float orbitSpeed = .05f;

    private const float distance = 10.0f;
    private const float viewAngle = 30.0f;

    private Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);

	void Start () {
        target = new Vector3(0.0f, 0.0f, 0.0f);
        float x = distance * Mathf.Cos(camTheta);
        float y = distance * Mathf.Sin(camTheta);
        float z = distance * 0.5f;
        offset = new Vector3(x, y, z);
        CamUpdate();
	}

	void Update () {
        bool needCamUpdate = false;
        if (Input.GetKey(KeyCode.A))
        {
            camTheta += orbitSpeed;
            needCamUpdate = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            camTheta -= orbitSpeed;
            needCamUpdate = true;
        }

        if (needCamUpdate) CamUpdate();
    }

    void CamUpdate()
    { 
        offset.x = distance * Mathf.Cos(camTheta);
        offset.y = distance * Mathf.Sin(camTheta);
        offset.z = distance * 0.5f;
        transform.position = offset;
        transform.LookAt(target, up);
    }
}
