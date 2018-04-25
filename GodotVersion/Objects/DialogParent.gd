extends Polygon2D

export (Vector2) var DialogSize

signal dialog_finished
signal dialog_end

onready var textBox = get_node("Text")
func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	pass


func _on_Text_dialog_finished():
	#if textBox.page != textBox.max_page:
	#	emit_signal("dialog_finished")
	#	print("finish")
	#else:
	#	emit_signal("dialog_end")
	#	print("end")
	emit_signal("dialog_finished")
	print("dialog_finished")
	


func _on_Text_dialog_end():
	emit_signal("dialog_end")
	print("dialog_end")
