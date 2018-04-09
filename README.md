# Pixel-Watch

Pixel watch is a recreation of Overwatch in 2D. The purpose of this project is to try out and practice Game architecture with scriptable objects as discussed by Ryan Hipple on Unite Austin 2017. 

I mostly focused on ensuring the modularity of each system/script using Scriptable Objects for events and communications. Though making the game this way, bloated the project with data and scripts It was actually easier to manage than OOP and the standard ECS because there are no hard references between entities and no singletons. Mostly all prefabs are independent of each other and would work and integrate itself in the system just by dragging it to the scene.

Been having a lot of fun recreating overwatch though the only hero available for now is Tracer, I'll be adding more in the future once I have free time again.

Changelog:
04/09/2018 - Implemented base systems and Tracer



