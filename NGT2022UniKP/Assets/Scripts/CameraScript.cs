using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 cameraOffset;

    public float smoothFactor = 0.1f;

    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = true;

    public float rotationSpeed;
    public float rotationSpeed_2;

    public Transform obstruction;
    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        obstruction = targetObject;
        cameraOffset = transform.position - targetObject.position;
        rotationSpeed = 3.0f;
        rotationSpeed_2 = 10.0f;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Mouse X") == 0)
        {
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Vertical2") * rotationSpeed, Vector3.up);

                cameraOffset = camTurnAngle * cameraOffset;
            }

            Vector3 newPosition = targetObject.transform.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        }
        else if (Input.GetAxis("Vertical2") == 0)
        {
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed_2, Vector3.up);

                cameraOffset = camTurnAngle * cameraOffset;
            }

            Vector3 newPosition = targetObject.transform.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        }

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(targetObject);
        }

        ViewObstructed();
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, targetObject.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "SyBall")
            {
                return;
            }
            if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Enemy")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, targetObject.position) >= 1.5f)
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }

        }
        else
        {
            obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            if (Vector3.Distance(transform.position, targetObject.position) < 4.5f)
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
        }
        
        
    }
}
