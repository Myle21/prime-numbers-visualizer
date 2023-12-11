shader_type canvas_item;

global uniform vec2 scale;

uniform vec3 color : source_color;

void vertex() {
	VERTEX *= scale;
}
void fragment(){
	COLOR.rgb = color;
}

