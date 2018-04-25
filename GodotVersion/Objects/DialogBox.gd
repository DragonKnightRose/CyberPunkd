extends RichTextLabel

enum speakers{
	one,
	two,
	none
}
var dialog = ["This is some example text.","Here is another line!"]
var page = 0
var max_page = 0
var speaker = speakers.none

onready var nextIndicator = get_node("../NextIndicator")
onready var speaker1 = get_node("../Speaker1")
onready var speaker2 = get_node("../Speaker2")

signal dialog_finished
signal dialog_end

func _ready():
	set_bbcode(dialog[page])
	set_visible_characters(0)
	nextIndicator.hide()
	set_process_input(true)
	
func _input(event):
	var visible = get_visible_characters()
	max_page = dialog.size()-1
	if event.type == InputEvent.KEY && event.is_pressed():
		if visible != -1 :
			set_visible_characters(-1)
		elif page < max_page:
			if speaker == speakers.one:
				speaker = speakers.two
				speaker1.hide()
				speaker2.show()
			elif speaker == speakers.two:
				speaker = speakers.one
				speaker2.hide()
				speaker1.show()
			page += 1
			set_bbcode(dialog[page])
			set_visible_characters(0)
			nextIndicator.hide()
		elif page == max_page:
			emit_signal("dialog_end")


func _on_Timer_timeout():
	#deal with visible characters
	var visible = get_visible_characters()
	if visible != -1 && visible < get_total_character_count():
		#not all characters are shown yet
		visible += 1
		set_visible_characters(get_visible_characters()+1)
	elif visible == dialog[page].length():
		set_visible_characters(-1)
		visible = -1
		emit_signal("dialog_finished")
		
		
func reset():
	page = 0
	set_bbcode(dialog[page])
	set_visible_characters(0)
	nextIndicator.hide()