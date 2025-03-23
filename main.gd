extends Node3D

@export var obj:PackedScene

func _ready()->void:
	var crystal:Node3D = obj.instantiate()
	add_child(crystal)
	crystal.global_position = Vector3(0,0,0)
	
	get_window().mouse_passthrough_polygon = []
