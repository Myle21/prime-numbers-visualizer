extends Node2D

@onready var animation_player = $"../AnimationPlayer"

const init_scale = Vector2(0.1,0.1)

func _process(delta):
	RenderingServer.global_shader_parameter_set("scale", init_scale / $'../'.scale)

func _ready():
	animation_player.play("out")
