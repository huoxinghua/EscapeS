using UnityEngine;
public class GameManager : MonoBehaviour
{
  public static int Points = 0;
  [SerializeField] GameObject gate;
  [SerializeField] GameObject fgate;
  private void Update()
  {
    if (Points >= 8)
    {
      gate.SetActive(false);
    }
    if (Points >= 14)
    {
      fgate.SetActive(false);
    }
  }
}
