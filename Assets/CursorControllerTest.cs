using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerTest : MonoBehaviour
{
    FaceDetector faceDetector;
    float speed = 3f;
    float unit = 2000f;
    float threshold = 5f;
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
        float h = 0;

        //Face X
        float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + normX, transform.position.y, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����

        if (transform.position.x < lastX && Mathf.Abs(transform.position.x - lastX) > threshold)
        {
            if (transform.position.x > 0.2)
            {
                threshold = 10f;
                h = unit * 2.5f;
            }
            else
            {
                threshold = 5f;
                h = unit;
            }
        }
        else if (transform.position.x > lastX && Mathf.Abs(transform.position.x - lastX) > threshold)
        {
            if (transform.position.x < -0.2)
            {
                threshold = 10f;
                h = -unit * 2.5f;
            }
            else
            {
                threshold = 5f;
                h = -unit;
            }
        }

        lastX = faceDetector.faceX;

        ////Face Y
        //float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - normY, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����
        //lastY = faceDetector.faceY;

        //Face
        //float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        //float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + normX, transform.position.y - normY, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����
        //lastX = faceDetector.faceX;
        //lastY = faceDetector.faceY;

        //Move();
    }

    void Move()
    {
        float step = speed * Time.deltaTime;

        ////Face X(Face�� ��ġ�� �ݿ��Ͽ� X ��ǥ �̵�)
        //float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + normX, transform.position.y, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����
        //lastX = faceDetector.faceX;

        ////Face Y(Face�� ��ġ�� �ݿ��Ͽ� X ��ǥ �̵�)
        //float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - normY, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����
        //lastY = faceDetector.faceY;

        float h = 0;
        float v = 0;

        float normX = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);
        float normY = Mathf.Clamp(faceDetector.faceY - lastY, -1, 1);

        //Vector3 curPos = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + normX, transform.position.y, transform.position.z), step); //transform.position.y + norm �� �ݴ�������� �ۿ��ϹǷ� ��ȣ �ݴ�� ����;
        Vector3 curPos = transform.position;

        if (curPos.x < lastX && Mathf.Abs(curPos.x - lastX) > 0.1)
        {
            h = 1;
        }
        else if (curPos.x > lastX && Mathf.Abs(curPos.x - lastX) > 0.1)
        {
            h = -1;
        }

        if (curPos.y < lastY && Mathf.Abs(curPos.y - lastY) > 0.1)
        {
            v = 1;
        }
        else if (curPos.y > lastY && Mathf.Abs(curPos.y - lastY) > 0.1)
        {
            v = -1;
        }
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;


        transform.position = curPos + nextPos;
        lastX = faceDetector.faceX;
        //lastY = faceDetector.faceY;

    }
}
