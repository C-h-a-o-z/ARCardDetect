using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImages : MonoBehaviour
{
    [SerializeField] GameObject[] arObjectsToPlace;

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            arObjects.Add(arObject.name, newARObject);
            newARObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                UpdateARImage(trackedImage);
            }
            else
            {
                arObjects[trackedImage.referenceImage.name].SetActive(false);
            }
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        AssignGameObject(trackedImage);
    }

    private void AssignGameObject(ARTrackedImage rTrackedImage)
    {
        GameObject prefab = arObjects[rTrackedImage.referenceImage.name];
        prefab.transform.position = rTrackedImage.transform.position;
        prefab.transform.rotation = rTrackedImage.transform.rotation; //Quaternion.Euler(rTrackedImage.transform.rotation.x/* + prefab.transform.rotation.x*/, rTrackedImage.transform.rotation.y, rTrackedImage.transform.rotation.z);
        prefab.SetActive(true);

        foreach (GameObject go in arObjects.Values)
        {
            if (go.name != rTrackedImage.referenceImage.name + "(Clone)")
            {
                go.SetActive(false);
            }
        }
    }
}
