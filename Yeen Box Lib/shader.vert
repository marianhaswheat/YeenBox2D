#version 440 core

layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 4) uniform mat4 projection;
layout (location = 5) uniform vec2 position;
layout (location = 6) uniform mat4 camera;

//layout (location = 6) uniform float ambientStrength;
//layout (location = 7) uniform vec3 ambientColor;

out vec2 texCoord;

void main(void)
{
    texCoord = aTexCoord;
    gl_Position = projection * camera * (vec4(position, -7, 1) + vec4(aPosition, 1.0));
}