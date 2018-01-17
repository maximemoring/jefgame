using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    private float camSize = 5.0f;
    private Vector3 target, offset;
    private float camTheta = Mathf.PI*0.25f;

    private const float orbitSpeed = .05f;

    private const float distance = 10.0f;
    private const float viewAngle = 30.0f;

	void Start () {
        target = new Vector3(0.0f, 0.0f, 0.0f);
        float x = distance * Mathf.Cos(camTheta);
        float y = distance * 0.5f;
        float z = distance * Mathf.Sin(camTheta);
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
        offset.y = distance * 0.5f;
        offset.z = distance * Mathf.Sin(camTheta);
        transform.position = offset;
        transform.LookAt(target);
    }
}
