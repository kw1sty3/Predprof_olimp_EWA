using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ProgrammScript : MonoBehaviour
{
    [Header("Put you marker")]
    [SerializeField] private GameObject PlaneMarkerPrefab;
    public bool flag = false;
    private ARRaycastManager ARRAycastManagerScripts;
    private Vector2 TouchPosition;
    public GameObject ObjectTospawn;
    public bool Rotation;
    private Quaternion YRotation;
    private GameObject SelectedObject;
    [SerializeField] private Camera ARCamera;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();



    void Start()
    {
        ObjectTospawn = Object.ChooseObject;
        ARRAycastManagerScripts = FindObjectOfType<ARRaycastManager>();
        
        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ShowMarkerAndObject();
        }
        MoveOBject();
    }
    void ShowMarkerAndObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRAycastManagerScripts.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);


        // показ маркера
        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
        // установка объекта
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(ObjectTospawn, hits[0].pose.position, ObjectTospawn.transform.rotation);
            flag = false;
        }
    }

    void MoveOBject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("UnSelected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }
            SelectedObject = GameObject.FindWithTag("Selected");
            if (touch.phase == TouchPhase.Moved)
            {
                if (Rotation)
                {
                    YRotation = Quaternion.Euler(0f, -touch.deltaPosition.x * 0.1f, 0f);
                    SelectedObject.transform.rotation = YRotation * SelectedObject.transform.rotation;
                }
                else
                {
                    ARRAycastManagerScripts.Raycast(TouchPosition, hits, TrackableType.Planes);
                    SelectedObject.transform.position = hits[0].pose.position;
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                }
            }
        }
    }
}

