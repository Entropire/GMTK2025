using Player.Dupes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayDupes : MonoBehaviour
{
  [SerializeField] public string KeyBind = "E";
  [SerializeField] private GameObject playerPrefab;
  List<GameObject> playerDupes = new();
  DupeTracker dupeTracker;

  void Start()
  {
    dupeTracker = FindObjectOfType<DupeTracker>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyBind) && dupeTracker != null && dupeTracker.CurrentInstance != null && dupeTracker.CurrentInstance.CoordsAnimSet.Count > 0)
    {
      foreach (var instance in DupeTracker.Instances)
      {
        playerDupes.Add(Instantiate(playerPrefab));
        if (instance.CoordsAnimSet.Count > 0)
        {
          StartCoroutine(PlaySequence(instance.transform, instance.CoordsAnimSet));
        }
      }
    }
  }
  public IEnumerator PlaySequence(Transform target, List<DupeData> sequence)
  {
    foreach (var dupe in sequence)
    {
      target.position = Vector3.Lerp(target.position, dupe.Transform.position, dupe.TimePassed);

      yield return new WaitForFixedUpdate();
    }
  }

}