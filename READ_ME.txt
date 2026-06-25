title - Slot Machine

Overview -
	I kept the project simple, clean, and easy to use. I added basic UI features such as a Start Game button and a Pause Menu. 
	To improve the overall presentation, I also included visual elements such as a particle system and background movement.

Instructions to Run the WebGL Build -
	To play the game in your browser, please use the itch.io link below. The page is password-protected.

	Link: https://arikoun.itch.io/slot-machine
	Password: 1234

	Enter the password on the itch.io page to access and play the game.

Instructions to Run the Windows Build -
	1. Open the Windows Build folder.
	2. Run the executable (.exe) file.

Bonus Features -

	Mercy System
	I implemented a mercy system to improve the player experience. If a player experiences multiple consecutive losses, they may become frustrated and stop playing. To 	prevent this, the game tracks the number of failed attempts.

	When the number of consecutive failures exceeds the configured mercy value, the player is guaranteed a successful result on the next spin. This guarantee is applied only 	once. After a successful spin, the failure counter is reset.

	Additional Features
		- Moving background animation
		- Sound effects
		- Particle system effects

My Approach and Thought Process -
	I focused on keeping the code clean, organized, and well-commented.

	The gameplay flow works as follows:

	1. The player pulls the lever.
	2. The reel animation begins.
	3. A random result is generated when the lever is pulled.
	4. After the animation finishes, the reels display the generated symbols.
	5. The game resets and is ready for the next spin.

	I had never developed an arcade-style game before, so this project was a completely new experience for me. It provided an opportunity to learn about animation timing, 	random result generation, UI implementation, and creating a polished gameplay experience in Unity.
