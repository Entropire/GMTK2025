using Player.Dupes;
using System.Linq;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(100)]

public class DupeCounter : MonoBehaviour
{
  TMP_Text text;
  DupeTracker dupeTracker;
  private void Start()
  {
    text = GetComponentsInChildren<TMP_Text>().FirstOrDefault(x => x.name == "DupeCountText");
    dupeTracker = FindObjectOfType<DupeTracker>();
    dupeTracker.NewDupeCreated += runUpdate;
    runUpdate();
  }

  private void runUpdate()
  {
    if (DupeTracker.Instances.Count == dupeTracker.MaxDupes)
    {
      text.fontStyle = FontStyles.Bold;
      text.color = Color.red;
      text.text = "No Dupes left";
    }
    else
    {
      text.text = $"Dupes left: {dupeTracker.MaxDupes - DupeTracker.Instances.Count}";
    }
  }
}
