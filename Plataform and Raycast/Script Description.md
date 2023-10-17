# Player Movement and Raycast
The 2D player moves and jump using velocity. 
There is method to determine if the player is looking left or right to invert the scale of the x axis, so changing the orientation of the player's sprite.

For debug purposes, the OnDrawGizmos method was implemented (E), to see how a single raycast would be draw on the screen.
And finally, there are 4 raycast methods declared, each one can be called by pressing the keys: R, M, C and O.