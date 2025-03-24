extends Camera3D

var ddelta:float = 0.0

var movementspeed:float = 10.0

var mouse_right_pressed:bool = false

var mouse_sensitivity:float = 0.01

func _ready() -> void:
	pass
	
func _process(delta: float)->void:
	ddelta = delta
	
	if Input.is_action_pressed("ZoomIn"):
		position += global_transform.basis.z * -movementspeed * delta
		
	if Input.is_action_pressed("ZoomOut"):
		position += global_transform.basis.z * movementspeed * delta
		
	if Input.is_action_pressed("StrafeForward"):
		var temp_transform =Transform3D(Basis.IDENTITY, position)
		position += temp_transform.basis.z * -movementspeed * delta
		
	if Input.is_action_pressed("StrafeBackward"):
		var temp_transform =Transform3D(Basis.IDENTITY, position)
		position += temp_transform.basis.z * movementspeed * delta
		
	if Input.is_action_pressed("StrafeLeft"):
		position += global_transform.basis.x * -movementspeed * delta
		
	if Input.is_action_pressed("StrafeRight"):
		position += global_transform.basis.x * movementspeed * delta
		
	if Input.is_action_pressed("MouseRight"):
		mouse_right_pressed = true
		
	if Input.is_action_just_released("MouseRight"):
		mouse_right_pressed = false
		
func _input(event):
	if event is InputEventMouseMotion:
		if mouse_right_pressed:
			handle_mouse_movement(event.relative)
	
	if event is InputEventMouseButton and event.button_index in [4,5]:
		if event.button_index == 4:
			position += global_transform.basis.z * -movementspeed * ddelta
		elif event.button_index == 5:
			position += global_transform.basis.z * movementspeed * ddelta
			

func handle_mouse_movement(mouse_motion:Vector2):
	position.x += -mouse_motion.x * mouse_sensitivity
	position.z += -mouse_motion.y * mouse_sensitivity
