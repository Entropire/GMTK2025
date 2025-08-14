using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Dupes
{
  public class DupeTracker : MonoBehaviour
  {
    [Header("This script should be on the dupe prefab")] public GameObject parent;
    public event Action<List< DupeTrackingData>> OnDupeDataChanged;
    public void Start()
    {
      parent = transform.parent.gameObject;
    }

    public void StartTracking()
    {
      StartCoroutine(trackUpdate());
    }

    public void StopTracking()
    {
      StopCoroutine(trackUpdate());

        }

    public IEnumerator trackUpdate()
    {

      yield return new WaitForFixedUpdate();
    }


    public class DupeTrackingData
    {

    }
  }
}
