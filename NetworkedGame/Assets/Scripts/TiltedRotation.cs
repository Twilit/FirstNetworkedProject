using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltedRotation : MonoBehaviour
{

    public float faceDir;
    public Quaternion axisTilt;
    public Camera cam;

    void Start()
    {
        axisTilt = transform.localRotation;
    }

    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0, faceDir, 0) * axisTilt;

        //transform.Rotate(0, faceDir, 0);
        //transform.RotateAroundLocal(transform.up,faceDir);

        transform.rotation = Quaternion.Euler( GetMousePosDir(transform.position));
    }

    Vector2 GetMousePosDir(Vector3 currentPos)
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos = cam.ScreenToViewportPoint(mousPos);

        Vector2 dir = currentPos - mousPos;

        return dir;
    }
}
