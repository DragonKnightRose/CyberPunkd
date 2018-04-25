extends Polygon2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
onready var textNode = get_node("../Text")

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	pass

func _on_Timer_timeout():
	#deal with visible characters
	var visible = textNode.get_visible_characters()
		
	#deal with next indicator
	if visible == -1:
		#start toggling the next indicator if there's another page
		var max_page = textNode.dialog.size() -1
		if textNode.page < max_page:
			if self.is_visible():
				self.hide()
			else :
				self.show()