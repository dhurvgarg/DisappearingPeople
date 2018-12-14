# Disappearing People

The experience puts a user into an area with multiple people surrounding them. These people, when approached, will disappear except for one person who interacts with the user.


Technical aspects:
Utilizes Unity with ARKit

Main functionality lies in the main camera, which has a controller child. On the controller child is a HideAndSeek script. This script takes in a hidden object parameter and a canvas parameter. The hidden object is the prefab to randomly instantiate around the world and the canvas contains the text that will display when the right object is found. The script works by first instantiating the object to find around a -10 to 10 unit space and then instantiates 14 other objects that will disappear around the space. The objects and the user use colliders and triggers in order to work and the controller child of the main camera contains the capsule collider that is used. The prefab used is located in Assets/.
