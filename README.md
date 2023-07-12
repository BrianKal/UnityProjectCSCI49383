# UnityProjectCSCI49383
Virtual Reality Video Game called Stranded Soldier

I had a lot of issues with the alien asset for this game, they would randomly disappear from Unity (either the textures or the entire prefab). If this project is open and it looks like the enemy is missing (they're invisible when playing the game), just right click in the "Enemy & Animations" folder and click create asset, then look for the enemy asset in that same folder (the folder contains the asset but Unity can't find it for some reason). The enemy asset should be called Ch50_nonPBR.fbx . Once the enemy asset is in Unity, click on extract textures to makre sure the enemy texture is there.

The scripts that I wrote myself are inside the "Samples" folder, opening up folders until you see the "Scripts" folder. AboutButtonBehavior.cs, AnimationStateController.cs, DoneButtonBehavior.cs, GameManager.cs, MainMeni.cs, ShieldBehavior.cs, ShootGun.cs, SpawnBehavior.cs, and StartButtonBehavior.cs are all scripts that I wrote myself.
