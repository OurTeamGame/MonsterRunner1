using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrallexEffect : MonoBehaviour
{
     public GameObject Camera;
     public Vector2 prallexMultiply;
     public float TexcureunitSize;
     public bool infinityBackgroundX;
     Vector3 CameraLastPosition , DeltaTransform;
    // Start is called before the first frame update
    void Start()
    {
        CameraLastPosition = Camera.transform.position;
        Sprite sprite =   GetComponent<SpriteRenderer>().sprite;
        Texture texture = sprite.texture;
        TexcureunitSize = texture.width / sprite.pixelsPerUnit;
            

    }

    // Update is called once per frame
    void LateUpdate()
    {
        DeltaTransform = Camera.transform.position - CameraLastPosition;
        transform.position += new Vector3(DeltaTransform.x * prallexMultiply.x, DeltaTransform.y * prallexMultiply.y, 0);
        CameraLastPosition = Camera.transform.position;

        //اگر به اخر بک گراند رسیدیم ان را به ماکن فعلی دوربین جابه جا کن
        if (Mathf.Abs(Camera.transform.position.x - transform.position.x) >= TexcureunitSize * transform.localScale.x && infinityBackgroundX)
        {
            float Offset = (Camera.transform.position.x - transform.position.x) % TexcureunitSize;
            transform.position = new Vector3(Camera.transform.position.x , transform.position.y, transform.position.z);
        }




    }
}
