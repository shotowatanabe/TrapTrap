using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera;
    public float speed = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit;
        Vector3 temp = this.transform.position - target.transform.position;
        Vector3 normal = temp.normalized;
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        int layerStage = LayerMask.GetMask(new string[] { "Stage" });

        if (Physics.Raycast(target.transform.position, normal, out hit, distance, layerStage))
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, hit.point, speed * Time.deltaTime);
        }
        else
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, this.transform.position, speed * Time.deltaTime);
        }
    }
}
