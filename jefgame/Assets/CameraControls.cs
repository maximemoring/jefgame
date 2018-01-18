using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    private float camSize = 5.0f;
    private Vector3 target, offset;
    private float camTheta = Mathf.PI*0.25f;

    private const float orbitSpeed = .05f;
    private const float moveSpeed = .05f;

    private const float distance = 10.0f;

    private const float heightCoef = 0.57735026919f; // =1/sqrt(3), for a 30-degree vertical viewing angle


    void Start () {
        target = new Vector3(0.0f, 0.0f, 0.0f);
        offset = new Vector3(0.0f, 0.0f, 0.0f);
        updateOffset();
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
            target.x += moveSpeed * Mathf.Cos(camTheta + Mathf.PI);
            target.z += moveSpeed * Mathf.Sin(camTheta + Mathf.PI);
            needCamUpdate = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target.x += moveSpeed * Mathf.Cos(camTheta + 0.5f * Mathf.PI);
            target.z += moveSpeed * Mathf.Sin(camTheta + 0.5f * Mathf.PI);
            needCamUpdate = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target.x += moveSpeed * Mathf.Cos(camTheta);
            target.z += moveSpeed * Mathf.Sin(camTheta);
            needCamUpdate = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            target.x += moveSpeed * Mathf.Cos(camTheta - 0.5f * Mathf.PI);
            target.z += moveSpeed * Mathf.Sin(camTheta - 0.5f * Mathf.PI);
            needCamUpdate = true;
        }

        if (needCamUpdate) CamUpdate();
    }

    void CamUpdate()
    {
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
