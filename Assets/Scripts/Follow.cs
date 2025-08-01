using UnityEngine;

public class Follow : MonoBehaviour
{
  [SerializeField] private GameObject following;
  [SerializeField] private float followSpeed = 2f;
  [SerializeField] private float stopThreshold = 0.01f; 

  void Update()
  {
    Vector3 currentPosition = transform.position;
    Vector3 targetPosition = following.transform.position;
    targetPosition.z = currentPosition.z; 

    if (Vector3.Distance(currentPosition, targetPosition) < stopThreshold)
    {
      transform.position = targetPosition;
    }
    else
    {
      transform.position = Vector3.Lerp(
          currentPosition,
          targetPosition,
          Time.deltaTime * followSpeed
      );
    }
  }

}
