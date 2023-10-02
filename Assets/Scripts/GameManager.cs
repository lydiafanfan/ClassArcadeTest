using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager me;
    private static int enemiesDestroyed = 0;

    void Start()
    {
        if(me != null) {
            Destroy(this.gameObject);
        }

        me = this;
    }

    public static void LogEnemyDestroyed()
    {
        me.LogEnemyDestroyedInternal();
    }

    private void LogEnemyDestroyedInternal()
    {
        enemiesDestroyed ++;
        Debug.Log("Enemies Destroyed: " + enemiesDestroyed);

        if(enemiesDestroyed >= 2) {
            enemiesDestroyed = 0;
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(currentSceneNumber+1);

        while(!asyncOperation.isDone) {
            yield return null;
        }
    }

}
