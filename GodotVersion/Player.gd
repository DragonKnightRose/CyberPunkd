extends KinematicBody2D

export (int) var SPEED #how fast the player will move in pixels/second
var screensize #size of the game window
onready var animation = get_node("animation")

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	screensize = get_viewport_rect().size
	set_process(true)


func _process(delta):
	var velocity = Vector2()
	
	if Input.is_action_pressed("ui_right"):
		velocity.x += 1
		if animation.get_current_animation() != "Walking_Right":
			animation.play("Walking_Right")
	if Input.is_action_pressed("ui_left"):
		velocity.x -= 1
		if animation.get_current_animation() != "Walking_Left":
			animation.play("Walking_Left")
	if Input.is_action_pressed("ui_down"):
		velocity.y += 1
		if animation.get_current_animation() != "Walking_Down":
			animation.play("Walking_Down")
	if Input.is_action_pressed("ui_up"):
		velocity.y -= 1
		if animation.get_current_animation() != "Walking_Up":
			animation.play("Walking_Up")
	
	if velocity.length() > 0:
		velocity = velocity.normalized() * SPEED
	else:
		animation.stop()
	
	
	var position = get_pos()
	position += velocity * delta
	position.x = clamp(position.x, 0, screensize.x)
	position.y = clamp(position.y, 0, screensize.y)
	
	set_pos(position)