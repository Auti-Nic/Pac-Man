using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private float radius = 3, angularSpeed = 2f;
    
    
    public Transform center;

    
    float posX, posY, angle = 0f;



    // Update is called once per frame
    void Update()
    {
        posX = center.position.x + Mathf.Cos(angle) * radius;
        posY = center.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if(angle > 360f)
        {
            angle = 0f;
        }

        Vector2 targetDir = center.position - transform.position; // 目标坐标与当前坐标差的向量

        Vector2.Angle(transform.forward, targetDir); // 返回当前坐标与目标坐标的角度
        
        Debug.Log(Vector2.Angle(transform.forward, targetDir));
    }
}
