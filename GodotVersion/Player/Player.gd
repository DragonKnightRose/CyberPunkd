extends KinematicBody2D

export (int) var SPEED #how fast the player will move in pixels/second
var screensize #size of the game window
var allowMovement = true
onready var animation = get_node("animation")

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	screensize = get_viewport_rect().size
	set_process(true)


func _process(delta):
	var velocity = Vector2()
	if allowMovement:
		if Input.is_action_pressed("ui_right"):
			velocity.x += 1
			if animation.get_current_animation() != "Walking_Right":
				animation.play("Walking_Right")
		elif Input.is_action_pressed("ui_left"):
			velocity.x -= 1
			if animation.get_current_animation() != "Walking_Left":
				animation.play("Walking_Left")
		elif Input.is_action_pressed("ui_down"):
			velocity.y += 1
			if animation.get_current_animation() != "Walking_Down":
				animation.play("Walking_Down")
		elif Input.is_action_pressed("ui_up"):
			velocity.y -= 1
			if animation.get_current_animation() != "Walking_Up":
				animation.play("Walking_Up")
		
		if velocity.length() > 0:
			velocity = velocity.normalized() * SPEED * delta
		else:
			animation.stop()
	
	move(velocity)
	#position.x = clamp(position.x, 0, screensize.x)
	#position.y = clamp(position.y, 0, screensize.y)
	

func _on_activeText():
	allowMovement = false
	animation.stop()


func _on_GenderSelect_textDone():
	allowMovement = true
