# Player Movement and Raycast
The 2D player moves and jumps using the linear velocity of the Rigidbody2D. 
There is method to determine if the player is looking left or right, so the scale of the x axis can be inverted, changing the orientation of the player's sprite.

For debug purposes, the OnDrawGizmos method was implemented (E) to see how a single raycast would be draw on the screen.
And finally, there are 4 Raycast interaction methods declared, each one can be called by pressing the keys: R, M, C and O.