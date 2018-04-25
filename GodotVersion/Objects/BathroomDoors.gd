extends StaticBody2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
signal mens_door
signal womens_door

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	pass


func _on_WomensDoor_body_enter( body ):
	if(body.get_name() == "Player"):
		emit_signal("womens_door")


func _on_MensDoor_body_enter( body ):
	if(body.get_name() == "Player"):
		emit_signal("mens_door")
