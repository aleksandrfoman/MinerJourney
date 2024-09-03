using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.Scripts.Services
{
    public class SceneService : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
