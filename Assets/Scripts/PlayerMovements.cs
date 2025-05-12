using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    public static PlayerMovements instance;

    public int score;

    [SerializeField] private float speed;
    [SerializeField] private float accel;
    [SerializeField] private float decel;

    [SerializeField] private TextMeshProUGUI scoreDisplay;

    private Rigidbody2D rb;
    private SaveSystem saveSystem;

    Vector2 moveDir;

    private void FixedUpdate()
    {
        Vector2 targetMovement = moveDir * speed;
        Vector2 movementDiff = targetMovement - rb.velocity;
        float accelRate = (Mathf.Abs(targetMovement.sqrMagnitude) > 0.1f) ? accel : decel;

        Vector2 movement = movementDiff * accelRate;

        rb.AddForce(movement, ForceMode2D.Force);

        scoreDisplay.text = score.ToString();
    }

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        saveSystem = SaveSystem.instance;
        if (SaveSystem.instance.HasASave(PlayerPrefs.GetInt("SaveIndex")))
        {
            transform.position = new Vector3(saveSystem.data.playerInfo.x, saveSystem.data.playerInfo.y, 0);
            score = saveSystem.data.playerInfo.score;
        }
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveDir = ctx.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            LevelLoader.mInstance.mCoins.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            score++;
        }
    }
}
