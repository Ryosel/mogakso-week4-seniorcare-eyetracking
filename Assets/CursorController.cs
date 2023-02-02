using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    FaceDetector faceDetector;
    float speed = 5f;

    float lastX = 0;
    float lastY = 0;

    // Start is called before the first frame update
    void Start()
    {
        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        ////Face X
        //float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x+normX, transform.position.y, transform.position.z), step); //transform.position.y + norm 시 반대방향으로 작용하므로 부호 반대로 적용
        //lastX = faceDetector.faceX;

        //////Face Y
        ////float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);
        ////transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - normY, transform.position.z), step); //transform.position.y + norm 시 반대방향으로 작용하므로 부호 반대로 적용
        ////lastY = faceDetector.faceY;
        ///

        //Face
        float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + normX, transform.position.y - normY, transform.position.z), step); //transform.position.y + norm 시 반대방향으로 작용하므로 부호 반대로 적용
        lastX = faceDetector.faceX;
        lastY = faceDetector.faceY;
    }
}
