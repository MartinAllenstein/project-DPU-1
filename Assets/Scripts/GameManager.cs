using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }
   }
   
   public InventoryPanel inventoryPanel;

   public void OpenInventoryPanel()
   {
      inventoryPanel.gameObject.SetActive(true);
      inventoryPanel.OnOpen();
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      //Time.timeScale = 0;
   }

   public void CloseInventoryPanel()
   {
      inventoryPanel.gameObject.SetActive(false);
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
      //Time.timeScale = 1;
   }
   
   public float timeCounter = 30f;
   public ItemData targetItem;
   public int targetAmount = 5;
   
   public TMP_Text timeCounterText;
   public Image targetImageIcon;
   public TMP_Text targetCurrenAmountText;
   
   public bool isWin = false;

   private void Start()
   {
      targetImageIcon.sprite = targetItem.icon;
   }

   private void Update()
   {
      if (isWin == true)
      {
         return;
      }
      if (timeCounter >0f)
      {
         timeCounter -= Time.deltaTime;
         timeCounterText.text = timeCounter.ToString();
         targetCurrenAmountText.text ="x " + (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString("F1");

         if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount)
         {
            Debug.Log("Player Win");
            isWin = true;
         }
      }
      else
      {
         SceneManager.LoadScene("MainMenu");
      }
   }
}

