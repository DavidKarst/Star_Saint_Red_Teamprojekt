using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineWalker : MonoBehaviour {

    public BezierSpline spline;

    public float duration;

    private float progress;

    public bool lookForward;

    public bool move;

    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        if(move)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                progress = 1f;
            }
            Vector3 position = spline.GetPoint(progress);
            transform.localPosition = position;
            if (lookForward)
            {
                transform.LookAt(position + spline.GetDirection(progress));
            }
        }

    }

    public void activate()
    {
        move = true;
    }

    public void deactivate()
    {
        move = !move;
    }

    public float getProgress()
    {
        return progress;
    }
}
