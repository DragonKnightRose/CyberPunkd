extends Node2D

enum dialog_locations{
	none
	men_prompt
	women_prompt
	room_confirm
	}

var screensize
var dialog_location = dialog_locations.none
signal activeText
signal textDone

onready var speaker1 = get_node("Dialog/DialogBox/Speaker1")
onready var speaker1_name = get_node("Dialog/DialogBox/Speaker1/SpeakerName")
onready var speaker2 = get_node("Dialog/DialogBox/Speaker2")
onready var speaker2_name = get_node("Dialog/DialogBox/Speaker2/SpeakerName")

onready var dialogParent = get_node("Dialog")
onready var dialogBox = get_node("Dialog/DialogBox")
onready var dialogText = get_node("Dialog/DialogBox/Text")

var options = preload("res://Objects/2OptionSelect.tscn")

var options_instance
var option1
var option2

onready var camera = get_node("Player/Camera2D")

onready var global_vars = get_node("/root/global")

func _ready():
	screensize = get_viewport().get_rect().size
	dialogBox.hide()

func showOptions():
	#create new instance
	options_instance = options.instance()
	dialogParent.add_child(options_instance)
	option1 = options_instance.get_node("Options/Option1")
	option2 = options_instance.get_node("Options/Option2")
	
	#position instance
	options_instance.set_z(1)
	options_instance.set_pos(Vector2(100,200))
	print(str(options_instance.get_pos()))
	option1.set_pos(Vector2(550,310))
	option2.set_pos(Vector2(550,342))
	
	#connect signals
	options_instance.connect("chose1",self,"_on_ConfirmGender_chose1")
	options_instance.connect("chose2",self,"_on_ConfirmGender_chose2")
	
	options_instance.show()
	option1.show()
	option2.show()

func hideOptions():
	if options_instance != null:
		options_instance.queue_free()
	option1 = null
	option2 = null

func showDialog():
	dialogText.reset()
	dialogBox.show()
	emit_signal("activeText")
	
func hideDialog():
	dialogBox.hide()

func _on_BathroomDoors_mens_door():
	print("Choose men's door")
	
	dialogText.dialog = ["Choose the men's door?"]
	dialog_location = dialog_locations.men_prompt
	showDialog()


func _on_BathroomDoors_womens_door():
	print("Choose women's door")
	
	dialogText.dialog = ["Choose the women's door?"]
	dialog_location = dialog_locations.women_prompt
	showDialog()


func _on_DialogBox_dialog_finished():
	if (dialog_location == dialog_locations.women_prompt) or (dialog_location == dialog_locations.men_prompt):
		showOptions()
	



func _on_ConfirmGender_chose1():
	#remove the confirmation box
	hideOptions()
	
	#set the names for the next conversation and hide the dialog box for reset
	speaker1_name.set_text("JD")
	speaker2_name.set_text("CO-WORKER")
	hideDialog()
	
	#set the character gender
	if dialog_location == women_prompt:
		global_vars.player_sprite = "res://Sprites/Male_sheet.png"
	else:
		global_vars.player_sprite = "res://Sprites/Female_sheet.png"
		
	#hide the option select
	hideOptions()
	
	#play conversation
	dialog_location = dialog_locations.room_confirm
	dialogText.dialog = ["EEEEEEEEK!","Whoops! Sorry, wrong room."]
	dialogText.speaker = dialogText.speakers.two
	dialogText.speaker2.show()
	showDialog()
	
func _on_ConfirmGender_chose2():
	#remove the confirmation box
	hideOptions()
	
	#remove dialog box
	hideDialog()
	
	#reset dialog location
	dialog_location = dialog_locations.none
	
	#reenable movement
	emit_signal("textDone")

func _on_DialogBox_dialog_end():
	if dialog_location == dialog_locations.room_confirm:
		hideDialog()
		global_vars.goto_scene("res://Levels/Tutorial/Tutorial.tscn")
	
