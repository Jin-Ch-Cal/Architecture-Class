using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchMovement : MonoBehaviour
{
    SketchFace sketchFace;

    public float modelmoveSpeed = 10f;
    public float modelturnSpeed = 50f;

    Vector3 rescale = new Vector3 (1,1,1);
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);

    Vector3 centralPoint;

    void Awake()
    {
        sketchFace = GetComponent<SketchFace>();
    }

    void Start()
    {

    }

    void Update()
    {
        //Get centralpoint.
        centralPoint = GetCentralPoint();
        
        //Move model forward, back, left, and right, by keyboard.
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * modelmoveSpeed * Time.deltaTime);

        //Rotate model by mouse wheel.
        transform.RotateAround (centralPoint, Vector3.up, Input.mouseScrollDelta.y * modelturnSpeed);

        //Scale model by [ and ].
        if (Input.GetKey(KeyCode.RightBracket))
        {
            rescale += scaleChange;
            ScaleAround(transform, (sketchFace.click1 + sketchFace.click2) / 2, rescale);
        }
        if (Input.GetKey(KeyCode.LeftBracket))
        {
            rescale -= scaleChange;
            ScaleAround(transform, (sketchFace.click1 + sketchFace.click2) / 2, rescale);
        }



    }
    public void ScaleAround(Transform target, Vector3 worldPivot, Vector3 newScale)
    {
        //Seemed to work, except when under a parent that has a non uniform scale and rotation it was a bit off.
        //This might be due to transform.lossyScale not being accurate under those conditions, or possibly something else is wrong...
        //Maybe things can work if we can find a way to convert the "newPosition = ..." line to use Matrix4x4 for possibly more scale accuracy.
        //However, I have tried and tried and have no idea how to do that kind of math =/

        Vector3 localOffset = target.InverseTransformPoint(worldPivot);

        Vector3 localScale = target.localScale;
        Vector3 scaleRatio = new Vector3(SafeDivide(newScale.x, localScale.x), SafeDivide(newScale.y, localScale.y), SafeDivide(newScale.z, localScale.z));
        Vector3 scaledLocalOffset = localOffset;
        scaledLocalOffset.Scale(scaleRatio);
        Vector3 newPosition = target.rotation * Vector3.Scale(localOffset - scaledLocalOffset, target.lossyScale) + target.position;

        target.localScale = newScale;
        target.position = newPosition;
    }

    float SafeDivide(float value, float divider)
    {
        if (divider == 0) return 0;
        return value / divider;
    }

    Vector3 GetCentralPoint()
    {
        return (sketchFace.click1 + sketchFace.click2) / 2;
    }

}
