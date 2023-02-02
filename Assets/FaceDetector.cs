using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.Serialization;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    public float faceX;
    public float faceY;
    string m_Path;

    /// <summary>
    /// Determines if flips vertically.
    /// </summary>
    public bool _flipVertical = false;
    public bool _flipHorizontal = true;



    // Start is called before the first frame update
    void Start()
    {
   
        WebCamDevice[] devices = WebCamTexture.devices;
        _webCamTexture = new WebCamTexture(devices[0].name);
        _webCamTexture.requestedFPS = 30f;
        _webCamTexture.Play();
        cascade = new CascadeClassifier(@"C:\Users\vit00\Documents\GitHub\seniorcare-eyetracking\Assets\OpenCV+Unity\Demo\Face_Detector\haarcascade_frontalface_default.xml");

        //cascade = new CascadeClassifier(@"C:\Unity\OpenCVPlusUnityTest\Assets\OpenCV+Unity\Demo\Face_Detector\haarcascade_eye.xml");

        //cascade = new CascadeClassifier(@"C:\Unity\OpenCVPlusUnityTest\Assets\OpenCV+Unity\Demo\Face_Detector\haarcascade_eye_tree_eyeglasses.xml");

        //cascade = new CascadeClassifier(Application.dataPath + \StreamingAssets\face @"haarcascade_frontalface_default.xml");

        //cascade = new CascadeClassifier(Application.dataPath + @"\StreamingAssets\face\haarcascade_frontalface_default.xml");
        //cascade = new CascadeClassifier(Application.dataPath + "OpenCV/Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
        //"C:\Unity\OpenCVPlusUnityTest\Assets\OpenCV+Unity\Demo\Face_Detector\haarcascade_frontalface_default.xml"
        //m_Path = Application.dataPath;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        findNewFace(frame);
        display(frame);
        //Debug.Log(m_Path);
    }

    void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        if(faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            MyFace = faces[0];
            faceX = faces[0].X;
            faceY = faces[0].Y;
        }
    }

    void display(Mat frame)
    {
        if(MyFace != null)
        {
            frame.Rectangle(MyFace, new Scalar(250, 0, 0), 2);
        }
        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }
}
