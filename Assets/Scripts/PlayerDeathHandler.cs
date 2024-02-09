using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas GameOverCanvas;

    private void Start() {
        GameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
