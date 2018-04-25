extends Node2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
onready var global_vars = get_node("/root/global")
onready var player = get_node("Player")

func _ready():
	#set the player sprite
	player.get_node("Sprite").set_texture(load(global_vars.player_sprite))
