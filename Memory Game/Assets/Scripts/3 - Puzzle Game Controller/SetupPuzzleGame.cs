﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetupPuzzleGame : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;

	private Sprite[] candyPuzzleSprites, transportPuzzleSprites, fruitPuzzleSprites;

    private AudioClip[] audioClips;

    private List<Sprite> gamePuzzles = new List<Sprite>();

    private List<AudioClip> gamePuzzleAudioClips = new List<AudioClip>();

    private List<Button> puzzleButtons = new List<Button> ();
	
	private List<Animator> puzzleButtonsAnimators = new List<Animator> ();
	
	private int level;
	private string selectedPuzzle;
	
	private int looper;

	void Awake() {
		candyPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Candy");
		transportPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Transport");
		fruitPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Fruits");

        audioClips = Resources.LoadAll<AudioClip>("Sounds/PNL");

        AudioSource aSource = GetComponent<AudioSource>();
	    aSource.clip = audioClips[4];
        aSource.Play();
	}

	void PrepareGameSprites() {
		gamePuzzles.Clear ();
		gamePuzzles = new List<Sprite> ();

        gamePuzzleAudioClips.Clear();
        gamePuzzleAudioClips = new List<AudioClip>();

		int index = 0;

		switch (level) {
		case 0:
			looper = 6;
			break;
			
		case 1:
			looper = 12;
			break;
			
		case 2:
			looper = 18;
			break;
			
		case 3:
			looper = 24;
			break;
			
		case 4:
			looper = 30;
			break;
		}

		switch (selectedPuzzle) {
		
		case "Candy Puzzle":

			for(int i = 0; i < looper; i++) {

				if(index == (looper / 2)) {
					index = 0;
				}

				gamePuzzles.Add(candyPuzzleSprites[index]);
                gamePuzzleAudioClips.Add(audioClips[index]);

				index++;

			}

			break;

		case "Transport Puzzle":
			
			
			for(int i = 0; i < looper; i++) {
				
				if(index == (looper / 2)) {
					index = 0;
				}
				
				gamePuzzles.Add(transportPuzzleSprites[index]);
				
				index++;
				
			}
			
			break;
			
		case "Fruit Puzzle":
			
			for(int i = 0; i < looper; i++) {
				
				if(index == (looper / 2)) {
					index = 0;
				}
				
				gamePuzzles.Add(fruitPuzzleSprites[index]);
				
				index++;
				
			}
			
			break;
			
		}

		Shuffle (gamePuzzles, gamePuzzleAudioClips);

	}

	void Shuffle(List<Sprite> list, List<AudioClip> audList ) {
		for (int i = 0; i < list.Count; i++) {
			Sprite temp = list[i];
            AudioClip tempAu = audList[i];
            int randomIndex = Random.Range(i, list.Count);
			list[i] = list[randomIndex];
		    audList[i] = audList[randomIndex];
            list[randomIndex] = temp;
            audList[randomIndex] = tempAu;

        }
	}

	public void SetLevelAndPuzzle(int level, string selectedPuzzle) {
		this.level = level;
		this.selectedPuzzle = selectedPuzzle;

		PrepareGameSprites ();

		puzzleGameManager.SetGamePuzzleSprites (this.gamePuzzles, gamePuzzleAudioClips);

	}
	
	public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons, List<Animator> puzzleButtonsAnimators) {
		this.puzzleButtons = puzzleButtons;
		this.puzzleButtonsAnimators = puzzleButtonsAnimators;

		puzzleGameManager.SetUpButtonsAndAnimators (puzzleButtons, puzzleButtonsAnimators);

	}

} // SetupPuzzleGame



















































