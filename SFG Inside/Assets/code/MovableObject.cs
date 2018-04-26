using UnityEngine;

public class MovableObject : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;

    private Vector3 target;
    private Vector3 source;
    private float distance;
    private float startTime;

    void Start ()
    {
        startTime = Time.time;
        target = endPoint.position;
        source = startPoint.position;
        distance = Vector3.Distance(source, target);
    }

	void Update ()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / distance;
        transform.position = Vector3.Lerp(source, target, fracJourney);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            startTime = Time.time;
            if (target == endPoint.position)
            {
                target = startPoint.position;
                source = endPoint.position;
            }
            else
            {
                target = endPoint.position;
                source = startPoint.position;
            }
        }
    }
}
