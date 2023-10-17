# Player Movement and Raycast
The 2D player moves and jumps using the linear velocity of the Rigidbody2D. 
There is method to determine if the player is looking left or right, so the scale of the x axis can be inverted, changing the orientation of the player's sprite.

For debugging purposes, the OnDrawGizmos method was implemented (keys E - Q) to see how the raycast is gonna be draw on the screen by Gizmos (DrawLine) and the Unity's Handles way (DrawWireDisc).
And finally, there are 4 Raycast interaction methods declared, each one can be called by pressing the keys: R, M, C and O.