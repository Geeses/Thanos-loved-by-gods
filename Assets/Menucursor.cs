using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class Menucursor : MonoBehaviour
{
    private int player1 = 0;
	private int player2 = 1;
    private Player player_one;
	private Player player_two;
    private Rigidbody2D rbb;
    private Vector2 moveCursor;
    public MainMenuScritable menu;

    public float cursorSpeed;
    // Use this for initialization
    void Start()
    {
	/*	wald = waldg.GetComponent<SpriteRenderer> ();
		tempel = tempelg.GetComponent<SpriteRenderer> ();
		berg = bergg.GetComponent<SpriteRenderer> ();
		bogen = bogeng.GetComponent<SpriteRenderer> ();
		gebeaude = gebaeudeg.GetComponent<SpriteRenderer> ();
		bogen1 = bogeng1.GetComponent<SpriteRenderer> ();
*/
		player_one = ReInput.players.GetPlayer(player1);
	    player_two = ReInput.players.GetPlayer(player2);
        rbb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        cursorSpeed = menu.cursorspeed;
        Eventclick();
    }

	private void FixedUpdate()
	{
		
		moveCursor.x = player_one.GetAxis("CursorHorizontal") + player_two.GetAxis("CursorHorizontal");
		moveCursor.y = player_one.GetAxis("CursorVertical") + player_two.GetAxis("CursorVertical");
		MoveCursor();
	}

	private void MoveCursor()
    {
        rbb.velocity = new Vector2(moveCursor.x * cursorSpeed, moveCursor.y * cursorSpeed); // Geschwindigkeit auf RB übertragen
    }
    
    public void Eventclick()
    {
		if (player_one.GetButtonDown ("selectMenuPoint") || player_two.GetButtonDown ("selectMenuPoint")) {
        
            

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
            Debug.DrawRay(transform.position, Vector2.zero, Color.green);


			switch (hit.collider.tag){
	
		case "NewGame":
			
				NewGame();
			
			//	gebeaude.sprite = wald.sprite;
				Debug.Log("NewGame");

				break;
			case "Options":
				Debug.Log("op");
				Settings();
				break;
			case "Exit":
				Debug.Log("exit");
				ExitGame();
				break;
			case "TempleLevel":
				SceneManager.LoadScene(1);
				break;
			case "WaldLevel":
				SceneManager.LoadScene(1);
				break;
			case "SchneeLevel":
				SceneManager.LoadScene(1);
				break;
			default:
				break;
		}
	}
		}

        
    


    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {

        //Pausenmenü.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
    

   
