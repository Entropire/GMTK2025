using Player.Dupes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDupes : MonoBehaviour
{
  [SerializeField] public KeyCode KeyBind = KeyCode.E;
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
        GameObject newDupe = Instantiate(playerPrefab);
        playerDupes.Add(Instantiate(newDupe));
        if (instance.CoordsAnimSet.Count > 0)
        {
          StartCoroutine(PlaySequence(newDupe.transform, instance.CoordsAnimSet));
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