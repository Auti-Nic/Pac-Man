using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBorder : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] borderElement;
    public float duration = 5.0f;
    private float width = 0.0f;
    private float height = 0.0f;
    private List<Tween> Tweens = new List<Tween>();

    void Start()
    {
        borderElement = GameObject.FindGameObjectsWithTag("Border");

        RectTransform parentCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        width = parentCanvas.rect.width - borderElement[0].GetComponent<RectTransform>().rect.width;
        height = parentCanvas.rect.height - borderElement[0].GetComponent<RectTransform>().rect.width;

        

        foreach(GameObject i in borderElement)
        {
            Vector2 StartPos = i.GetComponent<Transform>().position;
            Vector2 EndPos = new Vector2(StartPos.x + width, StartPos.y);
            Tweens.Add(new Tween(i.transform, StartPos, EndPos, Time.time, duration));
        }
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(MoveElement( (Time.time % duration) / duration   ));
        foreach (Tween i in Tweens)
        {
            if (i.Target.position.Equals(i.EndPos))
            {
                i.EndPos = i.StartPos;
                i.StartPos = i.Target.position;
            }
        }
    }

    private IEnumerator MoveElement(float time)
    {

       

        foreach (Tween i in Tweens)
        {
           i.Target.position = Vector2.Lerp(i.StartPos, i.EndPos, time);
        }
        yield return new WaitForSeconds(0.2f);
        
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {


        if (TweenExists(targetObject))
        {
            return false;

        }
        else
        {
            Tweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }

    }

    public bool TweenExists(Transform Target)
    {
        foreach (Tween i in Tweens)
        {
            if (i.Target == Target)
            {
                return true;
            }
        }
        return false;

    }
}
