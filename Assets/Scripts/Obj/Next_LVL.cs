using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_LVL : MonoBehaviour
{
    [SerializeField] private string nextLevelName = "lvl_0";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
