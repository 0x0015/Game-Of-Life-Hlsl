# Game-Of-Life-Hlsl
Conways game of life with the game logic on a shader.
for use with the fna library.
<br>Mac and Linux: use mono.
<br><br>
In the input image, the only color it cares about is the red channel.
<br><br><br>
Instructions:<br><br>
When started select the png file that you whish to simulate.  
<br>Controls:<br>
Numpad 1-9: scales the window<br>
R: restarts from the base image<br>
N: opens the file selection to start a new file<br>
Space: pauses or unpauses<br>
Mouse Scrollwheel:  increses or decreses the speed(default 60fps, so you may want to decrese)<br><br><br>

To Build:<br><br>
Just clone recursivly, and open up the sln and build or run "msbuild Life.sln".  then drop the libs(<a herf="http://fna.flibitijibibo.com/archive/fnalibs.tar.bz2">from here</a>) that are apropreate for your system into the bin folder.
