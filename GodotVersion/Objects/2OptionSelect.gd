extends Polygon2D

enum states{
	option1,
	option2
	}
var state = states.option1
var selection_initial = Vector2()

onready var selection = get_node("Selection")

signal chose1
signal chose2

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	selection_initial = selection.get_pos()
	set_process_unhandled_input(true)
	
func _unhandled_input(event):
	if Input.is_action_pressed("ui_accept"):
		if state == states.option1:
			emit_signal("chose1")
		else:
			emit_signal("chose2")
	elif Input.is_action_pressed("ui_up")|| Input.is_action_pressed("ui_down"):
			nextChoice()
			
func nextChoice():
	var location = selection.get_pos()
	
	if state == states.option1:
		state = states.option2
		location.y += 32
	else:
		state = states.option1
		location.y -= 32
	
	selection.set_pos(location)
