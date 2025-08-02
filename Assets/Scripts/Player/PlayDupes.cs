using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Dupes
{
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
          
          playerDupes.Add(newDupe);

          StartCoroutine(PlaySequence(newDupe.transform, instance.CoordsAnimSet));
        }
      }
    }
    public IEnumerator PlaySequence(Transform target, List<DupeData> sequence)
    {
      print("Playing sequence for dupe");
      for (int i = 0; i < sequence.Count; i++)
      {
        Vector3 startPos = target.position;
        Vector3 endPos = new Vector3(sequence[i].Location.x, sequence[i].Location.y, startPos.z);
        float duration = sequence[i].TimePassed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
          target.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
          elapsed += Time.deltaTime;
          yield return null;
        }
        target.position = endPos; // Ensure final position is set
      }
      sequence.Add(new DupeData(target.position, StatesEnum.Idle, 0f));
    }
  }
}