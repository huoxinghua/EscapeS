using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static int Points = 0;
  [SerializeField] GameObject gate;
  
  private void Update()
  {
    if (Points >= 8)
    {
      gate.SetActive(false);
    }
    if (Points >= 14)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
